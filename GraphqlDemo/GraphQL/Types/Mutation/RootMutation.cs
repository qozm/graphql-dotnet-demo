using GraphQL;
using GraphQL.Types;
using GraphqlDemo.Ef.Entities;
using GraphqlDemo.GraphQL.InputTypes;
using GraphqlDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.GraphQL.Types.Mutation
{
    public partial class RootMutation : ObjectGraphType
    {
        private readonly AuthorService _authorService;
        private readonly PostService _postService;

        public RootMutation(
            AuthorService authorService,
            PostService postService)
        {
            _authorService = authorService;
            _postService = postService;

            SetAuthorMutation();
            SetPostMutation();
        }

    }
}
