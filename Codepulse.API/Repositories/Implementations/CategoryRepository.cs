using Codepulse.API.Data;
using Codepulse.API.Repositories.Interfaces;
using Codepulse.Model;

namespace Codepulse.API.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CodepulseDbContext _context;

        public CategoryRepository(CodepulseDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public Task<Category?> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> UpdateAsync(long id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
