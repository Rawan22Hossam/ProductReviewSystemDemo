﻿using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ProductReviewSystemDemo.GlobalExceptionHandler
{
    public class GlobalExceptions
    {
        private readonly ILogger _logger;
        private readonly IHostEnvironment _env;
        public GlobalExceptions(ILogger<GlobalExceptions> logger,IHostEnvironment env) 
        {
            _logger = logger;
            _env = env;
        }
        public async Task Invoke(HttpContext context,RequestDelegate next)
        {
            try 
            {
                await next(context);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex,ex.Message);
                await Handle(context,ex);
            }

        }
        public async Task Handle(HttpContext context, Exception ex)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _env.IsDevelopment()
                ? new CustomResponse(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                : new CustomResponse(context.Response.StatusCode, "Internal server error");

            var options = new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }
    }

    internal class CustomResponse
    {
        private int statusCode;
        private string v;
        private string? v1;

        public CustomResponse(int statusCode, string v)
        {
            this.statusCode = statusCode;
            this.v = v;
        }

        public CustomResponse(int statusCode, string v, string? v1) : this(statusCode, v)
        {
            this.v1 = v1;
        }
    }
}
