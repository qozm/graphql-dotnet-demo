using GraphqlDemo.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GraphqlDemo.Ef
{
    public class WikiContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }

        public WikiContext(DbContextOptions<WikiContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(@"Data Source=Data/wiki.db");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}