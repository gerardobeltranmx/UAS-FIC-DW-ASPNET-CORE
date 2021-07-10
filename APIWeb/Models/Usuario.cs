using System;
namespace APIWeb.Models
{
    public class Usuario
    {

        public int id { get; set; }
        public int idrol { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }
        public bool activo { get; set; }




        public Usuario()
        {
        }
    }
}
