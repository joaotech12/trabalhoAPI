using Microsoft.AspNetCore.Mvc;
using teste.Data;
using teste.Models;
using Microsoft.EntityFrameworkCore;

namespace teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensVendaController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ItensVendaController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensVenda>>> Get()
        {
            var itens_venda = await _context.itens_venda.ToListAsync();

            return Ok(itens_venda);
        }
    

      [HttpPost]
        public async Task<ActionResult<ItensVenda>> PostItensVenda(ItensVenda itensVendas)
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

