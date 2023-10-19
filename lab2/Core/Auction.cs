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
			: this(id, name, "", auctioneer, startingPrice, endDate)
        { }

		public Auction () {}

        public void addBid(Bid bid)
		{
			_bids.Add(bid);
		}

        public void AddBids(IEnumerable<Bid> bids)
        {
            foreach (var bid in bids)
            {
                addBid(bid);
            }
        }

        public bool isCompleted()
		{
			return DateTime.Now >= EndDate;
		}

        public bool BidIsValid(int amount)
        {
			if (amount < StartingPrice) return false;
			int currentHighestBid = -1;
			foreach (Bid bid in _bids)
			{
				if (bid.Amount > currentHighestBid)
					currentHighestBid = bid.Amount;
			}
			return amount > currentHighestBid;
        }
    }
}

