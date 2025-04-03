using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs.Usuario;
using WebApplication1.Modelos;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/usuario/")]
public class UsuarioController : ControllerBase
{
    private readonly DBContext _context;
    private readonly ILogger<UsuarioController> _logger;
    public UsuarioController(DBContext context, ILogger<UsuarioController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    [Route("consultar")]
    public async Task<ActionResult<IEnumerable<Usuario>>> ConsultarUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    [HttpPost]
    [Route("crear")]
    public async Task<ActionResult<Usuario>> CrearUsuarios(UsuarioCreate usuarioCreate)
    {
        Usuario usuario = new Usuario
        {
            Nombre = usuarioCreate.Nombre,
            usuario = usuarioCreate.usuario,
            Contrasena = usuarioCreate.Contrasena,
            Correo = usuarioCreate.Correo,
            Estado = "Activo",
            FechaCreacion = System.DateTime.Now
        };


        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return usuario; //CreatedAtAction("Usuario creada No.", new { id = usuario.Id }, usuario);
    }

    [HttpPut]
    [Route("modificar")]
    public async Task<ActionResult<Usuario>> ModificarUsuarios(int Id, UsuarioCreate usuarioCreate)
    {
        Usuario usuario = new Usuario
        {
            Id = Id, 
            Nombre = usuarioCreate.Nombre,
            usuario = usuarioCreate.usuario,
            Contrasena = usuarioCreate.Contrasena,
            Correo = usuarioCreate.Correo,
            Estado = "Activo",
            FechaCreacion = System.DateTime.Now
        };

        if (usuario.Nombre == null)
        {
            return BadRequest();
        }

        _context.Entry(usuario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(usuario.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return usuario;
    }

    [HttpDelete]
    [Route("eliminar")]
    public async Task<ActionResult<Usuario>> EliminarUsuarios(int Id)
    {
        var Usuario = await _context.Usuarios.FindAsync(Id);
        if (Usuario == null)
        {
            return NotFound();
        }

        _context.Usuarios.Remove(Usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioExists(int Id)
    {
        return _context.Usuarios.Any(e => e.Id == Id);
    } 
    

}
