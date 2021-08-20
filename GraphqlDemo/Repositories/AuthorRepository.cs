using System.Collections.Generic;
using System.Linq;
using GraphqlDemo.Models;

namespace GraphqlDemo.Repositories
{
    public class AuthorRepository
    {
        private readonly List<Author> authors = new List<Author>();

        private readonly List<Post> posts = new List<Post>();

        public AuthorRepository()
        {
            Author author1 = new Author
            {
                Id = 1,
                FirstName = "Joydip",
                LastName = "Kanjilal"
            };
            Author author2 = new Author
            {
                Id = 2,
                FirstName = "Steve",
                LastName = "Smith"
            };
            Post csharp = new Post
            {
                Id = 1,
                Title = "Mastering C#",
                Content = "This is a series of articles on C#.",
                Author = author1
            };
            Post java = new Post
            {
                Id = 2,
                Title = "Mastering Java",
                Content = "This is a series of articles on Java",
                Author = author1
            };
            posts.Add(csharp);
            posts.Add(java);
            authors.Add(author1);
            authors.Add(author2);
        }

        public List<Author> GetAllAuthors()
        {
            return this.authors;
        }

        public Author GetAuthorById(int id)
        {
            return authors.Where(author => author.Id == id).FirstOrDefault<Author>();
        }

        public List<Post> GetPostsByAuthor(int id)
        {
            return posts.Where(post => post.Author.Id == id).ToList<Post>();
        }
    }
}