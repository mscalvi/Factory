//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.IO;
//using System.Linq;
//using System.Windows.Forms;

//namespace BingoManager.Services
//{
//    public static class CardsService
//    {
//        public static void CreateCards(List<DataRow> CompList, int listId, int CompNumber, int Qnt, string Title, string End, string CardsName)
//        {
//            // Lista para armazenar todas as cartelas geradas
//            List<List<DataRow>> allCards = new List<List<DataRow>>();

//            // Embaralhar Empresas
//            Random random = new Random();
//            CompList = CompList.OrderBy(x => random.Next()).ToList();

//            // Determina quantas empresas haverá em cada coluna de forma dinâmica
//            int companiesPerColumn = CompList.Count / 5;
//            int remainder = CompList.Count % 5;

//            // Distribui as empresas para cada coluna de forma dinâmica
//            List<DataRow> columnB = CompList.Take(companiesPerColumn + (remainder > 0 ? 1 : 0)).ToList();
//            List<DataRow> columnI = CompList.Skip(columnB.Count).Take(companiesPerColumn + (remainder > 1 ? 1 : 0)).ToList();
//            List<DataRow> columnN = CompList.Skip(columnB.Count + columnI.Count).Take(companiesPerColumn + (remainder > 2 ? 1 : 0)).ToList();
//            List<DataRow> columnG = CompList.Skip(columnB.Count + columnI.Count + columnN.Count).Take(companiesPerColumn + (remainder > 3 ? 1 : 0)).ToList();
//            List<DataRow> columnO = CompList.Skip(columnB.Count + columnI.Count + columnN.Count + columnG.Count).Take(companiesPerColumn).ToList();

//            // Serializar os grupos em uma string separada por vírgulas
//            string groupB = string.Join(",", columnB.Select(c => c["Id"].ToString()));
//            string groupI = string.Join(",", columnI.Select(c => c["Id"].ToString()));
//            string groupN = string.Join(",", columnN.Select(c => c["Id"].ToString()));
//            string groupG = string.Join(",", columnG.Select(c => c["Id"].ToString()));
//            string groupO = string.Join(",", columnO.Select(c => c["Id"].ToString()));

//            // Chama o método que cria a lista de cartelas no banco de dados
//            int setId = DataService.CreateCardList(listId, Qnt, End, Title, CardsName, groupB, groupI, groupN, groupG, groupO);

//            // Gerar as cartelas
//            for (int i = 1; i <= Qnt; i++)
//            {
//                List<DataRow> selectedCompanies = new List<DataRow>();

//                // Cria cópias temporárias dos grupos para garantir que as empresas não se repitam dentro da mesma cartela
//                List<DataRow> tempB = new List<DataRow>(columnB);
//                List<DataRow> tempI = new List<DataRow>(columnI);
//                List<DataRow> tempN = new List<DataRow>(columnN);
//                List<DataRow> tempG = new List<DataRow>(columnG);
//                List<DataRow> tempO = new List<DataRow>(columnO);

//                // Seleciona 5 empresas aleatoriamente de cada coluna (B, I, N, G, O) e remove as escolhidas da lista temporária
//                selectedCompanies.AddRange(SelectAndRemoveFromGroup(tempB, 5, random));
//                selectedCompanies.AddRange(SelectAndRemoveFromGroup(tempI, 5, random));
//                selectedCompanies.AddRange(SelectAndRemoveFromGroup(tempN, 5, random));
//                selectedCompanies.AddRange(SelectAndRemoveFromGroup(tempG, 5, random));
//                selectedCompanies.AddRange(SelectAndRemoveFromGroup(tempO, 5, random));

//                // A lógica para inserir as cartelas no banco de dados
//                List<int> companyIds = selectedCompanies.Select(c => Convert.ToInt32(c["Id"])).ToList();

//                if (companyIds.Count == 25)
//                {
//                    // Chama o método que insere a cartela no banco de dados
//                    DataService.CreateCard(listId, companyIds, i, setId);

//                    // Adiciona a cartela gerada à lista de todas as cartelas
//                    allCards.Add(selectedCompanies);
//                }
//            }

//            // Após criar todas as cartelas, gerar o PDF com todas elas (duas cartelas por página)
//            string saveName;
//            string savePath;

//            (saveName, savePath) = PrintingService.PrintCards(allCards, allCards.Count, Title, End);

//            if (!string.IsNullOrEmpty(saveName))
//            {
//                PrintList(CompList, saveName, savePath);
//            }
//        }

