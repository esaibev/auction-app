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
                    Name = "Guitar",
                    Description = "An antique guitar",
                    Auctioneer = "esaiasb@kth.se",
                    StartingPrice = 125,
                    EndDate = new DateTime(2023,12,21),
                });

            BidDb bid1 = new BidDb()
            {
                Id = -1,
                Bidder = "foo@mail.com",
                Amount = 150,
                DateMade = new DateTime(2023, 10, 14),
                AuctionDbId = -1
            };

            BidDb bid2 = new BidDb()
            {
                Id = -2,
                Bidder = "testUser@mail.com",
                Amount = 170,
                DateMade = new DateTime(2023, 10, 15),
                AuctionDbId = -1
            };

            modelBuilder.Entity<BidDb>().HasData(bid1, bid2);

            var auction2 = new AuctionDb
            {
                Id = -2,
                Name = "Piano",
                Description = "Belonged to Elton John",
                Auctioneer = "foo@mail.com",
                StartingPrice = 500,
                EndDate = new DateTime(2023, 10, 15),
            };

            var auction3 = new AuctionDb
            {
                Id = -3,
                Name = "Saxophone",
                Description = "In good condition",
                Auctioneer = "foo@mail.com",
                StartingPrice = 300,
                EndDate = new DateTime(2023, 12, 15),
            };
            modelBuilder.Entity<AuctionDb>().HasData(auction2, auction3);
        }
    }
}
