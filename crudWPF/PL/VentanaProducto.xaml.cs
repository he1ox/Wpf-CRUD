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
    /// Lógica de interacción para VentanaProducto.xaml
    /// </summary>
    public partial class VentanaProducto : Window
    {
        choosingAction ventanaPrincipal;
        public VentanaProducto()
        {
            ventanaPrincipal = new choosingAction();
            InitializeComponent();
        }

        private void btnVolver(object sender, RoutedEventArgs e)
        {
            ventanaPrincipal.Show();
            this.Close();
        }
    }
}
