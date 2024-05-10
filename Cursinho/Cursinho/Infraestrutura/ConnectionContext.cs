using Cursinho.Model.Autor;
using Microsoft.EntityFrameworkCore;

namespace Cursinho.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=curso;" +
                "User Id=postgres;" +
                "Password=vaval0645;");

    }
}
