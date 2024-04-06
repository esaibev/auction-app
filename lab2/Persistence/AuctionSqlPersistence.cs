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

        public List<Auction> GetActiveAuctionsByBidder(string bidderName)
        {
            var auctionsBidderParticipated = _dbContext.AuctionDbs
                .Where(a => a.EndDate >= DateTime.Now && a.BidDbs.Any(b => b.Bidder == bidderName))
                .Include(a => a.BidDbs)
                .OrderBy(a => a.EndDate)
                .ToList();

            List<Auction> auctions = new();

            foreach (var auctionDb in auctionsBidderParticipated)
            {
                Auction auction = _mapper.Map<Auction>(auctionDb);
                IEnumerable<Bid> bids = auctionDb.BidDbs.Select(_mapper.Map<Bid>);
                auction.AddBids(bids);
                auctions.Add(auction);
            }

            return auctions;
        }

        public List<Auction> GetAllActive()
        {
            var auctionDbs = _dbContext.AuctionDbs
                .Where(a => a.EndDate >= DateTime.Now)
                .Include(a => a.BidDbs)
                .OrderBy(a => a.EndDate)
                .ToList();

            List<Auction> auctions = new();

            foreach (var auctionDb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(auctionDb);
                IEnumerable<Bid> bids = auctionDb.BidDbs.Select(_mapper.Map<Bid>);
                auction.AddBids(bids);
                auctions.Add(auction);
            }
            return auctions;
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
                auction.AddBid(_mapper.Map<Bid>(bidDb));
            }

            return auction;
        }

        public List<Auction> GetWonAuctions(string username)
        {
            List<Auction> wonAuctions = new();

            var endedAuctions = _dbContext.AuctionDbs
                                          .Include(a => a.BidDbs)
                                          .Where(a => a.EndDate <= DateTime.Now)
                                          .ToList();

            foreach (var auctionDb in endedAuctions)
            {
                var highestBid = auctionDb.BidDbs
                                          .OrderByDescending(b => b.Amount)
                                          .FirstOrDefault();

                if (highestBid != null && highestBid.Bidder == username)
                {
                    Auction auction = _mapper.Map<Auction>(auctionDb);
                    IEnumerable<Bid> bids = auctionDb.BidDbs.Select(_mapper.Map<Bid>);
                    auction.AddBids(bids);
                    wonAuctions.Add(auction);
                }
            }

            return wonAuctions.OrderByDescending(a => a.EndDate).ToList();
        }

        public void MakeBid(Auction auction)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var adb = _dbContext.AuctionDbs
                        .Include(a => a.BidDbs)
                        .Where(a => a.Id == auction.Id)
                        .SingleOrDefault();

                    if (adb != null)
                    {
                        _mapper.Map(auction, adb);
                        var newBid = auction.GetLastBid();
                        var newBidDb = _mapper.Map<BidDb>(newBid);
                        adb.BidDbs.Add(newBidDb);

                        _dbContext.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    else throw new ArgumentException("Auction id " + auction.Id +
                        " cannot be found in the database.");
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
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
