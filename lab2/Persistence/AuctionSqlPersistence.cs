using lab2.Core;
using lab2.Core.Interfaces;

namespace lab2.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;

        public AuctionSqlPersistence(AuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Auction> GetAll()
        {
            var auctionDbs = _dbContext.AuctionDbs.ToList();
            List<Auction> result = new List<Auction>();

            foreach (AuctionDb adb in auctionDbs)
            {
                Auction auction = new Auction(
                    adb.Id,
                    adb.Name,
                    adb.Description,
                    adb.Auctioneer,
                    adb.StartingPrice,
                    adb.EndDate);

                foreach (BidDb bid in adb.BidDbs)
                {
                    auction.addBid(new Bid(
                        bid.Id, bid.Bidder, bid.Amount, bid.DateMade));
                }

                result.Add(auction);
            }
            return result;
        }
    }
}
