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
    /// Lógica de interacción para VentanaProducto.xaml
    /// </summary>
    public partial class VentanaProducto : Window
    {
        choosingAction ventanaPrincipal;
        proveedoresDAL oProveedorDAL;
        public VentanaProducto()
        {
            InitializeComponent();
            oProveedorDAL = new proveedoresDAL();
            ventanaPrincipal = new choosingAction();
            MostrarProveedores();
        }


        private void btnVolver(object sender, RoutedEventArgs e)
        {
            ventanaPrincipal.Show();
            this.Close();
        }

        private void fechaPicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fecha Ingresada.");
        }


        private void MostrarProveedores()
        {
            //Obtiene del dataset la informacion de nuestra tabla proveedores
            //DisplayMemberPath nos muestra la informacion de la columna nombre de nuestra tabla
            //SelectedValuePath cada empleado pertenece a un proveedor, se apunta a id
            //Por ende, cada vez que elegimos un proveedor, estamos seleccionando un id
            cbxProveedor.DataContext = oProveedorDAL.MostrarProveedores().Tables[0];
            cbxProveedor.DisplayMemberPath = "Nombre";
            cbxProveedor.SelectedValuePath = "id";
        }

    }
}
