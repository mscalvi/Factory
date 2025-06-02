using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        private static List<int> drawnCards = new List<int>();

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

        //Método para conferir cartelas que possuem a última empresa sorteada
        public static List<int> CheckCards(int companyId, int setId)
        {
            var cardData = DataService.GetCardsByCompanyId(companyId, setId);

            List<int> cardNumbers = new List<int>();
            foreach (var (CardId, CardNum) in cardData)
            {
                cardNumbers.Add(CardNum);
            }

            return cardNumbers; // Retorna a lista de números das cartelas
        }

        public static List<int> CheckBingo(List<int> cardNum, int setId, int bingoPhase, int compId)
        {
            List<int> winningCards = new List<int>();
            List<int> drawnNumbers = PlayService.drawnComp;

            foreach (var card in cardNum)
            {
                var cardDetails = DataService.GetCardDetails(card, setId);

                bool isFullBingo = cardDetails.AllCompanies.All(num => drawnNumbers.Contains(num));

                if (bingoPhase == 2 && isFullBingo)
                {
                    winningCards.Add(card);
                    continue;
                }

                if (bingoPhase == 1)
                {
                    // Verificar em qual linha (Companies1-5) está a empresa sorteada
                    List<List<int>> rows = new List<List<int>>
            {
                cardDetails.Companies1,
                cardDetails.Companies2,
                cardDetails.Companies3,
                cardDetails.Companies4,
                cardDetails.Companies5
            };

                    int rowIndex = rows.FindIndex(row => row.Contains(compId));

                    // Verificar em qual coluna (B-I-N-G-O) está a empresa sorteada
                    List<List<int>> columns = new List<List<int>>
            {
                cardDetails.BCompanies,
                cardDetails.ICompanies,
                cardDetails.NCompanies,
                cardDetails.GCompanies,
                cardDetails.OCompanies
            };

                    int colIndex = columns.FindIndex(col => col.Contains(compId));

                    bool rowComplete = false;
                    bool colComplete = false;

                    if (rowIndex != -1)
                    {
                        rowComplete = rows[rowIndex].All(num => drawnNumbers.Contains(num));
                    }

                    if (colIndex != -1)
                    {
                        colComplete = columns[colIndex].All(num => drawnNumbers.Contains(num));
                    }

                    if (rowComplete || colComplete)
                    {
                        winningCards.Add(card);
                    }
                }
            }

            return winningCards;
        }



        public static void ResetGame()
        {
            drawnComp.Clear(); 
            drawnCards.Clear();
        }

    }
}
