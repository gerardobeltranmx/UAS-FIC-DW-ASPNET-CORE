using System;
using APIWeb.ViewModels;

namespace APIWeb.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public Categoria()
        {

        }

        public Categoria(string nombre, string descripcion, bool activo)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.activo = activo;
        }
        public Categoria(ViewModelCategoria c)
        {
            this.nombre = c.nombre;
            this.descripcion = c.descripcion;
            this.activo = true;
        }

    }
}
