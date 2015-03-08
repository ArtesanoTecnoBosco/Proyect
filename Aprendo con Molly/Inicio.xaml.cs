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

                jUGADORES ventanaJugador = new jUGADORES(juego);
                ventanaJugador.Show();
                this.Close();
                



            }
            else
            {
                String x="Hay un problema a la hora de cargar los datos de la bd";
            }



		}



        public void cargarJuego()
        {
            juego.cargarNiveles();
            contadorMaximo = 33;

            for (int pos = contador; pos < contadorMaximo; pos++)
            {
                rellenarBarra(pos);
            }


            //añadir las siguientes cargas.


            


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