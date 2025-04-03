using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Modelos;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/factura/")]
public class FacturaController : ControllerBase
{
    private readonly DBContext _context;
    private readonly ILogger<FacturaController> _logger;
    public FacturaController(DBContext context, ILogger<FacturaController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    [Route("consultar")]
    public async Task<ActionResult<IEnumerable<Factura>>> ConsultarFacturas()
    {
        return await _context.Facturas.Include(f => f.Cliente).Include(f => f.Vendedor).Include(f => f.DetalleFactura).ThenInclude(f => f.Producto).ToListAsync();
        //return await _context.Facturas.ToListAsync();
    }

    [HttpPost]
    [Route("crear")]
    public async Task<ActionResult<Factura>> CrearFacturas(FacturaCreate facturaCreate)
    {
        var cliente = _context.Clientes.FirstOrDefault(e => e.Id == facturaCreate.IdCliente);
        var vendedor = _context.Usuarios.FirstOrDefault(e => e.Id == facturaCreate.IdVendedor);
        if (cliente == null || vendedor == null)
        {
            return BadRequest();
        };        
        List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();
        Factura factura = new Factura
        {
            IdCliente = facturaCreate.IdCliente,
            Cliente = cliente,
            IdVendedor = facturaCreate.IdVendedor,
            Vendedor = vendedor,
            FormaPago = facturaCreate.FormaPago,
            DetalleFactura = listaDetalleFactura,
            Subtotal = facturaCreate.Subtotal,
            Iva = facturaCreate.Iva,
            Total = facturaCreate.Total,
            Estado = "Pagado",
            FechaCreacion = System.DateTime.Now
        };
        foreach (DetalleFacturaCreate detalle in facturaCreate.DetalleFacturaCreate)
        {
            var producto = _context.Productos.FirstOrDefault(e => e.Id == detalle.IdProducto);
            if (producto == null)
            {
                producto = new Producto();
            }
            ;
            DetalleFactura detalleFactura = new DetalleFactura
            {
                IdFactura = factura.Id,
                Factura = factura,
                IdProducto = detalle.IdProducto,
                Producto = producto,
                Cantidad = detalle.Cantidad
            };
            listaDetalleFactura.Add(detalleFactura);
        };
       
        
        _context.Facturas.Add(factura);
        await _context.SaveChangesAsync();

        return factura;
    } 

    [HttpPut]
    [Route("modificar")]
    public async Task<ActionResult<Factura>> ModificarFacturas(int Id, FacturaCreate facturaCreate)
    {
        if (Id == 0)
        {
            return BadRequest();
        }
        var factura = _context.Facturas.FirstOrDefault(e => e.Id == Id);
        var cliente = _context.Clientes.FirstOrDefault(e => e.Id == facturaCreate.IdCliente);
        var vendedor = _context.Usuarios.FirstOrDefault(e => e.Id == facturaCreate.IdVendedor);
        if (cliente == null || vendedor == null)
        {
            return BadRequest();
        }
        ;
        List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();
        factura.IdCliente = facturaCreate.IdCliente;
        factura.Cliente = cliente;
        factura.IdVendedor = facturaCreate.IdVendedor;
        factura.Vendedor = vendedor;
        factura.FormaPago = facturaCreate.FormaPago;
        factura.DetalleFactura = listaDetalleFactura;
        factura.Subtotal = facturaCreate.Subtotal;
        factura.Iva = facturaCreate.Iva;
        factura.Total = facturaCreate.Total;
        factura.Estado = "Pagado";
        factura.FechaCreacion = System.DateTime.Now;

        foreach (DetalleFacturaCreate detalle in facturaCreate.DetalleFacturaCreate)
        {
            var producto = _context.Productos.FirstOrDefault(e => e.Id == detalle.IdProducto);
            if (producto == null)
            {
                producto = new Producto();
            }
            ;
            DetalleFactura detalleFactura = new DetalleFactura
            {
                IdFactura = Id,
                Factura = factura,
                IdProducto = detalle.IdProducto,
                Producto = producto,
                Cantidad = detalle.Cantidad
            };
            listaDetalleFactura.Add(detalleFactura);
        };



        _context.Entry(factura).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FacturaExists(Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return factura;
    }

    [HttpDelete]
    [Route("eliminar")]
    public async Task<ActionResult<Factura>> EliminarFacturas(int Id)
    {
        var factura = await _context.Facturas.FindAsync(Id);
        if (factura == null)
        {
            return NotFound();
        }

        _context.Facturas.Remove(factura);
        await _context.SaveChangesAsync();

        return NoContent();
    }     

    private bool FacturaExists(int Id)
    {
        return _context.Facturas.Any(e => e.Id == Id);
    }


}
