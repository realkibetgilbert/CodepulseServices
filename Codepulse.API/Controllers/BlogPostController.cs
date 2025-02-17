using AutoMapper;
using Codepulse.API.DTOs.BlogPost;
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

        public BlogPostController(IMapper mapper, IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBlogPostRequestDto createBlogPostRequestDto)
        {
            var blogPostDomain = _mapper.Map<BlogPost>(createBlogPostRequestDto);
            blogPostDomain = await _blogPostRepository.CreateAsync(blogPostDomain);
            return Ok(_mapper.Map<BlogPostToDisplay>(blogPostDomain));

        }
    }
}
