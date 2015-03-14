using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio.ModeloDatos
{
    /// <summary>
    ///Clase de representacion de un tipo de la base de datos. 
    /// </summary>
     public class Tipo
    {

        /// <summary>
        /// Propiedad que identifica el tipo.
        /// </summary>
        private Nullable<int> id;
        /// <summary>
        /// Propiedad que describe el tipo.
        /// </summary>
        private String nombre;

        /// <summary>
        /// Constructor vacio.
        /// </summary>
        public Tipo()
        {
            id = null;
            nombre = "";
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="id">Int Identificador del tipo.</param>
        /// <param name="nombre">String nombre del tipo.</param>
        public Tipo(int id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;

        }

        /// <summary>
        /// Metodo para obtener el identificador del tipo.
        /// </summary>
        /// <returns>int con el identificador del tipo.</returns>
        public int getId()
        {
            return id.Value;
        }

        /// <summary>
        /// Metodo para establecer el identificador.
        /// </summary>
        /// <param name="id">Int con el identificador del tipo.</param>
        public void setId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Metodo para obtener el nombre del tipo.
        /// </summary>
        /// <returns>String con el nombre del tipo.</returns>
        public String getNombre()
        {
            return nombre;
        }


        /// <summary>
        /// Metodo para establecer el nombre del tipo.
        /// </summary>
        /// <param name="nombre">String con el nombre del tipo.</param>
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }



















    }
}
