using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeGerenciamentoDeProdutos.Models
{
    [Table("produtos")]
    public class Produto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public double Preco { get; set; }

        [Required]
        public int Estoque { get; set; }
    }
}
