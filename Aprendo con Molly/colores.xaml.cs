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
        private static string ERROR = "\\audio\\error.wav";
        private static string ACIERTO = "\\audio\\Aplausos.wav";
        private int numeroIntentos;
        private int INTENTOS_MAXIMOS=3;
        private SoundPlayer escuchar;
        public static int TIPO;
        

        /// <summary>
        /// Contructor vacio.
        /// </summary>
		public colores()
		{
            numeroIntentos = 0;
            escuchar = new SoundPlayer();
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
            numeroIntentos = 0;
            escuchar = new SoundPlayer();
            this.InitializeComponent();
            btnJugar.Visibility = System.Windows.Visibility.Hidden;
            


            this.juego = juego;

            //Consulta para sacar una pregunta del tipo (panel).
            pregunta = new Capa_de_Negocio.ModeloDatos.Pregunta();
            mostrarPanel(panel);
            
        }


        /// <summary>
        /// Metodo para seleccionar que panel debe mostrarse.
        /// </summary>
        /// <param name="panel"></param>
        private void mostrarPanel(int panel)
        {

            ocultarPaneles();
            pregunta.cargarPregunta(panel);

            
            try
            {
                ocultarVideo();
            }
            catch (Exception e)
            {
                
            }



            switch (panel)
            {
                //MODO FACIL,MEDIO,DIFICIL
                case 1:
                    bolitas.Opacity = 100;
                    bolitas.Visibility = System.Windows.Visibility.Visible;
                    //Cargo imagen del centro y pongo visible todos los elemetos.
                    mostrarTodasLasBolas();
                    cargarImagenPregunta();
                    break;

                case 2:
                    letras.Opacity = 100;
                    letras.Visibility = System.Windows.Visibility.Visible;
                    mostrarTodasLasLetras();
                    
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

        private void mostrarPanelSinModificar(int panel)
        {

            try
            {
                ocultarVideo();
            }
            catch (Exception e)
            {

            }

            switch (panel)
            {
                //MODO FACIL,MEDIO,DIFICIL
                case 1:
                    bolitas.Opacity = 100;
                    bolitas.Visibility = System.Windows.Visibility.Visible;
                    espacioJuego.Opacity = 100;
                    espacioJuego.Visibility = System.Windows.Visibility.Visible;
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


        private void cargarImagenPregunta()
        {
            espacioJuego.Opacity = 100;
            espacioJuego.Visibility = System.Windows.Visibility.Visible;
            espacioJuego.Fill = new ImageBrush(new BitmapImage(new Uri(directorioPadre() + pregunta.getImagen(), UriKind.Relative)));

        }

        private void mostrarTodasLasBolas()
        {
            Button[] bolas = { amarillo, blanco, azul, marron, morado, naranja, negro, rojo, rosa, verde };
            String[] animacion ={"AmarilloDesaparece","BlancoDesaparece","AzulDesaparece","MarronDesaparece","MoradoDesaparece","NaranjaDesaparece","NegroDesaparece"
                               ,"RojoDesaparece","RosaDesaparece","VerdeDesaparece"};
            Storyboard storyBoard;
            

            for (int pos = 0; pos < bolas.Length; pos++)
            {
                storyBoard = (Storyboard)FindResource(animacion[pos]);
                storyBoard.Stop();
                bolas[pos].Opacity = 100;
                bolas[pos].Visibility = System.Windows.Visibility.Visible;
                
            }

            espacioJuego.Opacity = 100;
            espacioJuego.Visibility = System.Windows.Visibility.Visible;

            this.InvalidateVisual();
        }

        private void mostrarTodasLasLetras()
        {

            Rectangle[] letras = {a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z};
            String[] animacion = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            Storyboard storyBoard;

            for (int pos = 0; pos < letras.Length; pos++)
            {
                storyBoard = (Storyboard)FindResource(animacion[pos]);
                storyBoard.Stop();
                letras[pos].Opacity = 100;
                letras[pos].Visibility = System.Windows.Visibility.Visible;
            }
                      
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

            comprobarRespuestaColores(tag);
            
        }


        private void HandleLetras(object sender, MouseButtonEventArgs e)
        {

            Rectangle rectangulo = (Rectangle)sender;
            String tag = rectangulo.Tag.ToString();

            comprobarRespuestaLetras(tag,rectangulo);

        }



        private void comprobarRespuestaLetras(String tag,Rectangle rectangulo)
        {
            SoundPlayer sonido;
            if (numeroIntentos < INTENTOS_MAXIMOS)
            {
                //Si se ha acertado la pregunta.
                if (tag.Equals(pregunta.getTag()))
                {

                    try
                    {
                        //Reproducir el sonido
                        sonido = new SoundPlayer(directorioPadre() + ACIERTO);
                        sonido.Play();

                        //Insertar en BD.
                        insertarPartida();


                        //CargarVideo.
                        ocultarPaneles();
                        mostrarVideo();
                        mostrarBoton(btnJugar);
                    }
                    catch (Exception e)
                    {
                        VentanaEmergente ventana = new VentanaEmergente(e.ToString());
                        ventana.ShowDialog();
                        ventana.Focus();
                    }

                }
                //Si no se ha acertado la pregunta.
                else
                {
                    try
                    {
                        //Efecto desaparecer
                        desaparecerLetra(tag);

                        //Reproducir el sonido.
                        sonido = new SoundPlayer(directorioPadre() + ERROR);
                        sonido.Play();

                        insertarPartidaPerdida();
                    }
                    catch (Exception e)
                    {
                        VentanaEmergente ventana = new VentanaEmergente(e.ToString());
                        ventana.ShowDialog();
                        ventana.Focus();
                    }

                    numeroIntentos++;

                }
            }

            numeroIntentosMaximos();


        }

        private void numeroIntentosMaximos()
        {
            if (numeroIntentos == 3)
            {
                numeroIntentos = 0;
                insertarPartidaPerdida();
                botonJugar();
            }
        }

        private void insertarPartida()
        {
            Capa_de_Negocio.ModeloDatos.Partida partida = new Capa_de_Negocio.ModeloDatos.Partida();
            partida.setUsuario(this.juego.getUsuario());
            partida.setGanado(-1);
            partida.setNivel(this.juego.buscarNivel(jUGADORES.nivel));
            partida.getTipo().setId(TIPO);

            partida.insertarPartida();
        }

        private void insertarPartidaPerdida()
        {
            Capa_de_Negocio.ModeloDatos.Partida partida = new Capa_de_Negocio.ModeloDatos.Partida();
            partida.setUsuario(this.juego.getUsuario());
            partida.setGanado(0);
            partida.setNivel(this.juego.buscarNivel(jUGADORES.nivel));
            partida.getTipo().setId(TIPO);

            partida.insertarPartida();
        }


        private void desaparecerLetra(String tag)
        {

            Storyboard storyBoard = new Storyboard();


            storyBoard = (Storyboard)FindResource(tag);
            storyBoard.Begin();

        }




        private void ocultarRectangulo(Rectangle r)
        {
            r.Opacity = 0;
            r.Visibility = System.Windows.Visibility.Hidden;
        }


        private void comprobarRespuestaColores(String tag)
        {
           
            SoundPlayer sonido;

            if (numeroIntentos < INTENTOS_MAXIMOS)
            {
                //Si se ha acertado la pregunta.
                if (tag.Equals(pregunta.getTag()))
                {
                    try
                    {
                        //Reproducir el sonido
                        sonido = new SoundPlayer(directorioPadre() + ACIERTO);
                        sonido.Play();

                        //Insertar Partida en la BD
                        insertarPartida();

                        //CargarVideo.
                        ocultarPaneles();
                        mostrarVideo();
                        mostrarBoton(btnJugar);
                    }
                    catch (Exception e)
                    {
                        VentanaEmergente ventana = new VentanaEmergente(e.ToString());
                        ventana.ShowDialog();
                        ventana.Focus();
                    }


                }
                //Si no se ha acertado la pregunta.
                else
                {
                    try
                    {
                        //Efecto desaparecer
                        desaparecerBola(tag);

                        //Reproducir el sonido.
                        sonido = new SoundPlayer(directorioPadre() + ERROR);
                        sonido.Play();

                        insertarPartidaPerdida();
                    }
                    catch (Exception e)
                    {
                        VentanaEmergente ventana = new VentanaEmergente(e.ToString());
                        ventana.ShowDialog();
                        ventana.Focus();
                    }

                    numeroIntentos++;
                }
            }

            numeroIntentosMaximos();
            
        }


        private void mostrarBoton(Button boton)
        {
            boton.Opacity = 100;
            boton.Visibility = System.Windows.Visibility.Visible;
            
        }

        private void ocultarBoton(Button boton)
        {
            boton.Opacity = 0;
            boton.Visibility = System.Windows.Visibility.Hidden;
        }

        private void mostrarVideo()
        {
            mostrarBoton(btnParar);

            ocultarBoton(btnVer);

            video.Visibility = System.Windows.Visibility.Visible;
            video.Source = new Uri(directorioPadre() + pregunta.getVideo());

            elipseVideo.Opacity = 100;
            elipseVideo.Visibility = System.Windows.Visibility.Visible;

            mariposas.Opacity = 100;
            mariposas.Visibility = System.Windows.Visibility.Visible;

            video.Play();

        }

        private void ocultarVideo()
        {
            
            video.Stop();
            video.Visibility = System.Windows.Visibility.Hidden;
            elipseVideo.Opacity = 0;
            elipseVideo.Visibility = System.Windows.Visibility.Hidden;
            mariposas.Opacity = 0;
            mariposas.Visibility = System.Windows.Visibility.Hidden;
            
        }



        private void ocultarPaneles()
        {
            bolitas.Visibility = System.Windows.Visibility.Hidden;
            letras.Visibility = System.Windows.Visibility.Hidden;




            espacioJuego.Opacity = 0;
            espacioJuego.Visibility = System.Windows.Visibility.Hidden;


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



        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {

            botonJugar();

        }

        private void botonJugar()
        {
            int panel;
            numeroIntentos = 0;

            ocultarBoton(btnParar);

            mostrarBoton(btnVer);

            panel = seleccionPanelNivel(jUGADORES.nivel);
            pregunta.cargarPregunta(panel);

            TIPO = panel;

            mostrarPanel(panel);
        }



        /// <summary>
        /// Metodo para seleccionar un panel aleatorio del nivel que se le especifica.
        /// </summary>
        /// <param name="nivel">Nivel 1-Principiante 2-Medio 3-Avanzado</param>
        /// <returns></returns>
        private int seleccionPanelNivel(String nivel)
        {
            int numero = 0;
            int max = 2;
            int min = 1;

            Random random = new Random(DateTime.Now.Millisecond);


            switch (nivel)
            {

                case "Principiante":
                    max = this.juego.getUnNivel(0).getTipos().Count;
                    break;

                case "Medio":
                    max = this.juego.getUnNivel(1).getTipos().Count;
                    break;

                case "Avanzado":
                    max = this.juego.getUnNivel(2).getTipos().Count;
                    break;

            }

            numero = random.Next(min, max + 1);

            return numero;
        }

        /// <summary>
        /// Accion al pulsar el boton escuchar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntExcuchar_Click(object sender, RoutedEventArgs e)
        {

            escuchar.SoundLocation = directorioPadre() + pregunta.getSonido();
            escuchar.Play();



        }

        private void btnParar_Click(object sender, RoutedEventArgs e)
        {

            mostrarPanelSinModificar(TIPO);
            ocultarBoton(btnParar);
            mostrarBoton(btnVer);

        }

        private void btnVer_Click(object sender, RoutedEventArgs e)
        {
            ocultarPaneles();
            mostrarVideo();
        }




	}
}