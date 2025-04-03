using WebApplication1.Factories;
using WebApplication1.Modelos;

namespace WebApplication1.Seeders;

public static class ProductSeeder
{
    public static void Seed(DBContext context)
    {
        if (!context.Productos.Any())
        {
            var productos = ProductoFactory.CreateMany(20);
            context.Productos.AddRange(productos);
            context.SaveChanges();
        }
    }
}