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
    /// Lógica de interacción para VentanaProducto.xaml
    /// </summary>
    public partial class VentanaProducto : Window
    {
        choosingAction ventanaPrincipal;
        proveedoresDAL oProveedorDAL;
        productosDAL oProductoDAL;

        public VentanaProducto()
        {
            InitializeComponent();
            oProductoDAL = new productosDAL();
            oProveedorDAL = new proveedoresDAL();
            ventanaPrincipal = new choosingAction();
            UpdateGrid();
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

        private productosBLL RecolectarDatos()
        {
            //conexionsql conexion = new conexionsql();
            productosBLL oProductosBLL = new productosBLL();

            int codigoProducto = 1;
            int cant = 1;
            int precio = 1;

            int.TryParse(txtID.Text, out codigoProducto);
            int.TryParse(txtCantidad.Text, out cant);
            int.TryParse(txtPrecio.Text, out precio);

            oProductosBLL.id = codigoProducto;
            oProductosBLL.nombre = txtNombre.Text;
            oProductosBLL.descripcion = txtDescripcion.Text;
            oProductosBLL.precio = precio;
            oProductosBLL.cantidad = cant;


            int IDProveedor = 0;
            int.TryParse(cbxProveedor.SelectedValue.ToString(), out IDProveedor);
            oProductosBLL.proveedor = IDProveedor;



            //Obtener fechaPicker
            string fecha = fechaPicker.SelectedDate.ToString();
            fecha = fecha.Replace("/", "-");
            string fechaCorta = fecha.Substring(0, 10);

            string fechaDia = fechaCorta.Substring(0, 2);
            string fechaMes = fechaCorta.Substring(3, 2);
            string fechaAnio = fechaCorta.Substring(6, 4);

            string Fechas = $"{fechaAnio}-{fechaMes}-{fechaDia}";

            //Se corta la cadena de texto para que tenga el formato de 
            //yyyy-MM-dd

            oProductosBLL.fechaIngreso = Fechas;

            //Devuelve un objeto con los valores agregados desde los txtbox



            return oProductosBLL;

        }




        private void btnAgregar(object sender, RoutedEventArgs e)
        {
            oProductoDAL.Agregar(RecolectarDatos());
            UpdateGrid();
            LimpiarEntradas();
        }


        private void UpdateGrid()
        {
            dgvProductos.DataContext = oProductoDAL.MostrarProductos().Tables[0];
        }

        private void LimpiarEntradas()
        {
            txtCantidad.Clear();
            txtDescripcion.Clear();
            txtID.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            cbxProveedor.SelectedIndex = -1;
            fechaPicker.SelectedDate = null;
        }


    }
}
