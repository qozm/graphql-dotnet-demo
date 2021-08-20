using GraphqlDemo.Ef.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphqlDemo.Ef
{
    public class WikiContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=wiki.db");
    }
}