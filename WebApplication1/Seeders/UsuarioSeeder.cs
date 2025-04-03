using WebApplication1.Factories;
using WebApplication1.Modelos;

namespace WebApplication1.Seeders;

public static class UsuarioSeeder
{
    public static void Seed(DBContext context)
    {
        if (!context.Usuarios.Any())
        {
            var usuarios = UsuarioFactory.CreateMany(20);
            context.Usuarios.AddRange(usuarios);
            context.SaveChanges();
        }
    }
}