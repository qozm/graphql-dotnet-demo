using GraphQL;
using GraphQL.Types;
using GraphqlDemo.Models;
using GraphqlDemo.Services;
using System.Collections.Generic;

namespace GraphqlDemo.GraphQL.Types
{
    public class AuthorQuery : ObjectGraphType
    {

        //public AuthorQuery(AuthorService authorService)
        public AuthorQuery()
        {
            //int id = 0;

            Field<ListGraphType<AuthorType>>(
                name: "authors",
                resolve: context => { return new List<Author>(); }
            );


            //Field<ListGraphType<AuthorType>>(
            //    name: "authors",
            //    resolve: context => { return authorService.GetAllAuthors(); }
            //);

            //Field<AuthorType>(
            //    name: "author",
            //    arguments: new QueryArguments(
            //        new QueryArgument<IntGraphType>
            //        {
            //            Name = "id"
            //        }),
            //    resolve: context =>
            //    {
            //        id = context.GetArgument<int>("id");
            //        return authorService.GetAuthorById(id);
            //    }
            //);

            //Field<ListGraphType<BlogPostType>>(
            //    name: "blogs",
            //    arguments: new QueryArguments(
            //        new QueryArgument<IntGraphType>
            //        {
            //            Name = "id"
            //        }),
            //    resolve: context => { return authorService.GetPostsByAuthor(id); }
            //);
        }
    }



    //    public AuthorQuery(AuthorService authorService)
    //    {
    //        int id = 0;

    //        Field<ListGraphType<AuthorType>>(
    //            name: "authors",
    //            resolve: context => { return authorService.GetAllAuthors(); }
    //        );

    //        Field<AuthorType>(
    //            name: "author",
    //            arguments: new QueryArguments(
    //                new QueryArgument<IntGraphType>
    //                {
    //                    Name = "id"
    //                }),
    //            resolve: context =>
    //            {
    //                id = context.GetArgument<int>("id");
    //                return authorService.GetAuthorById(id);
    //            }
    //        );

    //        Field<ListGraphType<BlogPostType>>(
    //            name: "blogs",
    //            arguments: new QueryArguments(
    //                new QueryArgument<IntGraphType>
    //                {
    //                    Name = "id"
    //                }),
    //            resolve: context => { return authorService.GetPostsByAuthor(id); }
    //        );
    //    }
    //}
}