//        // Método para selecionar e remover empresas de um grupo temporário
//        private static List<DataRow> SelectAndRemoveFromGroup(List<DataRow> group, int count, Random random)
//        {
//            List<DataRow> selected = new List<DataRow>();
//            for (int i = 0; i < count; i++)
//            {
//                if (group.Count == 0) break; // Evitar erros se não houver mais empresas no grupo
//                int randomIndex = random.Next(group.Count);
//                selected.Add(group[randomIndex]);
//                group.RemoveAt(randomIndex); // Remove a empresa selecionada para evitar repetição
//            }
//            return selected;
//        }

//        // Método para gerar e salvar o PDF com todas as empresas separadas por grupo (B, I, N, G, O) e numeradas
//        public static void PrintList(List<DataRow> allCompanies, string nameWithoutExtension, string path)
//        {
//            string fileName = $"lista_{nameWithoutExtension}.pdf"; // Usa o nome sem extensão
//            string filePath = Path.Combine(path, fileName);

//            // Cria o documento PDF
//            Document document = new Document();
//            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
//            document.Open();

//            // Adiciona título ao documento
//            document.Add(new Paragraph("Lista de Elementos nas Cartelas\n\n"));

//            // Adiciona as empresas separadas por grupo em formato de lista numerada
//            int companyIndex = 1;

//            // Determina quantas empresas haverá em cada coluna de forma dinâmica
//            int companiesPerColumn = allCompanies.Count / 5;
//            int remainder = allCompanies.Count % 5;

//            // Dividir as empresas em grupos (Colunas B, I, N, G, O)
//            AddCompaniesToPdfList(document, "Coluna B", allCompanies.Take(companiesPerColumn + (remainder > 0 ? 1 : 0)).ToList(), ref companyIndex);
//            AddCompaniesToPdfList(document, "Coluna I", allCompanies.Skip(companyIndex - 1).Take(companiesPerColumn + (remainder > 1 ? 1 : 0)).ToList(), ref companyIndex);
//            AddCompaniesToPdfList(document, "Coluna N", allCompanies.Skip(companyIndex - 1).Take(companiesPerColumn + (remainder > 2 ? 1 : 0)).ToList(), ref companyIndex);
//            AddCompaniesToPdfList(document, "Coluna G", allCompanies.Skip(companyIndex - 1).Take(companiesPerColumn + (remainder > 3 ? 1 : 0)).ToList(), ref companyIndex);
//            AddCompaniesToPdfList(document, "Coluna O", allCompanies.Skip(companyIndex - 1).Take(companiesPerColumn).ToList(), ref companyIndex);

//            // Fecha o documento PDF
//            document.Close();

//            MessageBox.Show("Lista de Elementos criada com sucesso!");
//        }

//        // Método auxiliar para adicionar empresas ao PDF agrupadas por coluna e numeradas
//        private static void AddCompaniesToPdfList(Document document, string columnName, List<DataRow> companies, ref int companyIndex)
//        {
//            // Adiciona o título da coluna (B, I, N, G, O)
//            document.Add(new Paragraph(columnName + ":\n"));

//            // Adiciona as empresas à lista numerada
//            foreach (DataRow company in companies)
//            {
//                document.Add(new Paragraph($"{companyIndex}- {company["CardName"]} (Chamada: ___________________________)"));
//                companyIndex++;
//            }

//            // Adiciona uma linha em branco após cada coluna para espaçamento
//            document.Add(new Paragraph("\n"));
//        }
//    }
//}

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BingoManager.Models;
using PdfFont = iTextSharp.text.Font;

namespace BingoManager.Services
{
    public static class CardsService
    {
        // Alias para evitar ambiguidade de Font

