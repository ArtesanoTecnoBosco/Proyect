using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace Capa_de_Negocio
{
    public class Juego
    {

        public static int contadorBarra =0;


        List<ModeloDatos.Partida> partidas;
        List<ModeloDatos.Nivel> niveles;
        ModeloDatos.Usuario usuario;
        Capa_Acceso_a_Datos.Conexion conexion;



        public Juego()
        {
            partidas = new List<ModeloDatos.Partida>();
            niveles = new List<ModeloDatos.Nivel>();
            usuario = new ModeloDatos.Usuario();
            conexion = new Capa_Acceso_a_Datos.Conexion();
        }

        

        /// <summary>
        /// Metodo para cargar los niveles de la partida.
        /// </summary>
        public void cargarNiveles()
        {

            System.Data.OleDb.OleDbDataReader reader =conexion.ejecutarConsulta("Select IdNivel, Nombre from NIVELES");
            Capa_Acceso_a_Datos.Conexion conexion2;
            Capa_Acceso_a_Datos.Conexion conexion3;
            System.Data.OleDb.OleDbDataReader reader2;
            System.Data.OleDb.OleDbDataReader reader3;
            List<Capa_de_Negocio.ModeloDatos.Tipo> tipos;
            conexion2 = new Capa_Acceso_a_Datos.Conexion();
            conexion3 = new Capa_Acceso_a_Datos.Conexion();
       


            while (reader.Read())
            {
                

                niveles.Add(new ModeloDatos.Nivel(reader.GetInt32(0),reader.GetString(1)));

                
                reader2 = conexion2.ejecutarConsulta("Select IdTipo FROM NivelesTipos WHERE IdNivel=" + reader.GetInt32(0));

                tipos= new List<ModeloDatos.Tipo>();


                while (reader2.Read())
                {

                    reader3 = conexion3.ejecutarConsulta("Select IdTipo, Nombre FROM TIPOS WHERE IdTipo=" + Convert.ToInt32(reader2.GetValue(0)));

                    while (reader3.Read())
                    {


                        tipos.Add(new Capa_de_Negocio.ModeloDatos.Tipo(reader3.GetInt32(0), reader3.GetString(1)));

                    }

                    conexion3.cerrarConexion();
                }
                niveles.ElementAt(niveles.Count - 1).setTipos(tipos);

                conexion2.cerrarConexion();
            }
            
            conexion.cerrarConexion();
            
            

        }
    }
}
