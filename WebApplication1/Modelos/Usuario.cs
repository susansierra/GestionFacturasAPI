namespace WebApplication1.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string usuario { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        //Vendedor o cliente 
        public Tipo Tipo { get; set; }
    }
    public enum Tipo
    {
        Vendedor,
        Cliente
    }
}
