using System;
using GraphQL.Types;
using GraphqlDemo.GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GraphqlDemo.GraphQL.Schemas
{
    public class AuthorSchema : Schema, ISchema
    {
        public AuthorSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<AuthorQuery>();
        }
    }
}