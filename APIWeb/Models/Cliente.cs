using System;
namespace APIWeb.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string RFC { get; set; }
        public bool activo { get; set; }

        public Cliente()
        {
        }
    }
}
