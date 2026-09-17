using Microsoft.AspNetCore.Mvc;
using teste.Data;
using teste.Models;
using Microsoft.EntityFrameworkCore;

namespace teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class clientesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public clientesController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> Get()
        {
            var clientes = await _context.clientes.ToListAsync();

            return Ok(clientes);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclientes(int id)
        {
            var clientes = await _context.clientes.FindAsync(id);

            if (clientes == null)
            {
                return NotFound(new
                {
                    mensagem = "Cliente não encontrado."
                });
            }

            _context.clientes.Remove(clientes);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensagem = "Cliente excluído com sucesso."
            });
        }
        
        [HttpPost]
        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {
            _context.clientes.Add(clientes);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { Id = clientes.Id },
               clientes
            );
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return BadRequest(new
                {
                    mensagem = "O ID da URL é diferente do ID do produto."
                });
            }

            var produtoExistente = await _context.clientes.FindAsync(id);

            if (produtoExistente == null)
            {
                return NotFound(new
                {
                    mensagem = "Cliente não encontrado."
                });
            }

            produtoExistente.nome = clientes.nome;
            produtoExistente.cpf = clientes.cpf;
            produtoExistente.telefone = clientes.telefone;
            

            await _context.SaveChangesAsync();

            return Ok(produtoExistente);
        }






    }

}



