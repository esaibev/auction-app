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

        public List<Auction> GetAllActive()
        {
            return _auctionPersistence.GetAllActive();
        }

        public Auction GetAuctionById(int id)
        {
            return _auctionPersistence.GetAuctionById(id);
        }
    }
}

