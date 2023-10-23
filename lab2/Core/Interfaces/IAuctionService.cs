namespace lab2.Core.Interfaces
{
    public interface IAuctionService
	{
		/// <summary>
		/// Retrieves all active auctions.
		/// </summary>
		/// <returns>A list of active Auction objects.</returns>
		List<Auction> GetAllActive();

        /// <summary>
        /// Retrieves a specific auction identified by its auction id.
        /// </summary>
        /// <param name="id">The unique id of the auction to be retrieved.</param>
        /// <returns>The auction with the specified id, or null if no such auction exists.</returns>
        Auction GetAuctionById(int id);

        /// <summary>
        /// Adds a new auction to the system.
        /// </summary>
        /// <param name="auction">The auction to be added.</param>
        void AddAuction(Auction auction);

        /// <summary>
        /// Updates an existing auction in the system.
        /// </summary>
        /// <param name="auction">The auction to be updated.</param>
		void UpdateAuction(Auction auction);

        /// <summary>
        /// Makes a bid on the specified auction.
        /// </summary>
        /// <param name="auctionId">The id of the auction to bid on.</param>
        /// <param name="bidderName">The name of the bidder.</param>
        /// <param name="bidAmount">The amount of the bid.</param>
        void MakeBid(int auctionId, string bidderName, int bidAmount);

        /// <summary>
        /// Retrieves all active auctions that the specified bidder has participated in.
        /// </summary>
        /// <param name="bidderName">The name of the bidder.</param>
        /// <returns>A list of active auctions the bidder has participated in.</returns>
        List<Auction> GetActiveAuctionsByBidder(string bidderName);

        /// <summary>
        /// Retrieves all auctions won by the specified user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>A list of all auctions won by the user.</returns>
		List<Auction> GetWonAuctions(string username);
    }
}

