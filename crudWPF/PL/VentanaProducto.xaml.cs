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
using System.Data;
using System.IO;

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


            int IDProveedor = 1;

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

        private productosBLL RecolectarID()
        {
            productosBLL oProductosBLL = new productosBLL();

            int idproducto = 1;

            int.TryParse(txtID.Text, out idproducto);

            oProductosBLL.id = idproducto;

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

        private void btnBorrar(object sender, RoutedEventArgs e)
        {
            bool opcionBorrar = MensajePregunta("Eliminar", txtID);
            if (opcionBorrar)
            {
                oProductoDAL.Eliminar(RecolectarID());
                UpdateGrid();
                LimpiarEntradas();
            }
        }



        private bool MensajePregunta(string opcion, TextBox txtbox)
        {
            string msj = $"Deseas {opcion} el proveedor con ID {txtbox.Text}?";
            string msjcaption = $"{opcion} registro";

            MessageBoxButton botones = MessageBoxButton.YesNo;

            var result = MessageBox.Show(msj, msjcaption, botones, MessageBoxImage.Exclamation);

            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void btnModificar(object sender, RoutedEventArgs e)
        {
            bool opcionModificar = MensajePregunta("Modificar",txtID);
            if (opcionModificar)
            {
                oProductoDAL.Modificar(RecolectarDatos());
                UpdateGrid();
                LimpiarEntradas();
            }

        }

        private void btnCancelar(object sender, RoutedEventArgs e)
        {
            LimpiarEntradas();
        }

        private void btnBuscar(object sender, RoutedEventArgs e)
        {
            int idBuscar = 1;

            int.TryParse(txtID.Text, out idBuscar);

            DataSet Busqueda = oProductoDAL.BuscarPorID(idBuscar);

            dgvProductos.DataContext = Busqueda.Tables[0];
        }

        private void btnRestart(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }

        private void btnCSV(object sender, RoutedEventArgs e)
        {

            // Instancia de conexion a gestor
            conexionsql conexion = new conexionsql();

            //Instancia de tabla para pasarla a la funcion 
            var Table = conexion.consultaTablaDirecta("SELECT * FROM productos");

            //Generar archivo de texto
            if (GenerateFile(Table))
            {
                MessageBox.Show("El archivo csv se ha guardado en tus documentos",".CSV Creado");
            }
            else
            {
                MessageBox.Show("No se ha generado ningun archivo.", "Error");
            }
        }



        public bool GenerateFile(DataTable datosTabla)
        {
            try
            {
                int i = 0; //Iterador para foreach

                string content = "ID;NOMBRE;CANTIDAD;DESCRIPCION;PRECIO;FECHA DE INGRESO;\n"; //Encabezado + iterador de strings

                foreach (DataRow fila in datosTabla.Rows)
                {
                    content += ($"{fila[0]};{fila[1]};{fila[2]};{fila[3]};{fila[4]};{fila[5]};\n");
                    i++;
                }

                File.WriteAllText($@"C:\Users\georg\csv{i}.csv", content);

                return true;
            }
            catch 
            {
                return false;
            }
            
        }
    }
}
