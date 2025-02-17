using Codepulse.API.Data;
using Codepulse.API.Repositories.Interfaces;
using Codepulse.Model;

namespace Codepulse.API.Repositories.Implementations
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly CodepulseDbContext _context;

        public BlogPostRepository(CodepulseDbContext context)
        {
            _context = context;
        }
        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await _context.BlogPosts.AddAsync(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
        }
    }
}
