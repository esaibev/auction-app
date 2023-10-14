namespace lab2.Core
{
	public class Bid
	{
        public int Id { get; set; }
        public string Bidder { get; set; }
        public int Amount { get; set; }
        public DateTime DateMade { get; set; }

        public Bid(int id, string bidder, int amount, DateTime dateMade)
        {
            Id = id;
            Bidder = bidder;
            Amount = amount;
            DateMade = dateMade;
        }
    }
}

