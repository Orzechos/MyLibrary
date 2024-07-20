using MyLibraryApi.WebApi.Data.Models;
using MyLibraryApi.WebApi.IRepository;

namespace MyLibraryApi.WebApi.Endpoints
{
    public static class Books
    {
        public static void RegisterBookEndpoints(this IEndpointRouteBuilder routes)
        {
            string path = "/api/v1/books";

            var books = routes.MapGroup(path);
            books.MapGet("", async (IBookRepository bookRepository) =>
            {
                return Results.Ok(bookRepository.GetBooks());
            }).WithDisplayName("GetBooks")
            .WithName("GetBooks")
            .WithDescription("Method to get all books.");

            books.MapGet("/{id:guid}", async (IBookRepository bookRepository, Guid id) =>
            {
                var book = bookRepository.GetBook(id);

                if (book == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(book);
                }
            }).WithDisplayName("GetBookById").
            WithName("GetBookById")            
            .WithDescription("Method to get one book");

            books.MapPost("", async (IBookRepository bookRepository, Book book) =>
            {
                var bk = bookRepository.AddBook(book);

                if (bk == null)
                {
                    return Results.BadRequest("Book already exists");
                }
                else
                {
                    return Results.Created($"{path}/{bk.Id}", bk);
                }
            }).WithDisplayName("AddBook")
            .WithName("AddBook")
            .WithDescription("Method to add new book.");

            books.MapPut("", async (IBookRepository bookRepository, Book book) =>
            {
                var bk = bookRepository.UpdateBook(book);

                if (bk == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(bk);
                }
            }).WithDisplayName("UpdateBook")
            .WithName("UpdateBook")
            .WithDescription("Method to update book.");

            books.MapDelete("/{id:guid}", async (IBookRepository bookRepository, Guid id) =>
            {
                var bk = bookRepository.DeleteBook(id);

                if (bk)
                {
                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound();
                }
            }).WithDisplayName("DeleteBook")
            .WithName("DeleteBook")
            .WithDescription("Method to remove one book");
        }
    }
}