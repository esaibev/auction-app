using AutoMapper;
using lab2.Core;
using lab2.Persistence;

namespace lab2.Mappings
{
	public class BidProfile : Profile
	{
		public BidProfile()
		{
            CreateMap<BidDb, Bid>()
                .ReverseMap();
        }
	}
}

