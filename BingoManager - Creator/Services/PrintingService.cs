using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace BingoCreator.Services
{
    internal class PrintingService
    {
        // Imprimir Cartelas
        public static void PrintCards(string setName, List<List<DataRow>> allCards, int cardsQnt, string cardsTitle, string cardsEnd)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = $"cartelas_{setName}.pdf";
            string filePath = Path.Combine(desktop, fileName);

            var document = new PdfDocument();
            document.Info.Title = $"Cartelas - {cardsTitle}";

            const double margin = 40;
            const double cellHeight = 40;
            double pageWidth, pageHeight;
            double cardWidth = 0;
            double cardHeight = cellHeight * 8;

            var titleFont = new XFont("Helvetica", 17);
            var headerFont = new XFont("Helvetica", 15);
            var compFont = new XFont("Helvetica", 10);
            var footerFont = new XFont("Helvetica", 12);
            var numberFont = new XFont("Helvetica", 12);
            var pen = new XPen(XColors.Black, 1);

            XGraphics gfx = null;
            PdfPage page = null;

            for (int i = 0; i < cardsQnt; i++)
            {
                if (i % 2 == 0)
                {
                    // nova página
                    page = document.AddPage();
                    page.Size = PdfSharp.PageSize.A4;
                    pageWidth = page.Width;
                    pageHeight = page.Height;
                    cardWidth = pageWidth - 2 * margin;

                    gfx = XGraphics.FromPdfPage(page);
                }

                double y0 = margin + (i % 2) * (cardHeight + 20);

                DrawCardLayout(
                    gfx,
                    margin, y0,
                    cardWidth, cardHeight,
                    allCards[i],
                    i + 1,
                    cardsTitle, cardsEnd,
                    pen, titleFont, headerFont, compFont, footerFont, numberFont
                );
            }

            document.Save(filePath);
            MessageBox.Show($"Cartelas salvas no Desktop", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // Desenho das Cartelas
        private static void DrawCardLayout(
            XGraphics gfx,
            double x, double y,
            double width, double height,
            List<DataRow> cardComps,
            int cardNumber,
            string titleText,
            string footerText,
            XPen pen,
            XFont titleFont,
            XFont headerFont,
            XFont compFont,
            XFont footerFont,
            XFont numberFont)
        {
            double cellW = width / 5;
            double cellH = 40;

            // 1) Título (colspan 5)
            var titleRect = new XRect(x, y, width, cellH);
            gfx.DrawRectangle(pen, titleRect);
            gfx.DrawString(titleText, titleFont, XBrushes.Black, titleRect, XStringFormats.Center);

            // 2) Cabeçalhos B-I-N-G-O
            string[] headers = { "B", "I", "N", "G", "O" };
            for (int j = 0; j < 5; j++)
            {
                var r = new XRect(x + j * cellW, y + cellH, cellW, cellH);
                gfx.DrawRectangle(pen, r);
                gfx.DrawString(headers[j], headerFont, XBrushes.Black, r, XStringFormats.Center);
            }

            // 3) Grid 5x5 de empresas
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    double xx = x + col * cellW;
                    double yy = y + 2 * cellH + row * cellH;
                    var r = new XRect(xx, yy, cellW, cellH);
                    gfx.DrawRectangle(pen, r);

                    int idx = col * 5 + row;
                    if (idx < cardComps.Count)
                    {
                        string name = cardComps[idx]["Name"].ToString();
                        gfx.DrawString(name, compFont, XBrushes.Black, r, XStringFormats.Center);
                    }
                }
            }

            // 4) Rodapé (colspan 4) + número (colspan 1)
            double footerY = y + 7 * cellH;
            var footerRect = new XRect(x, footerY, cellW * 4, cellH);
            gfx.DrawRectangle(pen, footerRect);
            gfx.DrawString(footerText, footerFont, XBrushes.Black, footerRect, XStringFormats.Center);

            var numRect = new XRect(x + 4 * cellW, footerY, cellW, cellH);
            gfx.DrawRectangle(pen, numRect);
            gfx.DrawString($"Cartela {cardNumber:0000}", numberFont, XBrushes.Black, numRect, XStringFormats.Center);
        }

        // Imprimir Listas
        public static void PrintList(string setName, List<DataRow> groupB, List<DataRow> groupI, List<DataRow> groupN, List<DataRow> groupG, List<DataRow> groupO)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = $"lista_{setName}.pdf";
            string filePath = Path.Combine(desktop, fileName);

            PdfDocument document = new PdfDocument();
            document.Info.Title = $"Lista de Elementos {setName}";

            XFont font = new XFont("Segoe UI", 14);

            var groups = new Dictionary<string, List<DataRow>>
            {
                { "B", groupB },
                { "I", groupI },
                { "N", groupN },
                { "G", groupG },
                { "O", groupO }
            };

            int index = 1;
            const double margin = 40;  
            const double lineSpacing = 6;

            foreach (var kv in groups)
            {
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                double y = margin;

                gfx.DrawString(kv.Key,
                               new XFont("Segoe UI", 18),
                               XBrushes.Black,
                               new XRect(margin, y, page.Width - 2 * margin, 20),
                               XStringFormats.TopLeft);
                y += 24;

                foreach (var row in kv.Value)
                {
                    string text = $"{index}- {row["CardName"]}";
                    gfx.DrawString(text, font, XBrushes.Black,
                                   new XRect(margin, y, page.Width - 2 * margin, font.Height),
                                   XStringFormats.TopLeft);
                    y += font.GetHeight() + lineSpacing;
                    index++;

                    if (y + font.GetHeight() + margin > page.Height)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        y = margin;
                    }
                }
            }

            document.Save(filePath);
            MessageBox.Show($"Lista de elementos salva no Desktop", "PDF Criado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
