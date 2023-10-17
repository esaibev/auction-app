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

        public List<Auction> GetAllActive()
        {
            return _auctionPersistence.GetAllActive();
        }

        public Auction GetAuctionById(int id)
        {
            return _auctionPersistence.GetAuctionById(id);
        }

        public void MakeBid(Auction auction)
        {
            if (auction == null) throw new InvalidDataException();
            _auctionPersistence.MakeBid(auction);
        }

        public void UpdateAuction(Auction auction)
        {
            if (auction == null) throw new InvalidDataException();
            _auctionPersistence.UpdateAuction(auction);
        }
    }
}

