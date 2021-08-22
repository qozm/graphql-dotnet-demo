using GraphQL;
using GraphQL.Types;
using GraphqlDemo.Ef.Entities;
using GraphqlDemo.GraphQL.InputTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.GraphQL.Types.Mutation
{
    public partial class RootMutation
    {
        public void SetPostMutation()
        {
            Field<PostType>(
                name: "CreatePost",
                arguments: new QueryArguments(new QueryArgument<InputPostType> { Name = "post" }),
                resolve: context => CreatePostAsync(context.GetArgument<Post>("post")));
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            var author = await _authorService.GetAuthorByIdAsync(post.Author.Id);
            if (author == null)
            {
                throw new ArgumentException("The author does not exist.");
            }

            post.Id = Guid.NewGuid().ToString();
            return await _postService.CreatePostAsync(post);
        }
    }
}
