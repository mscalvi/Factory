using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BingoManager.Models
{
    public class BingoCardHtmlGenerator
    {
        private string _title;
        private string _footer;

        public BingoCardHtmlGenerator(string title, string footer)
        {
            _title = title;
            _footer = footer;
        }

        public string GenerateHtml(List<DataRow> companies, int cardNumber)
        {
            // HTML básico para a cartela de bingo
            var html = new StringBuilder();

            // Adicionando doctype e estrutura básica do HTML
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang='pt-BR'><head><meta charset='UTF-8'>");
            html.AppendLine("<title>Bingo Card</title>");
            html.AppendLine("<style>");
            html.AppendLine("table { width: 100%; border-collapse: collapse; }");
            html.AppendLine("th, td { border: 1px solid black; padding: 8px; text-align: center; }");
            html.AppendLine("th { background-color: #f2f2f2; }");
            html.AppendLine("h2 { text-align: center; }");
            html.AppendLine("footer { text-align: center; margin-top: 20px; font-size: small; }");
            html.AppendLine("</style></head><body>");

            // Adiciona o título da cartela
            html.AppendLine($"<h2>{_title} - Cartela {cardNumber:0000}</h2>");

            // Monta a tabela
            html.AppendLine("<table>");
            html.AppendLine("<tr><th>B</th><th>I</th><th>N</th><th>G</th><th>O</th></tr>");

            // Agrupando empresas em colunas
            for (int rowIndex = 0; rowIndex < 5; rowIndex++)
            {
                html.AppendLine("<tr>");
                for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                {
                    html.AppendLine($"<td>{GetCompanyByColumn(companies, rowIndex, columnIndex)}</td>");
                }
                html.AppendLine("</tr>");
            }

            html.AppendLine("</table>");

            // Adiciona o rodapé
            html.AppendLine($"<footer>{_footer}</footer>");

            // Finaliza o HTML
            html.AppendLine("</body></html>");

            return html.ToString();
        }

        private string GetCompanyByColumn(List<DataRow> companies, int rowIndex, int columnIndex)
        {
            // Cálculo do índice na lista de empresas
            int index = rowIndex + (columnIndex * 5); // A ordem correta de acesso às empresas
            return index < companies.Count ? companies[index]["Name"].ToString() : string.Empty; // Retorna o nome da empresa ou vazio
        }
    }
}
