using WebApplication1.Modelos;

namespace WebApplication1.DTOs
{
    public class FacturaCreate
    {
        public int IdCliente { get; set; }        
        public int IdVendedor { get; set; }
        public FormaPago FormaPago { get; set; }
        public List<DetalleFactura> DetalleFactura { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; } 

    }

    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public Factura Factura { get; set; }
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
     

}
