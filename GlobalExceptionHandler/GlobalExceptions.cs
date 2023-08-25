using Azure;
using Microsoft.AspNetCore.Hosting.Server;
using ProductReviewSystemDemo.DTO;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ProductReviewSystemDemo.GlobalExceptionHandler
{
    public class GlobalExceptions
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHostEnvironment _env;
        public GlobalExceptions(RequestDelegate next, ILogger<GlobalExceptions> logger, IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                 await Handle(context,ex);
            }


        }
          public async Task Handle(HttpContext context, Exception ex)
            {
           //  context.Response.ContentType = MediaTypeNames.Application.Json;
             context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            // var BadRequest = (context.Response.StatusCode = (int)HttpStatusCode.BadRequest);

           // var response = new GlobalExceptionDTO(context.Response.StatusCode, "Internal server error");

        
              // var options = new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
              // var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(ex.Message);
            }
        /*
         *   var response = _env.IsDevelopment()
                    ? new GlobalExceptionDTO(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new GlobalExceptionDTO(context.Response.StatusCode, "Internal server error");
         */
    }
}
