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
using crudWPF.BLL;

namespace crudWPF.PL
{
    /// <summary>
    /// Lógica de interacción para VentanaProveedores.xaml
    /// </summary>
    public partial class VentanaProveedores : Window
    {
        choosingAction ventanaPrincipial;
        proveedoresDAL oProveedor;
        public VentanaProveedores()
        {
            InitializeComponent();
            oProveedor = new proveedoresDAL();
            ventanaPrincipial = new choosingAction();
            GridUpdate();
        }




        private void btnVolver(object sender, RoutedEventArgs e)
        {
            this.Close();
            ventanaPrincipial.Show();
        }




        private void btnAgregar(object sender, RoutedEventArgs e)
        {

        }


        private void GridUpdate()
        {
            dgvProveedores.DataContext = oProveedor.MostrarProveedores().Tables[0];
        }

    }
}
