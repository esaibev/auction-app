namespace lab2.Core.Interfaces
{
    public interface IAuctionService
	{
		List<Auction> GetAllActive();
		Auction GetAuctionById(int id);
		void AddAuction(Auction auction);
		void UpdateAuction(Auction auction);
        void MakeBid(int auctionId, string bidderName, int bidAmount);
        List<Auction> GetActiveAuctionsByBidder(string bidderName);
		List<Auction> GetWonAuctions(string username);
    }
}

