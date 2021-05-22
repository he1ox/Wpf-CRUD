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


            //Se envia los datos de conexion a la conexion, son utiles para asignarlos
            //mediante el constructor de clase
            conexion.SendingData(servidor, port, usuario, password, database);


            PruebaConexion();

        }


        private void limpiarEntradas()
        {
            //Limpia las entradas de los textbox.
            txtContrasena.Text = "";
            txtNombreBD.Text = "";
            txtPuerto.Text = "";
            txtPuerto.Text = "";
            txtServidor.Text = "";
            txtUsuario.Text = "";
        }


        private void PruebaConexion()
        {
            //Devuelve true o false dependiendo si se conecta o no, tambien muestra un mensaje en pantalla.
            bool success = conexion.testBD();

            if (success != false)
            {
                MessageBox.Show("Conexion Establecida", "Te has conectado a la base de datos.", MessageBoxButton.OK, MessageBoxImage.Information);
                ventanaAccion.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vuelve a intentarlo", "No se pudo establecer una conexion", MessageBoxButton.OK, MessageBoxImage.Warning);
                limpiarEntradas();
            }
        }



    }
}