        public static void CreateCards(List<DataRow> CompList, int listId, int CompNumber, int Qnt, string Title, string End, string CardsName){
        List<List<DataRow>> allCards = new List<List<DataRow>>();
        Random random = new Random();
        CompList = CompList.OrderBy(x => random.Next()).ToList();

        int companiesPerColumn = CompList.Count / 5;
        int remainder = CompList.Count % 5;

        List<DataRow> columnB = CompList.Take(companiesPerColumn + (remainder > 0 ? 1 : 0)).ToList();
        List<DataRow> columnI = CompList.Skip(columnB.Count).Take(companiesPerColumn + (remainder > 1 ? 1 : 0)).ToList();
        List<DataRow> columnN = CompList.Skip(columnB.Count + columnI.Count).Take(companiesPerColumn + (remainder > 2 ? 1 : 0)).ToList();
        List<DataRow> columnG = CompList.Skip(columnB.Count + columnI.Count + columnN.Count).Take(companiesPerColumn + (remainder > 3 ? 1 : 0)).ToList();
        List<DataRow> columnO = CompList.Skip(columnB.Count + columnI.Count + columnN.Count + columnG.Count).Take(companiesPerColumn).ToList();

        string groupB = string.Join(",", columnB.Select(c => c["Id"].ToString()));
        string groupI = string.Join(",", columnI.Select(c => c["Id"].ToString()));
        string groupN = string.Join(",", columnN.Select(c => c["Id"].ToString()));
        string groupG = string.Join(",", columnG.Select(c => c["Id"].ToString()));
        string groupO = string.Join(",", columnO.Select(c => c["Id"].ToString()));

        int setId = DataService.CreateCardList(listId, Qnt, End, Title, CardsName, groupB, groupI, groupN, groupG, groupO);

        for (int i = 1; i <= Qnt; i++)
        {
            var tempB = new List<DataRow>(columnB);
            var tempI = new List<DataRow>(columnI);
            var tempN = new List<DataRow>(columnN);
            var tempG = new List<DataRow>(columnG);
            var tempO = new List<DataRow>(columnO);
            var selected = new List<DataRow>();

            selected.AddRange(SelectAndRemoveFromGroup(tempB, 5, random));
            selected.AddRange(SelectAndRemoveFromGroup(tempI, 5, random));
            selected.AddRange(SelectAndRemoveFromGroup(tempN, 5, random));
            selected.AddRange(SelectAndRemoveFromGroup(tempG, 5, random));
            selected.AddRange(SelectAndRemoveFromGroup(tempO, 5, random));

            var companyIds = selected.Select(c => Convert.ToInt32(c["Id"])).ToList();
            if (companyIds.Count == 25)
            {
                DataService.CreateCard(listId, companyIds, i, setId);
                allCards.Add(selected);
            }
        }

        // Gera PDF das cartelas
        var (saveName, savePath) = PrintingService.PrintCards(allCards, allCards.Count, Title, End);
        if (!string.IsNullOrEmpty(saveName))
            PrintList(CompList, saveName, savePath);
    }

    private static List<DataRow> SelectAndRemoveFromGroup(List<DataRow> group, int count, Random random)
    {
        var selected = new List<DataRow>();
        for (int i = 0; i < count && group.Count > 0; i++)
        {
            int idx = random.Next(group.Count);
            selected.Add(group[idx]);
            group.RemoveAt(idx);
        }
        return selected;
    }

    public static void PrintList(List<DataRow> allCompanies, string nameWithoutExtension, string path)
    {
        string fileName = $"lista_{nameWithoutExtension}.pdf";
        string filePath = Path.Combine(path, fileName);

        using var document = new Document(PageSize.A4, 36, 36, 36, 36);
        PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
        document.Open();

        // Fonte maior para o PDF
        PdfFont font = FontFactory.GetFont(FontFactory.HELVETICA, 14);

        int total = allCompanies.Count;
        int perCol = total / 5;
        int rem = total % 5;

        var groups = new Dictionary<string, List<DataRow>>
            {
                { "B", allCompanies.Take(perCol + (rem > 0 ? 1 : 0)).ToList() },
                { "I", allCompanies.Skip(perCol + (rem > 0 ? 1 : 0)).Take(perCol + (rem > 1 ? 1 : 0)).ToList() },
                { "N", allCompanies.Skip((perCol + (rem > 0 ? 1 : 0)) + (perCol + (rem > 1 ? 1 : 0))).Take(perCol + (rem > 2 ? 1 : 0)).ToList() },
                { "G", allCompanies.Skip((perCol + (rem > 0 ? 1 : 0)) + (perCol + (rem > 1 ? 1 : 0)) + (perCol + (rem > 2 ? 1 : 0))).Take(perCol + (rem > 3 ? 1 : 0)).ToList() },
                { "O", allCompanies.Skip((perCol + (rem > 0 ? 1 : 0)) + (perCol + (rem > 1 ? 1 : 0)) + (perCol + (rem > 2 ? 1 : 0)) + (perCol + (rem > 3 ? 1 : 0))).Take(perCol).ToList() }
            };

        bool first = true;
        int index = 1;
        foreach (var kv in groups)
        {
            if (!first)
                document.NewPage();
            first = false;

            AddCompaniesToPdfList(document, font, kv.Key, kv.Value, ref index);
        }

        document.Close();
        MessageBox.Show("Lista de Elementos criada com sucesso!");
    }

    private static void AddCompaniesToPdfList(
        Document document,
        PdfFont font,
        string columnName,
        List<DataRow> companies,
        ref int companyIndex)
    {
        // Título da letra
        var title = new Paragraph(columnName, font) { SpacingAfter = 14f };
        document.Add(title);

        foreach (var company in companies)
        {
            var p = new Paragraph { Font = font, SpacingAfter = 6f };
            p.Add(new Chunk($"{companyIndex}- {company["CardName"]} ", font));

            var separator = new DottedLineSeparator { Offset = -2f, Gap = 2f, LineWidth = 0.5f };
            p.Add(new Chunk(separator));

            document.Add(p);
            companyIndex++;
        }
    }
}
}
