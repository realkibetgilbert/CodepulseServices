using AutoMapper;
using Codepulse.API.DTOs.BlogPost;
using Codepulse.API.DTOs.Category;
using Codepulse.API.Repositories.Interfaces;
using Codepulse.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codepulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BlogPostController(IMapper mapper, IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBlogPostRequestDto createBlogPostRequestDto)
        {
            var blogPostDomain = _mapper.Map<BlogPost>(createBlogPostRequestDto);
            blogPostDomain.Categories = new List<Category>();
            foreach (var categoryId in createBlogPostRequestDto.Categories)
            {
                var existingCategory = await _categoryRepository.GetByIdAsync(categoryId);
                if (existingCategory != null)
                {
                    blogPostDomain.Categories.Add(existingCategory);
                }
            }
            blogPostDomain = await _blogPostRepository.CreateAsync(blogPostDomain);
            return Ok(_mapper.Map<BlogPostToDisplay>(blogPostDomain));

        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<BlogPost> blogPosts = await _blogPostRepository.GetAllAsync();
            List<BlogPostToDisplay> blogPostToDisplays = _mapper.Map<List<BlogPostToDisplay>>(blogPosts);

            return Ok(blogPostToDisplays);

        }
    }
}
