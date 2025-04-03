using WebApplication1.Factories;
using WebApplication1.Modelos;

namespace WebApplication1.Seeders;

public static class ClienteSeeder
{
    public static void Seed(DBContext context)
    {
        if (!context.Clientes.Any())
        {
            var usuarios = ClientesFactory.CreateMany(20);
            context.Clientes.AddRange(usuarios);
            context.SaveChanges();
        }
    }
}