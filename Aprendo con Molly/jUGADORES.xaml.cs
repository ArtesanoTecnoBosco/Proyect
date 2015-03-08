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
	/// Lógica de interacción para jUGADORES.xaml
	/// </summary>
	public partial class jUGADORES : Window
	{
        Capa_de_Negocio.Juego juego;


		public jUGADORES(Capa_de_Negocio.Juego juego)
		{
            this.juego = juego;

            if (juego != null)
            {
                this.InitializeComponent();

            }
            else
            {
                String x = "ERROR 102";
            }

			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
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

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {


            String usuario = txtUsuario.Text;

            if (!usuario.Equals(""))
            {

                MessageBox.Show("Introduce tu nombre.");

            }
            else
            {

                Capa_de_Negocio.ModeloDatos.Usuario auxUsu = new Capa_de_Negocio.ModeloDatos.Usuario();

                auxUsu.setNombre(usuario);
                

                Nombre.Opacity = 0;
                NIVELES.Opacity = 100;

            }




        }
	}
}