using Microsoft.AspNetCore.Mvc;
using teste.Data;
using teste.Models;
using Microsoft.EntityFrameworkCore;



namespace teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class pedidosController : ControllerBase
    {
        private readonly AppDBContext _context;

        public pedidosController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedidos>>> Get()
        {
            var pedidos = await _context.pedidos.ToListAsync();

            return Ok(pedidos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepedidos(int id)
        {
            var pedidos = await _context.pedidos.FindAsync(id);

            if (pedidos == null)
            {
                return NotFound(new
                {
                    mensagem = "Pedido não encontrado."
                });
            }

            _context.pedidos.Remove(pedidos);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensagem = "Pedido excluído com sucesso."
            });
        }

        [HttpPost]
        public async Task<ActionResult<Pedidos>> PostProduto(Pedidos pedido)
        {
            _context.pedidos.Add(pedido);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = pedido.Id },
                pedido
            );
        }
    }
}
