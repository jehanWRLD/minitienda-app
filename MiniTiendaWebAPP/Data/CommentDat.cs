using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class CommentDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistence objPer = new Persistence();


        // Método para mostrar los productos desde la base de datos.
        public DataSet showComments()
        {
            // Se crea un adaptador de datos para MySQL.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procShowComments";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        //Metodo para guardar un nuevo Producto
        public bool saveComments(int _id, string _comentario, double _calificacion, DateTime _fecha, int _productos_pro_id, int _clientes_cli_id)
        {
            // Se inicializa una variable para indicar si la operación se ejecutó correctamente.
            bool executed = false;
            int row;// Variable para almacenar el número de filas afectadas por la operación.

            // Se crea un comando MySQL para insertar un nuevo producto utilizando un procedimiento almacenado.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertComment"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan parámetros al comando para pasar los valores del producto.
            objSelectCmd.Parameters.Add("com_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("com_comentario", MySqlDbType.VarString).Value = _comentario;
            objSelectCmd.Parameters.Add("com_calificacion", MySqlDbType.Double).Value = _calificacion;
            objSelectCmd.Parameters.Add("com_fecha", MySqlDbType.Datetime).Value = _fecha;
            objSelectCmd.Parameters.Add("tbl_productos_pro_id", MySqlDbType.Int32).Value = _productos_pro_id;
            objSelectCmd.Parameters.Add("tbl_clientes_cli_id", MySqlDbType.Int32).Value = _clientes_cli_id;

            try
            {
                // Se ejecuta el comando y se obtiene el número de filas afectadas.
                row = objSelectCmd.ExecuteNonQuery();

                // Si se inserta una fila correctamente, se establece executed a true.
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                // Si ocurre un error durante la ejecución del comando, se muestra en la consola.
                Console.WriteLine("Error " + e.ToString());
            }
            objPer.closeConnection();
            // Se devuelve el valor de executed para indicar si la operación se ejecutó correctamente.
            return executed;
        }

        //Metodo para actulizar un producto
        public bool updateComments(int _id, string _comentario, double _calificacion, DateTime _fecha, int _productos_pro_id, int _clientes_cli_id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateComment"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan parámetros al comando para pasar los valores del producto.
            objSelectCmd.Parameters.Add("com_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("com_comentario", MySqlDbType.VarString).Value = _comentario;
            objSelectCmd.Parameters.Add("com_calificacion", MySqlDbType.Double).Value = _calificacion;
            objSelectCmd.Parameters.Add("com_fecha", MySqlDbType.Datetime).Value = _fecha;
            objSelectCmd.Parameters.Add("tbl_productos_pro_id", MySqlDbType.Int32).Value = _productos_pro_id;
            objSelectCmd.Parameters.Add("tbl_clientes_cli_id", MySqlDbType.Int32).Value = _clientes_cli_id;

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