using GraphqlDemo.Ef.Entities;
using GraphqlDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.Services
{
    public class PostService
    {
        private readonly PostRepository _postRepository;

        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> GetAllPostsAsnyc()
        {
            return await _postRepository.GetAllPostsAsnyc();
        }

        public Post GetPostById(string id)
        {
            return _postRepository.GetPostById(id);
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            await _postRepository.CreatePostrAsync(post);
            return post;
        }
    }
}
