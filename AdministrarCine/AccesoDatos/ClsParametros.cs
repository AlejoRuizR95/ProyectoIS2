using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace AccesoDatos
{
    public class ClsParametros
    {
        //Parámetros
        public string Nombre { get; set; }
        public object Valor { get; set; }

        public SqlDbType TipoDato { get; set; }

        public int Tamaño { get; set; }
        public ParameterDirection Direccion { get; set; }




        //Constructores
        //Entrada
        public ClsParametros(string objNombre, object objValor) {

            Nombre = objNombre;
            Valor = objValor;
            Direccion = ParameterDirection.Input;
        
        }


        //Salida
        public ClsParametros(string objNombre, SqlDbType objTipoDato, Int32 objTamaño)
        {

            Nombre = objNombre;
            TipoDato = objTipoDato;
            Tamaño = objTamaño;
            Direccion = ParameterDirection.Output;

        }


    }
}
