using System.ComponentModel.DataAnnotations;

namespace lab2.Persistence
{
	public class AuctionDb
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(320)]
        public string Description { get; set; }

        [Required]
        [MaxLength(64)]
        public string Auctioneer { get; set; }

        [Required]
        public int StartingPrice { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        public virtual List<BidDb> BidDbs { get; set; } = new List<BidDb>();
	}
}

