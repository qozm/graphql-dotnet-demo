using GraphQL;
using GraphQL.Types;
using GraphqlDemo.Services;

namespace GraphqlDemo.GraphQL.Types.Query
{
    public partial class RootQuery : ObjectGraphType
    {
        private readonly AuthorService _authorService;

        public RootQuery(AuthorService authorService)
        {
            _authorService = authorService;

            SetAuthorQuery();
        }


    }
}