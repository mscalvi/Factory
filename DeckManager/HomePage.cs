using DeckManager.Services;
using Newtonsoft.Json.Linq;
using DeckManager.Views;
using DeckManager.Models;
using DeckManager.Services;
using DeckManager.Enums;

namespace DeckManager
{
    public partial class HomePage : Form
    {
        private readonly ScryfallAPI _api;

        private int? selectedFormatId = null;
        private int? selectedOwnerId = null;
        private int? selectedArchetypeId = null;
        private int? selectedColorId = null;

        private Button selectedFormatButton = null;
        private Button selectedOwnerButton = null;
        private Button selectedArchetypeButton = null;
        private Button selectedColorButton = null;

        Panel selectedRowPanel = null;


        public HomePage()
        {
            InitializeComponent();
            _api = new ScryfallAPI();

            FiltersAtt(); // Inicializar os Filtros
            DecksFlowAtt(); // Inicializar Tabela de Decks
        }

        //Card Finder
        private async void BoxFinder_TextChanged(object sender, EventArgs e)
        {
            string cardName = BoxFinder.Text.Trim();

            if (!string.IsNullOrEmpty(cardName))
            {
                var scryfallService = new ScryfallAPI();
                string result = await scryfallService.SearchCardByNameAsync(cardName);

                // Aqui você pode tratar o JSON retornado e exibir os resultados no FlowLayoutPanel (FlwFinder)
                // Parsear o resultado JSON e popular a interface
                DisplayCardResults(result);
            }

            if (string.IsNullOrEmpty(cardName))
            {
                FlwFinder.Controls.Clear();
            }
        }

        private async void BtnFinder_Click(object sender, EventArgs e)
        {
            string cardName = BoxFinder.Text;
            if (!string.IsNullOrEmpty(cardName))
            {
                var scryfallService = new ScryfallAPI();
                string result = await scryfallService.SearchCardByNameAsync(cardName);
                DisplayCardResults(result);
            }
        }

        // Exibe as cartas encontradas no FlowLayoutPanel
        private void DisplayCardResults(string jsonResponse)
        {
            // Limpa o FlowLayoutPanel antes de adicionar novos resultados
            FlwFinder.Controls.Clear();

            // Aqui você faria o parse do JSON e mostraria os resultados. Exemplo simplificado:
            if (jsonResponse.StartsWith("{") || jsonResponse.StartsWith("["))
            {
                // Use um parser de JSON, como o Newtonsoft.Json, para analisar a resposta e criar controles visuais
                dynamic cards = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);

                foreach (var card in cards.data)  // Assumindo que há um array "data" com as cartas
                {
                    // Exibe o nome da carta em um Label (pode customizar como desejar)
                    var cardLabel = new Label();
                    cardLabel.Text = card.name.ToString();
                    FlwFinder.Controls.Add(cardLabel);
                }
            }
            else
            {
                // Exibir mensagem de erro se a resposta não for JSON válido
                MessageBox.Show(jsonResponse);
            }
        }

        // Método para criar um painel com as informações da carta
        private Panel CreateCardPanel(JObject card)
        {
            string name = card["name"].ToString();
            string type = card["type_line"].ToString();
            string imageUrl = card["image_uris"]?["small"]?.ToString();
            string oracleText = card["oracle_text"]?.ToString() ?? "Texto não disponível";

            // Criar o painel para a carta
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Width = 200;
            panel.Height = 300;
            panel.Margin = new Padding(10);

            // Criar os controles para o nome, tipo e imagem
            Label lblName = new Label();
            lblName.Text = name;
            lblName.Font = new Font("Arial", 10, FontStyle.Bold);
            lblName.AutoSize = true;
            lblName.Location = new Point(10, 10);

            Label lblType = new Label();
            lblType.Text = type;
            lblType.Font = new Font("Arial", 8);
            lblType.AutoSize = true;
            lblType.Location = new Point(10, 40);

            Label lblOracleText = new Label();
            lblOracleText.Text = oracleText;
            lblOracleText.Font = new Font("Arial", 7);
            lblOracleText.AutoSize = true;
            lblOracleText.MaximumSize = new Size(180, 60);
            lblOracleText.Location = new Point(10, 70);

            // Criar PictureBox para exibir a imagem
            PictureBox pictureBox = new PictureBox();
            if (!string.IsNullOrEmpty(imageUrl))
            {
                pictureBox.Load(imageUrl); // Carregar a imagem da URL
            }
            else
            {
                pictureBox.BackColor = Color.Gray; // Se não houver imagem, usar cor de fundo
            }
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Location = new Point(10, 140);
            pictureBox.Size = new Size(180, 150);

            // Adicionar os controles ao painel da carta
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblType);
            panel.Controls.Add(lblOracleText);
            panel.Controls.Add(pictureBox);

