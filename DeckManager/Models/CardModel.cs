using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.Models
{
    public class CardModel
    { 
        public int Id { get; set; }

        //Informações do Jogador
        public string Name { get; set; }
        public bool Owned { get; set; }

        //Buscada pela API
        public string ManaCost { get; set; }
        public string TextRules { get; set; }
        public string Type { get; set; }
        public string SuperType { get; set; }
        public string SamplePrice { get; set; }
    }
}
