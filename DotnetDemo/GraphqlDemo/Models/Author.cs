using System.Collections.Generic;

namespace GraphqlDemo.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
    }
}