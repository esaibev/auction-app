namespace lab2.Core
{
    public class Auction
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public string Auctioneer { get; set; }
		public int StartingPrice { get; set; }
		public DateTime EndDate { get; set; }

		private List<Bid> _bids = new List<Bid>();
		public IEnumerable<Bid> Bids => _bids;

		public Auction(int id, string name, string descr, string auctioneer, int startingPrice, DateTime endDate)
		{
			Id = id;
			Name = name;
			Description = descr;
			Auctioneer = auctioneer;
			StartingPrice = startingPrice;
			EndDate = endDate;
		}

        public Auction(int id, string name, string auctioneer, int startingPrice, DateTime endDate)
        {
            Id = id;
            Name = name;
			Description = "";
            Auctioneer = auctioneer;
            StartingPrice = startingPrice;
            EndDate = endDate;
        }

        public void addBid(Bid bid)
		{
			_bids.Add(bid);
		}

		public bool isCompleted()
		{
			return DateTime.Now >= EndDate;
		}
	}
}

