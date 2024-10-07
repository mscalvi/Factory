using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.Models
{
    public class CardModel
    {
        //Registrados
        public int Id { get; set; }
        public string Name { get; set; }
        public int Have { get; set; }

        //Baixados
        public string Type { get; set; }
        public string SuperType { get; set; }
        public string SubType { get; set; }
        public string Text { get; set; }
        public string ManaValue { get; set; }
        public string ImageAdress { get; set; }
    }
}
