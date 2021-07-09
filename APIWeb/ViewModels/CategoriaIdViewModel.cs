using System;
using APIWeb.Models;

namespace APIWeb.ViewModels
{
    public class CategoriaIdViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }


        public CategoriaIdViewModel()
        {

        }
        public CategoriaIdViewModel(int id, string nombre, string descripcion)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            
        }

        public CategoriaIdViewModel(Categoria c)
        {
            this.id = c.id;
            this.nombre = c.nombre;
            this.descripcion = c.descripcion;
      
        }
    }
}
