using AutoMapper;
using TravelsFreak.Data;
using TravelsFreak.Models.DataTransferObject;

namespace TravelsFreak.Repository.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Destinations, DestinationsDTO>().ReverseMap();
            CreateMap<TourPackage, TourPackageDTO>().ReverseMap();
            CreateMap<Blog, BlogDTO>().ReverseMap();
        }
    }
}
