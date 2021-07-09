using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIWeb.Models
{
    public class Producto
    {
        public int id { get; set; }
        [ForeignKey("categoria")] // Objeto de relaci n con llave foranea
        public int idcategoria { get; set; } // llave foranea
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal precio_venta { get; set; }
        public int existencia { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public Categoria categoria { get; set; }//Objeto de relación

        public Producto()
        {

        }
    }
}
