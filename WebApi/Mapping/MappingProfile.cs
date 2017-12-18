using AutoMapper;
using Core.Dto;
using Core.Entities;

namespace WebApi.Mapping
{
    public class MappingProfile: Profile
    {
       
        public MappingProfile()
        {
            //Domain to Dto
            CreateMap<Author, AuthorDto>()
                .ForMember(a => a.Name, opt => opt.MapFrom(src=>$"{src.FirstName} {src.LastName}"));

            //Dto to Domain
            CreateMap<AuthorForUpdateDto, Author>();
            CreateMap<AuthorForCreateDto, Author>();
        }
    }
}
