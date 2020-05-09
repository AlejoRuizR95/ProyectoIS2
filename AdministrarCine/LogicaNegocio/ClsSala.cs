using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class ClsSala
    {
        //Atributos
        public string Silla {get; set;}
        public string Estado { get; set; }
        //public string Pelicula { get; set; }

        //Actualizar Silla
        ClsManejador M = new ClsManejador();

        public string Registrar_Silla() {

            string msj = "";

            List<ClsParametros> list = new List<ClsParametros>();
            try
            {
                //pasar parametros Entrada 
                list.Add(new ClsParametros("@Silla", Silla));
                list.Add(new ClsParametros("@Estado", Estado));

                //pasar parametros Salida
                list.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 100));

                M.Ejecutar_P("Registrar_Silla", list);
                msj = list[2].Valor.ToString();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return msj;
        
        }

        public DataTable ListadoSala() {


            return M.Listado("Listar_Sala", null);
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


        public List<string> LeerProgramacion(string Pelicula) {
            List<ClsParametros> list = new List<ClsParametros>();
            list.Add(new ClsParametros("@Pelicula", Pelicula));
            DataTable dt;
            dt = M.Listado("Listar_Fechas", list);
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();


            return s;

        }

        public List<string> LeerProgramacion(string Pelicula, string Dia)
        {
            DateTime Fecha = DateTime.Parse(Dia);
            List<ClsParametros> list = new List<ClsParametros>();
            list.Add(new ClsParametros("@Pelicula", Pelicula));
            list.Add(new ClsParametros("@Dia", Fecha));
            DataTable dt;
            dt = M.Listado("Listar_Horas", list);
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();


            return s;

        }




    }
}
