using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Modelos;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/usuario/")]
public class UsuarioController : ControllerBase
{
    private readonly DBContext _context;
    public UsuarioController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("consultar")]
    public async Task<ActionResult<IEnumerable<Usuario>>> ConsultarUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    [HttpPost]
    [Route("crear")]
    public async Task<ActionResult<Usuario>> CrearUsuarios(Usuario Usuario)
    {
        _context.Usuarios.Add(Usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Usuario creada No.", new { id = Usuario.Id }, Usuario);
    } 

    [HttpPut]
    [Route("modificar")]
    public async Task<ActionResult<Usuario>> ModificarUsuarios(int id, Usuario Usuario)
    {
        if (id != Usuario.Id)
        {
            return BadRequest();
        }

        _context.Entry(Usuario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        } 

        return CreatedAtAction("Usuario No.", new { id = Usuario.Id }, Usuario);
    }

    [HttpDelete]
    [Route("eliminar")]
    public async Task<ActionResult<Usuario>> EliminarUsuarios(int id)
    {
        var Usuario = await _context.Usuarios.FindAsync(id);
        if (Usuario == null)
        {
            return NotFound();
        }

        _context.Usuarios.Remove(Usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
    }

    private bool UsuarioExists(int id)
    {
        return _context.Usuarios.Any(e => e.Id == id);
    }
    

}
