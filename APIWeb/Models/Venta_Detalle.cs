﻿using System;
namespace APIWeb.Models
{
    public class Venta_Detalle
    {
        public int id { get; set; }
        public int idventa { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }


        public Venta_Detalle()
        {
        }
    }
}
