using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class ClsManejador
    {
        SqlConnection conexion = new SqlConnection("server = DESKTOP-84TPD5K\\MSSQLSERVER01; DataBase = BDCine; Integrated Security = True ");

        public void abrir_conexion()
        {
            if (conexion.State == ConnectionState.Closed){ 
                conexion.Open();                
            }
            
            
        }
        public void cerrar_conexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            
        }


        // Ejecutar Insert, Update
        public void Ejecutar_P(string NombreP, List<ClsParametros> list) 
        {
            SqlCommand cmd;    
            try
            {

                abrir_conexion();
                cmd = new SqlCommand(NombreP, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if(list[i].Direccion== ParameterDirection.Input)
                            {
                            cmd.Parameters.AddWithValue(list[i].Nombre, list[i].Valor);
                        }
                        if (list[i].Direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(list[i].Nombre, list[i].TipoDato, list[i].Tamaño).Direction = ParameterDirection.Output;

                        }
                    }

                    cmd.ExecuteNonQuery();

                    //Informacion de Salida
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                            list[i].Valor = cmd.Parameters[i].Value.ToString();
                        {

                        }
                    }

                }
                
            }
            catch (Exception ex){

                throw ex;
            
            }

            cerrar_conexion();


        }

        //Ejecutar Consultas

        public DataTable Listado(string NombreP, List<ClsParametros> list) {

            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                
                da = new SqlDataAdapter(NombreP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(list[i].Nombre, list[i].Valor);
                    
                    }

                }
                da.Fill(dt);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;

            
        }
    }
}