            return panel;
        }


        //Ui Control
        private void BtnDeckManager_Click(object sender, EventArgs e)
        {
            MainControl.SelectedTab = TabDecks;
            DecksControl.SelectedTab = TabFormats;
        }
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            MainControl.SelectedTab = TabHome;
            DecksControl.SelectedTab = TabFormats;
        }



        //Deck Manager
        //Filtros
        private void BtnNewFilter_Click(object sender, EventArgs e)
        {
            NewFilter newFilterDialog = new NewFilter();
            if (newFilterDialog.ShowDialog() == DialogResult.OK)
            {
                string filterName = newFilterDialog.UserInput;
                FilterType filterType = newFilterDialog.SelectedFilterType;

                DataService.CreateFilter(filterName, filterType);
                FiltersAtt();
            }
        }
        private void BtnDelFilter_Click(object sender, EventArgs e)
        {
            DelFilter newFilterDialog = new DelFilter();
            if (newFilterDialog.ShowDialog() == DialogResult.OK)
            {
                string filterName = newFilterDialog.UserInput;
                FilterType filterType = newFilterDialog.SelectedFilterType;

                DataService.DeleteFilter(filterName, filterType);
                FiltersAtt();
            }
        }
        private void FiltersAtt()
        {
            FormatsFlowAtt();
            OwnersFlowAtt();
            ArchetypesFlowAtt();
            ColorsFlowAtt();
        }
        private void FormatsFlowAtt()
        {
            FlwFormatsList.Controls.Clear();

            List<FormatModel> formats = DataService.GetFormats();

            var sortedFormats = formats.OrderBy(f => f.Name).ToList();

            foreach (var format in sortedFormats)
            {
                CreateFilterButton(format.Name, format.Id, FlwFormatsList, (selectedId, clickedButton) =>
                {
                    selectedFormatButton = clickedButton; // Atualiza o botão selecionado
                    selectedFormatId = selectedId;
                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                });
            }
        }
        private void OwnersFlowAtt()
        {
            FlwOwnersList.Controls.Clear();

            List<OwnerModel> owners = DataService.GetOwners();

            var sortedOwners = owners.OrderBy(f => f.Name).ToList();

            foreach (var owner in sortedOwners)
            {
                CreateFilterButton(owner.Name, owner.Id, FlwOwnersList, (selectedId, clickedButton) =>
                {
                    selectedOwnerButton = clickedButton; // Atualiza o botão selecionado
                    selectedOwnerId = selectedId;
                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                });
            }
        }
        private void ArchetypesFlowAtt()
        {
            FlwArchetypesList.Controls.Clear();

            List<ArchetypeModel> archetypes = DataService.GetArchetypes();

            var sortedArchetypes = archetypes.OrderBy(f => f.Name).ToList();

            foreach (var archetype in sortedArchetypes)
            {
                CreateFilterButton(archetype.Name, archetype.Id, FlwArchetypesList, (selectedId, clickedButton) =>
                {
                    selectedArchetypeButton = clickedButton; // Atualiza o botão selecionado
                    selectedArchetypeId = selectedId;
                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                });
            }
        }
        private void ColorsFlowAtt()
        {
            FlwColorsList.Controls.Clear();

            List<ColorModel> colors = DataService.GetColors();

            var sortedColors = colors.OrderBy(f => f.Name).ToList();

            foreach (var color in sortedColors)
            {
                CreateFilterButton(color.Name, color.Id, FlwColorsList, (selectedId, clickedButton) =>
                {
                    selectedColorButton = clickedButton; // Atualiza o botão selecionado
                    selectedColorId = selectedId;
                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                });
            }
        }
        private void CreateFilterButton(string buttonText, int tag, FlowLayoutPanel parentPanel, Action<int, Button> onClickAction)
        {
            Button filterButton = new Button
            {
                Text = buttonText,
                AutoSize = true,
                Padding = new Padding(5),
                Size = new Size(120, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.Control,
                Tag = tag
            };

            filterButton.Click += (sender, e) =>
            {
                Button clickedButton = sender as Button; // Captura o botão que foi clicado

                if (clickedButton != null)
                {
                    if (parentPanel == FlwFormatsList)
                    {
                        if (clickedButton.Tag.Equals(selectedFormatId))
                        {
                            clickedButton.BackColor = SystemColors.Control;
                            selectedFormatId = null;
                            selectedFormatButton = null;
                        }
                        else if (selectedFormatButton != null)
                        {
                            selectedFormatButton.BackColor = SystemColors.Control;
                            selectedFormatButton = clickedButton;
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        } else
                        {
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                    }

                    if (parentPanel == FlwOwnersList)
                    {
                        if (clickedButton.Tag.Equals(selectedOwnerId))
                        {
                            clickedButton.BackColor = SystemColors.Control;
                            selectedOwnerId = null;
                            selectedOwnerButton = null;
                        }
                        else if (selectedOwnerButton != null)
                        {
                            selectedOwnerButton.BackColor = SystemColors.Control;
                            selectedOwnerButton = clickedButton;
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                        else
                        {
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                    }

                    if (parentPanel == FlwArchetypesList) 
                    {
                        if(clickedButton.Tag.Equals(selectedArchetypeId))
                        {
                            clickedButton.BackColor = SystemColors.Control;
                            selectedArchetypeId = null;
                            selectedArchetypeButton = null;
                        }
                        else if (selectedArchetypeButton != null)
                        {
                            selectedArchetypeButton.BackColor = SystemColors.Control;
                            selectedArchetypeButton = clickedButton;
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                        else
                        {
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                    }

                    if (parentPanel == FlwColorsList)
                    {
                        if (clickedButton.Tag.Equals(selectedColorId))
                        {
                            clickedButton.BackColor = SystemColors.Control;
                            selectedColorId = null;
                            selectedColorButton = null;
                        }
                        else if (selectedColorButton != null)
                        {
                            selectedColorButton.BackColor = SystemColors.Control;
                            selectedColorButton = clickedButton;
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                        else
                        {
                            clickedButton.BackColor = Color.LightBlue;
                            onClickAction((int)clickedButton.Tag, clickedButton);
                        }
                    }

                    DecksFlowAtt(selectedFormatId, selectedOwnerId, selectedArchetypeId, selectedColorId);
                }
            };

            parentPanel.Controls.Add(filterButton);
        }
        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            ResetButtonColors(FlwFormatsList);
            ResetButtonColors(FlwOwnersList);
            ResetButtonColors(FlwArchetypesList);
            ResetButtonColors(FlwColorsList);

            selectedFormatButton = null;
            selectedOwnerButton = null;
            selectedArchetypeButton = null;
            selectedColorButton = null;

            selectedFormatId = null;
            selectedOwnerId = null;
            selectedArchetypeId = null;
            selectedColorId = null;

            DecksFlowAtt();
        }
        private void ResetButtonColors(FlowLayoutPanel flowPanel)
        {
            foreach (Control control in flowPanel.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = SystemColors.Control;
                }
            }
        }

        //Decks
        private void BtnNewDeck_Click(object sender, EventArgs e)
        {
            NewDeck inputDialog = new NewDeck();
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                string deckName = inputDialog.UserInput;
                int deckFormat = inputDialog.SelectedFormatId;

                try
                {
                    // Criação do novo deck
                    DataService.NewDeck(deckName, deckFormat);

                    // Atualiza a lista de decks
                    DecksFlowAtt();

                    // Cria a nova aba como um clone da TabDeckManager
                    TabPage newDeckTab = CloneTabDeckManager(deckName, deckFormat);
                    DecksControl.TabPages.Add(newDeckTab);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DecksFlowAtt(int? formatId = null, int? ownerId = null, int? archetypeId = null, int? colorId = null)
        {
            FlwDecksList.Controls.Clear();

            List<DeckModel> decks;

            if (formatId == null && ownerId == null && archetypeId == null && colorId == null)
            {
                decks = DataService.GetAllDecks();
            }
            else
            {
                decks = DataService.GetSomeDecks(formatId, ownerId, archetypeId, colorId);
            }

            TableLayoutPanel table = new TableLayoutPanel
            {
                ColumnCount = 7,
                AutoSize = false,
                Width = PnlDecksList.Width,
                Height = PnlDecksList.Height,
                RowCount = decks.Count + 1,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None, 
                Padding = new Padding(0) 
            };

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100)); 
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120)); 
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220)); 
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300)); 
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220)); 

            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            Font dataFont = new Font("Arial", 12);

            table.Controls.Add(new Label { Text = "", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(100, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 0, 0);
            table.Controls.Add(new Label { Text = "ID", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(120, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 1, 0);
            table.Controls.Add(new Label { Text = "Nome", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(400, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 2, 0);
            table.Controls.Add(new Label { Text = "Formato", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(220, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 3, 0);
            table.Controls.Add(new Label { Text = "Dono", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(220, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 4, 0);
            table.Controls.Add(new Label { Text = "Arquétipo", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(300, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 5, 0);
            table.Controls.Add(new Label { Text = "Cores", AutoSize = false, Font = headerFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(220, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 6, 0);

            for (int i = 0; i < decks.Count; i++)
            {
                var deck = decks[i];

                Button actionButton = new Button
                {
                    Text = "Abrir",
                    AutoSize = false,
                    Font = dataFont,
                    Size = new Size(121, 30),
                    BackColor = Color.LightGray,
                    Margin = new Padding(0)
                };

                actionButton.Click += (sender, e) =>
                {
                    OpenDeckTab(deck, deck.Format);
                };

                table.Controls.Add(actionButton, 0, i + 1); 
                table.Controls.Add(new Label { Text = deck.Id.ToString(), AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(120, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 1, i + 1);
                table.Controls.Add(new Label { Text = deck.Name, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(400, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 2, i + 1);
                table.Controls.Add(new Label { Text = deck.FormatName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(220, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 3, i + 1);
                table.Controls.Add(new Label { Text = deck.OwnerName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(220, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 4, i + 1);
                table.Controls.Add(new Label { Text = deck.ArchetypeName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(300, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 5, i + 1);
                table.Controls.Add(new Label { Text = deck.ColorName, AutoSize = false, Font = dataFont, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(220, 30), BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0) }, 6, i + 1);
            }

            FlwDecksList.Controls.Add(table);
        }
        private TabPage CloneTabDeckManager(string deckName, int formatId)
        {
            DeckModel selectedDeck = DataService.GetDeckByName(deckName);
            DeckModel originalDeck = DataService.GetDeckByName(deckName);

            // Create a new tab with the deck name
            TabPage newDeckTab = new TabPage(selectedDeck.Name)
            {
                Location = new Point(4, 24),
                Padding = new Padding(3),
                Size = new Size(1882, 979),
                UseVisualStyleBackColor = true
            };

            // Create a panel to hold the controls
            Panel pnlDeckModel = new Panel
            {
                Dock = DockStyle.Fill,
                Size = new Size(1876, 973),
                Name = "PnlDeckModel"
            };

            // Button to save the deck
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
                bool hasChanges = CheckDeckChanges(originalDeck, selectedDeck);

                if (hasChanges)
                {
                    DataService.SaveDeckVersion(originalDeck);
                    DataService.UpdateDeck(selectedDeck);
                    MessageBox.Show("Deck modificado!");
                }

                DecksFlowAtt();

                TabPage currentTab = (TabPage)((Button)s).Parent.Parent;
                TabControl tabControl = currentTab.Parent as TabControl;
                if (tabControl != null)
                {
                    tabControl.TabPages.Remove(currentTab);
                }
            };

            // Label for the deck name
            Label lblDeckName = new Label
            {
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(5, 6),
                Size = new Size(976, 43),
                Text = selectedDeck.Name,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Panel to view cards
            Panel pnlCardView = new Panel
            {
                Location = new Point(987, 496),
                Size = new Size(886, 474),
                Name = "PnlCardView"
            };

            // Panel that contains the helper control
            Panel pnlDeckHelper = new Panel
            {
                Anchor = AnchorStyles.Top,
                Location = new Point(987, 6),
                Size = new Size(886, 484),
                Name = "PnlDeckHelper"
            };

            // Tab control for helper
            TabControl controlHelper = new TabControl
            {
                Dock = DockStyle.Fill,
                Name = "ControlHelper"
            };

            // Tab for help list
            TabPage helpList = new TabPage
            {
                Name = "HelpList",
                Text = "Help List",
                Padding = new Padding(3),
                Size = new Size(878, 456)
            };

            // ComboBox for help list
            ComboBox cboHelpList = new ComboBox
            {
                FormattingEnabled = true,
                Location = new Point(6, 6),
                Name = "CboHelpList",
                Size = new Size(413, 23)
            };
            helpList.Controls.Add(cboHelpList);

            // Panel for help list
            Panel pnlHelpList = new Panel
            {
                Location = new Point(6, 51),
                Name = "PnlHelpList",
                Size = new Size(866, 399),
                TabIndex = 12
            };

            // TableLayoutPanel for help list
            TableLayoutPanel tblHelpList = new TableLayoutPanel
            {
                AutoScroll = true,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                Name = "TblHelpList",
                RowCount = 2,
                Size = new Size(866, 399),
                TabIndex = 11
            };

            // Configuração das colunas para 3 partes iguais
            tblHelpList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tblHelpList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tblHelpList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));

            // Configuração das linhas para 2 partes iguais
            tblHelpList.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblHelpList.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            // Adiciona o TableLayoutPanel ao painel
            pnlHelpList.Controls.Add(tblHelpList);
            helpList.Controls.Add(pnlHelpList);

            // Labels for help list
            Label lblOpenList = new Label
            {
                Location = new Point(425, 6),
                Name = "LblOpenList",
                Size = new Size(447, 23),
                Text = "Selected Help List",
                TextAlign = ContentAlignment.MiddleCenter
            };
            helpList.Controls.Add(lblOpenList);

            // Tab for statistics
            TabPage statistics = new TabPage
            {
                Name = "Statistics",
                Text = "Estatísticas",
                Padding = new Padding(3),
                Size = new Size(878, 456)
            };

            // Labels for statistics
            Label lblOwner = new Label
            {
                Location = new Point(47, 10),
                Name = "LblOwner",
                Size = new Size(100, 27),
                Text = selectedDeck.OwnerName,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblArchetype = new Label
            {
                Location = new Point(47, 43),
                Name = "LblArchetype",
                Size = new Size(100, 27),
                Text = selectedDeck.ArchetypeName,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblColor = new Label
            {
                Location = new Point(47, 76),
                Name = "LblColor",
                Size = new Size(100, 27),
                Text = selectedDeck.ColorName,
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Botão para mudar o dono
            Button btnOwnerChange = new Button
            {
                Anchor = AnchorStyles.Top,
                Location = new Point(6, 10),
                Name = "BtnOwnerChange",
                Size = new Size(35, 27),
                Text = ">",
                UseVisualStyleBackColor = true
            };

            // Evento para abrir a PopUp de seleção de dono
            btnOwnerChange.Click += (s, e) =>
            {
                SelOwner newFilterDialog = new SelOwner();
                if (newFilterDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedDeck.Owner = newFilterDialog.SelectedOwnerId;
                    lblOwner.Text = selectedDeck.OwnerName;
                }
            };

            Button btnArchetypeChange = new Button
            {
                Anchor = AnchorStyles.Top,
                Location = new Point(6, 43),
                Name = "BtnArchetypeChange",
                Size = new Size(35, 27),
                Text = ">",
                UseVisualStyleBackColor = true
            };

            // Evento para abrir a PopUp de seleção de dono
            btnArchetypeChange.Click += (s, e) =>
            {
                SelArchetype newFilterDialog = new SelArchetype();
                if (newFilterDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedDeck.Archetype = newFilterDialog.SelectedArchetypeId;
                    lblArchetype.Text = selectedDeck.ArchetypeName;
                }
            };

            Button btnColorChange = new Button
            {
                Anchor = AnchorStyles.Top,
                Location = new Point(6, 76),
                Name = "BtnColorChange",
                Size = new Size(35, 27),
                Text = ">",
                UseVisualStyleBackColor = true
            };

            // Evento para abrir a PopUp de seleção de dono
            btnColorChange.Click += (s, e) =>
            {
                SelColor newFilterDialog = new SelColor();
                if (newFilterDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedDeck.Colors = newFilterDialog.SelectedColorId;
                    lblColor.Text = selectedDeck.ColorName;
                }
            };

            // Add controls to statistics tab
            statistics.Controls.Add(lblOwner);
            statistics.Controls.Add(lblArchetype);
            statistics.Controls.Add(lblColor);
            statistics.Controls.Add(btnOwnerChange);
            statistics.Controls.Add(btnArchetypeChange);
            statistics.Controls.Add(btnColorChange);

            // Add tabs to the tab control
            controlHelper.TabPages.Add(helpList);
            controlHelper.TabPages.Add(statistics);
            pnlDeckHelper.Controls.Add(controlHelper);

            // ComboBox for versions of the deck
            ComboBox cboDeckVersion = new ComboBox
            {
                Anchor = AnchorStyles.Top,
                Location = new Point(5, 52),
                Size = new Size(978, 23),
                Name = "CboDeckReal"
            };

            // Panel for real deck
            Panel pnlDeckReal = new Panel
            {
                Anchor = AnchorStyles.Top,
                Location = new Point(5, 81),
                Size = new Size(486, 889),
                Name = "PnlDeckReal"
            };

            // TableLayoutPanel for real deck
            TableLayoutPanel tblDeckReal = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Name = "TblDeckReal",
                ColumnCount = 2
            };

            // Configura o estilo das colunas para que cada uma ocupe 50% do espaço
            tblDeckReal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDeckReal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // Adiciona o TableLayoutPanel ao painel pai
            pnlDeckReal.Controls.Add(tblDeckReal);

            // Add all controls to the main panel
            pnlDeckModel.Controls.Add(btnSaveDeck);
            pnlDeckModel.Controls.Add(lblDeckName);
            pnlDeckModel.Controls.Add(pnlCardView);
            pnlDeckModel.Controls.Add(pnlDeckHelper);
            pnlDeckModel.Controls.Add(cboDeckVersion);
            pnlDeckModel.Controls.Add(pnlDeckReal);

            // Add the panel to the new tab
            newDeckTab.Controls.Add(pnlDeckModel);

            if (!string.IsNullOrEmpty(selectedDeck.OwnerName))
            {
                lblOwner.Text = selectedDeck.OwnerName;
            }
            if (!string.IsNullOrEmpty(selectedDeck.ArchetypeName))
            {
                lblArchetype.Text = selectedDeck.ArchetypeName;
            }
            if (!string.IsNullOrEmpty(selectedDeck.ColorName))
            {
                lblColor.Text = selectedDeck.ColorName;
            }

            return newDeckTab;
        }
        private void OpenDeckTab(DeckModel deck, int formatId)
        {
            // Verifica se a aba já existe
            TabPage existingTab = DecksControl.TabPages.Cast<TabPage>().FirstOrDefault(t => t.Text == deck.Name);

            if (existingTab == null)
            {
                TabPage newDeckTab = CloneTabDeckManager(deck.Name, deck.Format); 
                DecksControl.TabPages.Add(newDeckTab);
            }

            // Seleciona a aba
            DecksControl.SelectedTab = existingTab ?? DecksControl.TabPages.Cast<TabPage>().First(t => t.Text == deck.Name);
        }
        private static bool CheckDeckChanges(DeckModel original, DeckModel current)
        {
            return original.Name != current.Name ||
                   original.Format != current.Format ||
                   original.Owner != current.Owner ||
                   original.Archetype != current.Archetype ||
                   original.Colors != current.Colors;
        }


    }
}
