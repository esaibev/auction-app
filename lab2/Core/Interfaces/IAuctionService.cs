namespace lab2.Core.Interfaces
{
    public interface IAuctionService
	{
		List<Auction> GetAllActive();
		Auction GetAuctionById(int id);
		void AddAuction(Auction auction);
	}
}

