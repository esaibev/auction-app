using Microsoft.EntityFrameworkCore;

namespace lab2.Persistence
{
	public class AuctionDbContext : DbContext
	{
		public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }
		public DbSet<AuctionDb> AuctionDbs { get; set; }
		public DbSet<BidDb> BidDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionDb>().HasData(
                new AuctionDb
                {
                    Id = -1,
                    Name = "Default title",
                    Description = "Test description",
                    Auctioneer = "Foo",
                    StartingPrice = 100,
                    EndDate = new DateTime(2023,12,21),
                    BidDbs = new List<BidDb>()
                });

            BidDb bid1 = new BidDb()
            {
                Id = -1,
                Bidder = "FooBidder",
                Amount = 150,
                DateMade = new DateTime(2023, 10, 14),
                AuctionId = -1
            };
            modelBuilder.Entity<BidDb>().HasData(bid1);
        }
    }
}

