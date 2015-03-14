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
        Capa_de_Negocio.ModeloDatos.Usuario auxUsu;


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

        private void seleccionarCuadroUsuario()
        {

            txtUsuario.Text = "";
            txtUsuario.Focus();

        }


        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {

            

            //Si el panel nombre es visible almacenar nombre y pasar el panel.
            if (Nombre.Visibility == System.Windows.Visibility.Visible) {   

                String usuario = txtUsuario.Text;

                //Compruebo si no hay ningun nombre introducido.
                if (usuario.Equals("") || usuario.Trim().Equals(""))
                {

                    bocadillo.Content = "Dime tu nombre\n por favor";
                    seleccionarCuadroUsuario();

                    /**
                     *  ANIMACION NOMBRE.
                     * 
                     * */

                }
                else
                {
                    //Se comprueba que lo que introduce el usuario son letra, algun espacio o acentos.
                    if (nombreEsReal(usuario))
                    {

                        auxUsu = new Capa_de_Negocio.ModeloDatos.Usuario();
                        auxUsu.setNombre(usuario);


                        Nombre.Opacity = 0;
                        Nombre.Visibility = System.Windows.Visibility.Hidden;

                        NIVELES.Visibility = System.Windows.Visibility.Visible;
                        NIVELES.Opacity = 100;

                        bocadillo.Content = "Selecciona un nivel\n de dificultad";

                    }
                    else
                    {

                        bocadillo.Content = "Dime tu nombre\n de verdad";
                        seleccionarCuadroUsuario();

                        /**
                         * ANIMACION NOMBRE
                         * 
                         * */

                    }

                }

            }
            //Si el panel de niveles esta visible y el de nombre oculto guardar la dificultad seleccionada.
            else if (Nombre.Visibility == System.Windows.Visibility.Hidden && NIVELES.Visibility == System.Windows.Visibility.Visible)
            {


                try
                {

                    if (rdbBajo.IsChecked == true)
                    {

                        crearPartidaNivel("Principiante");

                    }
                    else if (rdbMedio.IsChecked == true)
                    {

                        crearPartidaNivel("Medio");

                    }
                    else if (rdbAlto.IsChecked == true) 
                    {
                        crearPartidaNivel("Avanzado");
                    }
                    else
                    {
                        bocadillo.Content="Por favor,\n selecciona un nivel.";

                        /**
                         * ANIMACION SELECCION DE NIVEL.
                         * */

                    }

                }
                catch (Exception ex)
                {

                    Inicio.crearEmergente(ex.Message);

                }

            }

        }



        /// <summary>
        /// Metodo que crea la partida con su nivel.
        /// </summary>
        /// <param name="nombreNivel">Nombre del nivel a crear.</param>
        private void crearPartidaNivel(String nombreNivel)
        {


            this.juego.getPartidas().Add(new Capa_de_Negocio.ModeloDatos.Partida(this.juego.buscarNivel(nombreNivel)));

            //Ocultar panel niveles.
            NIVELES.Visibility = System.Windows.Visibility.Hidden;
            NIVELES.Opacity = 0;

            //Mostrar panel de los avatares.
            imagenNene.Visibility = System.Windows.Visibility.Visible;
            imagenNene.Opacity = 100;


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