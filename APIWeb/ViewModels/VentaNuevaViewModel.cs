using System;
using System.Collections.Generic;

namespace APIWeb.ViewModels
{
    public class VentaNuevaViewModel
    {
        public int idcliente { get; set; }
        public int idusuario { get; set; }
        public int num_factura { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }

        public List<Venta_Detalle_NuevaViewModel> detalles { get; set; }


        public VentaNuevaViewModel()
        {
        }
    }
}
