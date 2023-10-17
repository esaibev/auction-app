using System.Linq;
using AutoMapper;
using lab2.Core;
using lab2.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab2.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;
        private IMapper _mapper;

        public AuctionSqlPersistence(AuctionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void AddAuction(Auction auction)
        {
            AuctionDb adb = _mapper.Map<AuctionDb>(auction);
            _dbContext.AuctionDbs.Add(adb);
            _dbContext.SaveChanges();
        }

        public List<Auction> GetAllActive()
        {
            var auctionDbs = _dbContext.AuctionDbs
                .Where(a => a.EndDate >= DateTime.Now)
                .OrderBy(a => a.EndDate)
                .ToList();

            return _mapper.Map<List<Auction>>(auctionDbs);
        }

        public Auction GetAuctionById(int id)
        {
            var adb = _dbContext.AuctionDbs
                .Include(a => a.BidDbs)
                .Where(a => a.Id == id)
                .SingleOrDefault();

            if (adb == null) return null;

            adb.BidDbs = adb.BidDbs.OrderByDescending(b => b.Amount).ToList();
            Auction auction = _mapper.Map<Auction>(adb);

            foreach (BidDb bidDb in adb.BidDbs)
            {
                auction.addBid(_mapper.Map<Bid>(bidDb));
            }

            return auction;
        }

        public void UpdateAuction(Auction auction)
        {
            var adb = _dbContext.AuctionDbs.Find(auction.Id);
            if (adb != null)
            {
                _mapper.Map(auction, adb);
                _dbContext.SaveChanges();
            }
            else throw new ArgumentException("Auction id " + auction.Id +
                " cannot be found in the database.");
        }
    }
}
