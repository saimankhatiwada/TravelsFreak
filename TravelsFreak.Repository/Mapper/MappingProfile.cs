using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
