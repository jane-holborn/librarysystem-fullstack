
using LibrarySystem.Api;
using LibrarySystem.Api.Data;
using LibrarySystem.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string dbPath = Path.Combine(AppContext.BaseDirectory, "librarysystem.db");

            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseSqlite($"Data Source={dbPath}"));

            builder.Services.AddScoped<LibraryService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
