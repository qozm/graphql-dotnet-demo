using GraphQL.Types;
using GraphqlDemo.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.GraphQL.InputTypes
{
    //public record AuthorInput(
    //    string Id,
    //    string FirstName,
    //    string LastName
    //    );

    //public class AuthorInputType : InputObjectGraphType<AuthorInput>
    //public class AuthorInputType : InputObjectGraphType<Author>
    public class AuthorInputType : InputObjectGraphType<Author>
    {
        public AuthorInputType()
        {
            //Name = nameof(Author);
            //Name = "AuthorInput";
            //Field<NonNullGraphType<IntGraphType>>("id");
            //Field<NonNullGraphType<StringGraphType>>("firstName");
            //Field<NonNullGraphType<StringGraphType>>("lastName");

            Name = nameof(AuthorInputType);
            Field(_ => _.Id);
            Field(_ => _.Name);
        }
    }
}
