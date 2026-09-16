using System.ComponentModel.DataAnnotations;

namespace teste.Models
{
    public class CadastroCategorias
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
