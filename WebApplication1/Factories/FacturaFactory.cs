using Bogus;
using WebApplication1.Modelos;

namespace WebApplication1.Factories;

public static class FacturaFactory
{
    private static int facturaId = 1;
    private static int detalleId = 1;

    public static Faker<Factura> GetFaker(List<Cliente> clientes, List<Usuario> vendedores, List<Producto> productos)
    {
        return new Faker<Factura>()
            .RuleFor(f => f.Id, _ => facturaId++)
            .RuleFor(f => f.Cliente, f => f.PickRandom(clientes))
            .RuleFor(f => f.IdCliente, (f, factura) => factura.Cliente.Id)
            .RuleFor(f => f.Vendedor, f => f.PickRandom(vendedores))
            .RuleFor(f => f.IdVendedor, (f, factura) => factura.Vendedor.Id)
            .RuleFor(f => f.FormaPago, f => f.PickRandom<FormaPago>())
            .RuleFor(f => f.FechaCreacion, f => f.Date.Past())
            .RuleFor(f => f.Estado, f => f.PickRandom(new[] { "Pagado", "Pendiente", "Anulado" }))
            .RuleFor(f => f.DetalleFactura, (f, factura) =>
            {
                var detalles = DetalleFacturaFactory.CreateMany(productos, f.Random.Int(1,5));
                factura.Subtotal = detalles.Sum(d => d.Producto.Precio * d.Cantidad);
                factura.Iva = factura.Subtotal * 0.12M;
                factura.Total = factura.Subtotal + factura.Iva;
                return detalles;
            });
    }

    public static Factura CreateOne(List<Cliente> clientes, List<Usuario> vendedores, List<Producto> productos) => GetFaker(clientes, vendedores, productos).Generate();

    public static List<Factura> CreateMany(List<Cliente> clientes, List<Usuario> vendedores, List<Producto> productos, int quantity) => GetFaker(clientes, vendedores, productos).Generate(quantity);
}