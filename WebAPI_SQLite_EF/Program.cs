using Microsoft.Extensions.Logging;
using Scalar.AspNetCore;
using Serilog; 
  
namespace WebAPI_SQLite_EF.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Data.MovieDataContext>();  //(options => options.UseSqlite(builder.Configuration.GetConnectionString("DbMovieData")));
            builder.Services.AddScoped<Services.IMovieService, Services.MovieService>();
            builder.Services.AddScoped<Services.IGenreService, Services.GenreService>();

           Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()  
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
