using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio.ModeloDatos
{
    /// <summary>
    ///Clase de representacion de un nivel de la base de datos. 
    /// </summary>
    class Nivel
    {

        /// <summary>
        /// Propiedad o atributo que Identifica el nivel.
        /// </summary>
        private Nullable<int> id;
        /// <summary>
        /// Propiedad o atributo que describe el nombre del nivel.
        /// </summary>
        private String nombre;
        /// <summary>
        /// Lista de los tipo de juego por nivel.
        /// </summary>
        private List<Tipo> tipos;



        /// <summary>
        /// Constructor vacio.
        /// </summary>
        public Nivel()
        {

            this.id = null;
            this.nombre = "";
            tipos = new List<Tipo>();

        }

        /// <summary>
        /// Contructor con parametros.
        /// </summary>
        /// <param name="id">Identificador del nivel.</param>
        /// <param name="nombre">Nombre del nivel.</param>
        public Nivel(int id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
            tipos = new List<Tipo>();

        }


        /// <summary>
        /// Metodo para obtener el identificador del nivel. 
        /// </summary>
        /// <returns>Int con el identicador.</returns>
        public int getId()
        {
            return id.Value;
        }


        /// <summary>
        /// Metodo para establecer el identificador del nivel.
        /// </summary>
        /// <param name="id">Int con Identificador del nivel.</param>
        public void setId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Metodo para obtener el nombre o la descripcion del nivel.
        /// </summary>
        /// <returns>String con el nombre del nivel.</returns>
        public String getNombre()
        {
            return nombre;
        }


        /// <summary>
        /// Metodo para establecer el nombre del nivel.
        /// </summary>
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Metodo para establecer el tipo de juego por nivel.
        /// </summary>
        /// <param name="tipos">List con los tipos de juego.</param>
        public void setTipos(List<Tipo> tipos)
        {
            this.tipos = tipos;
        }

        /// <summary>
        /// Metodo para obtener la lista de tipos de juego por el nivel.
        /// </summary>
        /// <returns>List<Juegos>Lista de tipos de juego de este nivel.</returns>
        public List<Tipo> getTipos()
        {
            return tipos;
        }

    }
}
