using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
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
        return await _context.Clientes.ToListAsync();
    }

    [HttpPost]
    [Route("crear")]
    public async Task<ActionResult<Cliente>> CrearClientes(ClienteCreate clienteCreate)
    {
        Cliente cliente = new Cliente
        {
            Nombre = clienteCreate.Nombre,
            Telefono = clienteCreate.Telefono,
            Correo = clienteCreate.Correo,
            Direccion = clienteCreate.Direccion,
            Estado = "Activo",
            FechaCreacion = System.DateTime.Now
        };

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return cliente;
    }

    [HttpPut]
    [Route("modificar")]
    public async Task<ActionResult<Cliente>> ModificarClientes(int Id, ClienteCreate clienteCreate)
    {
        Cliente cliente = new Cliente
        {
            Id = Id,
            Nombre = clienteCreate.Nombre,
            Telefono = clienteCreate.Telefono,
            Correo = clienteCreate.Correo,
            Direccion = clienteCreate.Direccion,
            Estado = "Activo",
            FechaCreacion = System.DateTime.Now
        };
        if (Id == 0)
        {
            return BadRequest();
        }

        _context.Entry(cliente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClienteExists(Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return cliente;
    }

    [HttpDelete]
    [Route("eliminar")]
    public async Task<ActionResult<Cliente>> EliminarClientes(int Id)
    {
        var Cliente = await _context.Clientes.FindAsync(Id);
        if (Cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(Cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    

    private bool ClienteExists(int Id)
    {
        return _context.Clientes.Any(e => e.Id == Id);
    }    

}
