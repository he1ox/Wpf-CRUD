using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crudWPF.BLL;


namespace crudWPF.DAL
{
    class productosDAL
    {
        conexionsql conexion;

        public productosDAL()
        {
            //Constructor asigna una conexion a cada objeto instanciado de ProductosDAL
            conexion = new conexionsql();
        }

        public DataSet MostrarProductos()
        {
            MySqlCommand SQLComando = new MySqlCommand("SELECT * FROM productos");
            return conexion.EjecutarSentencia(SQLComando);
        }

        public bool Agregar(productosBLL oProducto)
        {

            MySqlCommand SQLComando = new MySqlCommand($"INSERT INTO productos VALUES({oProducto.id},'{oProducto.nombre}',{oProducto.cantidad},'{oProducto.descripcion}',{oProducto.precio},'{oProducto.fechaIngreso}')");

            //SQLComando.Parameters.Add("@id", MySqlDbType.Int32).Value = oProducto.id;
            //SQLComando.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = oProducto.nombre;
            //SQLComando.Parameters.Add("@cantidad", MySqlDbType.Int32).Value = oProducto.cantidad;
            //SQLComando.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = oProducto.descripcion;
            //SQLComando.Parameters.Add("@precio", MySqlDbType.Int32).Value = oProducto.precio;
            //SQLComando.Parameters.Add("@fecha", MySqlDbType.VarChar).Value = oProducto.fechaIngreso;

            return conexion.execSinRetornoDatos(SQLComando);
        }

    }
}
