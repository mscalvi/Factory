using DeckManager;
using DeckManager.Models;
using DeckManager.Services;
using DeckManager.Views;
using System.Windows.Forms;

public class TabService
{
    private DeckModel selectedDeck;
    private DeckModel originalDeck;

    TableLayoutPanel tblDeckReal;

    DeckService deckService = new DeckService();

    public TabService(DeckModel deck)
    {
        this.selectedDeck = new DeckModel
        {
            Id = deck.Id,
            Name = deck.Name,
            Format = deck.Format,
            Owner = deck.Owner,
            Archetype = deck.Archetype,
            Colors = deck.Colors,
            FunctionsList = new List<string>(deck.FunctionsList),
            RealDeckList = new List<CardModel>(deck.RealDeckList),
            IdealDeckList = new List<CardModel>(deck.IdealDeckList),
            LastVersion = deck.LastVersion
        };
    }

    public TabPage BuildDeckTab(DeckModel originalDeck)
    {
        // Cria a nova aba para o deck
        TabPage newDeckTab = new TabPage(originalDeck.Name)
        {
            Location = new Point(4, 24),
            Padding = new Padding(3),
            Size = new Size(1882, 979),
            UseVisualStyleBackColor = true
        };

        Panel pnlDeckModel = CreateMainPanel();
        pnlDeckModel.Controls.Add(CreateSaveButton(originalDeck));
        pnlDeckModel.Controls.Add(CreateDeckNameLabel(originalDeck));
        pnlDeckModel.Controls.Add(CreateCardViewPanel());
        pnlDeckModel.Controls.Add(CreateDeckHelperPanel(originalDeck));
        pnlDeckModel.Controls.Add(CreateDeckVersionComboBox(originalDeck));
        pnlDeckModel.Controls.Add(CreateDeckRealPanel(originalDeck));

        newDeckTab.Controls.Add(pnlDeckModel);

        return newDeckTab;
    }

    private Panel CreateMainPanel()
    {
        return new Panel
        {
            Dock = DockStyle.Fill,
            Size = new Size(1876, 973),
            Name = "PnlDeckModel"
        };
    }

    private Button CreateSaveButton(DeckModel originalDeck)
    {
        Button btnSaveDeck = new Button
        {
            Name = "BtnSaveDeck",
            Size = new Size(61, 43),
            Location = new Point(5, 6),
            Text = "Salvar",
            UseVisualStyleBackColor = true
        };

        btnSaveDeck.Click += (s, e) =>
        {
            // Limpa as listas antes de preenchê-las novamente
            selectedDeck.FunctionsList.Clear();
            selectedDeck.RealDeckList.Clear();
            selectedDeck.IdealDeckList.Clear();

            // Itera por cada linha a partir da segunda, para ignorar os cabeçalhos
            for (int row = 1; row < tblDeckReal.RowCount; row++)
            {
                // Função (coluna 1)
                var functionControl = tblDeckReal.GetControlFromPosition(1, row);
                if (functionControl is Label lblFunction)
                {
                    selectedDeck.FunctionsList.Add(lblFunction.Text);
                }

                // Carta Real (coluna 2)
                var realCardControl = tblDeckReal.GetControlFromPosition(2, row);
                if (realCardControl is Label lblRealCard)
                {
                    selectedDeck.RealDeckList.Add(new CardModel { Name = lblRealCard.Text });
                }

                // Carta Ideal (coluna 3)
                var idealCardControl = tblDeckReal.GetControlFromPosition(3, row);
                if (idealCardControl is Label lblIdealCard)
                {
                    selectedDeck.IdealDeckList.Add(new CardModel { Name = lblIdealCard.Text });
                }
            }

            // Verifica se houve mudanças
            bool hasBasicChanges = CheckBasicChanges(originalDeck, selectedDeck);

            bool hasDeckChanges = CheckDeckChanges(originalDeck, selectedDeck);

            // Se houver mudanças, pede ao usuário o nome da nova versão
            if (hasBasicChanges || hasDeckChanges)
            {
                if (hasDeckChanges)
                {
                    // Exibe o formulário para o nome da nova versão
                    NewVersion newVersionForm = new NewVersion(originalDeck);
                    DialogResult result = newVersionForm.ShowDialog();

                    // Verifica se o usuário forneceu um nome para a nova versão
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(newVersionForm.VersionName))
                    {
                        // Atualiza o nome da versão no deck
                        originalDeck.VersionName = newVersionForm.VersionName;

                        selectedDeck.LastVersion = DataService.SaveDeckVersion(originalDeck); // Salva a versão histórica

                        // Atualiza as informações no banco
                        DataService.UpdateDeck(selectedDeck);
                        DataService.SaveRelations(selectedDeck);
                        MessageBox.Show("Deck modificado, versão anterior salva!");
                    }
                } else
                {
                    DataService.UpdateDeck(selectedDeck);
                    MessageBox.Show("Deck atualizado!");
                }
            }
            else
            {
                // Caso não haja mudanças, informa o usuário
                MessageBox.Show("Nenhuma alteração detectada. O deck não foi modificado.");
            }

            // Fecha a aba
            CloseCurrentTab(s as Button);
        };

