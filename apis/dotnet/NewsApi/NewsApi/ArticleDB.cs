using Microsoft.EntityFrameworkCore;

namespace NewsApi
{
    public class ArticleDb : DbContext
    {
        public ArticleDb(DbContextOptions<ArticleDb> options) 
            : base(options) { }

        public DbSet<Article> Articles => Set<Article>();
    }
}
