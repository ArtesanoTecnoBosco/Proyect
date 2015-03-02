using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace Capa_Acceso_a_Datos
{
    /// <summary>
    /// Clase para realizar la conexion a la bd. Recordar que se el cierre de la conexion tiene que ser manual.
    /// </summary>
    public class Conexion
    {
        /// <summary>
        /// Atributo enlace de conexion con la bd.
        /// </summary>
        private System.Data.OleDb.OleDbConnection conexion;
        /// <summary>
        /// Atributo de la ruta a la bd.
        /// </summary>
        private String ruta;


        /// <summary>
        /// Constructor vacio.
        /// </summary>
        public Conexion()
        {
            this.ruta="Capa Acceso a Datos\\BD\\Aprendo con Molly.mdb";
            conexion = new System.Data.OleDb.OleDbConnection();


            String r = directorioPadre() + "\\" + ruta;
            conexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data source="+ r;



        }


        /// <summary>
        /// Constructor con el parametro ruta.
        /// </summary>
        /// <param name="ruta"></param>
        public Conexion(String ruta)
        {
            this.ruta = ruta;
            conexion = new System.Data.OleDb.OleDbConnection();

            conexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data source=" + this.ruta;

        }


        /// <summary>
        /// Metodo para abrir la conexion.
        /// </summary>
        public void abrirConexion()
        {
            try
            {

                conexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al conectar la Bd. Por favor contactar con el administrador de la aplicacion. \n" + ex.Message);
            }
     

        }

        /// <summary>
        /// Metodo para cerrar la conexion.
        /// </summary>
        public void cerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible cerrar la conexion.  \n" + ex.Message);
            }
        }


        /// <summary>
        /// Metodo para obtener el directorio del ejecutable.
        /// </summary>
        /// <returns>String con la ruta del directorio padre.</returns>
        public String directorioPadre() {
        DirectoryInfo info;


            String path = Directory.GetCurrentDirectory();
            info = System.IO.Directory.GetParent(path);
            path = info.FullName;
            info = System.IO.Directory.GetParent(path);

            info = System.IO.Directory.GetParent(info.FullName);


            return info.FullName;
   
          }
       

        /// <summary>
        /// Metodo para ejecutar una consulta sql.
        /// </summary>
        /// <param name="sql">Instruccion sql a ejecutar.</param>
        /// <returns>Datos de tipo System.Data.OleDb.OleDbDataReader</returns>
        public System.Data.OleDb.OleDbDataReader ejecutarConsulta(String sql){

  
            System.Data.OleDb.OleDbConnection sqlConnection1 = conexion;
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            System.Data.OleDb.OleDbDataReader reader;

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
           

            //sqlConnection1.Close();

            return reader;

        }

        /// <summary>
        /// Metodo para ejecutar una sentencia sql.
        /// </summary>
        /// <param name="sql">Instruccion sql a ejecutar.</param>
        /// <returns>Int con el numero de filas modificadas.</returns>
        public int ejecutarSentencia(String sql)
        {


            System.Data.OleDb.OleDbConnection sqlConnection1 = conexion;
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
            

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int num = cmd.ExecuteNonQuery();


            // sqlConnection1.Close();

            return num;

        }


    }
}