        return btnSaveDeck;
    }

    private Label CreateDeckNameLabel(DeckModel originalDeck)
    {
        return new Label
        {
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            Location = new Point(5, 6),
            Size = new Size(976, 43),
            Text = originalDeck.Name,
            TextAlign = ContentAlignment.MiddleCenter
        };
    }

    private Panel CreateCardViewPanel()
    {
        return new Panel
        {
            Location = new Point(987, 496),
            Size = new Size(886, 474),
            Name = "PnlCardView"
        };
    }

    private Panel CreateDeckHelperPanel(DeckModel originalDeck)
    {
        Panel pnlDeckHelper = new Panel
        {
            Anchor = AnchorStyles.Top,
            Location = new Point(987, 6),
            Size = new Size(886, 484),
            Name = "PnlDeckHelper"
        };

        TabControl controlHelper = new TabControl { Dock = DockStyle.Fill, Name = "ControlHelper" };
        controlHelper.TabPages.Add(CreateHelpListTab(originalDeck));
        controlHelper.TabPages.Add(CreateStatisticsTab(originalDeck));

        pnlDeckHelper.Controls.Add(controlHelper);
        return pnlDeckHelper;
    }

    private TabPage CreateHelpListTab(DeckModel originalDeck)
    {
        TabPage helpList = new TabPage { Name = "HelpList", Text = "Help List", Padding = new Padding(3), Size = new Size(878, 456) };

        ComboBox cboHelpList = new ComboBox
        {
            FormattingEnabled = true,
            Location = new Point(6, 6),
            Name = "CboHelpList",
            Size = new Size(413, 23)
        };
        helpList.Controls.Add(cboHelpList);

        Panel pnlHelpList = new Panel { Location = new Point(6, 51), Name = "PnlHelpList", Size = new Size(866, 399), TabIndex = 12 };
        TableLayoutPanel tblHelpList = new TableLayoutPanel
        {
            AutoScroll = true,
            ColumnCount = 3,
            Dock = DockStyle.Fill,
            Location = new Point(0, 0),
            Name = "TblHelpList",
            RowCount = 10,
            Size = new Size(866, 399),
            TabIndex = 11
        };

        tblHelpList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
        tblHelpList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
        tblHelpList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));

        pnlHelpList.Controls.Add(tblHelpList);
        helpList.Controls.Add(pnlHelpList);

        return helpList;
    }

    private TabPage CreateStatisticsTab(DeckModel originalDeck)
    {
        TabPage statistics = new TabPage
        {
            Name = "Statistics",
            Text = "Estatísticas",
            Padding = new Padding(3),
            Size = new Size(878, 456)
        };

        // Label for Owner
        Label lblOwner = new Label
        {
            Location = new Point(47, 10),
            Name = "LblOwner",
            Size = new Size(100, 27),
            Text = selectedDeck.OwnerName,
            TextAlign = ContentAlignment.MiddleLeft
        };

        Button btnOwnerChange = new Button
        {
            Location = new Point(6, 10),
            Name = "BtnOwnerChange",
            Size = new Size(35, 27),
            Text = ">",
            UseVisualStyleBackColor = true
        };

        btnOwnerChange.Click += (s, e) =>
        {
            SelOwner newOwnerDialog = new SelOwner();
            if (newOwnerDialog.ShowDialog() == DialogResult.OK)
            {
                selectedDeck.Owner = newOwnerDialog.SelectedOwnerId;
                lblOwner.Text = selectedDeck.OwnerName;
            }
        };

        // Label for Archetype
        Label lblArchetype = new Label
        {
            Location = new Point(47, 43),
            Name = "LblArchetype",
            Size = new Size(100, 27),
            Text = selectedDeck.ArchetypeName,
            TextAlign = ContentAlignment.MiddleLeft
        };

        Button btnArchetypeChange = new Button
        {
            Location = new Point(6, 43),
            Name = "BtnArchetypeChange",
            Size = new Size(35, 27),
            Text = ">",
            UseVisualStyleBackColor = true
        };

        btnArchetypeChange.Click += (s, e) =>
        {
            SelArchetype newArchetypeDialog = new SelArchetype();
            if (newArchetypeDialog.ShowDialog() == DialogResult.OK)
            {
                selectedDeck.Archetype = newArchetypeDialog.SelectedArchetypeId;
                lblArchetype.Text = selectedDeck.ArchetypeName;
            }
        };

        // Label for Color
        Label lblColor = new Label
        {
            Location = new Point(47, 76),
            Name = "LblColor",
            Size = new Size(100, 27),
            Text = selectedDeck.ColorName,
            TextAlign = ContentAlignment.MiddleLeft
        };

        Button btnColorChange = new Button
        {
            Location = new Point(6, 76),
            Name = "BtnColorChange",
            Size = new Size(35, 27),
            Text = ">",
            UseVisualStyleBackColor = true
        };

        btnColorChange.Click += (s, e) =>
        {
            SelColor newColorDialog = new SelColor();
            if (newColorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedDeck.Colors = newColorDialog.SelectedColorId;
                lblColor.Text = selectedDeck.ColorName;
            }
        };

        // Add all controls to the tab
        statistics.Controls.Add(lblOwner);
        statistics.Controls.Add(btnOwnerChange);
        statistics.Controls.Add(lblArchetype);
        statistics.Controls.Add(btnArchetypeChange);
        statistics.Controls.Add(lblColor);
        statistics.Controls.Add(btnColorChange);

        return statistics;
    }

    private ComboBox CreateDeckVersionComboBox(DeckModel originalDeck)
    {
        return new ComboBox
        {
            Anchor = AnchorStyles.Top,
            Location = new Point(5, 52),
            Size = new Size(978, 23),
            Name = "CboDeckReal"
        };
    }

    private Panel CreateDeckRealPanel(DeckModel originalDeck)
    {
        Panel pnlDeckReal = new Panel
        {
            Anchor = AnchorStyles.Top,
            Location = new Point(5, 81),
            Size = new Size(976, 870),
            Name = "PnlDeckReal",
            Padding = new Padding(0, 0, 0, 10)
        };

        if (selectedDeck.FormatName == "Commander")
        {
            tblDeckReal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Name = "TblDeckReal",
                RowCount = 101,
                ColumnCount = 4
            };
        } else
        {
            tblDeckReal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Name = "TblDeckReal",
                RowCount = 61,
                ColumnCount = 4
            };
        }

        tblDeckReal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
        tblDeckReal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
        tblDeckReal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41F));
        tblDeckReal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41F));

        for (int i = 0; i < tblDeckReal.RowCount; i++)
        {
            tblDeckReal.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
        }

        tblDeckReal.CellPaint += (sender, e) =>
        {
            using (Pen borderPen = new Pen(Color.Gray, 1))
            {
                e.Graphics.DrawRectangle(borderPen, e.CellBounds);
            }
        };

        deckService.PopulateDeckTable(tblDeckReal, originalDeck);
        pnlDeckReal.Controls.Add(tblDeckReal);
        return pnlDeckReal;
    }

    private void CloseCurrentTab(Button button)
    {
        TabPage currentTab = (TabPage)button.Parent.Parent;
        TabControl tabControl = currentTab.Parent as TabControl;
        tabControl?.TabPages.Remove(currentTab);
    }

    private static bool CheckBasicChanges(DeckModel original, DeckModel selected)
    {
        // Verifica mudanças simples nas propriedades de texto e numéricas
        if (original.Name != selected.Name ||
            original.Format != selected.Format ||
            original.Owner != selected.Owner ||
            original.Archetype != selected.Archetype ||
            original.Colors != selected.Colors)
        {
            return true;
        }
        return false;
    }
    
    private static bool CheckDeckChanges(DeckModel original, DeckModel selected)
    {
        return !original.FunctionsList.SequenceEqual(selected.FunctionsList) ||
               !original.RealDeckList.SequenceEqual(selected.RealDeckList) ||
               !original.IdealDeckList.SequenceEqual(selected.IdealDeckList);
    }
}
