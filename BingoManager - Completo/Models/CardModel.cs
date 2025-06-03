using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoManager.Models
{
    public class CardModel
    {
        public int CardId { get; set; }
        public int CardNumber { get; set; }
        public List<int> AllCompanies { get; set; }
        public List<int> BCompanies { get; set; }
        public List<int> ICompanies { get; set; }
        public List<int> NCompanies { get; set; }
        public List<int> GCompanies { get; set; }
        public List<int> OCompanies { get; set; }
        public List<int> Companies1 { get; set; }
        public List<int> Companies2 { get; set; }
        public List<int> Companies3 { get; set; }
        public List<int> Companies4 { get; set; }
        public List<int> Companies5 { get; set; }

    }
}
