using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoManager.Services
{
    public static class PlayService
    {
        private static List<int> drawnComp = new List<int>();

        // Método para adicionar uma empresa à lista das sorteadas
        public static void AddCompany(int companyId)
        {
            if (!drawnComp.Contains(companyId))
            {
                drawnComp.Add(companyId);
            } else
            {
                drawnComp.Remove(companyId);
            }
        }
    }
}
