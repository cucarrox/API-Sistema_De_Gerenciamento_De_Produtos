using GerenciadorAlunos.Serialization;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeGerenciamentoDeProdutos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(
                options => options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter())
              );

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("DC"))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
