using System.Collections.Generic;
using System.Threading.Tasks;
using GraphqlDemo.Ef.Entities;
using GraphqlDemo.Repositories;

namespace GraphqlDemo.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService(AuthorRepository
            authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await _authorRepository.GetAllAuthors();
        }

        //public async Task<Author> GetAuthorById(int id)
        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetAuthorById(id);
        }

        public async Task<List<Post>> GetPostsByAuthor(int id)
        {
            return await _authorRepository.GetPostsByAuthor(id);
        }
    }
}