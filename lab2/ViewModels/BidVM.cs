using lab2.Core;

namespace lab2.ViewModels
{
	public class BidVM
	{
        public int Id { get; set; }
        public string Bidder { get; set; }
        public int Amount { get; set; }
        public DateTime DateMade { get; set; }

        public static BidVM FromBid(Bid bid)
        {
            return new BidVM()
            {
                Id = bid.Id,
                Bidder = bid.Bidder,
                Amount = bid.Amount,
                DateMade = bid.DateMade
            };
        }
    }
}

