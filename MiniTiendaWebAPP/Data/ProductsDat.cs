using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class ProductsDat
    {
        Persistence objPer = new Persistence();

        // Método para insertar un nuevo producto
        public bool InsertProduct(int _id, string _nombre, string _descripcion, double _precio, int _stock, string _imagen, int _proveedores_prov_id, int _categoria_cat_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertProduct"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Añadir parámetros al procedimiento
            objSelectCmd.Parameters.Add("pro_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("pro_nombre", MySqlDbType.VarChar).Value = _nombre;
            objSelectCmd.Parameters.Add("pro_descripcion", MySqlDbType.VarString).Value = _descripcion;
            objSelectCmd.Parameters.Add("pro_precio", MySqlDbType.Double).Value = _precio;
            objSelectCmd.Parameters.Add("pro_stock", MySqlDbType.Double).Value = _stock;
            objSelectCmd.Parameters.Add("pro_imagen", MySqlDbType.VarChar).Value = _imagen;
            objSelectCmd.Parameters.Add("tbl_proveedores_prov_id", MySqlDbType.Int32).Value = _proveedores_prov_id;
            objSelectCmd.Parameters.Add("tbl_categoria_cat_id", MySqlDbType.Int32).Value = _categoria_cat_id;


            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para actualizar un producto existente
        public bool UpdateProduct(int _id, string _nombre, string _descripcion, double _precio, int _stock, string _imagen, int _proveedores_prov_id, int _categoria_cat_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateProduct"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Añadir parámetros al procedimiento
            objSelectCmd.Parameters.Add("pro_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("pro_nombre", MySqlDbType.VarChar).Value = _nombre;
            objSelectCmd.Parameters.Add("pro_descripcion", MySqlDbType.VarString).Value = _descripcion;
            objSelectCmd.Parameters.Add("pro_precio", MySqlDbType.Double).Value = _precio;
            objSelectCmd.Parameters.Add("pro_stock", MySqlDbType.Double).Value = _stock;
            objSelectCmd.Parameters.Add("pro_imagen", MySqlDbType.VarChar).Value = _imagen;
            objSelectCmd.Parameters.Add("tbl_proveedores_prov_id", MySqlDbType.Int32).Value = _proveedores_prov_id;
            objSelectCmd.Parameters.Add("tbl_categoria_cat_id", MySqlDbType.Int32).Value = _categoria_cat_id;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }

        // Método para mostrar todos los productos
        public DataSet ShowProducts()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procShowProducts"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);

            objPer.closeConnection();
            return objData;
        }

        // Método para eliminar un producto
        public bool DeleteProduct(int id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteProduct"; // Nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Añadir parámetros al procedimiento
            objSelectCmd.Parameters.Add("v_id", MySqlDbType.Int32).Value = id;

            try
            {
                row = objSelectCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
            objPer.closeConnection();
            return executed;
        }
    }
}