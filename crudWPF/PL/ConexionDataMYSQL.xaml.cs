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
    /// Lógica de interacción para ConexionDataMYSQL.xaml
    /// </summary>
    public partial class ConexionDataMYSQL : Window
    {
        public ConexionDataMYSQL()
        {
            InitializeComponent();
        }

        private void btnConectar(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hola!");
        }
    }
}
