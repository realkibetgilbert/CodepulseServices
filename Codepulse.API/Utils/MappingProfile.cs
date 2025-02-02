using AutoMapper;
using Codepulse.API.DTOs.Category;
using Codepulse.Model;

namespace Codepulse.API.Utils
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryToCreateDto, Category>().ReverseMap();
            CreateMap<Category, CategoryToDisplayDto>().ReverseMap();
        }
    }
}
