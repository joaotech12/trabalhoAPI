using Microsoft.AspNetCore.Mvc;
using teste.Data;
using teste.Models;
using Microsoft.EntityFrameworkCore;

namespace teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrutasController : ControllerBase
    {
        private readonly AppDBContext _context;

        public FrutasController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Frutas>>> Get()
        {
            var frutas = await _context.frutas.ToListAsync();
            return Ok(frutas);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFruta(int id)
        {
            var fruta = await _context.frutas.FindAsync(id);

            if (fruta == null)
                return NotFound(new { mensagem = "Fruta não encontrada." });

            _context.frutas.Remove(fruta);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Fruta excluída com sucesso." });
        }
        [HttpPost]
        public async Task<ActionResult<Frutas>> PostFrutas(Frutas frutas)
        {
            _context.frutas.Add(frutas);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { Id = frutas.Id },
               frutas
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrutas(int id, Frutas frutas)
        {
            if (id != frutas.Id)
            {
                return BadRequest(new
                {
                    mensagem = "O ID da URL é diferente do ID do produto."
                });
            }

            var produtoExistente = await _context.frutas.FindAsync(id);

            if (produtoExistente == null)
            {
                return NotFound(new
                {
                    mensagem = "Produto não encontrado."
                });
            }

            produtoExistente.Nome = frutas.Nome;
            produtoExistente.categoria_id = frutas.categoria_id;
            produtoExistente.preco = frutas.preco;
            produtoExistente.estoque = frutas.estoque;
            produtoExistente.validade = frutas.validade;

            await _context.SaveChangesAsync();

            return Ok(produtoExistente);
        }
    }
}
