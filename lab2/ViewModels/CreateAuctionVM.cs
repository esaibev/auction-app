using System.ComponentModel.DataAnnotations;

namespace lab2.ViewModels
{
	public class CreateAuctionVM
	{
        [Required]
        [StringLength(64, ErrorMessage = "Max length 64 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(320, ErrorMessage = "Max length 320 characters")]
        public string Description { get; set; }

        [Required]
        public int StartingPrice { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

    }
}

