namespace WebApplication1.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
        public string Direccion  { get; set; }
        public string Estado { get; set; } 
    }
}
