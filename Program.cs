using Microsoft.EntityFrameworkCore;
using ProductReviewSystemDemo.Context;
using Serilog;
using ProductReviewSystemDemo.GenericRepository;
using ProductReviewSystemDemo.Services.Interfaces;
using ProductReviewSystemDemo.Services;
using ProductReviewSystemDemo.EntityConfiguration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;

namespace ProductReviewSystemDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProductReviewDemo")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MapperConfiguration));

            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
            var app = builder.Build();
        
       
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();
            //app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseStatusCodePages();

            app.MapControllers();

            app.Run();
        }
    }
     
    }