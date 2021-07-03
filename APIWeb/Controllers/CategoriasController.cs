using System;
using System.Collections.Generic;
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

            try
            {
                List<ViewModelCategoriaId> lista = new List<ViewModelCategoriaId>();

                foreach (Categoria c in db.Categorias)
                    lista.Add(new ViewModelCategoriaId(c));

                if (lista.Count == 0)
                    throw new CategoriaException("Son muy pocas categorias");

                Resultado.Info = lista;
            }
            catch(CategoriaException ex)
            {
                Resultado.Estado = false;
                Resultado.Mensaje = ex.Message;
            }
            catch(Exception)
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
                    Resultado.Info = new ViewModelCategoriaId(BuscarCategoria);
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
        public ActionResult Nueva([FromBody] ViewModelCategoria c)
        {
            try
            {
                Categoria nueva = new Categoria(c);
                db.Categorias.Add(nueva);
                db.SaveChanges();
                Resultado.Info = new ViewModelCategoriaId(nueva);
            }
           
            catch (Exception)
            {
                Resultado.Mensaje = "Error en el Sistema, consulta al admin";
            }

            return Ok(Resultado);
        }

        // PUT api/values/5
        [HttpPut("Actualizar/{id}")]
        public ActionResult Actualizar(int id, [FromBody] ViewModelCategoria c)
        {

            try
            {
                Categoria BuscarCategoria = db.Categorias.Find(id);

                if (BuscarCategoria != null)
                {
                    BuscarCategoria.nombre = c.nombre;
                    BuscarCategoria.descripcion = c.descripcion;
                    db.SaveChanges();
                    Resultado.Info= new ViewModelCategoriaId(BuscarCategoria);

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
                            ViewModelCategoriaId (BuscarCategoria);

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
