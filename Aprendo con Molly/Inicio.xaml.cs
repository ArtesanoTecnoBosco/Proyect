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

        Timer timer = new Timer();
        int contador = 0;
        int contadorMaximo = 33;


		public Inicio()
		{
			this.InitializeComponent();
			
            configurarBarra();
            Capa_de_Negocio.Juego juego = new Capa_de_Negocio.Juego();

            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 50;
            juego.cargarNiveles();
            contadorMaximo = 33;
            timer.Start();
            
            
            

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


        /// <summary>
        /// Accion del timer por medio segundo.
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        private void TimerEventProcessor(Object myObject,
                                           EventArgs myEventArgs)
        {

            if (contador < contadorMaximo)
            {
                contador++;
                rellenarBarra(contador);

            }
            else
            {
                timer.Stop();
            }

        }



	}
}