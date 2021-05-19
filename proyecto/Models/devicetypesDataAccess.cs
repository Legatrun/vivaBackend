using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class devicetypesDataAccess
	{
		devicetypes.State _state = new devicetypes.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public devicetypes Consultardevicetypes()
		{
		    _log.Traceo("Ingresa a Metodo Consultar devicetypes", "0");
			List<devicetypes.Data> lstdevicetypes = new List<devicetypes.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicetypes_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicetypes.Data _devicetypes= new devicetypes.Data();
					_devicetypes.identification = Convert.ToString(rdr["identification"].ToString());
					_devicetypes.description = !rdr.IsDBNull(1) ? Convert.ToString(rdr["description"].ToString()) : "";
					_devicetypes.enabled = Convert.ToInt32(rdr["enabled"].ToString());
					_devicetypes.createtimestamp = !rdr.IsDBNull(3) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_devicetypes.updatetimestamp = !rdr.IsDBNull(4) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_devicetypes.createuser = !rdr.IsDBNull(5) ? Convert.ToString(rdr["createuser"].ToString()) : "";
					_devicetypes.updateuser = !rdr.IsDBNull(6) ? Convert.ToString(rdr["updateuser"].ToString()) : "";
					_devicetypes.configuration = !rdr.IsDBNull(7) ? Convert.ToString(rdr["configuration"].ToString()) : "";
					lstdevicetypes.Add(_devicetypes);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar devicetypes", _state.error.ToString());
				return new devicetypes(_state, lstdevicetypes);
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new devicetypes(_state);
		}
		public devicetypes Buscardevicetypes(devicetypes.Data _devicetypesData)
		{
			List<devicetypes.Data> lstdevicetypes = new List<devicetypes.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar devicetypes", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicetypes_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@pIDENTIFICATION", _devicetypesData.identification);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicetypes.Data _devicetypes= new devicetypes.Data();
					_devicetypes.identification = Convert.ToString(rdr["identification"].ToString());
					_devicetypes.description = !rdr.IsDBNull(1) ? Convert.ToString(rdr["description"].ToString()) : "";
					_devicetypes.enabled = Convert.ToInt32(rdr["enabled"].ToString());
					_devicetypes.createtimestamp = !rdr.IsDBNull(3) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_devicetypes.updatetimestamp = !rdr.IsDBNull(4) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_devicetypes.createuser = !rdr.IsDBNull(5) ? Convert.ToString(rdr["createuser"].ToString()) : "";
					_devicetypes.updateuser = !rdr.IsDBNull(6) ? Convert.ToString(rdr["updateuser"].ToString()) : "";
					_devicetypes.configuration = !rdr.IsDBNull(7) ? Convert.ToString(rdr["configuration"].ToString()) : "";
					lstdevicetypes.Add(_devicetypes);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar devicetypes", _state.error.ToString());
				return new devicetypes(_state, lstdevicetypes);
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new devicetypes(_state);
		}
		public devicetypes.State Insertardevicetypes(devicetypes.Data _devicetypes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar devicetypes", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicetypes_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devicetypes.identification);
				SqlCmd.Parameters.AddWithValue("@description", _devicetypes.description);
				SqlCmd.Parameters.AddWithValue("@enabled", _devicetypes.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _devicetypes.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devicetypes.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _devicetypes.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _devicetypes.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _devicetypes.configuration);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar devicetypes", _state.error.ToString());
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
		public devicetypes.State Actualizardevicetypes(devicetypes.Data _devicetypes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar devicetypes", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicetypes_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devicetypes.identification);
				SqlCmd.Parameters.AddWithValue("@description", _devicetypes.description);
				SqlCmd.Parameters.AddWithValue("@enabled", _devicetypes.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _devicetypes.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devicetypes.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _devicetypes.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _devicetypes.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _devicetypes.configuration);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar devicetypes", _state.error.ToString());
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
		public devicetypes.State Eliminardevicetypes(devicetypes.Data _devicetypes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar devicetypes", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicetypes_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devicetypes.identification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar devicetypes", _state.error.ToString());
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
	}
}
