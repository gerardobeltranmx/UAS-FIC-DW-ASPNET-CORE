using System;
namespace APIWeb.ViewModels
{
    public class ProductoTodosViewModel
    {

        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public decimal precio_venta { get; set; }
        public int existencia { get; set; }
        public string descripcion { get; set; }
        public int idcategoria { get; set; } 
        public string nombre_categoria { get; set; }



        public ProductoTodosViewModel()
        {
        }
    }
}
