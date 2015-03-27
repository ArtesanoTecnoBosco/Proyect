using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aprendo_con_Molly
{
	/// <summary>
	/// Lógica de interacción para colores.xaml
	/// </summary>
	public partial class colores : Window
	{
        /// <summary>
        /// Estructura del juego donde se almacen todos los datos y se pasa entre ventanas.
        /// </summary>
        private Capa_de_Negocio.Juego juego;
        
        /// <summary>
        /// Contructor vacio.
        /// </summary>
		public colores()
		{
			this.InitializeComponent();
						
		}

        /// <summary>
        /// Contructor con parametros.
        /// </summary>
        /// <param name="panel">Numero de panel a mostrar (Tiene que ver con el nivel seleccionado)</param>
        /// <param name="juego">Dato de tipo juego con la estructura del juego USUARIO, NIVELES, etc.</param>
        public colores(int panel,Capa_de_Negocio.Juego juego)
        {
            this.InitializeComponent();
            mostrarPanel(panel);
            this.juego = juego;            
        }


        /// <summary>
        /// Metodo para seleccionar que panel debe mostrarse.
        /// </summary>
        /// <param name="panel"></param>
        private void mostrarPanel(int panel)
        {

            switch (panel)
            {
                //MODO FACIL,MEDIO,DIFICIL
                case 1:
                    bolitas.Opacity = 100;
                    bolitas.Visibility = System.Windows.Visibility.Visible;
                    break;

                case 2:
                    letras.Opacity = 100;
                    letras.Visibility = System.Windows.Visibility.Visible;
                    break;
                //FIN MODO FACIL
                
                case 3:
                    //NUMEROS.
                    break;

                case 4:
                    //OBJETOS
                    break;
            
                case 5:
                    //SUMAR
                    break;

                case 6:
                    //RESTAR
                    break;                 
            }
           
        }




	}
}