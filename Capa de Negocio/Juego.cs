using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;



namespace Capa_de_Negocio
{
    /// <summary>
    /// Modelo de datos del juego.
    /// </summary>
    public class Juego
    {
        /// <summary>
        /// Contador de la barra de progreso.
        /// </summary>
        public static int contadorBarra =0;
        /// <summary>
        /// Avatares del juego
        /// </summary>
        private List<ModeloDatos.Avatar> avatares;
        /// <summary>
        /// Partidas del juego(Se utilizara mas que otra cosa para estadisticas).
        /// </summary>
        private List<ModeloDatos.Partida> partidas;
        /// <summary>
        /// Niveles del juego.
        /// </summary>
        private List<ModeloDatos.Nivel> niveles;
        /// <summary>
        /// Usuario que juega.
        /// </summary>
        private ModeloDatos.Usuario usuario;
        /// <summary>
        /// Conexion a la BD.
        /// </summary>
        private Capa_Acceso_a_Datos.Conexion conexion;


        /// <summary>
        /// Constructor.
        /// </summary>
        public Juego()
        {
            avatares = new List<ModeloDatos.Avatar>();
            partidas = new List<ModeloDatos.Partida>();
            niveles = new List<ModeloDatos.Nivel>();
            usuario = new ModeloDatos.Usuario();
            conexion = new Capa_Acceso_a_Datos.Conexion();
        }


        /// <summary>
        /// Metodo para cargar los niveles en memoria.
        /// </summary>
        /// <param name="rutaPadre">Directorio en el que se encuentra el programa.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo para comprobar que existen los avatares.
        /// </summary>
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

        /// <summary>
        /// Metodo para obtener el directorio raiz del proyecto.
        /// </summary>
        /// <returns>String - Directorio raiz del proyecto.</returns>
        private String directorioPadre()
        {
            DirectoryInfo info;
            String path = Directory.GetCurrentDirectory();
            info = System.IO.Directory.GetParent(path);
            info = System.IO.Directory.GetParent(info.FullName);
            return info.FullName;
        }

        /// <summary>
        /// Metodo para buscar un nivel.
        /// </summary>
        /// <param name="nombre">Nombre del nivel.</param>
        /// <returns>Nivel - Nivel encontrado.</returns>
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

      

        /// <summary>
        /// Metodo para obtener los usuarios.
        /// </summary>
        /// <returns>Usuario - Usuario que juega.</returns>
        public ModeloDatos.Usuario getUsuario()
        {
            return usuario;
        }

        /// <summary>
        /// Metodo para establecer el usuario del juego.
        /// </summary>
        /// <param name="usuario">Usuario - Usuario del juego.</param>
        public void setUsuario(ModeloDatos.Usuario usuario)
        {
            this.usuario = usuario;
        }

        /// <summary>
        /// Metodo para obtener las partidas del juego. Principalmente se utilizara para estadisticas.
        /// </summary>
        /// <returns>Lista de partidas.</returns>
        public List<ModeloDatos.Partida> getPartidas()
        {
            return this.partidas;
        }

        /// <summary>
        /// Metodo para obtener el listado de avatares.
        /// </summary>
        /// <returns>Lista de avatares.</returns>
        public List<ModeloDatos.Avatar> getAvatares()
        {
            return this.avatares;
            
        }

        /// <summary>
        /// Metodo para obtener un unico avatar,.
        /// </summary>
        /// <param name="pos">Posicion del avatar a devolver.</param>
        /// <returns>Avatar - Un avatar.</returns>
        public ModeloDatos.Avatar getUnAvatar(int pos)
        {

            return this.avatares.ElementAt(pos);

        }

        /// <summary>
        /// Metodo para obtener el listado de niveles.
        /// </summary>
        /// <returns>Lista con los niveles.</returns>
        public List<ModeloDatos.Nivel> getNiveles()
        {
            return niveles;
        }

        /// <summary>
        /// Metodo para obtener un unico nivel.
        /// </summary>
        /// <param name="pos">Posicion en la lista del nivel a devolver.</param>
        /// <returns>Nivel - Nivel de juego.</returns>
        public ModeloDatos.Nivel getUnNivel(int pos)
        {
            return niveles.ElementAt(pos);
        }

        public String obtenerEstadistica(String nivel)
        {
            String salida;
            int total=0;
            int ganadas = 0;
            int perdidas = 0;
            String sql;
            System.Data.OleDb.OleDbDataReader reader;
            List<int> ids= new List<int>();
            
            //OBTENER LOS ID DE LOS NIVELESTIPOS
            sql = "SELECT Id FROM NivelesTipos WHERE IdNivel=" + this.buscarNivel(nivel).getId();
            reader = conexion.ejecutarConsulta(sql);


            while(reader.Read()){
                ids.Add(reader.GetInt32(0));

            }
            conexion.cerrarConexion();

            //OBTENER EL TOTAL DE PARTIDAS
            sql = "Select count(Ganado) from PARTIDAS WHERE IdUsuario =" + this.usuario.getId() + " AND (IdNivelTipo="
                + ids.ElementAt(0);

            for (int pos = 1; pos < ids.Count; pos++)
            {

                sql = sql + " OR IdNivelTipo=" + ids.ElementAt(pos);

            }

            sql = sql + ")";
            reader = conexion.ejecutarConsulta(sql);



            while (reader.Read())
            {
                total = reader.GetInt32(0);
            }

            conexion.cerrarConexion();

            //OBTENER PARTIDAS GANADAS.
            sql = "Select count(Ganado) from PARTIDAS WHERE IdUsuario =" + this.usuario.getId() +"AND Ganado=0  AND (IdNivelTipo="
                + ids.ElementAt(0);

            for (int pos = 1; pos < ids.Count; pos++)
            {

                sql = sql + " OR IdNivelTipo=" + ids.ElementAt(pos);

            }

            sql = sql + ")";
            reader = conexion.ejecutarConsulta(sql);



            while (reader.Read())
            {
                ganadas = reader.GetInt32(0);
            }

            conexion.cerrarConexion();

            //OBTENER PARTIDAS PERDIDAS.

            sql = "Select count(Ganado) from PARTIDAS WHERE IdUsuario =" + this.usuario.getId() + "AND Ganado=-1  AND (IdNivelTipo="
               + ids.ElementAt(0);

            for (int pos = 1; pos < ids.Count; pos++)
            {

                sql = sql + " OR IdNivelTipo=" + ids.ElementAt(pos);

            }

            sql = sql + ")";
            reader = conexion.ejecutarConsulta(sql);



            while (reader.Read())
            {
                perdidas = reader.GetInt32(0);
            }

            conexion.cerrarConexion();





            salida ="Total partidas: " + total.ToString() +"\n"
                    + "Partidas Ganadas: " + ganadas.ToString() + "(";

            decimal porciento = (Convert.ToDecimal(ganadas) /Convert.ToDecimal(total)) * 100;

            salida = salida + Convert.ToInt32(porciento) + "%)\n"
                       + "Partidas Perdidas: " + perdidas.ToString() + "(";

            porciento = (Convert.ToDecimal(perdidas) / Convert.ToDecimal(total)) * 100;

            salida = salida + Convert.ToInt32(porciento) + "%)";

            return salida;
        }

    }
}
