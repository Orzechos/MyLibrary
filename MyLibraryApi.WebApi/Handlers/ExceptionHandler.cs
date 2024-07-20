using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace MyLibraryApi.WebApi.Handlers
{
    public static class ExceptionHandler
    {
        public static void RegisterExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(errorApp =>
            {                
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var cf = context.Features.Get<IExceptionHandlerFeature>();
                    
                    if(cf is not null)
                    {                        
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error"
                        });
                    }
                });
            });
        }
    }
}
