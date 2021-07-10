using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWeb.Helpers;
using APIWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        // GET: api/values
        [HttpGet("[action]")]
        public ActionResult Todos()
        {
            Datos db = new Datos();
            Respuesta Resultado = new Respuesta();

            var prod = db.Productos;// .Include(c => c.categoria);

            var lista = prod.Select(p => new ProductoTodosViewModel
                {
                    id = p.id,
                    nombre = p.nombre,
                    codigo = p.codigo,
                    descripcion = p.descripcion,
                    existencia = p.existencia,
                    idcategoria = p.idcategoria,
                    //nombre_categoria = p.categoria.nombre
                }
              );


            Resultado.Info = lista;

            return Ok(Resultado);

         }


        [HttpGet("[action]")]
        public ActionResult Todos2()
        {
            Datos db = new Datos();
            Respuesta Resultado = new Respuesta();


            var prod = (from p in db.Productos
                        join c in db.Categorias on p.idcategoria equals c.id
                        orderby p.nombre ascending
                        select new
                        {
                            p.codigo,
                            p.nombre,
                            p.descripcion,
                            p.existencia,
                            p.precio_venta,
                            p.idcategoria,
                            nombre_categoria = c.nombre
                        }) ; 
          

            Resultado.Info = prod;

            return Ok(Resultado);

        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/values/5
        [HttpGet("[action]/{nombre}")]
        public ActionResult BuscarNombre(string nombre)
        {
            Respuesta Resultado = new Respuesta();

            Datos db = new Datos();

            var BuscarProducto = (from p in db.Productos
                                 where p.nombre.Contains(nombre)
                                 select new {
                                        p.id,
                                        p.nombre,
                                        p.existencia,
                                        p.precio_venta
                                        }).ToList() ;


            Resultado.Info = BuscarProducto;

            return Ok(Resultado);
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
