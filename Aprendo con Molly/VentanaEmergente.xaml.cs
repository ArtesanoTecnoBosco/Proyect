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
	/// Lógica de interacción para VentanaEmergente.xaml
	/// </summary>
	public partial class VentanaEmergente : Window
	{

        /// <summary>
        /// Constructor vacio.
        /// </summary>
        public VentanaEmergente()
        {
            this.InitializeComponent();
            personalizar();

            // A partir de este punto se requiere la inserción de código para la creación del objeto.
        }


        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="x">Mensaje a escribir.</param>
		public VentanaEmergente(String x)
		{
			this.InitializeComponent();
            personalizar();
            lblMensag.Text = x;
           

			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        /// <summary>
        /// Metodo al hacer click en el boton de cerrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        /// <summary>
        /// Metodo al hacer click en el boton OK.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Metodo para personalizar la ventana(No mostrarse en la barra, no resize etc).
        /// </summary>
        private void personalizar()
        {
            ShowInTaskbar = false;
            Topmost = true;
            ResizeMode = ResizeMode.NoResize;
           
        }



	}
}