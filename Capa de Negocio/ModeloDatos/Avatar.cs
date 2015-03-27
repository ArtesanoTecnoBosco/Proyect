using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio.ModeloDatos
{
    /// <summary>
    /// Clase Modelo de datos Avatar.
    /// </summary>
    public class Avatar
    {
        /// <summary>
        /// Identificador del avatar.
        /// </summary>
        private Nullable<int> id;
        /// <summary>
        /// Ruta del avatar.
        /// </summary>
        private String ruta;

        /// <summary>
        /// Constructor vacio.
        /// </summary>
        public Avatar()
        {
            this.id = null;
            this.ruta = "";
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="id">Identificador del avatar.</param>
        /// <param name="ruta">Ruta del avatar</param>
        public Avatar(int id, String ruta)
        {
            this.id = id;
            this.ruta = ruta;
        }

        /// <summary>
        /// Metodo para obtener el identificador del avatar.
        /// </summary>
        /// <returns>Int - Identificador del avatar.</returns>
        public Nullable<int> getId()
        {
            return id;
        }

        /// <summary>
        /// Metodo para establecer el identificador del avatar.
        /// </summary>
        /// <param name="id">Int Identificador del avatar.</param>
        public void setId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Metodo para obtener la ruta del avatar.
        /// </summary>
        /// <returns>String - Ruta del avatar.</returns>
        public String getRuta()
        {
            return ruta;
        }

        /// <summary>
        /// Metodo para establecer la ruta del avatar.
        /// </summary>
        /// <param name="ruta">String - Ruta del avatar.</param>
        public void setRuta(String ruta)
        {
            this.ruta = ruta;
        }

        
    }
}
