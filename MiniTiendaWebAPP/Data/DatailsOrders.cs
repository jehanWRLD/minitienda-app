using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class DatailsOrders
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistence objPer = new Persistence();

        // Método para mostrar los detalles de pedidos desde la base de datos.
        public DataSet showDetailsOrders()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();


            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spSelectDetailsOrders"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);

            objPer.closeConnection();

            return objData;
        }

        // Método para guardar un nuevo detalle de pedido
        public bool saveDetailsOrder(int _id, int _cantidad, double _precio, int _pedidos_ped_id, int _productos_pro_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spInsertDetailsOrder"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan parámetros al comando para pasar los valores del detalle de pedido.
            objSelectCmd.Parameters.Add("det_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("det_cantidad", MySqlDbType.Int32).Value = _cantidad;
            objSelectCmd.Parameters.Add("det_precio", MySqlDbType.Double).Value = _precio;
            objSelectCmd.Parameters.Add("tbl_pedidos_ped_id", MySqlDbType.Int32).Value = _pedidos_ped_id;
            objSelectCmd.Parameters.Add("tbl_productos_pro_id", MySqlDbType.Int32).Value = _productos_pro_id;

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
                Console.WriteLine("Error " + e.ToString());
            }

            objPer.closeConnection();
            return executed;
        }

        // Método para actualizar un detalle de pedido existente
        public bool updateDetailsOrder(int _id, int _cantidad, double _precio, int _pedidos_ped_id, int _productos_pro_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "spUpdateDetailsOrder"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan parámetros al comando para pasar los valores del detalle de pedido.
            objSelectCmd.Parameters.Add("det_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("det_cantidad", MySqlDbType.Int32).Value = _cantidad;
            objSelectCmd.Parameters.Add("det_precio", MySqlDbType.Double).Value = _precio;
            objSelectCmd.Parameters.Add("tbl_pedidos_ped_id", MySqlDbType.Int32).Value = _pedidos_ped_id;
            objSelectCmd.Parameters.Add("tbl_productos_pro_id", MySqlDbType.Int32).Value = _productos_pro_id;

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
                Console.WriteLine("Error " + e.ToString());
            }

            objPer.closeConnection();
            return executed;
        }
    }
}