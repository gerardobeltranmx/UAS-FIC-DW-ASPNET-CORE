using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIWeb.Models
{
    public class Venta_Detalle
    {
        public int id { get; set; }
        [ForeignKey("venta")]

        public int idventa { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }
        public Venta venta  { get; set; }


        public Venta_Detalle()
        {
        }
    }
}
