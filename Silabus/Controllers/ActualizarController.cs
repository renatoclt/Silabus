using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Silabus.Controllers
{
    public class ActualizarController : ApiController
    {
        [HttpPost]
        public IHttpActionResult ActualizarEstado( string cadena)
        {
            int hola;
            try
            {
                //revisar documentación 
                //VisualizarSilabo.guardarDato();
                //return exitoso 200

                return Ok("OK");
            }
            catch (Exception)
            {
                //error cod 500 como retornar el error

                return NotFound();

            }

        }
    }
}
