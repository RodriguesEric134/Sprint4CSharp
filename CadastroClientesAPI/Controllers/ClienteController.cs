using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroClientesAPI.Data;
using CadastroClientesAPI.Models;
using CadastroClientesAPI.Services;

namespace CadastroClientesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ViaCepService _viaCepService;

        public ClienteController(ApplicationDbContext context, ViaCepService viaCepService)
        {
            _context = context;
            _viaCepService = viaCepService;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes
                .Include(c => c.Endereco)
                .ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                return NotFound();

            return cliente;
        }

        // POST: api/Cliente
        // Agora o cadastro busca o endereço automaticamente via ViaCEP
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            // Busca endereço pelo CEP informado
            var enderecoViaCep = await _viaCepService.BuscarEnderecoPorCep(cliente.Cep);

            if (enderecoViaCep == null)
                return BadRequest("CEP inválido ou não encontrado na base ViaCEP.");

            // Cria o objeto Endereco com base no retorno da API
            var endereco = new Endereco
            {
                Cep = enderecoViaCep.Cep,
                Logradouro = enderecoViaCep.Logradouro,
                Bairro = enderecoViaCep.Bairro,
                Localidade = enderecoViaCep.Localidade,
                Uf = enderecoViaCep.Uf
            };

            // Salva o endereço e vincula ao cliente
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            cliente.EnderecoId = endereco.Id;

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // LINQ: clientes por estado
        [HttpGet("por-estado/{uf}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesPorEstado(string uf)
        {
            var clientes = await _context.Clientes
                .Include(c => c.Endereco)
                .Where(c => c.Endereco.Uf.ToLower() == uf.ToLower())
                .ToListAsync();

            if (!clientes.Any())
                return NotFound($"Nenhum cliente encontrado no estado {uf}.");

            return clientes;
        }

        // LINQ: últimos 5 clientes cadastrados
        [HttpGet("recentes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesRecentes()
        {
            var clientes = await _context.Clientes
                .Include(c => c.Endereco)
                .OrderByDescending(c => c.Id)
                .Take(5)
                .ToListAsync();

            return clientes;
        }

        // LINQ: contagem por cidade
        [HttpGet("contagem-por-cidade")]
        public async Task<ActionResult<IEnumerable<object>>> GetContagemClientesPorCidade()
        {
            var resultado = await _context.Clientes
                .Include(c => c.Endereco)
                .GroupBy(c => c.Endereco.Localidade)
                .Select(g => new
                {
                    Cidade = g.Key,
                    Quantidade = g.Count()
                })
                .OrderByDescending(g => g.Quantidade)
                .ToListAsync();

            return resultado;
        }
    }
}
