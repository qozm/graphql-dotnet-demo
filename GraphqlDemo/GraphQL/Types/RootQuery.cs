using GraphQL;
using GraphQL.Types;
using GraphqlDemo.Services;

namespace GraphqlDemo.GraphQL.Types
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(AuthorService authorService)
        {
            int id = 0;

            Field<ListGraphType<AuthorType>>(
                name: "authors",
                resolve: context => { return authorService.GetAllAuthors(); }
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
                    return authorService.GetAuthorById(id);
                }
            );

            Field<ListGraphType<PostType>>(
                name: "posts",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>
                    {
                        Name = "id"
                    }),
                resolve: context => { return authorService.GetPostsByAuthor(id); }
            );
        }
    }
}