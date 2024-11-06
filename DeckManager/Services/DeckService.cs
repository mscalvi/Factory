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
        AddFunctionsLines(deckTable);
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
            Font = new Font("Arial", 10, FontStyle.Bold),
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

    private static void AddFunctionsLines(TableLayoutPanel deckTable)
    {
        for (int row = 1; row < deckTable.RowCount; row++)
        {
            // Coluna "Função" (editável)
            Label lblFunction = CreateLabel("Func " + row);
            lblFunction.DoubleClick += (sender, e) => SwitchToTextBox(deckTable, lblFunction);
            deckTable.Controls.Add(lblFunction, 1, row);
        }
    }

    // Cria Labels padrão para células
    private static Label CreateLabel(string text)
    {
        return new Label
        {
            Text = text,
            Font = new Font("Arial", 10, FontStyle.Regular),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill
        };
    }

    // Alterna o Label para TextBox quando clicado
    private static void SwitchToTextBox(TableLayoutPanel table, Label lblFunction)
    {
        int col = table.GetColumn(lblFunction);
        int row = table.GetRow(lblFunction);

        table.Controls.Remove(lblFunction);

        // Cria uma TextBox na mesma posição
        TextBox txtEdit = new TextBox
        {
            Text = lblFunction.Text,
            Dock = DockStyle.Fill
        };

        txtEdit.KeyDown += (sender, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
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

        table.Controls.Remove(txtEdit);

        // Cria o Label atualizado com o novo valor da TextBox
        Label lblFunction = CreateLabel(txtEdit.Text);
        lblFunction.DoubleClick += (sender, e) => SwitchToTextBox(table, lblFunction);

        table.Controls.Add(lblFunction, col, row);
    }
}
