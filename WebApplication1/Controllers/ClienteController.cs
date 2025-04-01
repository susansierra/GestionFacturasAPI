using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Modelos;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/cliente/")]
public class ClienteController : ControllerBase
{
    private readonly DBContext _context;
    private readonly ILogger<ClienteController> _logger;
    public ClienteController(DBContext context, ILogger<ClienteController> logger)
    {
        _context = context;
        _logger = logger;
    }   
    

    [HttpGet]
    [Route("consultar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> ConsultarClientes()
    {
        return await _context.Clientes.Include(f => f.Usuario).ToListAsync();
    }

    [HttpPost]
    [Route("crear")]
    public async Task<ActionResult<Cliente>> CrearClientes(Cliente Cliente)
    {
        _context.Clientes.Add(Cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Cliente creada No.", new { id = Cliente.Id }, Cliente);
    } 

    [HttpPut]
    [Route("modificar")]
    public async Task<ActionResult<Cliente>> ModificarClientes(int id, Cliente Cliente)
    {
        if (id != Cliente.Id)
        {
            return BadRequest();
        }

        _context.Entry(Cliente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClienteExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        } 

        return CreatedAtAction("Cliente No.", new { id = Cliente.Id }, Cliente);
    }

    [HttpDelete]
    [Route("eliminar")]
    public async Task<ActionResult<Cliente>> EliminarClientes(int id)
    {
        var Cliente = await _context.Clientes.FindAsync(id);
        if (Cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(Cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    

    private bool ClienteExists(int id)
    {
        return _context.Clientes.Any(e => e.Id == id);
    }    

}
