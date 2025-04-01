using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Modelos;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/producto/")]
public class ProductoController : ControllerBase
{
    private readonly DBContext _context;
    public ProductoController(DBContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("consultar")]
    public async Task<ActionResult<IEnumerable<Factura>>> ConsultarFacturas()
    {
        return await _context.Facturas.Include(f => f.Cliente).Include(f => f.Vendedor).Include(f => f.DetalleFactura).Include(f => f.FormaPago).ToListAsync();
    }

    [HttpPost]
    [Route("crear")]
    public async Task<ActionResult<Factura>> CrearFacturas(Factura factura)
    {
        _context.Facturas.Add(factura);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Factura creada No.", new { id = factura.Id }, factura);
    } 

    [HttpPut]
    [Route("modificar")]
    public async Task<ActionResult<Factura>> ModificarFacturas(int id, Factura factura)
    {
        if (id != factura.Id)
        {
            return BadRequest();
        }

        _context.Entry(factura).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        } 

        return CreatedAtAction("Factura No.", new { id = factura.Id }, factura);
    }

    [HttpDelete]
    [Route("eliminar")]
    public async Task<ActionResult<Factura>> EliminarFacturas(int id)
    {
        var factura = await _context.Facturas.FindAsync(id);
        if (factura == null)
        {
            return NotFound();
        }

        _context.Facturas.Remove(factura);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private readonly ILogger<ClienteController> _logger;

    public ProductoController(ILogger<ClienteController> logger)
    {
        _logger = logger;
    }

    private bool ProductoExists(int id)
    {
        return _context.Productos.Any(e => e.Id == id);
    }


}
