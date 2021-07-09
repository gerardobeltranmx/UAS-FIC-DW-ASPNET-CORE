using System;
using System.ComponentModel.DataAnnotations;
using APIWeb.Models;

namespace APIWeb.ViewModels
{
    public class CategoriaViewModel
    {
        [Required(ErrorMessage = "Debe escribir el nombre")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El campo {0} puede tener de {2} a {1} caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Debe escribir la descripción")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "El campo {0} puede tener de {2} a {1} caracteres")]
        public string descripcion { get; set; }

        public CategoriaViewModel()
        {

        }
        public CategoriaViewModel(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
        public CategoriaViewModel(Categoria c)
        {
            this.nombre = c.nombre;
            this.descripcion = c.descripcion;
        }

    }
}
