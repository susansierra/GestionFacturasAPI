using Bogus;
using WebApplication1.Modelos;

namespace WebApplication1.Factories;

public static class ClientesFactory
{
    public static Faker<Cliente> GetFaker()
    {
        return new Faker<Cliente>()
            .RuleFor(c => c.Nombre, f => f.Person.FullName)
            .RuleFor(c => c.Direccion, f => f.Address.FullAddress())
            .RuleFor(c => c.Telefono, f => f.Person.Phone)
            .RuleFor(c => c.Correo, f => f.Person.Email)
            .RuleFor(c => c.FechaCreacion, f => f.Date.Past())
            .RuleFor(c => c.Estado, f => "Activo");
    }

    public static Cliente CreateOne() => GetFaker().Generate();

    public static List<Cliente> CreateMany(int quantity) => GetFaker().Generate(quantity);
}