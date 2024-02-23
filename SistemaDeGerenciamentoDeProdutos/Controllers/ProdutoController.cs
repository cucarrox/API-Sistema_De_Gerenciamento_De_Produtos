using Microsoft.AspNetCore.Mvc;
using SistemaDeGerenciamentoDeProdutos.DTOs;
using SistemaDeGerenciamentoDeProdutos.Models;

namespace SistemaDeGerenciamentoDeProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ProdutoDTO> GetProduto()
        {
            // Coletar dados do banco de dados
            var produtos = _context.produtos.ToList().OrderBy(a => a.Id).Select(a => new ProdutoDTO(a));

            return produtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> GetProdutoById(int id)
        {
            var produto = await _context.produtos.FindAsync(id);

            if (produto == null) return NotFound(new { Message = "Produto não existe" });

            return new ProdutoDTO(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> CreateProduto(Produto produto)
        {
            var adicionarProduto = await _context.produtos.AddAsync(produto);

            await _context.SaveChangesAsync();

            return Created(nameof(CreateProduto), new { id = adicionarProduto.Entity.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.produtos.FindAsync(id);

            if (produto == null) return NotFound(new { Message = "Produto não existe" });

            _context.produtos.Remove(produto);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoDTO>> UpdateProduto(int id, Produto produto)
        {
            var buscarProduto = await _context.produtos.FindAsync(id);

            if (buscarProduto == null) return NotFound(new { Message = "Produto não existe" });

            buscarProduto.Nome = produto.Nome;
            buscarProduto.Descricao = produto.Descricao;
            buscarProduto.Preco = produto.Preco;
            buscarProduto.Estoque = produto.Estoque;

            await _context.SaveChangesAsync();

            return Ok(new ProdutoDTO(buscarProduto));
        }
    }
}
