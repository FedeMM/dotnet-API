using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>();
            CreateMap<Beer, BeerDto>()
                .ForMember(dto => dto.Id,
                           m => m.MapFrom(b => b.BeerId));

            CreateMap<BeerUpdateDto, Beer>();

            //CreateMap<Brand, DTOs.BrandDto>();
            //CreateMap<PostDto, Models.Post>();
            //CreateMap<Models.Post, PostDto>();
        }
    }
}
