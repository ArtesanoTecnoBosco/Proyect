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


        public VentanaEmergente()
        {
            this.InitializeComponent();
            personalizar();

            // A partir de este punto se requiere la inserción de código para la creación del objeto.
        }



		public VentanaEmergente(String x)
		{
			this.InitializeComponent();
            personalizar();
            lblMensag.Text = x;
           

			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void personalizar()
        {
            ShowInTaskbar = false;
            Topmost = true;
            ResizeMode = ResizeMode.NoResize;
           
        }



	}
}