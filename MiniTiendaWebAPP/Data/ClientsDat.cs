using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Data
{
    public class ClientsDat
    {
        // Se crea una instancia de la clase Persistence para manejar la conexión a la base de datos.
        Persistence objPer = new Persistence();


        // Método para mostrar los productos desde la base de datos.
        public DataSet showClients()
        {
            // Se crea un adaptador de datos para MySQL.
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procShowClients";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        //Metodo para guardar un nuevo Producto
        public bool saveClients(int _id, string _nombre, string _apellido, string _correo, string _contrasena, string _direccion_envio, int _telefono, DateTime _fecha_registro)
        {
            // Se inicializa una variable para indicar si la operación se ejecutó correctamente.
            bool executed = false;
            int row;// Variable para almacenar el número de filas afectadas por la operación.

            // Se crea un comando MySQL para insertar un nuevo producto utilizando un procedimiento almacenado.
            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertClient"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan parámetros al comando para pasar los valores del producto.
            objSelectCmd.Parameters.Add("cli_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("cli_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("cli_apellido", MySqlDbType.VarString).Value = _apellido;
            objSelectCmd.Parameters.Add("cli_correo", MySqlDbType.VarString).Value = _correo;
            objSelectCmd.Parameters.Add("cli_contrasena", MySqlDbType.VarString).Value = _contrasena;
            objSelectCmd.Parameters.Add("cli_direccion_envio", MySqlDbType.VarString).Value = _direccion_envio;
            objSelectCmd.Parameters.Add("cli_telefono", MySqlDbType.Int32).Value = _telefono;
            objSelectCmd.Parameters.Add("cli_fecha_registro", MySqlDbType.Datetime).Value = _fecha_registro;

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
        public bool updateClients(int _id, string _nombre, string _apellido, string _correo, string _contrasena, string _direccion_envio, int _telefono, DateTime _fecha_registro)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateClient"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;

            // Se agregan parámetros al comando para pasar los valores del producto.
            objSelectCmd.Parameters.Add("cli_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("cli_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("cli_apellido", MySqlDbType.VarString).Value = _apellido;
            objSelectCmd.Parameters.Add("cli_correo", MySqlDbType.VarString).Value = _correo;
            objSelectCmd.Parameters.Add("cli_contrasena", MySqlDbType.VarString).Value = _contrasena;
            objSelectCmd.Parameters.Add("cli_direccion_envio", MySqlDbType.VarString).Value = _direccion_envio;
            objSelectCmd.Parameters.Add("cli_telefono", MySqlDbType.Int32).Value = _telefono;
            objSelectCmd.Parameters.Add("cli_fecha_registro", MySqlDbType.Datetime).Value = _fecha_registro;

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

        // Método para eliminar un cliente
        public bool DeleteClient(int id)
        {
            bool executed = false;
            int row;

            MySqlCommand objCmd = new MySqlCommand();
            objCmd.Connection = objPer.openConnection();
            objCmd.CommandText = "procDeleteClient"; // Nombre del procedimiento almacenado
            objCmd.CommandType = CommandType.StoredProcedure;

            // Añadir parámetros al procedimiento
            objCmd.Parameters.Add("cli_id", MySqlDbType.Int32).Value = id;

            try
            {
                row = objCmd.ExecuteNonQuery();
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