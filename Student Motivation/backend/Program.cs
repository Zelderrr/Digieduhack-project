using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyGameBackend.Services;

namespace MyGameBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register services for dependency injection
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure middleware and endpoints
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}