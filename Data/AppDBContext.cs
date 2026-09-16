using teste.Models;
using Microsoft.EntityFrameworkCore;


namespace teste.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) 
            : base(options) 
        { 
        
        }
        public DbSet<Clientes> clientes  { get; set; }
          
        public DbSet<Pedidos> pedidos { get; set; }

        public DbSet<Frutas> frutas { get; set; }

        public DbSet<CadastroCategorias> cadastroCategorias  { get; set; }

        public DbSet<ItensVenda> itens_venda { get; set; }




    }
}
