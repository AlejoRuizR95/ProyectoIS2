using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class ClsSala
    {
        //Atributos
        public string Columna {get; set;}
        public int Fila { get; set; }
        public int Dato { get; set; }
        public string Tabla { get; set; }
        //public string Pelicula { get; set; }

        //Actualizar Silla
        ClsManejador M = new ClsManejador();

        public string Registrar_Silla() {

            string msj = "";

            List<ClsParametros> list = new List<ClsParametros>();
            try
            {
                //Validar Valor de dato para verificar si se esta enviando una silla ya ocupada
                if (Dato == 0)
                   Dato = 1;
                else
                   Dato = 0;


                //pasar parametros Entrada 
                list.Add(new ClsParametros("@Columna", Columna));
                list.Add(new ClsParametros("@Fila", Fila));
                list.Add(new ClsParametros("@Dato", Dato));
                list.Add(new ClsParametros("@Tabla", Tabla));

                //pasar parametros Salida
                list.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                M.Ejecutar_P("CambiarDato", list);
                msj = list[4].Valor.ToString();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return msj;
        
        }

        public DataTable ListadoSala(string Sala) {
            List<ClsParametros> list = new List<ClsParametros>();
            list.Add(new ClsParametros("@Sala", Sala));

            return M.Listado("Listar_Sala", list);
        }

        public List<string> ListadoSillas() {
            DataTable dt;
            dt = M.Listado("Listar_Sala", null);
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            return s;

        }

        public List<string> ListadoPeliculas()
        {
            DataTable dt;
            dt = M.Listado("Listar_Peliculas", null);
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            return s;

        }


        public List<string> LeerFechas(string Pelicula) {
            List<ClsParametros> list = new List<ClsParametros>();
            list.Add(new ClsParametros("@Pelicula", Pelicula));
            
            DataTable dt;
            dt = M.Listado("Listar_Fechas", list);
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();


            return s;

        }

        public List<string> LeerHoras(string Pelicula, string Dia)
        {
            List<ClsParametros> list = new List<ClsParametros>();
            string Dia2 = "";
            DateTime dt1 = DateTime.ParseExact(Dia, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            Dia2 = dt1.ToString("yyyy-mm-dd");
            
           
            list.Add(new ClsParametros("@Pelicula", Pelicula));
            list.Add(new ClsParametros("@Dia", Dia2));

            DataTable dt;
            dt = M.Listado("Listar_Horas", list);
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            

            return s;

        }

        public string LeerId(string Pelicula, string Dia, string Hora)
        {
            List<ClsParametros> list = new List<ClsParametros>();
            string Dia2 = "";
            DateTime dt1 = DateTime.ParseExact(Dia, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            Dia2 = dt1.ToString("yyyy-mm-dd");


            list.Add(new ClsParametros("@Pelicula", Pelicula));
            list.Add(new ClsParametros("@Dia", Dia2));
            list.Add(new ClsParametros("@Hora", Hora));

            DataTable dt;
            dt = M.Listado("Listar_Id", list);
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            Console.WriteLine(s[0]);

            return ("S"+s[0]);

        }
           

    }
}
