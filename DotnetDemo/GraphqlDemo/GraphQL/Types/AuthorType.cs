using GraphQL.Types;
using GraphqlDemo.Models;

namespace GraphqlDemo.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            //Name = "Author";
            Name = nameof(Author);
            //Field(_ => _.Id).Description("Author's Id.");
            Field(_ => _.Id, type: typeof(IdGraphType)).Description("Author Id.");
            Field(_ => _.FirstName).Description("First name of the author");
            Field(_ => _.LastName).Description("Last name of the author");
            Field(_ => _.BlogPosts, type : typeof(ListGraphType<BlogPostType>)).Description("Author's blog posts.");
        }
    }
}