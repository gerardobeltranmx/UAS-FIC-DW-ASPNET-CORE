using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWeb.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        // GET: api/values
        [HttpGet]
        public ActionResult Get()
        {
            Respuesta Resultado = new Respuesta();
            Datos db = new Datos();
            var usuarios = from u in db.Usuarios
                           select new
                           {
                               u.id,
                               u.idrol,
                               u.nombre,
                               u.email,
                               u.telefono
                           };
            Resultado.Info = usuarios;


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
