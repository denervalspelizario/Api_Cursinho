using Api_Cursinho.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Cursinho.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        // Essa propriedade Administradores que meio que faz o mapeamento
        public DbSet<Administradores> administradores { get; set; }


        /*Aqui será o método onde eu sobreescrever OnConfiguring e adicionar os dados 
        do banco que eu criei antes de iniciar o projeto no caso o banco cursinho
        conferir os dados pelo beekeeper */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=cursinho;" +
                "User Id=postgres;" +
                "Password=vaval0645;");

    }
}
