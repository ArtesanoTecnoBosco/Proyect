using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio.ModeloDatos
{
    /// <summary>
    /// Clase de representacion para una partida.
    /// </summary>
    public class Partida
    {

        /// <summary>
        /// Atributo identificador de la partida.
        /// </summary>
        private Nullable<int> id;
        /// <summary>
        /// Atributo usuario que a creado la partida.
        /// </summary>
        private Usuario usuario;
        /// <summary>
        /// Atributo si el usuario ha ganado la partida o no -1 Gana 0 Pierde.
        /// </summary>
        private int ganado;
        /// <summary>
        /// Atributo que especifica el tipo de partida.
        /// </summary>
        private Tipo tipo;
        /// <summary>
        /// Atributo que especifica el nivel de la partida.
        /// </summary>
        private Nivel nivel;

        /// <summary>
        /// Constructor vacio.
        /// </summary>
        public Partida()
        {
            id = null;
            usuario = new Usuario();
            ganado = 0;
            tipo = new Tipo();
            nivel = new Nivel();
        }

        /// <summary>
        /// Contructor con parametros.
        /// </summary>
        /// <param name="id">Int - identificador de la partida.</param>
        /// <param name="usuario">Usuario - Usuario que crea la partida.</param>
        /// <param name="ganado">Ganado - Boolean true si se a ganado la partida o por el contrario false.</param>
        /// <param name="tipo">Tipo - Tipo que especifica el tipo de la partida.</param>
        /// <param name="nivel">Nivel - Nivel de la partida.</param>
        public Partida(int id, Usuario usuario, Boolean ganado, Tipo tipo, Nivel nivel)
        {
            this.id = id;
            this.usuario = usuario;
            this.ganado = 0;
            this.tipo = tipo;
            this.nivel = nivel;
        }


        /// <summary>
        /// Constructor con un parametros.
        /// </summary>
        /// <param name="nivel">Nivel - Nivel de la partida.</param>
        public Partida(Nivel nivel)
        {
            this.nivel = nivel;
        }


        /// <summary>
        /// Metodo para obtener el identificador de la partida.
        /// </summary>
        /// <returns>Int con el identificador de la partida.</returns>
        public int getId()
        {
            return id.Value;
        }

        /// <summary>
        /// Metodo para establecer el identificador de la partida.
        /// </summary>
        /// <param name="id"></param>
        public void setId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Metodo para obtener el usuario de la partida.
        /// </summary>
        /// <returns>Usuario de la partida.</returns>
        public Usuario getUsuario()
        {
            return usuario;
        }

        /// <summary>
        /// Metodo para establecer el usuario de la partida.
        /// </summary>
        /// <param name="usuario">Usuario de la partida.</param>
        public void setUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        /// <summary>
        /// Metodo para obtener si la partida se a ganado.
        /// </summary>
        /// <returns>Boolean True si ha ganado, false si a perdido.</returns>
        public int getGanado()
        {
            return ganado;
        }

        /// <summary>
        /// Metodo para establecer el atributo de si a ganado o no.
        /// </summary>
        /// <param name="ganado">Boolean true si la partida es ganada, false si la partida es perdida.</param>
        public void setGanado(int ganado)
        {
            this.ganado = ganado;
        }

        /// <summary>
        /// Metodo para obtener el tipo de partida.
        /// </summary>
        /// <returns>Objeto de tipo tipo.</returns>
        public Tipo getTipo()
        {
            return tipo;
        }

        /// <summary>
        /// Metodo para establecer el tipo de partida.
        /// </summary>
        /// <param name="tipo">Dato de tipo Tipo con el tipo de partida.</param>
        public void setTipo(Tipo tipo)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Metodo para obtener el nivel de la partida.
        /// </summary>
        /// <returns>Dato de tipo Nivel.</returns>
        public Nivel getNivel()
        {
            return nivel;
        }

        /// <summary>
        /// Metodo para establecer el nivel de la partida.
        /// </summary>
        /// <param name="nivel">Dato de tipo nivel con el nivel de la partida.</param>
        public void setNivel(Nivel nivel)
        {
            this.nivel = nivel;
        }


        public void insertarPartida()
        {
            try{

            Capa_Acceso_a_Datos.Conexion conexion = new Capa_Acceso_a_Datos.Conexion();

            String sql="SELECT Id FROM NivelesTipos WHERE IdNivel="+this.nivel.getId()+" AND IdTipo="+this.tipo.getId();
            int id=0;
            System.Data.OleDb.OleDbDataReader reader = conexion.ejecutarConsulta(sql);

            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }


            conexion.cerrarConexion();

            sql = "INSERT INTO PARTIDAS (IdUsuario,Ganado,IdNivelTipo) VALUES ('" + this.usuario.getId() + "'," + this.ganado + ","+id+")";

            int numero = conexion.ejecutarSentencia(sql);
            conexion.cerrarConexion();

            if(numero<1){
                String x = "ERROR 110\nPor favor pongase en contacto con el administrador de la aplicación.";
                throw new System.Exception(x);
            }



            }catch(Exception e){
                String x = "ERROR 109\nPor favor pongase en contacto con el administrador de la aplicación.";
                throw new System.Exception(x);
            }
    

            
        }
    }
}
