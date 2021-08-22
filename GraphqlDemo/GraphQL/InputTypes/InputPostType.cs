using GraphQL.Types;
using GraphqlDemo.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlDemo.GraphQL.InputTypes
{
    public class InputPostType : InputObjectGraphType<Post>
    {
        public InputPostType()
        {
            Name = nameof(InputPostType);
            Field(_ => _.Title);
            Field(_ => _.Content);
            //Field(_ => _.Author);
        }
    }
}
