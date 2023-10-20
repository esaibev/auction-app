using AutoMapper;
using lab2.Core;
using lab2.Persistence;

namespace lab2.Mappings
{
	public class AuctionProfile : Profile
	{
		public AuctionProfile()
		{
			CreateMap<AuctionDb, Auction>()
				.ReverseMap();
        }
	}
}

