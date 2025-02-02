using Codepulse.Model;

namespace Codepulse.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(long id);
        Task<Category?> UpdateAsync(long id, Category category);
        Task<Category?> DeleteAsync(long id);
    }
}
