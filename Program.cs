using Microsoft.EntityFrameworkCore;
using PhoenixLifeApi.Databases;

namespace PhoenixLifeApi
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<PhoenixContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("PhoenixContext")));
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            if(app.Environment.IsDevelopment())
            {
                app.Run("https://0.0.0.0:10801");
            }
            else
            {
                app.Run("https://0.0.0.0:10801");
            }
        }
    }
}
