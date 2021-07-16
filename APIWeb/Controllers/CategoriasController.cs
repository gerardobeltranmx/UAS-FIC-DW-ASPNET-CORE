using System;
using System.Collections.Generic;
using System.Linq;
using APIWeb.Helpers;
using APIWeb.Models;
using APIWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    public class CategoriasController : Controller
    {
        Datos db = new Datos();
        Respuesta Resultado = new Respuesta();

        // GET: api/Categorias/Todos
        [HttpGet("Todos")]
        public ActionResult Todos()
        {
            // vser
            try
            {
                List<CategoriaIdViewModel> lista = new List<CategoriaIdViewModel>();

                foreach (Categoria c in db.Categorias)
                    lista.Add(new CategoriaIdViewModel(c));

                if (lista.Count == 0)
                    throw new CategoriaException("Son muy pocas categorias");

                Resultado.Info = lista;
            }
            catch(CategoriaException ex)
            {
                Resultado.Estado = false;
                Resultado.Mensaje = ex.Message;
            }
            catch(Exception ex)
            {
                Resultado.Estado = false;
                Resultado.Mensaje = ex.Message; //"Se presento un error, consulta al administrador";
                //ex.Message;
            }
            return Ok(Resultado);
        }

        // GET: api/Categorias/Todos2
        [HttpGet("[action]")]
        public ActionResult Todos2()
        {
            // vser
            try
            {
                // Consulta usando Linq To SQL
               //var lista = (from c in db.Categorias select c).ToList();

                var lista = (from c in db.Categorias
                                orderby c.id ascending 
                                select new {
                                        categoria_id = c.id,
                                        categoria_nombre = c.nombre
                                        }
                                ).ToList();


                if (lista.Count == 0)
                    throw new CategoriaException("Son muy pocas categorias");

                Resultado.Info = lista;
            }
            catch (CategoriaException ex)
            {
                Resultado.Estado = false;
                Resultado.Mensaje = ex.Message;
            }
            catch (Exception)
            {
                Resultado.Estado = false;
                Resultado.Mensaje = "Se presento un error, consulta al administrador";
                //ex.Message;
            }
            return Ok(Resultado);
        }

        // GET api/Categoria/Buscar/1
        [HttpGet("Buscar/{id}")]
        public ActionResult Buscar(int id)
        {

            Categoria BuscarCategoria;
            try
            {
                BuscarCategoria = db.Categorias.Find(id);
                if (BuscarCategoria != null)
                    Resultado.Info = new CategoriaIdViewModel(BuscarCategoria);
                else
                    throw new CategoriaException("Categoria no encontrada");
            }
            catch (CategoriaException ex)
            {
                Resultado.Mensaje = ex.Message;
                Resultado.Estado = false;
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }

            return Ok(Resultado);

        }

        // GET api/Categoria/Buscar/1
        [HttpGet("[action]/{id}")]
        public ActionResult BuscarId(int id)
        {

            //Categoria BuscarCategoria;
            try
            {

                var BuscarCategoria = (from c in db.Categorias
                                       where c.id == id
                                       select new
                                       {
                                           c.id,
                                           c.nombre,
                                           c.descripcion
                                       }
                                      ).ToList() ;

                if (BuscarCategoria.Count > 0)
                    Resultado.Info = BuscarCategoria;
                else
                    throw new CategoriaException("Categoria no encontrada");
            }
            catch (CategoriaException ex)
            {
                Resultado.Mensaje = ex.Message;
                Resultado.Estado = false;
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }

            return Ok(Resultado);

        }

        [HttpGet("[action]/{nombre}")]
        public ActionResult BuscarNombre(string nombre)
        {

            //Categoria BuscarCategoria;
            try
            {

                var BuscarCategoria = (from c in db.Categorias
                                       where c.nombre.Contains(nombre)
                                       select new
                                       {
                                           c.id,
                                           c.nombre,
                                           c.descripcion
                                       }
                                      ).ToList();

                if (BuscarCategoria.Count > 0)
                    Resultado.Info = BuscarCategoria;
                else
                    throw new CategoriaException("Categoria no encontrada");
            }
            catch (CategoriaException ex)
            {
                Resultado.Mensaje = ex.Message;
                Resultado.Estado = false;
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }

            return Ok(Resultado);

        }




        // POST api/Categorias/Nueva
        [HttpPost("Nueva")]
        public ActionResult Nueva([FromBody] CategoriaViewModel c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categoria nueva = new Categoria(c);
                    db.Categorias.Add(nueva);
                    db.SaveChanges();
                    Resultado.Info = new CategoriaIdViewModel(nueva);
                }
                else
                {
                    Resultado.Estado = false;
                    string MensajeError = "";

                    foreach(var valor in ModelState.Values)
                    {
                        MensajeError+= valor.Errors[0].ErrorMessage;
                        MensajeError += " | ";
                    }
                    // MensajeError = ModelState.Values.First().Errors[0].ErrorMessage;

                    Resultado.Mensaje =  MensajeError; ;
                }
            }
           
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }

            return Ok(Resultado);
        }

        // PUT api/values/5
        [HttpPut("Actualizar/{id}")]
        public ActionResult Actualizar(int id, [FromBody] CategoriaViewModel c)
        {

            try
            {
                Categoria BuscarCategoria = db.Categorias.Find(id);

                if (BuscarCategoria != null)
                {
                    BuscarCategoria.nombre = c.nombre;
                    BuscarCategoria.descripcion = c.descripcion;
                    db.SaveChanges();
                    Resultado.Info= new CategoriaIdViewModel(BuscarCategoria);

                }
                else
                    throw new Exception("Categoria no fue encontrada");
            }
            catch (CategoriaException ex)
            {
                Resultado.Mensaje = ex.Message;
                Resultado.Estado = false;
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }



            return Ok(Resultado);

        }

        // DELETE api/values/5
        [HttpDelete("Inactivar/{id}")]
        public ActionResult Inactivar(int id)
        {

            try
            {
                Categoria BuscarCategoria = db.Categorias.Find(id);
                if (BuscarCategoria != null)
                {
                    // db.Categorias.Remove(BuscarCategoria);
                    BuscarCategoria.activo = false;
                    db.SaveChanges();
                    Resultado.Info=new
                            CategoriaIdViewModel(BuscarCategoria);

                }
                else
                    throw new Exception("Categoria no fue encontrada para inactivar");


            }
            catch (CategoriaException ex)
            {
                Resultado.Mensaje = ex.Message;
                Resultado.Estado = false;
            }
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }

            return Ok(Resultado);

        }
    }
}
