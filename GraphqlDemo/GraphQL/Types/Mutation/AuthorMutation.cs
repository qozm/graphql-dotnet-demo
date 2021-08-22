using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphqlDemo.Ef.Entities;
using GraphqlDemo.GraphQL.InputTypes;

namespace GraphqlDemo.GraphQL.Types.Mutation
{
    public partial class RootMutation
    {
        //public void SetAuthorMutation()
        //{
        //    Field<AuthorType>(
        //        name: "CreateAuthor",
        //        //arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" }),
        //        arguments: new QueryArguments(new QueryArgument<AuthorInputType> { Name = "author" }),
        //        //resolve: context => CreateAuthorAsync(context.GetArgument<AuthorInput>("author"))
        //        resolve: context => CreateAuthorAsync(context.GetArgument<Author>("author"))
        //       );
        //}

        //public async Task<Author> CreateAuthorAsync(AuthorInput authorInput)
        //public async Task<Author> CreateAuthorAsync(Author author)
        //{
        //    author.Id += 1;
        //    return await _authorService.CreateAuthorAsync(author);
        //}
    }
}
