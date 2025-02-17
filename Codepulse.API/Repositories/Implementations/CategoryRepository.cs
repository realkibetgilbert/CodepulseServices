using Codepulse.API.Data;
using Codepulse.API.DTOs.Category;
using Codepulse.API.Repositories.Interfaces;
using Codepulse.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Category?> DeleteAsync(long id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null) return null;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.OrderByDescending(c => c.Id).ToListAsync();
        }
        public async Task<Category?> GetByIdAsync(long id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null) return null;
            return category;
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(r => r.Id == category.Id);

            if (category == null)
            {
                return null;
            }
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.UrlHandle = category.UrlHandle;

            }
            await _context.SaveChangesAsync();
            return existingCategory;
        }

    }
}
