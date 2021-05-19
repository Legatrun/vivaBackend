using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using proyecto.Helpers;
using MySql.Data.MySqlClient;

namespace proyecto
{
	class Conexion
	{
        private AdministradorParametros.SQLParams administradorParametros = new AdministradorParametros.SQLParams();
        private Log _log = new Log();

        public SqlConnection AbrirConexion()
		{
			SqlConnection Cnn = new SqlConnection();
			try
			{
                string SQLConnection = administradorParametros.GetConnectionString(AdministradorParametros.SQLParams.SqlProvider.SQLSERVER.ToString());
                Cnn.ConnectionString = SQLConnection;
                Cnn.Open();
                return Cnn;
			}
			catch(Exception ex)
			{
                _log.Error(ex.Message,"-1");
                throw new Exception("Error al Abrir la Conexion a la Base de Datos");
            }
		}
		public void CerrarConexion(SqlConnection Cnn)
		{
			try
			{
				Cnn.Close();
			}
			catch(Exception ex)
			{
                _log.Error(ex.Message,"-1");
                throw new Exception("Error al Cerrar la Conexion a la Base de Datos");
			}
		}

        public MySqlConnection AbrirConexionMySql() {

            string connectionString = administradorParametros.GetConnectionString(AdministradorParametros.SQLParams.SqlProvider.MYSQL.ToString());
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            //commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                // Abre la base de datos
                databaseConnection.Open();
                return databaseConnection;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, "-1");
                throw new Exception("Error al Abrir la Conexion a la Base de Datos");
            }
        }

        public void CerrarConexionMySql(MySqlConnection Cnn)
        {
            try
            {
                // Cerrar la conexión
                Cnn.Close();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, "-1");
                throw new Exception("Error al Cerrar la Conexion a la Base de Datos");
            }
        }
    }
}
