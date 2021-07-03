using System;
using APIWeb.Models;

namespace APIWeb.ViewModels
{
    public class ViewModelCategoria
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public ViewModelCategoria()
        {

        }
        public ViewModelCategoria(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
        public ViewModelCategoria(Categoria c)
        {
            this.nombre = c.nombre;
            this.descripcion = c.descripcion;
        }

    }
}
