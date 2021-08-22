using GraphQL;
using GraphQL.Types;
using GraphqlDemo.Services;

namespace GraphqlDemo.GraphQL.Types.Query
{
    public partial class RootQuery 
    {
        public void SetAuthorQuery()
        {
            int id = 0;

            Field<ListGraphType<AuthorType>>(
                name: "authors",
                resolve: context => { return _authorService.GetAllAuthorsAsync(); }
            );

            Field<AuthorType>(
                name: "author",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>
                    {
                        Name = "id"
                    }),
                resolve: context =>
                {
                    id = context.GetArgument<int>("id");
                    return _authorService.GetAuthorById(id);
                }
            );

            Field<ListGraphType<PostType>>(
                name: "posts",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>
                    {
                        Name = "id"
                    }),
                resolve: context => { return _authorService.GetPostsByAuthorAsync(id); }
            );
        }
    }
}
