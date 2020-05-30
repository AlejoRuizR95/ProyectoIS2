using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicaNegocio;

namespace AplicacionREST.Controllers
{
    public class CineController : ApiController
    {
        ClsSala S = new ClsSala();

        // GET api/<controller>/5
        public string Get(string Columna, int Fila, int Dato, string Tabla)
        {
            S.Columna = Columna;
            S.Fila = Fila;
            S.Dato = Dato;
            S.Tabla = Tabla;
            return S.Registrar_Silla();
        }

        public List<string> Get()
        {
            return S.ListadoPeliculas();
        }

        public List<string> Get(string pelicula)
        {
            return S.LeerFechas(pelicula);
        }

        public List<string> Get(string pelicula, string Dia)
        {
            return S.LeerHoras(pelicula, Dia);
        }


    }
}