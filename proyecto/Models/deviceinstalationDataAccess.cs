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
	public class deviceinstalationDataAccess
	{
		deviceinstalation.State _state = new deviceinstalation.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public deviceinstalation Consultardeviceinstalation()
		{
		    _log.Traceo("Ingresa a Metodo Consultar deviceinstalation", "0");
			List<deviceinstalation.Data> lstdeviceinstalation = new List<deviceinstalation.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalation_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					deviceinstalation.Data _deviceinstalation= new deviceinstalation.Data();
					lstdeviceinstalation.Add(_deviceinstalation);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar deviceinstalation", _state.error.ToString());
				return new deviceinstalation(_state, lstdeviceinstalation);
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
			return new deviceinstalation(_state);
		}
		public deviceinstalation Buscardeviceinstalation(deviceinstalation.Data _deviceinstalationData)
		{
			List<deviceinstalation.Data> lstdeviceinstalation = new List<deviceinstalation.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar deviceinstalation", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalation_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					deviceinstalation.Data _deviceinstalation= new deviceinstalation.Data();
					lstdeviceinstalation.Add(_deviceinstalation);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar deviceinstalation", _state.error.ToString());
				return new deviceinstalation(_state, lstdeviceinstalation);
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
			return new deviceinstalation(_state);
		}
		public deviceinstalation.State Insertardeviceinstalation(deviceinstalation.Data _deviceinstalation)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar deviceinstalation", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalation_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _deviceinstalation.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@enabled", _deviceinstalation.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _deviceinstalation.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _deviceinstalation.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _deviceinstalation.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _deviceinstalation.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _deviceinstalation.configuration);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _deviceinstalation.locationidentification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar deviceinstalation", _state.error.ToString());
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
		public deviceinstalation.State Actualizardeviceinstalation(deviceinstalation.Data _deviceinstalation)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar deviceinstalation", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalation_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _deviceinstalation.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@enabled", _deviceinstalation.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _deviceinstalation.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _deviceinstalation.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _deviceinstalation.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _deviceinstalation.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _deviceinstalation.configuration);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _deviceinstalation.locationidentification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar deviceinstalation", _state.error.ToString());
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
		public deviceinstalation.State Eliminardeviceinstalation(deviceinstalation.Data _deviceinstalation)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar deviceinstalation", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalation_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar deviceinstalation", _state.error.ToString());
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
