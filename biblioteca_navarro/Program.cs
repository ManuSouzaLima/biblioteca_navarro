using biblioteca_navarro.Data;
using biblioteca_navarro.Services;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_navarro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Banco SQLite (arquivo biblioteca_navarro.db), configurado no appsettings.json
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("BibliotecaNavarro")
                    ?? throw new InvalidOperationException("Connection string 'BibliotecaNavarro' não encontrada.")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            //configuração do swagger
            builder.Services.AddSwaggerGen();

            // Repositórios: quando alguém pedir a interface, entregue a implementação com EF.
            // Scoped: um por requisição, como o AppDbContext que eles usam.
            builder.Services.AddScoped<ILivroRepository, LivroRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Services: quando alguém pedir a interface, entregue o serviço.
            builder.Services.AddScoped<ILivroService, LivroService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

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