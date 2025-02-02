using Codepulse.Model;
using Microsoft.EntityFrameworkCore;

namespace Codepulse.API.Data
{
    public class CodepulseDbContext : DbContext
    {
        public CodepulseDbContext(DbContextOptions<CodepulseDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }  
        public DbSet<Category> Categories { get; set; }  
    }
}
