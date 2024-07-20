using MyLibraryApi.WebApi.Endpoints;
using MyLibraryApi.WebApi.Extensions;
using MyLibraryApi.WebApi.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();
builder.AddScopedServices();
builder.RegisterLogger();

var app = builder.Build();

app.RegisterBookEndpoints();


app.RegisterMiddlewares();
app.RegisterExceptionHandler();
app.Run();
