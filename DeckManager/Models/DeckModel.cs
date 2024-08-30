using DynamicData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckManager.Models
{
    public class DeckModel
    {
        //Informações Gerais
        public int Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }

        //Informações de Versão
        public int Version { get; set; }
        public int Variation { get; set; }
        public string VersionName { get; set; }
        public DateTime VersionAtt { get; set; }

        //Listas
        public ObservableCollection<CardModel> DeckList { get; set; } = new ObservableCollection<CardModel>();
        public ObservableCollection<CardModel> CmdList { get; set; } = new ObservableCollection<CardModel>();
        public ObservableCollection<CardModel> SideList { get; set; } = new ObservableCollection<CardModel>();
        public ObservableCollection<CardModel> WishList { get; set; } = new ObservableCollection<CardModel>();
        public ObservableCollection<CardModel> MaybeList { get; set; } = new ObservableCollection<CardModel>();

    }
}
