using lab2.Core.Interfaces;

namespace lab2.Core
{
	public class MockAuctionService //: IAuctionService
	{
		public MockAuctionService()
		{
		}

        public void AddAuction(Auction auction)
        {
            throw new NotImplementedException();
        }

        public List<Auction> GetAllActive()
        {
            Auction a1 = new Auction(1, "Guitar", "A precious antique guitar", "Esaias", 500, new DateTime(2023,10,25,10,00,00));
            Auction a2 = new Auction(2, "Piano", "Used by Elton John", "Robert", 3000, new DateTime(2023,10,30,15,30,00));
            a1.AddBid(new Core.Bid(1, "Adam", 1000, new DateTime(2023, 10, 14)));
            a2.AddBid(new Core.Bid(1, "Peter", 5000, new DateTime(2023, 10, 15)));
            List<Auction> auctions = new();
            auctions.Add(a1);
            auctions.Add(a2);
            return auctions;
        }

        public Auction GetAuctionById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

