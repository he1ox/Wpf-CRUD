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
        conexionsql conexion;
        public ConexionDataMYSQL()
        {
            conexion = new conexionsql();
            InitializeComponent();
        }

        private void btnConectar(object sender, RoutedEventArgs e)
        {
            string servidor = txtServidor.Text;
            string port = txtPuerto.Text;
            string usuario = txtUsuario.Text;
            string password = txtContrasena.Text;
            string database = txtNombreBD.Text;

            conexion.SendingData(servidor,port,usuario,password,database);

            MessageBox.Show(conexion.MostrarDatos());


            MessageBox.Show(conexion.testBD().ToString()); 

        }




    }
}
