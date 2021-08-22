using System.Collections.Generic;
using System.Threading.Tasks;
using GraphqlDemo.Ef.Entities;
using GraphqlDemo.Repositories;

namespace GraphqlDemo.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAuthors();
        }

        //public async Task<Author> GetAuthorById(int id)
        public async Task<Author> GetAuthorByIdAsync(string id)
        {
            return await _authorRepository.GetAuthorByIdAsync(id);
        }

        public async Task<List<Post>> GetPostsByAuthorAsync(string id)
        {
            return await _authorRepository.GetPostsByAuthor(id);
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            await _authorRepository.CreateAuthorAsync(author);
            return author;
        }
    }
}