using BingoManager.Models;
using iText.Layout.Element;
using iText.Layout.Properties;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BingoManager.Services
{
    public static class PrintingService
    {
        public static (string fileNameWithoutExtension, string directoryPath) PrintCards(List<List<DataRow>> allCards, int CardQnt, string title, string footer)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Document|*.pdf",
                Title = "Salvar PDF com Cartelas"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath); // Obter apenas o nome sem extensão
                string directoryPath = Path.GetDirectoryName(filePath); // Obter o diretório

                // Cria o documento PDF
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Itera sobre todas as cartelas, gerando duas por página
                for (int cardIndex = 0; cardIndex < CardQnt; cardIndex++)
                {
                    // Adiciona uma nova cartela no layout
                    CardLayout(document, allCards[cardIndex], cardIndex + 1, title, footer);

                    // A cada duas cartelas, inicia uma nova página
                    if (cardIndex % 2 == 1)
                    {
                        document.NewPage();
                    }
                    else
                    {
                        // Adiciona espaçamento entre as cartelas na mesma página
                        document.Add(new Phrase("\n\n"));
                    }
                }

                // Fecha o documento
                document.Close();

                // Mensagem de sucesso
                MessageBox.Show("Cartelas criadas com sucesso!");

                return (fileNameWithoutExtension, directoryPath); // Retorna o nome sem extensão e o diretório
            }
            else
            {
                MessageBox.Show("Erro ao criar PDF das Cartelas!");
                return (string.Empty, string.Empty);
            }
        }



        // Método auxiliar para desenhar o layout de uma cartela
        private static void CardLayout(Document document, List<DataRow> cardComps, int cardNumber, string titleCard, string footerCard)
        {
            PdfPTable card = new PdfPTable(5);
            card.WidthPercentage = 100;

            // Definindo as fontes
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 17, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font footerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font numberFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font compFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10);

            // Adiciona o título
            PdfPCell titleCell = new PdfPCell(new Phrase(titleCard, titleFont));
            titleCell.Colspan = 5;
            titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
            titleCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            titleCell.BorderWidth = 2f;
            titleCell.FixedHeight = 40;
            titleCell.Padding = 0;
            card.AddCell(titleCell);

            // Adiciona os cabeçalhos B, I, N, G, O
            string[] headers = { "B", "I", "N", "G", "O" };
            foreach (string header in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.BorderWidth = 2f;
                cell.FixedHeight = 40;
                card.AddCell(cell);
            }

            // Divide as empresas nas colunas
            List<List<DataRow>> columns = new List<List<DataRow>>
            {
                cardComps.Take(5).ToList(),
                cardComps.Skip(5).Take(5).ToList(),
                cardComps.Skip(10).Take(5).ToList(),
                cardComps.Skip(15).Take(5).ToList(),
                cardComps.Skip(20).Take(5).ToList()
            };

            // Adiciona as empresas em cada coluna
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (columns[j].Count > i)
                    {
                        var company = columns[j][i];
                        PdfPCell companyCell = new PdfPCell(new Phrase($"{company["Name"]}", compFont));
                        companyCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        companyCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        companyCell.BorderWidth = 1f;
                        companyCell.FixedHeight = 40;
                        card.AddCell(companyCell);
                    }
                    else
                    {
                        PdfPCell emptyCell = new PdfPCell(new Phrase("ERRO")); // Célula vazia (???) se não houver empresa
                        emptyCell.FixedHeight = 40;
                        card.AddCell(emptyCell);
                    }
                }
            }

            // Adiciona o rodapé como uma célula que ocupa 4 colunas
            PdfPCell footerCell = new PdfPCell(new Phrase(footerCard, footerFont));
            footerCell.Colspan = 4;
            footerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            footerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            footerCell.BorderWidth = 2f;
            footerCell.FixedHeight = 40;
            card.AddCell(footerCell);

            // Adiciona o número da cartela como uma célula que ocupa 1 coluna
            string formattedCardNumber = $"Cartela {cardNumber:0000}";
            PdfPCell numberCell = new PdfPCell(new Phrase(formattedCardNumber, numberFont));
            numberCell.Colspan = 1;
            numberCell.HorizontalAlignment = Element.ALIGN_CENTER;
            numberCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            numberCell.BorderWidth = 2f;
            numberCell.FixedHeight = 40;
            card.AddCell(numberCell);

            // Adiciona a tabela ao documento
            document.Add(card);
        }
    }
}