using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.Models
{
    public class DeckModel
    {
        //Registradas
        public int Id { get; set; }
        public string Name { get; set; }
        public string Formato { get; set; }
        public int Montado { get; set; }

        public List<CardModel> DeckList { get; set; }
        public List<CardModel> SideList {  get; set; }
        public List<CardModel> MaybeList { get; set; }
        public List<CardModel> WishList { get; set; }
        public List<CardModel> Commander {  get; set; }

    }
}
