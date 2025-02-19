using Codepulse.Model;

namespace Codepulse.API.Repositories.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateAsync(BlogPost blogPost);
        Task<List<BlogPost>> GetAllAsync();
    }
}
