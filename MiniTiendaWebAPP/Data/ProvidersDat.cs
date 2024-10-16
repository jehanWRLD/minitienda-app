using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Data
{
    public class ProvidersDat
    {
        Persistence objPer = new Persistence();

        // Método para mostrar todos los Proveedores
        public DataSet showProviders()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procShowSuppliers";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para mostrar únicamente el id y el nombre del proveedor
        public DataSet showProvidersDDL()
        {
            MySqlDataAdapter objAdapter = new MySqlDataAdapter();
            DataSet objData = new DataSet();

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procShowSuppliersDDL";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(objData);
            objPer.closeConnection();
            return objData;
        }

        // Método para guardar un nuevo Proveedor
        public bool saveProvider(int _id, string _nombre, string _contacto, string _telefono, string _direccion)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procInsertSupplier"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("prov_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("prov_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("prov_contacto", MySqlDbType.VarString).Value = _contacto;
            objSelectCmd.Parameters.Add("prov_telefono", MySqlDbType.Double).Value = _telefono;
            objSelectCmd.Parameters.Add("prov_direccion", MySqlDbType.VarString).Value = _direccion;


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

        // Método para actualizar un Proveedor
        public bool updateProvider(int _id, string _nombre, string _contacto, string _telefono, string _direccion)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procUpdateSupplier"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("prov_id", MySqlDbType.Int32).Value = _id;
            objSelectCmd.Parameters.Add("prov_nombre", MySqlDbType.VarString).Value = _nombre;
            objSelectCmd.Parameters.Add("prov_contacto", MySqlDbType.VarString).Value = _contacto;
            objSelectCmd.Parameters.Add("prov_telefono", MySqlDbType.Double).Value = _telefono;
            objSelectCmd.Parameters.Add("prov_direccion", MySqlDbType.Text).Value = _direccion;

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

        // Método para borrar un Proveedor
        public bool deleteProvider(int _id)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelectCmd = new MySqlCommand();
            objSelectCmd.Connection = objPer.openConnection();
            objSelectCmd.CommandText = "procDeleteSupplier"; //nombre del procedimiento almacenado
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("prov_id", MySqlDbType.Int32).Value = _id;

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