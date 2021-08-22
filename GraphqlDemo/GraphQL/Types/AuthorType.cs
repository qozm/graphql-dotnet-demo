using GraphQL.Types;
using GraphqlDemo.Ef.Entities;

namespace GraphqlDemo.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Name = nameof(Author);
            Field(_ => _.Id).Description("Author's Id.");
            Field(_ => _.Name).Description("First name of the author");
        }
    }
}