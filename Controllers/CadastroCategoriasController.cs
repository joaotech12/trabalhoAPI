using Microsoft.AspNetCore.Mvc;
using teste.Data;
using teste.Models;
using Microsoft.EntityFrameworkCore;



namespace teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class cadastroCategoriasController : ControllerBase
    {
        private readonly AppDBContext _context;

        public cadastroCategoriasController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastroCategorias>>> Get()
        {
            var cadastroCategorias = await _context.cadastroCategorias.ToListAsync();

            return Ok(cadastroCategorias);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var cadastroCategorias = await _context.cadastroCategorias.FindAsync(id);

            if (cadastroCategorias == null)
            {
                return NotFound(new
                {
                    mensagem = "Categoria não encontrado."
                });
            }

            _context.cadastroCategorias.Remove(cadastroCategorias);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensagem = "Categoria excluído com sucesso."
            });
        }
        [HttpPost]
        public async Task<ActionResult<CadastroCategorias>> PostcadastroCategorias(ItensVenda itensVendas)
        {
            _context.itens_venda.Add(itensVendas);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { Id = itensVendas.Id },
               itensVendas
            );
        }
    }
}
