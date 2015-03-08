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
        private String avatar;
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
            avatar = "";
            partidas = new List<Partida>();

        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="id">int identificador del usuario.</param>
        /// <param name="nombre">String nombre del usuario.</param>
        /// <param name="avatar">String ruta del avatar del usuario.</param>
        public Usuario(int id, String nombre, String avatar)
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
        public String getAvatar()
        {
            return avatar;
        }

        /// <summary>
        /// Metodo para establecer la ruta del avatar.
        /// </summary>
        /// <param name="avatar">String ruta del avatar.</param>
        public void setAvatar(String avatar)
        {
            this.avatar = avatar;
        }
 



    }
}
