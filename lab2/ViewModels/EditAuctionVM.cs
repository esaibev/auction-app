using System.ComponentModel.DataAnnotations;
using lab2.Core;

namespace lab2.ViewModels
{
	public class EditAuctionVM
	{
        public int Id { get; set; }

        [Required]
        [StringLength(320, ErrorMessage = "Max length 320 characters")]
        public string Description { get; set; }

        public static EditAuctionVM FromAuction(Auction auction)
        {
            var editAuctionVM = new EditAuctionVM()
            {
                Id = auction.Id,
                Description = auction.Description,
            };
            return editAuctionVM;
        }
    }
}

