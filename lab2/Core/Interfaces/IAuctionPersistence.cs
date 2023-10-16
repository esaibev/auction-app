namespace lab2.Core.Interfaces
{
	public interface IAuctionPersistence
	{
		List<Auction> GetAllActive();
        Auction GetAuctionById(int id);
		void AddAuction(Auction auction);
    }
}

