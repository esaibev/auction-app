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
        public string Winner { get; set; }

        private List<Bid> _bids = new List<Bid>();
		public IEnumerable<Bid> Bids => _bids;

		public Auction(int id, string name, string descr, string auctioneer, int startingPrice, DateTime endDate, string winner)
		{
			Id = id;
			Name = name;
			Description = descr;
			Auctioneer = auctioneer;
			StartingPrice = startingPrice;
			EndDate = endDate;
			Winner = winner;
		}

        public Auction(int id, string name, string auctioneer, int startingPrice, DateTime endDate)
			: this(id, name, "", auctioneer, startingPrice, endDate, "")
        { }

		public Auction () {}

        public void AddBid(Bid bid)
		{
			_bids.Add(bid);
		}

        public void AddBids(IEnumerable<Bid> bids)
        {
            foreach (var bid in bids)
            {
                AddBid(bid);
            }
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

		public Bid GetLastBid()
		{
            if (!_bids.Any())
            {
                throw new InvalidOperationException("There are no bids yet.");
            }
            return _bids.Last();
		}
    }
}

