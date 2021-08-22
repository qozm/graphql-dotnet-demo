using GraphqlDemo.Ef;
using GraphqlDemo.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.Repositories
{
    public class PostRepository
    {
        protected WikiContext _wikiContext;

        public PostRepository(WikiContext wikiContext)
        {
            _wikiContext = wikiContext;
        }

        public async Task<List<Post>> GetAllPostsAsnyc()
        {
            return await _wikiContext.Posts.AsQueryable().ToListAsync();
        }

        public Post GetPostById(string id)
        {
            return _wikiContext.Posts.Where(_ => _.Id == id).FirstOrDefault();
        }

        public async Task CreatePostrAsync(Post post)
        {
            await _wikiContext.Posts.AddAsync(post);
            await _wikiContext.SaveChangesAsync();
        }
    }
}
