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
        public bool IsCompleted { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                Auctioneer = auction.Auctioneer,
                StartingPrice = auction.StartingPrice,
                EndDate = auction.EndDate,
                IsCompleted = auction.isCompleted()
            };
        }
    }
}
