using GraphqlDemo.Ef;
using GraphqlDemo.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphqlDemo.Repositories
{
    public class AuthorRepository
    {
        protected WikiContext _wikiContext;
        //private readonly IDbContextFactory<WikiContext> _contextFactory;

        //public AuthorRepository(IDbContextFactory<WikiContext> contextFactory)
        //{
        //    _contextFactory = contextFactory;
        //}

        public AuthorRepository(WikiContext wikiContext)
        {
            _wikiContext = wikiContext;
        }

        public async Task<List<Author>> GetAllAuthors()
        {

            return await _wikiContext.Authors.AsQueryable().ToListAsync();

            //using (var wikiDbContext = _contextFactory.CreateDbContext())
            //{
            //    return await wikiDbContext.Set<Author>().AsQueryable().ToListAsync();
            //}
        }

        public Author GetAuthorById(int id)
        {
            return _wikiContext.Authors.Where(_ => _.Id == id).FirstOrDefault();

            //using (var wikiDbContext = _contextFactory.CreateDbContext())
            //{
            //    //wikiDbContext.ChangeTracker.AutoDetectChangesEnabled = false;
            //    return wikiDbContext.Set<Author>().Where(_ => _.Id == id).FirstOrDefault();
            //    //return wikiDbContext.Authors.Where(_ => _.Id == id).FirstOrDefault();
            //}
        }

        public async Task<List<Post>> GetPostsByAuthor(int id)
        {
            return await _wikiContext.Posts.Where(_ => _.Author.Id == id).AsQueryable().ToListAsync();
            //using (var wikiDbContext = _contextFactory.CreateDbContext())
            //{
            //    return await wikiDbContext.Set<Post>().Where(_ => _.Author.Id == id).AsQueryable().ToListAsync();
            //}
        }

        public async Task CreateAuthorAsync(Author author)
        {
            await _wikiContext.Authors.AddAsync(author);
            await _wikiContext.SaveChangesAsync();
        }
    }
}