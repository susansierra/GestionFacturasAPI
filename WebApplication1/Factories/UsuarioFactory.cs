using Bogus;
using WebApplication1.Modelos;

namespace WebApplication1.Factories;

public static class UsuarioFactory
{
    public static Faker<Usuario> GetFaker()
    {
        return new Faker<Usuario>()
            .RuleFor(u => u.Nombre, f => f.Person.FullName)
            .RuleFor(u => u.usuario, f => f.Internet.UserName())
            .RuleFor(u => u.Contrasena, f => "123123123123")
            .RuleFor(u => u.Correo, f => f.Person.Email)
            .RuleFor(u => u.FechaCreacion, f => f.Date.Past())
            .RuleFor(u => u.Estado, f => "Activo");
    }

    public static Usuario CreateOne() => GetFaker().Generate();

    public static List<Usuario> CreateMany(int quantity) => GetFaker().Generate(quantity);
}