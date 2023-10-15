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
            // Define the relationship between AuctionDb and BidDb
            modelBuilder.Entity<AuctionDb>()
                        .HasMany(a => a.BidDbs)
                        .WithOne(b => b.AuctionDb)
                        .HasForeignKey(b => b.AuctionDbId);

            modelBuilder.Entity<AuctionDb>().HasData(
                new AuctionDb
                {
                    Id = -1,
                    Name = "Default title",
                    Description = "Test description",
                    Auctioneer = "Foo",
                    StartingPrice = 125,
                    EndDate = new DateTime(2023,12,21),
                });

            BidDb bid1 = new BidDb()
            {
                Id = -1,
                Bidder = "SampleBid1",
                Amount = 150,
                DateMade = new DateTime(2023, 10, 14),
                AuctionDbId = -1
            };

            BidDb bid2 = new BidDb()
            {
                Id = -2,
                Bidder = "SampleBid2",
                Amount = 170,
                DateMade = new DateTime(2023, 10, 15),
                AuctionDbId = -1
            };

            modelBuilder.Entity<BidDb>().HasData(bid1, bid2);
        }
    }
}

