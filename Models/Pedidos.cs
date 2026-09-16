using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models
{
    public class Pedidos
    {
        public int Id { get; set; }

        public DateTime data_pedido { get; set; }

        public int quantidade { get; set; }

        [Column("frutas_id")]
        public int Frutas_id { get; set; }

        [Column("clientes_id")]
        public int Clientes_id { get; set; }

        [ForeignKey(nameof(Clientes_id))]
        public Clientes Clientes { get; set; }

        [ForeignKey(nameof(Frutas_id))]
        public Frutas Frutas { get; set; }
    }
}