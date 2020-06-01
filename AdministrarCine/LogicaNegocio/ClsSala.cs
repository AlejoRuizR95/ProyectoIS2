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
        public string Fecha { get; set; }
        public string Hora { get; set; }

        public double acumFactura { get; set; }
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

        public DataTable ListarTablaPeliculas()
        {
            DataTable dt;
            dt = M.Listado("Listar_FullPeliculas", null);

            return dt; 
        }

        public DataTable TablaProgramacion()
        {
            DataTable dt;
            dt = M.Listado("ListarProgramacion", null);

            return dt;
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

        public DataTable Fechas(string Pelicula)
        {
            List<ClsParametros> list = new List<ClsParametros>();
            list.Add(new ClsParametros("@Pelicula", Pelicula));
            DataTable dt;
            dt = M.Listado("Listar_Fechas", list);

            return dt;
        }

        public DataTable Horas(string Pelicula, string Dia)
        {
            List<ClsParametros> list = new List<ClsParametros>();
            string Dia2 = "";
            DateTime dt1 = DateTime.ParseExact(Dia, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            Dia2 = dt1.ToString("yyyy-mm-dd");


            list.Add(new ClsParametros("@Pelicula", Pelicula));
            list.Add(new ClsParametros("@Dia", Dia2));

            DataTable dt;
            dt = M.Listado("Listar_Horas", list);

            return dt;
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

        public string Programar_Pelicula(string Pelicula, string Sala, string Fecha, string Hora)
        {

            string msj = "";

            List<ClsParametros> list = new List<ClsParametros>();
            try
            {
                string Fecha2 = "";
                DateTime dt2 = DateTime.ParseExact(Fecha, "dd/mm/yyyy", CultureInfo.InvariantCulture);
                Fecha2 = dt2.ToString("yyyy-mm-dd");

                Console.WriteLine(Fecha);

                //pasar parametros Entrada 
                list.Add(new ClsParametros("@Pelicula", Pelicula));
                list.Add(new ClsParametros("@Sala", Sala));
                list.Add(new ClsParametros("@Dia", Fecha2));
                list.Add(new ClsParametros("@Hora", Hora));

                //pasar parametros Salida
                list.Add(new ClsParametros("@Id", SqlDbType.VarChar, 100));

                M.Ejecutar_P("Programar_Pelicula", list);
                msj = list[4].Valor.ToString();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return msj;

        }


        public static double Calcular_Pago(string fila, string fecha, string hora)
        {
            double precio = 15000;
            string dia = "";
            DateTime date = DateTime.Parse(hora, System.Globalization.CultureInfo.CurrentCulture);
            Int32 hora1 = date.Hour;
            DateTime oDate = Convert.ToDateTime(fecha);            
            dia = oDate.ToString("dddd", new CultureInfo("es-ES"));
            //Console.WriteLine(dia);


            if (dia == "martes" || dia == "miércoles")
            {

                precio = (precio * 0.5);
            }
            else if ((dia == "lunes" || dia == "jueves") && hora1 <= 15)
            {
                precio = (precio * 0.65);
            }
            else if((dia == "viernes" || dia == "sábado" || dia == "domingo") && hora1 <= 15) {
                precio = (precio * 0.8);
            }

            if(fila =="9" || fila == "10")
            {

                precio = precio*1.20;

            }
            Console.WriteLine(precio);
            return precio;
            


        }

        public string Calcular_Pago()
        {
            string text = "";
            double precio = 15000;
            string dia = "";
            Console.WriteLine(Fecha);
            DateTime date = DateTime.Parse(Hora, System.Globalization.CultureInfo.CurrentCulture);
            Int32 hora1 = date.Hour;
            DateTime oDate = Convert.ToDateTime(Fecha);
            dia = oDate.ToString("dddd", new CultureInfo("es-ES"));
            //Console.WriteLine(dia);


            if (dia == "martes" || dia == "miércoles")
            {

                precio = (precio * 0.5);
                
                text = "Silla "+Columna + Fila.ToString() + " - Día Mart/Mierc: " + precio.ToString();
            }
            else if ((dia == "lunes" || dia == "jueves") && hora1 <= 15)
            {
                precio = (precio * 0.65);
                
                text = "Silla " + Columna + Fila.ToString() + " - Día Normal ant. 3 pm: " + precio.ToString();
            }
            else if ((dia == "viernes" || dia == "sábado" || dia == "domingo") && hora1 <= 15)
            {
                precio = (precio * 0.8);
                
                text = "Silla " + Columna + Fila.ToString() + " - Fin de Sem. ant 3 pm: " + precio.ToString();
            }
            else
            {
                
                text = "Silla " + Columna + Fila.ToString() + " - Precio Stand.: " + precio.ToString();
            }

            if (Fila == 9 || Fila == 10)
            {

                precio = precio * 1.20;
                
                text = "Silla " + Columna + Fila.ToString() + " - Fila VIP: " + precio.ToString();

            }
            acumFactura = acumFactura + precio;

            return text;



        }


    }
}
