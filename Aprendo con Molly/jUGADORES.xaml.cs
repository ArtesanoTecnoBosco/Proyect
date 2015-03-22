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
using System.IO;
using System.Windows.Media.Animation;

namespace Aprendo_con_Molly
{
	/// <summary>
	/// Lógica de interacción para jUGADORES.xaml
	/// </summary>
	public partial class jUGADORES : Window
	{
        private Capa_de_Negocio.Juego juego;
        private Capa_de_Negocio.ModeloDatos.Usuario auxUsu;
        private int posicionAvatar;


		public jUGADORES(Capa_de_Negocio.Juego juego)
		{
            this.InitializeComponent();
            this.posicionAvatar = 0;
            this.juego = juego;            

            //Compruebo si hemos tenido algun problema al cargar el juego para mandar un error.
            if (this.juego == null)
            {
               String x = "ERROR 102\nPor favor pongase en contacto con el administrador de la aplicación.";

                throw new System.Exception(x);

            }

            //Fuerzo a que el txt obtenga el foco.
            txtUsuario.Focus();
			
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

            //Quitar bocadillo
            bocadillo.Visibility = System.Windows.Visibility.Hidden;

            //Mostrar panel de los avatares.
            imagenNene.Visibility = System.Windows.Visibility.Visible;
            imagenNene.Opacity = 100;


            /**Iniciar Animacion**/
            Storyboard animacion = new Storyboard();
            animacion = (Storyboard)FindResource("EfectoFondoCentro");
            animacion.Begin();


            //Cargo imagenes estaticas en los paneles.
            imgCentro.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + this.juego.getUnAvatar(posicionAvatar).getRuta(), UriKind.Relative)));
            imgIzda.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + this.juego.getUnAvatar(this.juego.getAvatares().Count-1).getRuta(), UriKind.Relative)));
            imgDcha.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + this.juego.getUnAvatar(posicionAvatar+1).getRuta(), UriKind.Relative)));


        }

        private String directorioPadre()
        {
            DirectoryInfo info;
            String path = Directory.GetCurrentDirectory();
            info = System.IO.Directory.GetParent(path);
            info = System.IO.Directory.GetParent(info.FullName);
            return info.FullName;
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

        /// <summary>
        /// Accion del boton derecho de los avatares (Ir hacia delante).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)

        {

            delante();


        }


        private void delante()
        {
            posicionAvatar = posicionAvatar - 1;

            if (posicionAvatar < 0)
            {

                posicionAvatar = this.juego.getAvatares().Count - 1;

            }

            //Cargo imagen centro.
            imgCentro.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + this.juego.getUnAvatar(posicionAvatar).getRuta(), UriKind.Relative)));


            int auxiliar = posicionAvatar;

            if (posicionAvatar - 1 < 0)
            {
                auxiliar = this.juego.getAvatares().Count - 1;
            }
            else
            {
                auxiliar = auxiliar - 1;
            }


            imgIzda.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + this.juego.getUnAvatar(auxiliar).getRuta(), UriKind.Relative)));


            auxiliar = posicionAvatar + 1;

            if (auxiliar > this.juego.getAvatares().Count - 1)
            {
                auxiliar = 0;
            }


            //Cargo imagen derecha.
            imgDcha.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + this.juego.getUnAvatar(auxiliar).getRuta(), UriKind.Relative)));
        }



        /// <summary>
        /// Accion del boton izquierdo de los avatares (Ir hacia atras).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            atras();


        }

        private void atras()
        {
            posicionAvatar = posicionAvatar + 1;

            if (posicionAvatar > this.juego.getAvatares().Count - 1)
            {

                posicionAvatar = 0;

            }

            //Cargo imagen centro.
            imgCentro.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + this.juego.getUnAvatar(posicionAvatar).getRuta(), UriKind.Relative)));

            int auxiliar = posicionAvatar;

            if (posicionAvatar + 1 > this.juego.getAvatares().Count - 1)
            {
                auxiliar = 0;
            }
            else
            {
                auxiliar = auxiliar + 1;
            }

            //Cargo imagen derecha.
            imgDcha.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + this.juego.getUnAvatar(auxiliar).getRuta(), UriKind.Relative)));


            auxiliar = posicionAvatar - 1;

            if (posicionAvatar - 1 < 0)
            {
                auxiliar = this.juego.getAvatares().Count - 1;
            }


            imgIzda.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + this.juego.getUnAvatar(auxiliar).getRuta(), UriKind.Relative)));

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (imagenNene.Visibility == System.Windows.Visibility.Visible)
            {

                //Sì pulsa la tecla izquierda.
                if (e.Key == Key.Left)
                {

                    atras();

                }

                //`Si pulsa derecha.
                if (e.Key == Key.Right)
                {

                    delante();

                }
            }
        }

        private void imgCentro_MouseDown(object sender, MouseButtonEventArgs e)
        {

            //Guardar datos del usuario.            
            this.auxUsu.setAvatar(this.juego.getUnAvatar(posicionAvatar));
            this.auxUsu.insertarUsuario();



            this.juego.setUsuario(auxUsu);

            //Mostrar animacion de selección.



            //Cargar ventana del juego.
            //Crear contador de tiempo y cuando finalice que cargue la ventana.
            colores ventana = new colores();
            ventana = new colores();
            ventana.Show();

            this.Close();
            




        }



	}
}