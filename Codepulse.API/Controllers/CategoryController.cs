using AutoMapper;
using Codepulse.API.DTOs.Category;
using Codepulse.API.Repositories.Interfaces;
using Codepulse.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Codepulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryToCreateDto categoryToCreateDto)
        {
            var categoryDomain = _mapper.Map<Category>(categoryToCreateDto);

            await _repository.CreateAsync(categoryDomain);

            return Ok(_mapper.Map<CategoryToDisplayDto>(categoryDomain));
        }
    }
}
