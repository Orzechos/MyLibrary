using MyLibraryApi.WebApi.Data.Models;
using MyLibraryApi.WebApi.IRepository;

namespace MyLibraryApi.WebApi.Endpoints
{
    public static class Authors
    {
        public static void RegisterAuthorsEndpoints(this IEndpointRouteBuilder routes)
        {
            string path = "/api/v1/Authors";

            var authors = routes.MapGroup(path);

            authors.MapGet("", async (IAuthorRepository authorRepository) =>
            {
                return Results.Ok(authorRepository.GetAuthors());
            })
                .Produces(statusCode: 200, contentType: "application/json")
                .Produces(statusCode: 500)
                .WithTags("Authors")
                .WithName("GetAllAuthors")
                .WithSummary("Get list of all authors");

            authors.MapGet("/{id:guid}", async (IAuthorRepository authorRepository, Guid id) =>
            {
                var author = authorRepository.GetAuthor(id);

                if (author == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(author);
                }
            })
                .Produces(statusCode: 200, contentType: "application/json")
                .Produces(statusCode: 404)
                .Produces(statusCode: 500)
                .WithTags("Authors")
                .WithName("GetOneAuthorById")
                .WithSummary("Get one author by id");

            authors.MapGet("/{firstName}/{lastName}", async (IAuthorRepository authorRepository, string firstName, string lastName) =>
            {
                var author = authorRepository.GetAuthor(firstName, lastName);

                if (author == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(author);
                }
            })
                .Produces(statusCode: 200, contentType: "application/json")
                .Produces(statusCode: 404)
                .Produces(statusCode: 500)
                .WithTags("Authors")
                .WithName("GetOneAuthorByName")
                .WithSummary("Get one author by name");

            authors.MapPost("", async (IAuthorRepository authorRepository, Author author) =>
            {
                var auth = authorRepository.AddAuthor(author);

                if(auth == null)
                {
                    return Results.BadRequest("Author already exists");
                }
                else
                {
                    return Results.Created($"{path}/{auth.Id}", auth);
                }
            })
                .Produces(statusCode: 201, contentType: "application/json")
                .Produces(statusCode: 400)
                .Produces(statusCode: 500)
                .WithTags("Authors")
                .WithName("AddNewAuthor")
                .WithSummary("Add new author");

            authors.MapPut("", async (IAuthorRepository authorRepository, Author author) =>
            {
                var auth = authorRepository.UpdateAuthor(author);

                if (auth == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(auth);
                }
            })
                .Produces(statusCode: 200, contentType: "application/json")
                .Produces(statusCode: 404)
                .Produces(statusCode: 500)
                .WithTags("Authors")
                .WithName("UpdateAuthor")
                .WithSummary("Update author");            

            authors.MapDelete("/{id:guid}", async (IAuthorRepository authorRepository, Guid id) =>
            {
                if (authorRepository.DeleteAuthor(id))
                {
                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound();
                }
            }).Produces(statusCode: 204)
                .Produces(statusCode: 404)
                .Produces(statusCode: 500)
                .WithTags("Authors")
                .WithName("DeleteAuthor")
                .WithSummary("Delete author");               
        }
    }
}
