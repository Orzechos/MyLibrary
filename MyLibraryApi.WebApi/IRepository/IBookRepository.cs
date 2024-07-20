using MyLibraryApi.WebApi.Data.Models;

namespace MyLibraryApi.WebApi.IRepository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book? GetBook(Guid id);
        Book AddBook(Book book);
        Book? UpdateBook(Book book);
        bool DeleteBook(Guid id);
    }
}
