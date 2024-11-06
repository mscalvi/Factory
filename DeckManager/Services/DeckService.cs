using DeckManager.Models;

public class DeckService
{
    // Método para popular a tabela do deck com dados
    public static void PopulateDeckTable(TableLayoutPanel deckTable, DeckModel deckData)
    {
        // Limpa os dados existentes para uma nova carga
        deckTable.Controls.Clear();

        // Configura os cabeçalhos
        AddHeaders(deckTable);
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

    /*
    private static void AddDeckRow(TableLayoutPanel deckTable, DeckModel deckItem, int rowNumber)
    {
        // Adiciona informações do item do deck nas colunas da linha
        deckTable.Controls.Add(new Label { Text = rowNumber.ToString(), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 0, rowNumber);
        deckTable.Controls.Add(new Label { Text = deckItem.Function, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 1, rowNumber);
        deckTable.Controls.Add(new Label { Text = deckItem.CurrentCard, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 2, rowNumber);
        deckTable.Controls.Add(new Label { Text = deckItem.IdealCard, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 3, rowNumber);
    }
    */
}
