using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWeb.Helpers;
using APIWeb.Models;
using APIWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    public class VentasController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            Respuesta Resultado = new Respuesta();
            Datos db = new Datos();
            var ventas = from v in db.Ventas
                         join dv in db.Ventas_Detalles
                           on v.id equals dv.idventa
                         select new
                         {
                             v.id,
                             v.idcliente,
                             v.idusuario,
                             v.num_factura,
                             v.impuesto,
                             v.total,
                         };


            Resultado.Info = ventas;


            return Ok(Resultado);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
            [HttpPost("[action]")]
            public ActionResult Nueva([FromBody] VentaNuevaViewModel v)
        {
            Datos db = new Datos();
            var venta = new Venta()
            {
                idcliente = v.idcliente,
                idusuario = v.idusuario,
                num_factura = v.num_factura,
                fecha_hora = DateTime.Now,
                impuesto = v.impuesto,
                total = v.total
            };
            // Agrega y Guarda al venta
            db.Ventas.Add(venta);
            db.SaveChanges();

            // Guardar los detalles de la venta
            
            foreach (var d in v.detalles)
            {
                var detalle = new Venta_Detalle()
                {
                    idproducto = d.idproducto,
                    idventa = venta.id,
                    cantidad = d.cantidad,
                    precio = d.precio,
                    descuento = d.descuento
                };

                db.Ventas_Detalles.Add(detalle);
            }
            db.SaveChanges();

            return Ok(venta);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
