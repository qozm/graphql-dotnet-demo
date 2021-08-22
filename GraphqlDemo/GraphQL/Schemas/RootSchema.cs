using System;
using GraphQL.Types;
using GraphqlDemo.GraphQL.Types.Mutation;
using GraphqlDemo.GraphQL.Types.Query
    ;
using Microsoft.Extensions.DependencyInjection;

namespace GraphqlDemo.GraphQL.Schemas
{
    public class RootSchema : Schema //, ISchema
    {
        public RootSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<RootQuery>();
            Mutation = provider.GetRequiredService<RootMutation>();
        }
    }
}