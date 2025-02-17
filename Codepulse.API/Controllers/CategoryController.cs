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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var categories = await _repository.GetAllAsync();
            var categoriesToDisplay = _mapper.Map<List<CategoryToDisplayDto>>(categories);
            return Ok(categories);

        }


        [HttpGet]
        [Route("{id:long}")]

        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var category = await _repository.GetByIdAsync(id);

            if (category == null) return NotFound();

            return Ok(_mapper.Map<CategoryToDisplayDto>(category));
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] CategoryToUpdateDto categoryToUpdateDto)
        {

            var categoryDomain = _mapper.Map<Category>(categoryToUpdateDto);
            categoryDomain.Id = id;
            categoryDomain = await _repository.UpdateAsync(categoryDomain);

            if (categoryDomain == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryToDisplayDto>(categoryDomain));

        }


        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute,] long id)
        {
            var categoryDomain = await _repository.DeleteAsync(id);

            if (categoryDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoryToDisplayDto>(categoryDomain));
        }
    }
}
