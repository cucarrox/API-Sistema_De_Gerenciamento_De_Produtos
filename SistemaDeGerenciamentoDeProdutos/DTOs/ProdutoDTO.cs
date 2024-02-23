using SistemaDeGerenciamentoDeProdutos.Models;

namespace SistemaDeGerenciamentoDeProdutos.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }

        public ProdutoDTO(Produto produto)
        {
            this.Id = produto.Id;
            this.Nome = produto.Nome;
            this.Descricao = produto.Descricao;
            this.Preco = produto.Preco;
            this.Estoque = produto.Estoque;
        }
    }
}
