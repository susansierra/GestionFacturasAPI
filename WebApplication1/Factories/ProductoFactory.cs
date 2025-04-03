using Bogus;
using WebApplication1.Modelos;

namespace WebApplication1.Factories;

public class ProductoFactory
{
    public static Faker<Producto> GetFaker()
    {
        return new Faker<Producto>()
            .RuleFor(p => p.Nombre, f => f.Commerce.ProductName())
            .RuleFor(p => p.Precio, f => f.Random.Decimal(10, 1000))
            .RuleFor(p => p.FechaCreacion, f => f.Date.Past())
            .RuleFor(p => p.Estado, f => "Activo");
    }

    public static Producto CreateOne() => GetFaker().Generate();

    public static List<Producto> CreateMany(int quantity) => GetFaker().Generate(quantity);
}