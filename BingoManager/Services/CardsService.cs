using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BingoManager.Services
{
    public static class CardsService
    {
        public static void CreateCards(List<DataRow> CompList, int listId, int CompNumber, bool Center, int Qnt, string Title, string End)
        {
            int intCenter = Center ? 1 : 0;

            // Chama o método que cria a lista de cartelas no banco de dados
            DataService.CreateCardList(listId, intCenter, Qnt, End, Title);

            if (!Center)
            {
                // Determina quantas empresas haverá em cada coluna de forma dinâmica
                int companiesPerColumn = CompList.Count / 5; // Dividindo igualmente as empresas entre as 5 colunas
                int remainder = CompList.Count % 5; // Para lidar com casos em que o número de empresas não é divisível por 5

                // Distribui as empresas para cada coluna de forma dinâmica
                List<DataRow> columnB = CompList.Take(companiesPerColumn + (remainder > 0 ? 1 : 0)).ToList();
                List<DataRow> columnI = CompList.Skip(columnB.Count).Take(companiesPerColumn + (remainder > 1 ? 1 : 0)).ToList();
                List<DataRow> columnN = CompList.Skip(columnB.Count + columnI.Count).Take(companiesPerColumn + (remainder > 2 ? 1 : 0)).ToList();
                List<DataRow> columnG = CompList.Skip(columnB.Count + columnI.Count + columnN.Count).Take(companiesPerColumn + (remainder > 3 ? 1 : 0)).ToList();
                List<DataRow> columnO = CompList.Skip(columnB.Count + columnI.Count + columnN.Count + columnG.Count).Take(companiesPerColumn).ToList();

                // Inicializa o randomizador
                Random random = new Random();

                // Gerar as cartelas
                for (int i = 1; i <= Qnt; i++)
                {
                    List<DataRow> selectedCompanies = new List<DataRow>();

                    // Cria cópias temporárias dos grupos para garantir que as empresas não se repitam dentro da mesma cartela
                    List<DataRow> tempB = new List<DataRow>(columnB);
                    List<DataRow> tempI = new List<DataRow>(columnI);
                    List<DataRow> tempN = new List<DataRow>(columnN);
                    List<DataRow> tempG = new List<DataRow>(columnG);
                    List<DataRow> tempO = new List<DataRow>(columnO);

                    // Seleciona 5 empresas aleatoriamente de cada coluna (B, I, N, G, O) e remove as escolhidas da lista temporária
                    selectedCompanies.AddRange(SelectAndRemoveFromGroup(tempB, 5, random));
                    selectedCompanies.AddRange(SelectAndRemoveFromGroup(tempI, 5, random));
                    selectedCompanies.AddRange(SelectAndRemoveFromGroup(tempN, 5, random));
                    selectedCompanies.AddRange(SelectAndRemoveFromGroup(tempG, 5, random));
                    selectedCompanies.AddRange(SelectAndRemoveFromGroup(tempO, 5, random));

                    // A lógica para inserir as cartelas no banco de dados
                    List<int> companyIds = selectedCompanies.Select(c => Convert.ToInt32(c["Id"])).ToList();

                    if (companyIds.Count == 25)
                    {
                        // Chama o método que insere a cartela no banco de dados
                        DataService.CreateCard(listId, companyIds, i);
                    }
                }

                MessageBox.Show($"Cartelas Criadas com Sucesso!");

                // Chama o método para gerar o PDF com todas as empresas da lista completa (CompList)
                SavePdfWithCompaniesByGroup(CompList);
            }
        }

        // Método para selecionar e remover empresas de um grupo temporário
        private static List<DataRow> SelectAndRemoveFromGroup(List<DataRow> group, int count, Random random)
        {
            List<DataRow> selected = new List<DataRow>();
            for (int i = 0; i < count; i++)
            {
                if (group.Count == 0) break; // Evitar erros se não houver mais empresas no grupo
                int randomIndex = random.Next(group.Count);
                selected.Add(group[randomIndex]);
                group.RemoveAt(randomIndex); // Remove a empresa selecionada para evitar repetição
            }
            return selected;
        }

        // Método para gerar e salvar o PDF com todas as empresas separadas por grupo (B, I, N, G, O) e numeradas
        public static void SavePdfWithCompaniesByGroup(List<DataRow> allCompanies)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Document|*.pdf",
                Title = "Salvar PDF com todas as empresas utilizadas"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Cria o documento PDF
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Adiciona título ao documento
                document.Add(new Paragraph("Lista de Empresas nas Cartelas\n\n"));

                // Adiciona as empresas separadas por grupo em formato de lista numerada
                int companyIndex = 1;

                // Determina quantas empresas haverá em cada coluna de forma dinâmica
                int companiesPerColumn = allCompanies.Count / 5;
                int remainder = allCompanies.Count % 5;

                // Dividir as empresas em grupos (Colunas B, I, N, G, O)
                AddCompaniesToPdfList(document, "Coluna B", allCompanies.Take(companiesPerColumn + (remainder > 0 ? 1 : 0)).ToList(), ref companyIndex);
                AddCompaniesToPdfList(document, "Coluna I", allCompanies.Skip(companyIndex - 1).Take(companiesPerColumn + (remainder > 1 ? 1 : 0)).ToList(), ref companyIndex);
                AddCompaniesToPdfList(document, "Coluna N", allCompanies.Skip(companyIndex - 1).Take(companiesPerColumn + (remainder > 2 ? 1 : 0)).ToList(), ref companyIndex);
                AddCompaniesToPdfList(document, "Coluna G", allCompanies.Skip(companyIndex - 1).Take(companiesPerColumn + (remainder > 3 ? 1 : 0)).ToList(), ref companyIndex);
                AddCompaniesToPdfList(document, "Coluna O", allCompanies.Skip(companyIndex - 1).Take(companiesPerColumn).ToList(), ref companyIndex);

                // Fecha o documento PDF
                document.Close();

                MessageBox.Show("PDF criado com sucesso!");
            }
        }

        // Método auxiliar para adicionar empresas ao PDF agrupadas por coluna e numeradas
        private static void AddCompaniesToPdfList(Document document, string columnName, List<DataRow> companies, ref int companyIndex)
        {
            // Adiciona o título da coluna (B, I, N, G, O)
            document.Add(new Paragraph(columnName + ":\n"));

            // Adiciona as empresas à lista numerada
            foreach (DataRow company in companies)
            {
                document.Add(new Paragraph($"{companyIndex}- {company["Name"]} (ID: {company["Id"]})"));
                companyIndex++;
            }

            // Adiciona uma linha em branco após cada coluna para espaçamento
            document.Add(new Paragraph("\n"));
        }
    }
}
