using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Modelos;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/producto/")]
public class ProductoController : ControllerBase
{
    private readonly DBContext _context;
    private readonly ILogger<ProductoController> _logger;
    public ProductoController(DBContext context, ILogger<ProductoController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    [Route("consultar")]
    public async Task<ActionResult<IEnumerable<Producto>>> ConsultarProductos()
    {
        return await _context.Productos.ToListAsync();
    }

    [HttpPost]
    [Route("crear")]
    public async Task<ActionResult<Producto>> CrearFacturas(ProductoCreate productoCreate)
    {
        Producto producto = new Producto
        {
            Nombre = productoCreate.Nombre,
            Precio = productoCreate.Precio,
            Estado = "Activo",
            FechaCreacion = System.DateTime.Now
        };
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return producto;
    } 

    [HttpPut]
    [Route("modificar")]
    public async Task<ActionResult<Producto>> ModificarFacturas(int Id, ProductoCreate productoCreate)
    {
        Producto producto = new Producto
        {
            Id = Id,
            Nombre = productoCreate.Nombre,
            Precio = productoCreate.Precio,
            Estado = "Activo",
            FechaCreacion = System.DateTime.Now
        };

        if (Id == 0)
        {
            return BadRequest();
        }

        _context.Entry(producto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductoExists(Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return producto;
    }

    [HttpDelete]
    [Route("eliminar")]
    public async Task<ActionResult<Producto>> EliminarFacturas(int Id)
    {
        var Producto = await _context.Productos.FindAsync(Id);
        if (Producto == null)
        {
            return NotFound();
        }

        _context.Productos.Remove(Producto);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductoExists(int Id)
    {
        return _context.Productos.Any(e => e.Id == Id);
    }


}
