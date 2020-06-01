using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicaNegocio;
using System.Web.Http.Cors;

namespace AplicacionREST.Controllers
{
    [EnableCors("*", "*", "*")]

    public class CineController : ApiController
    {
        ClsSala S = new ClsSala();

        // GET api/<controller>/5 
        
        public System.Data.DataTable GetDescripcionPeliculas(string descri)
        {
            return S.ListarTablaPeliculas();
            //localhost:44359/api/Cine?descri=
        }

        public System.Data.DataTable GetProgramacion(string progr)
        {
            return S.TablaProgramacion();
            //localhost:44359/api/Cine?progr=
        }
        public System.Data.DataTable GetFechas(string pelicula)
        {
            return S.Fechas(pelicula);
            //localhost:44359/api/Cine?pelicula={pelicula}
        }

        public System.Data.DataTable GetHoras(string pelicula, string Dia)
        {
            return S.Horas(pelicula, Dia);
            //localhost:44359/api/Cine?pelicula={pelicula},Dia={Dia}
        }


        public string GetRegistrar(string Columna, int Fila, int Dato, string Tabla)
        {
            S.Columna = Columna;
            S.Fila = Fila;
            S.Dato = Dato;
            S.Tabla = Tabla;
            return S.Registrar_Silla();
            //localhost:44359/api/Cine?Columna={Columna}&Fila={Fila}&Dato={Dato}&Tabla={Tabla}
        }

    }
}