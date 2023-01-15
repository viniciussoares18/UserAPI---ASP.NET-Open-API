using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Data
{
    /// <summary>
    /// Essa classe representa uma instância de sessão de Banco de Dados Relacional
    /// </summary>
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options): base(options) {
        }

        //Mapeia a Entidade de Banco de Dados Relacional de acordo com sua classe de modelo.
        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}
