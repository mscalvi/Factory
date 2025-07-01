using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using System.Diagnostics;
using PdfSharpCore.Drawing.Layout.enums;

namespace BingoCreator.Services
{

    internal class PrintingService
    {
        // Imprimir Cartelas
        public static void PrintCards5x5(string setName, List<List<DataRow>> allCards, int cardsQnt, string cardsTitle, string cardsEnd)
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

            XFont titleFont = new XFont("Arial", 17, XFontStyle.Bold);
            XFont headerFont = new XFont("Arial", 15, XFontStyle.Bold);
            XFont compFont = new XFont("Arial", 10, XFontStyle.Regular);
            XFont footerFont = new XFont("Arial", 12, XFontStyle.Bold);
            XFont numberFont = new XFont("Arial", 12, XFontStyle.Bold);
            var pen = new XPen(XColors.Black, 1);

            XGraphics gfx = null;
            PdfPage page = null;

            for (int i = 0; i < cardsQnt; i++)
            {
                if (i % 2 == 0)
                {
                    page = document.AddPage();
                    page.Size = PdfSharpCore.PageSize.A4;
                    pageWidth = page.Width;
                    pageHeight = page.Height;
                    cardWidth = pageWidth - 2 * margin;

                    gfx = XGraphics.FromPdfPage(page);
                }

                double y0 = margin + (i % 2) * (cardHeight + 20);

                DrawCards5x5(
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

        public static void PrintCards4x4(string setName, List<List<DataRow>> allCards, int cardsQnt, string cardsTitle, string cardsEnd)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = $"cartelas_{setName}.pdf";
            string filePath = Path.Combine(desktop, fileName);

            var document = new PdfDocument();
            document.Info.Title = $"Cartelas 4×4 – {cardsTitle}";

            const double margin = 40;
            const double cellH4 = 40;
            double pageWidth, pageHeight;
            double cardWidth = 0;
            double cardHeight = cellH4 * 6;

            var titleFont = new XFont("Arial", 17, XFontStyle.Bold);
            var compFont = new XFont("Arial", 10, XFontStyle.Regular);
            var footerFont = new XFont("Arial", 12, XFontStyle.Bold);
            var numberFont = new XFont("Arial", 12, XFontStyle.Bold);
            var pen = new XPen(XColors.Black, 1);

            XGraphics gfx = null;
            PdfPage page = null;

            for (int i = 0; i < cardsQnt; i++)
            {
                if (i % 2 == 0)
                {
                    page = document.AddPage();
                    page.Size = PdfSharpCore.PageSize.A4;
                    gfx = XGraphics.FromPdfPage(page);
                    pageWidth = page.Width;
                    pageHeight = page.Height;
                    cardWidth = pageWidth - 2 * margin;
                }

                double y0 = margin + (i % 2) * (cardHeight + 20);

                DrawCards4x4(gfx, margin, y0, cardWidth, cardHeight, allCards[i], i + 1, cardsTitle, cardsEnd, pen, titleFont, compFont, footerFont, numberFont);
            }

            document.Save(filePath);
            MessageBox.Show($"Cartelas 4×4 salvas no Desktop:\n{fileName}", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Desenho das Cartelas
        private static void DrawCards5x5(XGraphics gfx, double x, double y, double width, double height, List<DataRow> cardsElements, int cardNumber, string titleText, string footerText, XPen pen, XFont titleFont, XFont headerFont, XFont elementFont, XFont footerFont, XFont numberFont)
        {
            double cellW = width / 5;
            double cellH = 40;

            var tf = new XTextFormatter(gfx);
            tf.Alignment = XParagraphAlignment.Center;

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
                    var cell = new XRect(xx, yy, cellW, cellH);
                    gfx.DrawRectangle(pen, cell);

                    int idx = col * 5 + row;
                    if (idx < cardsElements.Count)
                    {
                        string name = cardsElements[idx]["Name"].ToString();
                        if (idx < cardsElements.Count)
                        {
                            tf.DrawString(
                                name,
                                elementFont,
                                XBrushes.Black,
                                new XRect(cell.X + 2, cell.Y + 2, cell.Width - 4, cell.Height - 4),
                                new TextFormatAlignment
                                {
                                    Horizontal = XParagraphAlignment.Center,
                                    Vertical = XVerticalAlignment.Middle
                                }
                            );
                        }
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

        private static void DrawCards4x4(XGraphics gfx, double x, double y, double width, double height, List<DataRow> cardsElements, int cardNumber, string titleText, string footerText, XPen pen, XFont titleFont, XFont elementFont, XFont footerFont, XFont numberFont)
        {
            double cellW = width / 4;
            double cellH = height / 6;

            // 1) Título (1 linha)
            var titleRect = new XRect(x, y, width, cellH);
            gfx.DrawRectangle(pen, titleRect);
            gfx.DrawString(titleText, titleFont, XBrushes.Black, titleRect, XStringFormats.Center);

            // 2) Grid 4×4
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    double xx = x + col * cellW;
                    double yy = y + (1 + row) * cellH;
                    var cell = new XRect(xx, yy, cellW, cellH);
                    gfx.DrawRectangle(pen, cell);

                    int idx = row * 4 + col;
                    if (idx < cardsElements.Count)
                    {
                        string name = cardsElements[idx]["Name"].ToString();
                        // word-wrap e centralização simples:
                        var tf = new PdfSharpCore.Drawing.Layout.XTextFormatter(gfx);
                        tf.Alignment = PdfSharpCore.Drawing.Layout.XParagraphAlignment.Center;
                        tf.DrawString(
                            name,
                            elementFont,
                            XBrushes.Black,
                            new XRect(cell.X + 2, cell.Y + 2, cell.Width - 4, cell.Height - 4),
                            new TextFormatAlignment
                            {
                                Horizontal = XParagraphAlignment.Center,
                                Vertical = XVerticalAlignment.Middle
                            }
                        );
                    }
                }
            }

            // 3) Rodapé (1 linha) + número de cartela
            double footerY = y + 5 * cellH;
            var footerRect = new XRect(x, footerY, cellW * 3, cellH);
            gfx.DrawRectangle(pen, footerRect);
            gfx.DrawString(footerText, footerFont, XBrushes.Black, footerRect, XStringFormats.Center);

            var numRect = new XRect(x + 3 * cellW, footerY, cellW, cellH);
            gfx.DrawRectangle(pen, numRect);
            gfx.DrawString($"Cartela {cardNumber:0000}", numberFont, XBrushes.Black, numRect, XStringFormats.Center);
        }


        // Imprimir Listas
        public static void PrintList5(string setName, List<DataRow> groupB, List<DataRow> groupI, List<DataRow> groupN, List<DataRow> groupG, List<DataRow> groupO)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = $"lista_{setName}.pdf";
            string filePath = Path.Combine(desktop, fileName);

            PdfDocument document = new PdfDocument();
            document.Info.Title = $"Lista de Elementos {setName}";

            XFont font = new XFont("Segoe UI", 14);

            var groups = new Dictionary<string, List<DataRow>>
            {
                { "Coluna B", groupB },
                { "Coluna I", groupI },
                { "Coluna N", groupN },
                { "Coluna G", groupG },
                { "Coluna O", groupO }
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
                               XStringFormats.Center);
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

        public static void PrintList4(string setName, List<DataRow> elementsList)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = $"lista4_{setName}.pdf";
            string filePath = Path.Combine(desktop, fileName);

            var document = new PdfDocument();
            document.Info.Title = $"Relação 4×4 – {setName}";

            var page = document.AddPage();
            page.Size = PdfSharpCore.PageSize.A4;
            var gfx = XGraphics.FromPdfPage(page);

            double margin = 40;
            double lineSpacing = 6;
            var headerFont = new XFont("Arial", 16, XFontStyle.Bold);
            var itemFont = new XFont("Arial", 12, XFontStyle.Regular);

            double y = margin;
            gfx.DrawString(
                $"Relação Elementos – {setName}",
                headerFont,
                XBrushes.Black,
                new XRect(margin, y, page.Width - 2 * margin, headerFont.GetHeight()),
                XStringFormats.TopLeft
            );
            y += headerFont.GetHeight() + 20;

            for (int i = 0; i < elementsList.Count; i++)
            {
                string name = elementsList[i]["CardName"].ToString();
                string text = $"{i + 1:00} – {name}";
                gfx.DrawString(
                    text,
                    itemFont,
                    XBrushes.Black,
                    new XRect(margin, y, page.Width - 2 * margin, itemFont.GetHeight()),
                    XStringFormats.TopLeft
                );
                y += itemFont.GetHeight() + lineSpacing;

                if (y + itemFont.GetHeight() + margin > page.Height)
                {
                    page = document.AddPage();
                    page.Size = PdfSharpCore.PageSize.A4;
                    gfx = XGraphics.FromPdfPage(page);
                    y = margin;
                }
            }

            document.Save(filePath);
            MessageBox.Show($"Relação 4×4 salva no Desktop:\n{fileName}", "PDF Criado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
