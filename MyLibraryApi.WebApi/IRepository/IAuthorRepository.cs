using MyLibraryApi.WebApi.Data.Models;

namespace MyLibraryApi.WebApi.IRepository
{
    public interface IAuthorRepository
    {
        public IEnumerable<Author> GetAuthors();
        public Author GetAuthor(Guid id);
        public Author GetAuthor(string firstName, string lastName);
        public Author AddAuthor(Author author);
        public Author UpdateAuthor(Author author);
        public bool DeleteAuthor(Guid id);
    }
}
