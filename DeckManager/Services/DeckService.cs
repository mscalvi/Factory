using DeckManager.Models;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

public class DeckService
{
    // Método para popular a tabela do deck com dados
    public static void PopulateDeckTable(TableLayoutPanel deckTable, DeckModel deckData)
    {
        // Limpa os dados existentes para uma nova carga
        deckTable.Controls.Clear();

        // Configura os cabeçalhos
        AddHeaders(deckTable);
        AddNumbersLines(deckTable);
        AddFunctionsLines(deckTable, deckData);
        AddRealDeckLines(deckTable, deckData);
        AddIdealDeckLines(deckTable, deckData);
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

    private static void AddFunctionsLines(TableLayoutPanel deckTable, DeckModel deckData)
    {
        for (int row = 1; row < deckTable.RowCount; row++)
        {
            string functionText = row <= deckData.FunctionsList.Count ? deckData.FunctionsList[row - 1] : " ";

            Label lblFunction = CreateLabel(functionText);
            lblFunction.DoubleClick += (sender, e) => SwitchToTextBox(deckTable, lblFunction);

            deckTable.Controls.Add(lblFunction, 1, row);
        }
    }

    private static void AddRealDeckLines(TableLayoutPanel deckTable, DeckModel deckData)
    {
        for (int row = 1; row < deckTable.RowCount; row++)
        {
            string cardName = row <= deckData.DeckListReal.Count ? deckData.DeckListReal[row - 1].Name : " ";

            Label lblRealCard = CreateLabel(cardName);
            lblRealCard.DoubleClick += (sender, e) => SwitchToTextBox(deckTable, lblRealCard);

            deckTable.Controls.Add(lblRealCard, 2, row);
        }
    }

    private static void AddIdealDeckLines(TableLayoutPanel deckTable, DeckModel deckData)
    {
        for (int row = 1; row < deckTable.RowCount; row++)
        {
            string idealCardName = row <= deckData.DeckListIdeal.Count ? deckData.DeckListIdeal[row - 1].Name : " ";

            Label lblIdealCard = CreateLabel(idealCardName);
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
    private static void SwitchToTextBox(TableLayoutPanel table, Label lblEdit)
    {
        bool isSwitched = false;

        int col = table.GetColumn(lblEdit);
        int row = table.GetRow(lblEdit);

        table.Controls.Remove(lblEdit);

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
                SwitchToLabel(table, txtEdit);
            }
        };

        txtEdit.Leave += (sender, e) =>
        {
            if (!isSwitched)
            {
                isSwitched = true;
                SwitchToLabel(table, txtEdit);
            }
        };

        table.Controls.Add(txtEdit, col, row);
        txtEdit.Focus();
    }

    // Alterna a TextBox de volta para Label após edição
    private static void SwitchToLabel(TableLayoutPanel table, TextBox txtEdit)
    {
        int col = table.GetColumn(txtEdit);
        int row = table.GetRow(txtEdit);

        // Remove a TextBox da célula
        table.Controls.Remove(txtEdit);

        // Cria o Label atualizado com o novo valor da TextBox
        Label lblEdit = CreateLabel(txtEdit.Text);
        lblEdit.DoubleClick += (sender, e) => SwitchToTextBox(table, lblEdit);

        // Adiciona o novo Label de volta à célula
        table.Controls.Add(lblEdit, col, row);

        CheckDeck(table);
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

}
