using DeckManager.Services;
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
        public int LastVersion { get; set; }
        public string VersionName { get; set; }

        //Questionáveis
        public int Ready { get; set; }

        //Categorias
        public int Format { get; set; }
        public int Owner { get; set; }
        public int Archetype { get; set; }
        public int Colors { get; set; }

        public string FormatName => DataService.GetFormatName(Format); // Método que retorna o nome do formato
        public string OwnerName => DataService.GetOwnerName(Owner); // Método que retorna o nome do dono
        public string ArchetypeName => DataService.GetArchetypeName(Archetype); // Método que retorna o nome do arquétipo
        public string ColorName => DataService.GetColorName(Colors); // Método que retorna os nomes das cores

        //Listas
        public List<string> FunctionsList { get; set; } = new List<string>();
        public List<CardModel> RealDeckList { get; set; } = new List<CardModel>();
        public List<CardModel> IdealDeckList { get; set; } = new List<CardModel>();
        public List<CardModel> SideList { get; set; } = new List<CardModel>();
        public List<CardModel> MaybeList { get; set; } = new List<CardModel>();
        public List<CardModel> WishList { get; set; } = new List<CardModel>();
        public List<CardModel> Commander { get; set; } = new List<CardModel>();


    }
}
