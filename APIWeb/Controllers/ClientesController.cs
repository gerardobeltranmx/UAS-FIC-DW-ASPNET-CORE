﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWeb.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public ActionResult Get()
        {
            Respuesta Resultado = new Respuesta();
            Datos db = new Datos();
            var clientes = from c in db.Clientes
                           select new {
                               c.id,
                               c.nombre,
                               c.email,
                               c.telefono
                           };
            Resultado.Info = clientes;


            return Ok(Resultado);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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