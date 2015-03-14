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
using Capa_de_Negocio.ModeloDatos;
using System.Windows.Forms;
using System.IO;

namespace Aprendo_con_Molly
{
	/// <summary>
	/// Lógica de interacción para Inicio.xaml
	/// </summary>
	public partial class Inicio : Window
	{

        Capa_de_Negocio.Juego juego;


        
        int contador = 0;
        int contadorMaximo = 33;


		public Inicio()
		{
			this.InitializeComponent();
			
            configurarBarra();
            juego = new Capa_de_Negocio.Juego();


            cargarJuego();

            

            if (settingsOk())
            {
                try
                {
                    jUGADORES ventanaJugador = new jUGADORES(juego);
                    ventanaJugador.Show();
                    this.Close();
                }
                catch (Exception e)
                {
                    crearEmergente(e.Message);
                }
                



            }
            else
            {
                String x = "ERROR 101\nPor favor pongase en contacto con el administrador de la aplicación.";
                crearEmergente(x);
            }



		}

        public static void crearEmergente(String x)
        {
            VentanaEmergente emergente = new VentanaEmergente(x);
            emergente.ShowDialog();
            emergente.Focus();
        }

        public void cargarJuego()
        {
            juego.cargarNiveles();
            contadorMaximo = 33;

            for (int pos = contador; pos < contadorMaximo; pos++)
            {
                rellenarBarra(pos);
            }


            cargarImagenes();
            //añadir las siguientes cargas.


            


        }


        public void cargarImagenes()
        {

            String padre = directorioPadre();
            String ruta = padre + "\\Imagenes";

            if(Directory.Exists(ruta)){

                ruta = padre + "\\Imagenes\avatares";

                if (Directory.Exists(ruta))
                {

                    this.juego.cargarAvatares(ruta);

                }
                else
                {

                    String x = "ERROR 104\nPor favor pongase en contacto con el administrador de la aplicación.";
                    crearEmergente(x);

                }


            }
            else
            {
                String x = "ERROR 104\nPor favor pongase en contacto con el administrador de la aplicación.";
                crearEmergente(x);
            }





        }

        
       private String directorioPadre(){
            DirectoryInfo info; 
            String path = Directory.GetCurrentDirectory();
            info = System.IO.Directory.GetParent(path);
            info = System.IO.Directory.GetParent(info.FullName);
            return info.FullName;
       }




        public Boolean settingsOk()
        {
            Boolean bien = true;


            return bien;
        }




        /// <summary>
        /// Metodo para configurar la barra de progreso.
        /// </summary>
        private void configurarBarra()
        {
            barraProgreso.Maximum = 100;
            barraProgreso.Minimum = 0;
        }

        /// <summary>
        /// Metodo para rellenar la barra de progreso.
        /// </summary>
        /// <param name="pos">Int con el valor de la barra de progreso.</param>
        private void rellenarBarra(int pos)
        {
                        
                    barraProgreso.Value = pos;

        }






	}
}