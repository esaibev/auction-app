using System.Linq;
using lab2.Core;
using lab2.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab2.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;

        public AuctionSqlPersistence(AuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Auction> GetAllActive()
        {
            var auctionDbs = _dbContext.AuctionDbs
                .Where(a => a.EndDate >= DateTime.Now)
                .OrderBy(a => a.EndDate)
                .ToList();
                
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

                result.Add(auction);
            }
            return result;
        }

        public Auction GetAuctionById(int id)
        {
            var adb = _dbContext.AuctionDbs
                .Include(a => a.BidDbs)
                .Where(a => a.Id == id)
                .SingleOrDefault();

            if (adb == null) return null;

            adb.BidDbs = adb.BidDbs.OrderByDescending(b => b.Amount).ToList();

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

            return auction;
        }
    }
}
