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

        //Método para conferir se uma Cartela Bingou!
        public static List<int> CheckBingo(List<int> cardNum, int setId, int bingoPhase, int compId)
        {
            List<int> winningCards = new List<int>();
            List<int> drawnNumbers = PlayService.drawnComp;

            foreach (var card in cardNum)
            {
                var cardDetails = DataService.GetCardDetails(card, setId);

                bool isQuina = false;
                bool isFullBingo = true;

                for (int i = 0; i < 5; i++)
                {
                    var rowNumbers = new List<int>
                        {
                            cardDetails.Companies1[i],
                            cardDetails.Companies2[i],
                            cardDetails.Companies3[i],
                            cardDetails.Companies4[i],
                            cardDetails.Companies5[i]
                        };

                    if (rowNumbers.All(num => drawnNumbers.Contains(num)) && rowNumbers.Contains(compId))
                    {
                        isQuina = true;
                        break;
                    }
                }

                if ((cardDetails.BCompanies.All(num => drawnNumbers.Contains(num)) && cardDetails.BCompanies.Contains(compId)) ||
                    (cardDetails.ICompanies.All(num => drawnNumbers.Contains(num)) && cardDetails.ICompanies.Contains(compId)) ||
                    (cardDetails.NCompanies.All(num => drawnNumbers.Contains(num)) && cardDetails.NCompanies.Contains(compId)) ||
                    (cardDetails.GCompanies.All(num => drawnNumbers.Contains(num)) && cardDetails.GCompanies.Contains(compId)) ||
                    (cardDetails.OCompanies.All(num => drawnNumbers.Contains(num)) && cardDetails.OCompanies.Contains(compId)))
                {
                    isQuina = true;
                }

                if (!cardDetails.AllCompanies.All(num => drawnNumbers.Contains(num)))
                {
                    isFullBingo = false;
                }

                if (bingoPhase == 1 && isQuina)
                {
                    winningCards.Add(card);
                }
                else if (bingoPhase == 2 && isFullBingo)
                {
                    winningCards.Add(card);
                }
            }

            return winningCards;
        }

    }
}
