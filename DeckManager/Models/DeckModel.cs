namespace DeckManager.Models
{
    public class DeckModel
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public string Format { get; set; }

        public int Version { get; set; }
        public int VersionVar { get; set; }
        public string VersionName { get; set; }
        public DateTime VersionAtt { get; set; }

        public List<CardModel> Decklist { get; set; }
        public List<CardModel> Sideboard { get; set; }
        public List<CardModel> Wishlist { get; set; }
        public List<CardModel> Maybelist { get; set; }
        public CardModel Commander { get; set; }

        public bool OfflineMode { get; set; }

        public DeckModel()
        {
            Decklist = new List<CardModel>();
            Sideboard = new List<CardModel>();
            Wishlist = new List<CardModel>();
            Maybelist = new List<CardModel>();
            VersionAtt = DateTime.Now;
        }
    }
}