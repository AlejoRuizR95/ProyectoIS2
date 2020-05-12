﻿using System;
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
       

        // GET api/<controller>/5
        public string Get(string Columna, int Fila, int Dato, string Tabla)
        {
            ClsSala S = new ClsSala();
            S.Columna = Columna;
            S.Fila = Fila;
            S.Dato = Dato;
            S.Tabla = Tabla;            
            return S.Registrar_Silla();
        }

        
    }
}