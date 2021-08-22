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

        public RootMutation(AuthorService authorService)
        {
            _authorService = authorService;
            SetAuthorMutation();
        }

    }
}
