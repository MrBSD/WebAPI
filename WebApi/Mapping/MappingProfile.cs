using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dto;
using Core.Entities;
using AuthorForUpdateDto = WebApi.Controllers.AuthorForUpdateDto;

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
