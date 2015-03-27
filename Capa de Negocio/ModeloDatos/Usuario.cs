using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio.ModeloDatos
{
    /// <summary>
    /// Clase de representacion para un usuario.
    /// </summary>
    public class Usuario
    {

        /// <summary>
        /// Atributo identificador del usuario.
        /// </summary>
        private Nullable<int> id;
        /// <summary>
        /// Atributo que describe el nombre del usuario.
        /// </summary>
        private String nombre;
        /// <summary>
        /// Ruta del avatar del usuario.
        /// </summary>
        private Avatar avatar;
        /// <summary>
        /// Lista de partidas del usuario.
        /// </summary>
        private List<Partida> partidas;


        /// <summary>
        /// Contructor vacio.
        /// </summary>
        public Usuario()
        {
            id = null;
            nombre = "";
            avatar = new Avatar();
            partidas = new List<Partida>();

        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="id">int identificador del usuario.</param>
        /// <param name="nombre">String nombre del usuario.</param>
        /// <param name="avatar">String ruta del avatar del usuario.</param>
        public Usuario(int id, String nombre, Avatar avatar)
        {
            this.id = id;
            this.nombre = nombre;
            this.avatar = avatar;
            partidas = new List<Partida>();

        }

        /// <summary>
        /// Metodo para obtener el identificador del usuario.
        /// </summary>
        /// <returns></returns>
        public int getId()
        {
            return id.Value;
        }

        /// <summary>
        /// Metodo para establecer el identificador del usuario.
        /// </summary>
        /// <param name="id">Int identificador del usuario.</param>
        public void setId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Metodo para obtener el nombre del usuario.
        /// </summary>
        /// <returns>String Nombre del usuario.</returns>
        public String getNombre()
        {
            return nombre;
        }

        /// <summary>
        /// Metodo para establecer el nombre del usuario.
        /// </summary>
        /// <param name="nombre">String Nombre del usuario.</param>
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Metodo para obtener la ruta del avatar del usuario.
        /// </summary>
        /// <returns>String con la ruta del avatar.</returns>
        public Avatar getAvatar()
        {
            return avatar;
        }

        /// <summary>
        /// Metodo para establecer la ruta del avatar.
        /// </summary>
        /// <param name="avatar">String ruta del avatar.</param>
        public void setAvatar(Avatar avatar)
        {
            this.avatar = avatar;
        }

        /// <summary>
        /// Metodo para insertar el usuario en la bd si existe por el contrario se actualizara su avatar.
        /// </summary>
        public void insertarUsuario()
        {
            

            //Añadir usuario y saber que identificador es para pasarsele a este usuario.

            Capa_Acceso_a_Datos.Conexion conexion = new Capa_Acceso_a_Datos.Conexion();

            System.Data.OleDb.OleDbDataReader reader = conexion.ejecutarConsulta("SELECT Id FROM USUARIOS WHERE Nombre='" + this.nombre + "'");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.id = reader.GetInt32(0);
                }
                conexion.cerrarConexion();
                conexion.ejecutarSentencia("UPDATE USUARIOS SET Avatar='" + this.avatar + "' WHERE Id=" + this.id);
                conexion.cerrarConexion();
            }
            else
            {

                this.id = conexion.ejecutarSentencia("INSERT INTO USUARIOS (Nombre, Avatar) VALUES ('" + this.nombre + "','" + this.avatar.getRuta() + "')");
                conexion.cerrarConexion();
            }
            
        }


    }
}
