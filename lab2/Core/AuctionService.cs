using lab2.Core.Interfaces;

namespace lab2.Core
{
	public class AuctionService : IAuctionService
	{
        private IAuctionPersistence _auctionPersistence;

        public AuctionService(IAuctionPersistence auctionPersistence)
        {
            _auctionPersistence = auctionPersistence;
        }

        public void AddAuction(Auction auction)
        {
            // Id should be 0 since db handles it
            if (auction == null || auction.Id != 0 || auction.EndDate <= DateTime.Now) throw new InvalidDataException();

            _auctionPersistence.AddAuction(auction);
        }

        public List<Auction> GetActiveAuctionsByBidder(string bidderName)
        {
            if (bidderName == null) throw new InvalidDataException();
            return _auctionPersistence.GetActiveAuctionsByBidder(bidderName);
        }

        public List<Auction> GetAllActive()
        {
            return _auctionPersistence.GetAllActive();
        }

        public Auction GetAuctionById(int id)
        {
            return _auctionPersistence.GetAuctionById(id);
        }

        public List<Auction> GetWonAuctions(string username)
        {
            return _auctionPersistence.GetWonAuctions(username);
        }

        public void MakeBid(int auctionId, string bidderName, int bidAmount)
        {
            var auction = _auctionPersistence.GetAuctionById(auctionId);

            if (auction == null)
                throw new InvalidOperationException("Auction not found.");

            if (auction.Auctioneer.Equals(bidderName))
                throw new InvalidOperationException("Cannot bid on your own auction.");

            if (auction.EndDate < DateTime.Now)
                throw new InvalidOperationException("Bids cannot be made on a completed auction.");

            if (!auction.BidIsValid(bidAmount))
                throw new InvalidOperationException("Bid amount must be higher than the starting price and the current highest bid.");

            Bid bid = new Bid()
            {
                Bidder = bidderName,
                Amount = bidAmount,
                DateMade = DateTime.Now,
            };

            auction.AddBid(bid);
            _auctionPersistence.MakeBid(auction);
        }

        public void UpdateAuction(Auction auction)
        {
            if (auction == null) throw new InvalidDataException();
            _auctionPersistence.UpdateAuction(auction);
        }
    }
}

