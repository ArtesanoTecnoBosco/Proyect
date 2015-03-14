using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;



namespace Capa_de_Negocio
{
    public class Juego
    {

        public static int contadorBarra =0;

        private List<ModeloDatos.Avatar> avatares;
        private List<ModeloDatos.Partida> partidas;
        private List<ModeloDatos.Nivel> niveles;
        private ModeloDatos.Usuario usuario;
        private Capa_Acceso_a_Datos.Conexion conexion;



        public Juego()
        {
            avatares = new List<ModeloDatos.Avatar>();
            partidas = new List<ModeloDatos.Partida>();
            niveles = new List<ModeloDatos.Nivel>();
            usuario = new ModeloDatos.Usuario();
            conexion = new Capa_Acceso_a_Datos.Conexion();
        }



        public int cargarAvatares(String rutaPadre)
        {
            
            
          

            System.Data.OleDb.OleDbDataReader reader = conexion.ejecutarConsulta("Select Id,Ruta from AVATARES");

            while (reader.Read())
            {

                avatares.Add(new Capa_de_Negocio.ModeloDatos.Avatar(reader.GetInt32(0), reader.GetString(1)));


            }


            conexion.cerrarConexion();

            return avatares.Count();
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

        public void comprobarImagenes()
        {

            for (int pos = 0; pos < this.avatares.Count; pos++)
            {

                if (!File.Exists(directorioPadre() + this.avatares.ElementAt(pos).getRuta()))
                {
                    this.avatares.RemoveAt(pos);
                }

            }

        }

        private String directorioPadre()
        {
            DirectoryInfo info;
            String path = Directory.GetCurrentDirectory();
            info = System.IO.Directory.GetParent(path);
            info = System.IO.Directory.GetParent(info.FullName);
            return info.FullName;
        }


        public Capa_de_Negocio.ModeloDatos.Nivel buscarNivel(String nombre){

            Capa_de_Negocio.ModeloDatos.Nivel n = new ModeloDatos.Nivel();

            int pos = 0;
            Boolean encontrado = false;

            while (!encontrado && this.niveles.Count() > pos)
            {

                if (this.niveles.ElementAt(pos).getNombre().Equals(nombre))
                {

                    encontrado = true;
                    n = this.niveles.ElementAt(pos);

                }
                else
                {
                    pos++;
                }


            }

            if (!encontrado)
            {
                String x = "ERROR 103\nPor favor pongase en contacto con el administrador de la aplicación.";

                throw new System.Exception(x);
            }

            return n;
        }


        public ModeloDatos.Usuario getUsuario()
        {
            return usuario;
        }


        public void setUsuario(ModeloDatos.Usuario usuario)
        {
            this.usuario = usuario;
        }


        public List<ModeloDatos.Partida> getPartidas()
        {
            return this.partidas;
        }


        public List<ModeloDatos.Avatar> getAvatares()
        {
            return this.avatares;
            
        }
    }
}
