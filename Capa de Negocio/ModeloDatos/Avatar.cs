using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio.ModeloDatos
{
    public class Avatar
    {

        private Nullable<int> id;
        private String ruta;

        public Avatar()
        {
            this.id = null;
            this.ruta = "";
        }

        public Avatar(int id, String ruta)
        {
            this.id = id;
            this.ruta = ruta;
        }


        public Nullable<int> getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getRuta()
        {
            return ruta;
        }

        public void setRuta(String ruta)
        {
            this.ruta = ruta;
        }

        
    }
}
