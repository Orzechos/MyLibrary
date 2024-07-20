using MyLibraryApi.WebApi.Data;
using MyLibraryApi.WebApi.Data.Models;
using MyLibraryApi.WebApi.IRepository;

namespace MyLibraryApi.WebApi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private Serilog.ILogger _log;

        public AuthorRepository(Serilog.ILogger logger)
        {
            _log = logger;
        }

        public Author AddAuthor(Author author)
        {
            if(Collections.Authors.Exists(a => a.FirstName.ToLower() == author.FirstName.ToLower() && a.LastName.ToLower() == author.LastName.ToLower()))
            {
                return null;
            }
            else
            {
                author.Id = Guid.NewGuid();
                Collections.Authors.Add(author);

                return author;
            }            
        }

        public bool DeleteAuthor(Guid id)
        {
            Author? author = Collections.Authors.FirstOrDefault(a => a.Id == id);

            if(author != null)
            {
                if(Collections.Books.Exists(b => b.Autor.Id == author.Id))
                {
                    return false;
                }

                Collections.Authors.Remove(author);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Author GetAuthor(Guid id)
        {
            return Collections.Authors.FirstOrDefault(a => a.Id == id);
        }

        public Author GetAuthor(string firstName, string lastName)
        {
            return Collections.Authors.FirstOrDefault(a => a.FirstName.ToLower() == firstName.ToLower() && a.LastName.ToLower() == lastName.ToLower());
        }

        public IEnumerable<Author> GetAuthors()
        {
            return Collections.Authors;
        }

        public Author UpdateAuthor(Author author)
        {
            Author? authordb = Collections.Authors.FirstOrDefault(a => a.Id == author.Id);

            if(authordb != null)
            {
                authordb.FirstName = author.FirstName;
                authordb.LastName = author.LastName;

                return authordb;
            }
            else
            {
                return null;
            }
        }
    }
}
