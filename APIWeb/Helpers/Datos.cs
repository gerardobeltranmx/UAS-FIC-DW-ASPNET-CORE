﻿using System;
using APIWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace APIWeb.Helpers
{
    public class Datos : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; } // tabla categorias la base de datos
        public DbSet<Producto> Productos { get; set; } // tabla productos la base de datos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Conexion = @"Server = surtidor.database.windows.net;
                                Database = surtidordb;
                                User = admindb;
                                Password = 12AB34cd*;";
            optionsBuilder.UseSqlServer(Conexion);
        }
    }
}
