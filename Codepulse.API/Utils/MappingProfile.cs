using AutoMapper;
using Codepulse.API.DTOs;
using Codepulse.API.DTOs.BlogPost;
using Codepulse.API.DTOs.Category;
using Codepulse.Model;

namespace Codepulse.API.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryToCreateDto, Category>().ReverseMap();
            CreateMap<Category, CategoryToDisplayDto>().ReverseMap();
            CreateMap<CategoryToUpdateDto, Category>().ReverseMap();
            CreateMap<CreateBlogPostRequestDto, BlogPost>().ReverseMap();
            CreateMap<BlogPost, BlogPostToDisplay>().ReverseMap();
        }
    }
}
