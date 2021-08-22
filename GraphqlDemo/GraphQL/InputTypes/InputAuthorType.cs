using GraphQL.Types;
using GraphqlDemo.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.GraphQL.InputTypes
{
    public class InputAuthorType : InputObjectGraphType<Author>
    {
        public InputAuthorType()
        {
            Name = nameof(InputAuthorType);
            Field(_ => _.Id);
            Field(_ => _.Name);
        }
    }
}
