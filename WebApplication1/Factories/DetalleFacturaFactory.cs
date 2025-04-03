using Bogus;
using WebApplication1.Modelos;

namespace WebApplication1.Factories;

public static class DetalleFacturaFactory
{
    private static int facturaId = 1;
    private static int detalleId = 1;

    public static Faker<DetalleFactura> GetFaker(List<Producto> productos)
    {
        return new Faker<DetalleFactura>()
            .RuleFor(d => d.Id, _ => detalleId++)
            .RuleFor(d => d.IdProducto, f => f.PickRandom(productos).Id)
            .RuleFor(d => d.Producto, f => f.PickRandom(productos))
            .RuleFor(d => d.Cantidad, f => f.Random.Int(1, 5));
    }

    public static DetalleFactura CreateOne(List<Producto> productos) => GetFaker(productos).Generate();

    public static List<DetalleFactura> CreateMany(List<Producto> productos, int quantity) => GetFaker(productos).Generate(quantity);
}