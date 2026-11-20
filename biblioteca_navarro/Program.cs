using Microsoft.EntityFrameworkCore;

namespace biblioteca_navarro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Banco SQLite (arquivo biblioteca_navarro.db), configurado no appsettings.json
            builder.Services.AddDbContext<biblioteca_navarro.Data.AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("BibliotecaNavarro")
                    ?? throw new InvalidOperationException("Connection string 'BibliotecaNavarro' não encontrada.")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            //configuração do swagger
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

       
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
