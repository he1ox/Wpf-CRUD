using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using crudWPF.DAL;

namespace crudWPF.PL
{
    /// <summary>
    /// Lógica de interacción para ConexionDataMYSQL.xaml
    /// </summary>
    public partial class ConexionDataMYSQL : Window
    {
        conexionsql conexion; //conexion a la BD en mysql.
        choosingAction ventanaAccion; // Ventana para elegir entre proveedores y productos
        public ConexionDataMYSQL()
        {
            ventanaAccion = new choosingAction();
            conexion = new conexionsql();
            InitializeComponent();
        }

        
        private void btnConexion(object sender, RoutedEventArgs e)
        {
            string servidor = txtServidor.Text;
            string port = txtPuerto.Text;
            string usuario = txtUsuario.Text;
            string password = txtContrasena.Text;
            string database = txtNombreBD.Text;

            conexion.SendingData(servidor, port, usuario, password, database);

            bool success = conexion.testBD();

            if (success!=false)
            {
                MessageBox.Show("Conexion Establecida","Te has conectado a la base de datos.",MessageBoxButton.OK, MessageBoxImage.Information);
                ventanaAccion.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vuelve a intentarlo","No se pudo establecer una conexion", MessageBoxButton.OK, MessageBoxImage.Warning);
                limpiarEntradas();
            }

        }


        private void limpiarEntradas()
        {
            txtContrasena.Text = "";
            txtNombreBD.Text = "";
            txtPuerto.Text = "";
            txtPuerto.Text = "";
            txtServidor.Text = "";
            txtUsuario.Text = "";
        }

    }
}
