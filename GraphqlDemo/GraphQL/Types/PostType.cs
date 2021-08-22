using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphqlDemo.Ef.Entities;
using GraphqlDemo.Services;
using System.Linq;

namespace GraphqlDemo.GraphQL.Types
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType(AuthorService authorService)
        {
            Name = nameof(Post);
            Field(_ => _.Id, type: typeof(IdGraphType)).Description("The Id of the post.");
            Field(_ => _.Title).Description("The title of the post.");
            Field(_ => _.Content).Description("The content of the post.");
            Field<AuthorType>()
                .Name("Author")
                .Resolve(_ =>
                {
                    return authorService.GetAuthorByIdAsync(_.Source.Author.Id);
                });
        }

        //private static class PostResolvers
        //{
        //    public static IDataLoaderResult<Author> GetAuthorById(
        //        IDataLoaderContextAccessor accessor,
        //        IResolveFieldContext<Author> context,
        //        AuthorService authorService)
        //    {
        //        var loader = accessor.Context.GetOrAddBatchLoader<string, Author>("GetAuthorById", async x =>
        //        {
        //            var authors = await authorService.GetAllAuthorsAsync();
        //            return authors.ToArray(g => g);
        //        });

        //        return loader.LoadAsync(context.Source.AdministratorId);
        //    }
        //}

    }
}