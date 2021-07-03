using System;
using APIWeb.Models;

namespace APIWeb.ViewModels
{
    public class ViewModelCategoriaId
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }


        public ViewModelCategoriaId()
        {

        }
        public ViewModelCategoriaId(int id, string nombre, string descripcion)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            
        }

        public ViewModelCategoriaId(Categoria c)
        {
            this.id = c.id;
            this.nombre = c.nombre;
            this.descripcion = c.descripcion;
      
        }
    }
}
