using lab2.Core;

namespace lab2.ViewModels
{
	public class AuctionVM
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Auctioneer { get; set; }
        public int StartingPrice { get; set; }
        public DateTime EndDate { get; set; }
        public int HighestBid { get; set; }
        public string Winner { get; set; }

        public List<BidVM> Bids { get; set; } = new List<BidVM>();

        public static AuctionVM FromAuction(Auction auction)
        {
            var highestBid = auction.Bids.DefaultIfEmpty(null).Max(b => b?.Amount ?? 0);

            var auctionVM = new AuctionVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                Auctioneer = auction.Auctioneer,
                StartingPrice = auction.StartingPrice,
                EndDate = auction.EndDate,
                HighestBid = highestBid,
                Winner = auction.Winner
            };  

            foreach(var bid in auction.Bids)
            {
                auctionVM.Bids.Add(BidVM.FromBid(bid));
            }

            return auctionVM;
        }
    }
}
