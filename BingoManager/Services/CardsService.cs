using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoManager.Services
{
    public static class CardsService
    {
        public static void CreateCards(List<DataRow> CompList, int List, int CompNumber, bool Center, int Qnt, string Title, string End)
        {
            if (Center == false)
            {
                // Inicializa os grupos
                List<List<DataRow>> companyGroups = new List<List<DataRow>>();
                for (int i = 0; i < 5; i++)
                {
                    companyGroups.Add(new List<DataRow>());
                }

                // Distribui as empresas nos grupos
                int index = 0;
                foreach (DataRow row in CompList)
                {
                    int groupIndex = index % 5;
                    companyGroups[groupIndex].Add(row);
                    index++;
                }

                // Inicializa o randomizador
                Random random = new Random();

                // Gerar as cartelas
                for (int i = 0; i < Qnt; i++)
                {
                    List<DataRow> selectedCompanies = new List<DataRow>();

                    // Seleciona 5 empresas de cada grupo
                    foreach (var group in companyGroups)
                    {
                        var randomSelection = group.OrderBy(x => random.Next()).Take(5).ToList();
                        selectedCompanies.AddRange(randomSelection);
                    }

                    foreach (var company in selectedCompanies)
                    {
                        MessageBox.Show($"Empresa: {company["CardName"]} adicionada à Cartela!");
                    }

                    // A lógica para criar a cartela, como salvar ou imprimir

                }
            }
        }
    }
}
