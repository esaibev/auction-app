using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Persistence
{
	public class BidDb
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Bidder { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateMade { get; set; }

        [ForeignKey("AuctionDbId")]
        public virtual AuctionDb AuctionDb { get; set; }

        public int AuctionDbId { get; set; }
	}
}

