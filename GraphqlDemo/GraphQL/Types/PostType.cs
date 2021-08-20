using GraphQL.Types;
using GraphqlDemo.Ef.Entities;

namespace GraphqlDemo.GraphQL.Types
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Name = "Post";
            Field(_ => _.Id, type: typeof(IdGraphType)).Description("The Id of the post.");
            Field(_ => _.Title).Description("The title of the post.");
            Field(_ => _.Content).Description("The content of the post.");
        }
    }
}