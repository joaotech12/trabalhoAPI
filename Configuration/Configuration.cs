using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using teste.Models;

namespace teste.configuration
{   
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedidos>
    {
        public void Configure(EntityTypeBuilder<Pedidos> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .HasOne(p => p.Clientes)
                .WithMany()
                .HasForeignKey(p => p.Id);

            builder
                .HasOne(p => p.Frutas)
                .WithMany()
                .HasForeignKey(p => p.Id);
        }
    }
    
}

