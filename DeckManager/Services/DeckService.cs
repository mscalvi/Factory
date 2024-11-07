using DeckManager.Models;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

public class DeckService
{
    private string copiedText = string.Empty;
    private Label selectedLabel1 = null;
    private Label selectedLabel2 = null;

    // Método para popular a tabela do deck com dados
    public void PopulateDeckTable(TableLayoutPanel deckTable, DeckModel originalDeck)
    {
        // Limpa os dados existentes para uma nova carga
        deckTable.Controls.Clear();

        // Configura os cabeçalhos
        AddHeaders(deckTable);
        AddNumbersLines(deckTable);
        AddFunctionsLines(deckTable, originalDeck);
        AddRealDeckLines(deckTable, originalDeck);
        AddIdealDeckLines(deckTable, originalDeck);
        CheckDeck(deckTable);
    }

    private static void AddHeaders(TableLayoutPanel deckTable)
    {
        // Configura e adiciona os cabeçalhos das colunas
        deckTable.Controls.Add(CreateHeaderLabel("No"), 0, 0);
        deckTable.Controls.Add(CreateHeaderLabel("Função"), 1, 0);
        deckTable.Controls.Add(CreateHeaderLabel("Carta Atual"), 2, 0);
        deckTable.Controls.Add(CreateHeaderLabel("Carta Ideal"), 3, 0);
    }

