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
            })
            .Produces(statusCode: 200, contentType: "application/json")
            .Produces(statusCode: 500)
            .WithTags("Books")
            .WithName("GetAllBooks")
            .WithSummary("Method to get all book");

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
            })                
            .Produces(statusCode: 200, contentType: "application/json")
            .Produces(statusCode: 404)
            .Produces(statusCode: 500)   
            .WithTags("Books")
            .WithName("GetOneBook")
            .WithSummary("Method to get one book");

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
            })
            .Produces(statusCode: 201, contentType: "application/json")
            .Produces(statusCode: 400)
            .Produces(statusCode: 500)
            .WithTags("Books")
            .WithName("AddNewBook")
            .WithSummary("Method to add new book.");

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
            })
                .Produces(statusCode: 200, contentType: "application/json")
                .Produces(statusCode: 404)
                .Produces(statusCode: 500)
                .WithTags("Books")
                .WithName("UpdateBook")
            .WithSummary("Method to update book.");

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
            })
             .Produces(statusCode: 204)
             .Produces(statusCode: 404)
             .Produces(statusCode: 500)
             .WithTags("Books")
             .WithName("DeleteBook")
            .WithSummary("Method to remove one book")
            ;
        }
    }
}