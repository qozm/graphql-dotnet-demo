using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Demo.Schemas
{
    public class GraphQLDemoSchema : Schema, ISchema
    {
        //public GraphQLDemoSchema(IDependencyResolver resolver) : base(resolver)
        //public GraphQLDemoSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        //{
        //    Query = serviceProvider.Resolve<AuthorQuery>();
        //}


        public GraphQLDemoSchema(IServiceProvider provider)
        : base(provider)
        {
            Query = provider.GetRequiredService<AuthorQuery>();
            //Mutation = provider.GetRequiredService<StarWarsMutation>();
        }


    }
}
