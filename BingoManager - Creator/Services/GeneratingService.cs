using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BingoCreator.Services
{
    internal class GeneratingService
    {
        public static int CreateCards(int listId, string setName, string setTitle, string setEnd, int setQnt, int cardsSize)
        {
            Random random = new Random();

            List<List<DataRow>> allCards = new List<List<DataRow>>();

            List<DataRow> ElementsList = DataService.GetElementsInList(listId);

            ElementsList = ElementsList.OrderBy(x => random.Next()).ToList();

            int elementsPerColumn = 1;
            int remainder = 1;

            if (cardsSize == 5)
            {
                elementsPerColumn = ElementsList.Count / 5;
                remainder = ElementsList.Count % 5;
            } else if (cardsSize == 4)
            {
                elementsPerColumn = ElementsList.Count / 4;
                remainder = ElementsList.Count % 4;
            }

            List<DataRow> columnB = ElementsList.Take(elementsPerColumn + (remainder > 0 ? 1 : 0)).ToList();
            List<DataRow> columnI = ElementsList.Skip(columnB.Count).Take(elementsPerColumn + (remainder > 1 ? 1 : 0)).ToList();
            List<DataRow> columnN = ElementsList.Skip(columnB.Count + columnI.Count).Take(elementsPerColumn + (remainder > 2 ? 1 : 0)).ToList();
            List<DataRow> columnG = ElementsList.Skip(columnB.Count + columnI.Count + columnN.Count).Take(elementsPerColumn + (remainder > 3 ? 1 : 0)).ToList();
            List<DataRow> columnO = ElementsList.Skip(columnB.Count + columnI.Count + columnN.Count + columnG.Count).Take(elementsPerColumn).ToList();

            string groupB = string.Join(",", columnB.Select(c => c["Id"].ToString()));
            string groupI = string.Join(",", columnI.Select(c => c["Id"].ToString()));
            string groupN = string.Join(",", columnN.Select(c => c["Id"].ToString()));
            string groupG = string.Join(",", columnG.Select(c => c["Id"].ToString()));
            string groupO = string.Join(",", columnO.Select(c => c["Id"].ToString()));

            string addTime = DateTime.Now.ToString("MMddyyyy - HH:mm:ss");

            int setId = DataService.CreateCardList(listId, setName, setTitle, setEnd, setQnt, cardsSize, groupB, groupI, groupN, groupG, groupO, addTime);

            for (int i = 1; i <= setQnt; i++)
            {
                var tempB = new List<DataRow>(columnB);
                var tempI = new List<DataRow>(columnI);
                var tempN = new List<DataRow>(columnN);
                var tempG = new List<DataRow>(columnG);
                var tempO = new List<DataRow>(columnO);
                var selected = new List<DataRow>();

                selected.AddRange(SelectAndRemoveFromGroup(tempB, 5, random));
                selected.AddRange(SelectAndRemoveFromGroup(tempI, 5, random));
                selected.AddRange(SelectAndRemoveFromGroup(tempN, 5, random));
                selected.AddRange(SelectAndRemoveFromGroup(tempG, 5, random));
                selected.AddRange(SelectAndRemoveFromGroup(tempO, 5, random));

                var companyIds = selected.Select(c => Convert.ToInt32(c["Id"])).ToList();
                if (companyIds.Count == 25)
                {
                    DataService.CreateCard(listId, companyIds, i, setId);
                    allCards.Add(selected);
                }
            }

            try
            {
                PrintingService.PrintCards(setName, allCards, allCards.Count, setTitle, setEnd);
                PrintingService.PrintList(setName, columnB, columnI, columnN, columnG, columnO);
            } catch
            {

            }

            return setId;
        }

        private static List<DataRow> SelectAndRemoveFromGroup(List<DataRow> group, int count, Random random)
        {
            var selected = new List<DataRow>();
            for (int i = 0; i < count && group.Count > 0; i++)
            {
                int idx = random.Next(group.Count);
                selected.Add(group[idx]);
                group.RemoveAt(idx);
            }
            return selected;
        }
    }
}
