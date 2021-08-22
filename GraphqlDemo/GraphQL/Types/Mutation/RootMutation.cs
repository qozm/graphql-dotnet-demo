using GraphQL;
using GraphQL.Types;
using GraphqlDemo.Ef.Entities;
using GraphqlDemo.GraphQL.InputTypes;
using GraphqlDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.GraphQL.Types.Mutation
{
    public partial class RootMutation : ObjectGraphType
    {
        //private readonly AuthorService _authorService;

        public RootMutation(AuthorService authorService)
        {
            //Name = "RootMutation";
            //Description = "RootMutation";

            //_authorService = authorService;


            Field<AuthorType>(
               name: "CreateAuthor",
              //arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" }),
              //arguments: new QueryArguments(new QueryArgument<AuthorInputType> { Name = "author" }),
              arguments: new QueryArguments(new QueryArgument<AuthorInputType> { Name = "author" }),
              //resolve: context => CreateAuthorAsync(context.GetArgument<AuthorInput>("author"))
              resolve: context =>
              {
                  var author = context.GetArgument<Author>("author");
                  author.Id = Guid.NewGuid().ToString();
                  return authorService.CreateAuthorAsync(author);
              });

            //SetAuthorMutation();
        }

    }
}
