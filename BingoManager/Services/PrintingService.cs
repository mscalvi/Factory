using BingoManager.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Asn1.X509;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BingoManager.Services
{
    public static class PrintingService
    {
        public static void PrintCards(List<List<DataRow>> allCards, int CardQnt, string title, string footer)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Document|*.pdf",
                Title = "Salvar PDF com Cartelas"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Cria o documento PDF
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Itera sobre todas as cartelas, gerando duas por página
                for (int cardIndex = 0; cardIndex < CardQnt; cardIndex++)
                {
                    // Adiciona uma nova cartela no layout
                    //CardLayout(document, allCards[cardIndex], cardIndex + 1);

                    var cardHtmlGenerator = new BingoCardHtmlGenerator(title, footer);
                    string cardHtml = cardHtmlGenerator.GenerateHtml(allCards[cardIndex], cardIndex + 1);

                    using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(document))
                    {
                        using (StringReader sr = new StringReader(cardHtml))
                        {
                            htmlWorker.Parse(sr);
                        }
                    }

                    // A cada duas cartelas, inicia uma nova página
                    if (cardIndex % 2 == 1)
                    {
                        document.NewPage();
                    }
                    else
                    {
                        // Adiciona espaçamento entre as cartelas na mesma página
                        document.Add(new Paragraph("\n\n"));
                    }
                }

                // Fecha o documento
                document.Close();

                // Mensagem de sucesso
                MessageBox.Show("Cartelas criadas com sucesso!");
            } else
            {
                MessageBox.Show("Erro ao criar PDF das Cartelas!");
            }
        }

        // Método auxiliar para desenhar o layout de uma cartela
        private static void CardLayout(Document document, List<DataRow> cartela, int cartelaNumber)
        {
            // Configura o título da cartela usando o construtor Font diretamente
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD);
            Paragraph title = new Paragraph($"Cartela {cartelaNumber}\n\n", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Configura a tabela de cartela (5 colunas para B, I, N, G, O)
            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 90;

            // Adiciona o cabeçalho (B, I, N, G, O)
            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
            string[] headers = { "B", "I", "N", "G", "O" };
            foreach (string header in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            // Adiciona as empresas em cada coluna (exibe Nome e ID)
            List<DataRow> columnB = cartela.Take(5).ToList();
            List<DataRow> columnI = cartela.Skip(5).Take(5).ToList();
            List<DataRow> columnN = cartela.Skip(10).Take(5).ToList();
            List<DataRow> columnG = cartela.Skip(15).Take(5).ToList();
            List<DataRow> columnO = cartela.Skip(20).Take(5).ToList();

            for (int i = 0; i < 5; i++)
            {
                table.AddCell(new Phrase($"{columnB[i]["Name"]} (ID: {columnB[i]["Id"]})"));
                table.AddCell(new Phrase($"{columnI[i]["Name"]} (ID: {columnI[i]["Id"]})"));
                table.AddCell(new Phrase($"{columnN[i]["Name"]} (ID: {columnN[i]["Id"]})"));
                table.AddCell(new Phrase($"{columnG[i]["Name"]} (ID: {columnG[i]["Id"]})"));
                table.AddCell(new Phrase($"{columnO[i]["Name"]} (ID: {columnO[i]["Id"]})"));
            }

            // Adiciona a tabela ao documento
            document.Add(table);
        }
    }
}
