using System;
namespace APIWeb.Models
{
    public class Rol
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public Rol()
        {
        }
    }
}
