using System;
namespace APIWeb.Helpers
{
    public class Respuesta
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public object Info { get; set; }

        public Respuesta()
        {
            this.Estado = true;
            this.Mensaje = "Sin error";
            this.Info = null;
        }
        public Respuesta(bool Estado, string Mensaje, Object Info)
        {
            this.Estado = Estado;
            this.Mensaje = Mensaje;
            this.Info = Info;
        }
    }
}
