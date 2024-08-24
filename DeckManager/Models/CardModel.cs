namespace DeckManager.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Owned { get; set; }


        public string ManaCost { get; set; }
        public string Type { get; set; }
        public string Supertype { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ScryfallId { get; set; }
        public string OracleId { get; set; }


        public string Edition { get; set; }
        public string Condition { get; set; }
        public string Extras { get; set; }

    }
}