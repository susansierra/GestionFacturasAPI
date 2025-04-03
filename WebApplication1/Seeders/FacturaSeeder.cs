using WebApplication1.Factories;
using WebApplication1.Modelos;

namespace WebApplication1.Seeders;

public static class FacturaSeeder
{
    public static void Seed(DBContext context)
    {
        if (!context.Facturas.Any())
        {
            
            var clientes = context.Clientes.ToList();
            var productos = context.Productos.ToList();
            var vendedores = context.Usuarios.ToList();
            
            var facturas = FacturaFactory.CreateMany(clientes, vendedores, productos, 20);
            
            
            context.Facturas.AddRange(facturas);
            context.SaveChanges();
        }
    }
}