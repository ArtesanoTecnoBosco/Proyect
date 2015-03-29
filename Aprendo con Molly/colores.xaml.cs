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
using System.IO;
using System.Windows.Media.Animation;
using System.Media;

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
        private Capa_de_Negocio.ModeloDatos.Pregunta pregunta;

       
        

        /// <summary>
        /// Contructor vacio.
        /// </summary>
		public colores()
		{
			this.InitializeComponent();
            pregunta = new Capa_de_Negocio.ModeloDatos.Pregunta();
            btnJugar.Visibility = System.Windows.Visibility.Hidden;
						
		}

        /// <summary>
        /// Contructor con parametros.
        /// </summary>
        /// <param name="panel">Numero de panel a mostrar (Tiene que ver con el nivel seleccionado)</param>
        /// <param name="juego">Dato de tipo juego con la estructura del juego USUARIO, NIVELES, etc.</param>
        public colores(int panel,Capa_de_Negocio.Juego juego)
        {
            this.InitializeComponent();
            btnJugar.Visibility = System.Windows.Visibility.Hidden;
            


            this.juego = juego;

            //Consulta para sacar una pregunta del tipo (panel).
            pregunta = new Capa_de_Negocio.ModeloDatos.Pregunta();
            mostrarPanel(1);
            
            
           

        }


        /// <summary>
        /// Metodo para seleccionar que panel debe mostrarse.
        /// </summary>
        /// <param name="panel"></param>
        private void mostrarPanel(int panel)
        {

            pregunta.cargarPregunta(panel);

            switch (panel)
            {
                //MODO FACIL,MEDIO,DIFICIL
                case 1:
                    bolitas.Opacity = 100;
                    bolitas.Visibility = System.Windows.Visibility.Visible;
                    //Cargo imagen del centro y demas.
                    cargarPreguntaBolas();
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
                //FIN MODO MEDIO
                case 5:
                    //SUMAR
                    break;

                case 6:
                    //RESTAR
                    break;      
                //FIN MODO AVANZADO
            }

            
           
        }






        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void cargarPreguntaBolas()
        {
            espacioJuego.Opacity = 100;
            espacioJuego.Visibility = System.Windows.Visibility.Visible;
            espacioJuego.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + pregunta.getImagen(), UriKind.Relative)));


        }


        /// <summary>
        /// Metodo para saber el directorio padre.
        /// </summary>
        /// <returns></returns>
        private String directorioPadre()
        {
            DirectoryInfo info;
            String path = Directory.GetCurrentDirectory();
            info = System.IO.Directory.GetParent(path);
            info = System.IO.Directory.GetParent(info.FullName);
            return info.FullName;
        }



        private void HandlerBolas(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            String tag = b.Tag.ToString();
            SoundPlayer sonido;

            //Si se ha acertado la pregunta.
            if (tag.Equals(pregunta.getTag()))
            {

                //Reproducir el sonido

                //Esperar dos segundos.

                //CargarVideo.


            }
            //Si no se ha acertado la pregunta.
            else
            {
                //Efecto desaparecer
                desaparecerBola(tag);
                //Reproducir el sonido.
                
                //sonido = new SoundPlayer("RUTA");

                //sonido.PlaySync();

            }

            
        }


        private void desaparecerBola(String tag)
        {

            Storyboard storyBoard = new Storyboard();
            String efecto = "";
            

            switch (tag)
            {

                case "Blanco":
                    efecto = "BlancoDesaparece";
                    break;

                case "Amarillo":
                    efecto = "AmarilloDesaparece";
                    break;

                case "Azul":
                    efecto = "AzulDesaparece";
                    break;

                case "Marron":
                    efecto = "MarronDesaparece";
                    break;

                case "Morado":
                    efecto="MoradoDesaparece";
                    break;

                case "Naranja":
                    efecto = "NaranjaDesaparece";
                    break;

                case "Negro":
                    efecto = "NegroDesaparece";
                    break;

                case "Rojo":
                    efecto = "RojoDesaparece";
                    break;

                case "Rosa":
                    efecto = "RosaDesaparece";
                    break;

                case "Verde":
                    efecto = "VerdeDesaparece";
                    break;

            }
            storyBoard = (Storyboard)FindResource(efecto);
            storyBoard.Begin();

        }


        
        ///(Ver y jugar deshabilitado)
        ///1-Saco el nombre del color.
        ///2-Reproduzco el audio del color.

        ///Seleccion:
	        //- Mal--> Oculto la bola y reproduzco audio ooohhh.
	        //- Bien--> Reproduzco el sonido bien. Oculto panel de las bolas. Y pongo todas las bolas como visibles.
		    //Pongo el panel del video a visible. Y cargo el video


	}
}