    private static Label CreateHeaderLabel(string text)
    {
        return new Label
        {
            Text = text,
            Font = new Font("Arial", 12, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill
        };
    }

    private static void AddNumbersLines(TableLayoutPanel deckTable)
    {
        for (int i = 1; i < deckTable.RowCount; i++)
        {
            deckTable.Controls.Add(new Label { Text = i.ToString(), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, i);
        }

    }

    private void AddFunctionsLines(TableLayoutPanel deckTable, DeckModel originalDeck)
    {
        for (int row = 1; row < deckTable.RowCount; row++)
        {
            string functionText = null;

            if (originalDeck.FunctionsList[row - 1] == null)
            {
                functionText = " ";
            } else
            {
                functionText = originalDeck.FunctionsList[row - 1];
            }

            // Cria e configura o Label para exibir a função
            Label lblFunction = CreateLabel(functionText);
            lblFunction.MouseDown += (sender, e) => Label_MouseDown(sender, e, deckTable);
            lblFunction.DoubleClick += (sender, e) => SwitchToTextBox(deckTable, lblFunction);

            // Adiciona o Label à coluna de funções da tabela, na posição específica
            deckTable.Controls.Add(lblFunction, 1, row);
        }
    }

    private void AddRealDeckLines(TableLayoutPanel deckTable, DeckModel originalDeck)
    {
        for (int row = 1; row < deckTable.RowCount; row++)
        {
            string cardName = row <= originalDeck.RealDeckList.Count ? originalDeck.RealDeckList[row - 1].Name : " ";

            Label lblRealCard = CreateLabel(cardName);
            lblRealCard.MouseDown += (sender, e) => Label_MouseDown(sender, e, deckTable);
            lblRealCard.DoubleClick += (sender, e) => SwitchToTextBox(deckTable, lblRealCard);

            deckTable.Controls.Add(lblRealCard, 2, row);
        }
    }

    private void AddIdealDeckLines(TableLayoutPanel deckTable, DeckModel originalDeck)
    {
        for (int row = 1; row < deckTable.RowCount; row++)
        {
            string idealCardName = row <= originalDeck.IdealDeckList.Count ? originalDeck.IdealDeckList[row - 1].Name : " ";

            Label lblIdealCard = CreateLabel(idealCardName);
            lblIdealCard.MouseDown += (sender, e) => Label_MouseDown(sender, e, deckTable);
            lblIdealCard.DoubleClick += (sender, e) => SwitchToTextBox(deckTable, lblIdealCard);

            deckTable.Controls.Add(lblIdealCard, 3, row);
        }
    }

    // Cria Labels padrão para células
    private static Label CreateLabel(string text)
    {
        return new Label
        {
            Text = text,
            Font = new Font("Arial", 11, FontStyle.Regular),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill
        };
    }

    // Alterna o Label para TextBox quando clicado
    private void SwitchToTextBox(TableLayoutPanel deckTable, Label lblEdit)
    {
        bool isSwitched = false;

        int col = deckTable.GetColumn(lblEdit);
        int row = deckTable.GetRow(lblEdit);

        deckTable.Controls.Remove(lblEdit);

        // Cria uma TextBox na mesma posição
        TextBox txtEdit = new TextBox
        {
            Text = lblEdit.Text,
            Dock = DockStyle.Fill
        };

        txtEdit.KeyDown += (sender, e) =>
        {
            if (e.KeyCode == Keys.Enter && !isSwitched)
            {
                isSwitched = true;
                SwitchToLabel(deckTable, txtEdit);
            }
        };

        txtEdit.Leave += (sender, e) =>
        {
            if (!isSwitched)
            {
                isSwitched = true;
                SwitchToLabel(deckTable, txtEdit);
            }
        };

        deckTable.Controls.Add(txtEdit, col, row);
        txtEdit.Focus();
    }

    // Alterna a TextBox de volta para Label após edição
    private void SwitchToLabel(TableLayoutPanel deckTable, TextBox txtEdit)
    {
        int col = deckTable.GetColumn(txtEdit);
        int row = deckTable.GetRow(txtEdit);

        // Remove a TextBox da célula
        deckTable.Controls.Remove(txtEdit);

        // Cria o Label atualizado com o novo valor da TextBox
        Label lblEdit = CreateLabel(txtEdit.Text);
        lblEdit.DoubleClick += (sender, e) => SwitchToTextBox(deckTable, lblEdit);
        lblEdit.MouseDown += (sender, e) => Label_MouseDown(sender, e, deckTable);

        // Adiciona o novo Label de volta à célula
        deckTable.Controls.Add(lblEdit, col, row);

        CheckDeck(deckTable);
    }

    //Confere quais cartas do deck ideal já estão no real
    private static void CheckDeck(TableLayoutPanel table)
    {
        // Inicia a checagem em cada linha da tabela
        for (int row = 1; row < table.RowCount; row++)
        {
            // Verificando as colunas 2 e 3 (na linha atual) para valores iguais
            var labelColumn2 = table.GetControlFromPosition(2, row) as Label;
            var labelColumn3 = table.GetControlFromPosition(3, row) as Label;

            if (labelColumn2 != null && labelColumn3 != null)
            {
                string valueColumn2 = labelColumn2.Text;
                string valueColumn3 = labelColumn3.Text;

                // Se os valores das colunas 2 e 3 forem iguais
                if (string.IsNullOrWhiteSpace(valueColumn2) || string.IsNullOrWhiteSpace(valueColumn3))
                {
                    var cellControl = table.GetControlFromPosition(0, row);
                    cellControl.BackColor = Color.Yellow;
                } else
                {
                    if (valueColumn2 == valueColumn3)
                    {
                        var cellControl = table.GetControlFromPosition(0, row);
                        cellControl.BackColor = Color.Green;
                    }
                    else
                    {
                        var cellControl = table.GetControlFromPosition(0, row);
                        cellControl.BackColor = Color.Red;
                    }
                }
            }
        }
    }

    // Evento MouseDown: registra o início do arraste
    private void Label_MouseDown(object sender, MouseEventArgs e, TableLayoutPanel deckTable)
    {
        if (e.Button == MouseButtons.Right)  
        {
            Label targetLabel = sender as Label;

            if (targetLabel != null)
            {
                if (!string.IsNullOrWhiteSpace(targetLabel.Text) && !string.IsNullOrWhiteSpace(copiedText))
                {
                    targetLabel.Text = " ";
                    copiedText = null;
                    MessageBox.Show("Texto copiado limpo");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(targetLabel.Text) && string.IsNullOrEmpty(copiedText)) 
                {
                    copiedText = targetLabel.Text;
                    MessageBox.Show("Texto copiado: " + copiedText);
                    return;
                }
                if (string.IsNullOrWhiteSpace(targetLabel.Text) && !string.IsNullOrWhiteSpace(copiedText))
                {
                    targetLabel.Text = copiedText;
                    return;
                }
            }
        }

        if (e.Button == MouseButtons.Left)
        {
            Label targetLabel = sender as Label;

            if (targetLabel != null)
            {
                if (selectedLabel1 != null)
                {
                    if (selectedLabel2 == null)
                    {
                        targetLabel.BackColor = Color.LightBlue;
                        selectedLabel2 = targetLabel;
                    } else
                    {
                        selectedLabel1.BackColor = Color.Transparent;
                        selectedLabel1 = null;
                        selectedLabel2.BackColor = Color.Transparent;
                        selectedLabel2 = null;
                    }
                } else
                {
                    targetLabel.BackColor = Color.LightBlue;
                    selectedLabel1 = targetLabel;
                }
            }
        }
    }
}
