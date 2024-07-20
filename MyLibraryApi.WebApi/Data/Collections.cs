using MyLibraryApi.WebApi.Data.Models;

namespace MyLibraryApi.WebApi.Data
{
    public static class Collections
    {
        public static List<Author> Authors = new List<Author>()
        {
            new Author() { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe" },
            new Author() { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe" },
            new Author() { Id = Guid.NewGuid(), FirstName = "John", LastName = "Smith" },
            new Author() { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith" }
        };

        public static List<Book> Books = new List<Book>()
        {
            new Book() { Id = Guid.NewGuid(), Name = "Book 1", Autor = Authors[0], IsAvailable = true },
            new Book() { Id = Guid.NewGuid(), Name = "Book 2", Autor = Authors[1], IsAvailable = true },
            new Book() { Id = Guid.NewGuid(), Name = "Book 3", Autor = Authors[2], IsAvailable = true },
            new Book() { Id = Guid.NewGuid(), Name = "Book 4", Autor = Authors[3], IsAvailable = true },
            new Book() { Id = Guid.NewGuid(), Name = "Book 5", Autor = Authors[0], IsAvailable = true },
            new Book() { Id = Guid.NewGuid(), Name = "Book 6", Autor = Authors[1], IsAvailable = true },
            new Book() { Id = Guid.NewGuid(), Name = "Book 7", Autor = Authors[2], IsAvailable = true },
            new Book() { Id = Guid.NewGuid(), Name = "Book 8", Autor = Authors[3], IsAvailable = true },
            new Book() { Id = Guid.NewGuid(), Name = "Book 9", Autor = Authors[0], IsAvailable = true }
        };    
    }
}

