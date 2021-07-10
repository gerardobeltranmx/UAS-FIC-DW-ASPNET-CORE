using System;
namespace APIWeb.Models
{
    public class Venta
    {

        public int id { get; set; }
        public int idcliente { get; set; }
        public int idusuario { get; set; }
        public int num_factura { get; set; }
        public DateTime fecha_hora { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }

        public Venta()
        {
        }
    }
}
