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

namespace crudWPF.PL
{
    /// <summary>
    /// Lógica de interacción para VentanaProveedores.xaml
    /// </summary>
    public partial class VentanaProveedores : Window
    {
        choosingAction ventanaPrincipial;
        public VentanaProveedores()
        {
            ventanaPrincipial = new choosingAction();
            InitializeComponent();
            //dgvProveedores.Columns[0].Header = "ID";
            //dgvProveedores.Columns[1].Header = "Nombre";
        }

        private void btnVolver(object sender, RoutedEventArgs e)
        {
            this.Close();
            ventanaPrincipial.Show();
        }
    }
}
