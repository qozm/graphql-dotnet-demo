using GraphQL;
using GraphQL.Types;
using GraphqlDemo.Services;

namespace GraphqlDemo.GraphQL.Types.Query
{
    public partial class RootQuery
    {
        public void SetAuthorQuery()
        {
            string id = string.Empty;

            Field<ListGraphType<AuthorType>>(
                name: "authors",
                resolve: context => { return _authorService.GetAllAuthorsAsync(); }
            );

            Field<AuthorType>(
                name: "author",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>
                    {
                        Name = "id"
                    }),
                resolve: context =>
                {
                    id = context.GetArgument<string>("id");
                    return _authorService.GetAuthorByIdAsync(id);
                }
            );

            Field<ListGraphType<PostType>>(
                name: "posts",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>
                    {
                        Name = "id"
                    }),
                resolve: context => { return _authorService.GetPostsByAuthorAsync(id); }
            );
        }
    }
}
