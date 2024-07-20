using MyLibraryApi.WebApi.Data;
using MyLibraryApi.WebApi.Data.Models;
using MyLibraryApi.WebApi.IRepository;

namespace MyLibraryApi.WebApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private Serilog.ILogger _log;


        public BookRepository(Serilog.ILogger logger)
        {
            _log = logger;
        }


        public Book AddBook(Book book)
        {
            if (Collections.Books.Exists(b => b.Name.ToLower() == book.Name.ToLower() && !b.IsDeleted))
            {
                return null;
            }
            else
            {
                if(Collections.Authors.Exists(a => a.Id == book.Autor.Id))
                {
                    book.Autor = Collections.Authors.Find(a => a.FirstName == book.Autor.FirstName && a.LastName == book.Autor.LastName);
                }
                else
                {
                    book.Autor.Id = Guid.NewGuid();
                    Collections.Authors.Add(book.Autor);
                }


                book.Id = Guid.NewGuid();
                Collections.Books.Add(book);
                return book;
            }
        }

        public bool DeleteBook(Guid id)
        {
            Book? book = Collections.Books.FirstOrDefault(b => b.Id == id && !b.IsDeleted);

            if (book != null)
            {
                Collections.Books.Remove(book);
                return true;
            }
            else {                
                return false;
            }
        }

        public Book GetBook(Guid id)
        {
            return Collections.Books.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
        }

        public IEnumerable<Book> GetBooks()
        {
            return  Collections.Books.Where(x=> !x.IsDeleted);
        }

        public Book UpdateBook(Book book)
        {
            Book? bookDb = Collections.Books.FirstOrDefault(b => b.Id == book.Id && !b.IsDeleted);

            bookDb = book;
            bookDb.IsAvailable = true;

            return bookDb;
        }
    }
}
