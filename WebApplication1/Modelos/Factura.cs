using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Modelos
{
    public class Factura
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public int IdVendedor { get; set; }
        public Usuario Vendedor { get; set; }
        public FormaPago FormaPago { get; set; }
        public List<DetalleFactura> DetalleFactura { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

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

    public enum FormaPago
    {
        Efectivo,
        TarjetaCredito, 
        TarjetaDebito
    }

}
