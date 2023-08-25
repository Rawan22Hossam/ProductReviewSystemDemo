using Microsoft.EntityFrameworkCore;
using ProductReviewSystemDemo.Context;
using Serilog;
using ProductReviewSystemDemo.GenericRepository;
using ProductReviewSystemDemo.Services.Interfaces;
using ProductReviewSystemDemo.Services;
using ProductReviewSystemDemo.EntityConfiguration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentAssertions.Common;
using ProductReviewSystemDemo.GlobalExceptionHandler;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace ProductReviewSystemDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProductReviewDemo")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MapperConfiguration));

            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
         

            var key = Encoding.ASCII.GetBytes
                                    (builder.Configuration.GetSection("Token:secretKey").Value);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(optyion =>
                {
                    optyion.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("Admin"));          //For Admin
                options.AddPolicy("RequireClientRole",
                     policy => policy.RequireRole("Client"));         //For Client 
                options.AddPolicy("ForAuthorizedUsers",
                     policy => policy.RequireRole("Admin", "Client"));  // For Both

            });
            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/MyLoggs.txt", rollingInterval : RollingInterval.Month)
                .CreateLogger();
            var app = builder.Build();

            
           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<GlobalExceptions>();
            

            app.UseStatusCodePages();

            app.MapControllers();

            app.Run();
        }
    }
     
    }