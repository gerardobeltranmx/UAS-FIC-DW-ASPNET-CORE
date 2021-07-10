using System;
namespace APIWeb.ViewModels
{
    public class Venta_Detalle_NuevaViewModel
    {
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }

        public Venta_Detalle_NuevaViewModel()
        {
        }
    }
}
