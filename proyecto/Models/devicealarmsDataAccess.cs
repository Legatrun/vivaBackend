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
	public class devicealarmsDataAccess
	{
		devicealarms.State _state = new devicealarms.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public devicealarms Consultardevicealarms()
		{
		    _log.Traceo("Ingresa a Metodo Consultar devicealarms", "0");
			List<devicealarms.Data> lstdevicealarms = new List<devicealarms.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicealarms_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicealarms.Data _devicealarms= new devicealarms.Data();
					_devicealarms.id = Convert.ToInt32(rdr["id"].ToString());
					lstdevicealarms.Add(_devicealarms);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar devicealarms", _state.error.ToString());
				return new devicealarms(_state, lstdevicealarms);
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new devicealarms(_state);
		}
		public devicealarms Buscardevicealarms(devicealarms.Data _devicealarmsData)
		{
			List<devicealarms.Data> lstdevicealarms = new List<devicealarms.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar devicealarms", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicealarms_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicealarmsData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicealarms.Data _devicealarms= new devicealarms.Data();
					_devicealarms.id = Convert.ToInt32(rdr["id"].ToString());
					lstdevicealarms.Add(_devicealarms);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar devicealarms", _state.error.ToString());
				return new devicealarms(_state, lstdevicealarms);
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new devicealarms(_state);
		}
		public devicealarms.State Insertardevicealarms(devicealarms.Data _devicealarms)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar devicealarms", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicealarms_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicealarms.id);
				SqlCmd.Parameters.AddWithValue("@identification", _devicealarms.identification);
				SqlCmd.Parameters.AddWithValue("@alarmgroup", _devicealarms.alarmgroup);
				SqlCmd.Parameters.AddWithValue("@reportenabled", _devicealarms.reportenabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _devicealarms.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devicealarms.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _devicealarms.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _devicealarms.updateuser);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar devicealarms", _state.error.ToString());
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
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
		public devicealarms.State Actualizardevicealarms(devicealarms.Data _devicealarms)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar devicealarms", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicealarms_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicealarms.id);
				SqlCmd.Parameters.AddWithValue("@identification", _devicealarms.identification);
				SqlCmd.Parameters.AddWithValue("@alarmgroup", _devicealarms.alarmgroup);
				SqlCmd.Parameters.AddWithValue("@reportenabled", _devicealarms.reportenabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _devicealarms.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devicealarms.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _devicealarms.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _devicealarms.updateuser);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar devicealarms", _state.error.ToString());
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
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
		public devicealarms.State Eliminardevicealarms(devicealarms.Data _devicealarms)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar devicealarms", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicealarms_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicealarms.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar devicealarms", _state.error.ToString());
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
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
