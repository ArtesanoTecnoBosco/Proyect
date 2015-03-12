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
using System.Text.RegularExpressions;

namespace Aprendo_con_Molly
{
	/// <summary>
	/// Lógica de interacción para jUGADORES.xaml
	/// </summary>
	public partial class jUGADORES : Window
	{
        Capa_de_Negocio.Juego juego;


		public jUGADORES(Capa_de_Negocio.Juego juego)
		{
            this.InitializeComponent();
            this.juego = juego;

            if (this.juego == null)
            {
               String x = "ERROR 102\nPor favor pongase en contacto con el administrador de la aplicación.";

                throw new System.Exception(x);

            }

           
          

			
		}


        /// <summary>
        /// Metodo de accion al hacer click en el boton de cerrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            this.WindowState = WindowState.Minimized;

        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {


            String usuario = txtUsuario.Text;

            if (usuario.Equals(""))
            {

                bocadillo.Content = "Dime tu nombre por favor";
                /**
                 *  ANIMACION NOMBRE.
                 * 
                 * */

            }
            else
            {

                if (nombreEsReal(usuario))
                {
                    Capa_de_Negocio.ModeloDatos.Usuario auxUsu = new Capa_de_Negocio.ModeloDatos.Usuario();

                    auxUsu.setNombre(usuario);


                    Nombre.Opacity = 0;
                    Nombre.Visibility = System.Windows.Visibility.Hidden;

                    NIVELES.Visibility = System.Windows.Visibility.Visible;
                    NIVELES.Opacity = 100;

                }
                else
                {

                    bocadillo.Content = "Dime tu nombre de verdad";

                }

      

            }

        }


        private Boolean nombreEsReal(String nombre)
        {
            Boolean real =true;

            
            char [] x = nombre.ToCharArray();

            int pos=0;

            while(pos<x.Length && real){

                if (Char.IsLetter(x[pos]) ||(int)x[pos]==32)
                {
                    pos++;
                }
                else
                {
                    real = false;
                }
                               
            }


            return real;

        }



	}
}