using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio.ModeloDatos
{
    /// <summary>
    /// Modelo de datos de una pregunta.
    /// </summary>
    public class Pregunta
    {
        /// <summary>
        /// Identificador de la pregunta.
        /// </summary>
        private int id;
        /// <summary>
        /// Identificador del tipo.
        /// </summary>
        private int idTipo;
        /// <summary>
        /// Nombre de la pregunta.
        /// </summary>
        private String nombre;
        /// <summary>
        /// Ruta de la imagen de la pregunta.
        /// </summary>
        private String imagen;
        /// <summary>
        /// Ruta del sonido de la pregunta.
        /// </summary>
        private String sonido;
        /// <summary>
        /// Ruta del video de la pregunta.
        /// </summary>
        private String video;
        /// <summary>
        /// Etiqueta del objeto.
        /// </summary>
        private String tag;
       
        /// <summary>
        /// Constructor vacio.
        /// </summary>
        public Pregunta()
        {
        
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="id">Identificador de la pregunta.</param>
        /// <param name="idTipo">Identificador del tipo.</param>
        /// <param name="nombre">Nombre de la pregunta.</param>
        /// <param name="imagen">Ruta de la imagen.</param>
        /// <param name="sonido">Ruta del sonido.</param>
        /// <param name="video">Ruta del video.</param>
        /// <param name="tag">Nombre de la etiqueta.</param>
        public Pregunta(int id, int idTipo, String nombre, String imagen, String sonido, String video, String tag)
        {
            this.id = id;
            this.idTipo = idTipo;
            this.nombre = nombre;
            this.imagen = imagen;
            this.sonido = sonido;
            this.video = video;
            this.tag = tag;
        }

        /// <summary>
        /// Metodo para obtener el identificador de la pregunta.
        /// </summary>
        /// <returns>Int - Identificador de la pregunta.</returns>
        public int getId()
        {
            return id;
        }

        /// <summary>
        /// Metodo para establecer el identificador de la pregunta.
        /// </summary>
        /// <param name="id">Int - Identificador de la pregunta.</param>
        public void setId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Metodo para obtener el identificador del tipo de la pregunta.
        /// </summary>
        /// <returns>Int - Identificador del tipo.</returns>
        public int getIdTipo()
        {
            return idTipo;
        }

        /// <summary>
        /// Metodo para establecer el identificador del tipo.
        /// </summary>
        /// <param name="idTipo">Int - Identificador del tipo.</param>
        public void setIdTipo(int idTipo)
        {
            this.idTipo = idTipo;
        }

        /// <summary>
        /// Metodo para obtener el nombre de la pregunta.
        /// </summary>
        /// <returns>String - Nombre de la pregunta.</returns>
        public String getNombre()
        {
            return nombre;
        }

        /// <summary>
        /// Metodo para establecer el nombre de la pregunta.
        /// </summary>
        /// <param name="nombre">String - Nombre de la pregunta.</param>
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Metodo para obtener la etiqueta del objeto.
        /// </summary>
        /// <returns>String - Etiqueta del objeto. </returns>
        public String getTag()
        {
            return tag;
        }

        /// <summary>
        /// Metodo para establecer la etiqueta del objeto.
        /// </summary>
        /// <param name="tag">String - Etiqueta del objeto.</param>
        public void setTag(String tag)
        {
            this.tag = tag;
        }

        /// <summary>
        /// Metodo para obtener la ruta de la imagen.
        /// </summary>
        /// <returns>String - Ruta de la imagen.</returns>
        public String getImagen()
        {
            return imagen;
        }

        /// <summary>
        /// Metodo para establecer la ruta de la imagen.
        /// </summary>
        /// <param name="imagen">String - Ruta de la imagen.</param>
        public void setImagen(String imagen)
        {
            this.imagen = imagen;
        }

        /// <summary>
        /// Metodo para obtener el sonido de la pregunta.
        /// </summary>
        /// <returns>String - Sonido de la pregunta.</returns>
        public String getSonido()
        {
            return sonido;
        }

        /// <summary>
        /// Metodo para establecer el sonido de la pregunta.
        /// </summary>
        /// <param name="sonido">String - Ruta del sonido de la pregunta.</param>
        public void setSonido(String sonido)
        {
            this.sonido = sonido;
        }

        /// <summary>
        /// Metodo para obtener el video de la pregunta.
        /// </summary>
        /// <returns>String - Ruta de la pregunta.</returns>
        public String getVideo()
        {
            return video;
        }

        /// <summary>
        /// Metodo para establecer la ruta de la pregunta.
        /// </summary>
        /// <param name="video">String - Ruta del video de la pregunta.</param>
        public void setVideo(String video)
        {
            this.video = video;
        }


        /// <summary>
        /// Metodo para cargar una pregunta aleatoria de la bd a la pregunta.
        /// </summary>
        /// <param name="tipo">Tipo de pregunta que equivale al panel a cargar.</param>
        public void cargarPregunta(int tipo)
        {
            Capa_Acceso_a_Datos.Conexion conexion = new Capa_Acceso_a_Datos.Conexion();

            System.Data.OleDb.OleDbDataReader reader = conexion.ejecutarConsulta("SELECT top 1 Id, IdTipo, Nombre, Imagen, Video, Sonido, TagSeleccion FROM PREGUNTAS_TIPO WHERE IdTipo=" + tipo + " ORDER BY rnd(INT(NOW*Id)-NOW*Id)");

            while (reader.Read())
            {

                this.id = reader.GetInt32(0);
                this.idTipo = reader.GetInt32(1);
                this.nombre = reader.GetString(2);
                this.imagen = reader.GetString(3);
                this.video = reader.GetString(4);
                this.sonido = reader.GetString(5);
                this.tag = reader.GetString(6);

            }

            conexion.cerrarConexion();
        }
    }
}
