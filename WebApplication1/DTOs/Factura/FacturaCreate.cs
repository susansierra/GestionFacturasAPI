using WebApplication1.Modelos;

namespace WebApplication1.DTOs
{
    public class FacturaCreate
    {
        public int IdCliente { get; set; }        
        public int IdVendedor { get; set; }
        public FormaPago FormaPago { get; set; }
        public List<DetalleFacturaCreate> DetalleFacturaCreate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; } 

    }

    public class DetalleFacturaCreate
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }

}
