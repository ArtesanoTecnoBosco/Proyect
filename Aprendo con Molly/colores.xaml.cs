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
using System.Windows.Media.Animation;

namespace Aprendo_con_Molly
{
	/// <summary>
	/// Lógica de interacción para colores.xaml
	/// </summary>
	public partial class colores : Window
	{
		public colores()
		{
			this.InitializeComponent();
			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void Nubes_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            Storyboard animacion = new Storyboard();
            animacion = (Storyboard)FindResource("EfectoNubes");

            if (Nubes.Visibility == System.Windows.Visibility.Hidden)
            {

                animacion.Stop();

            }

            if (Nubes.Visibility == System.Windows.Visibility.Visible)
            {
                animacion.Begin();
            }


        }
	}
}