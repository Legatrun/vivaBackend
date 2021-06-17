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
	public class deviceinstalationtransactionprDataAccess
	{
		deviceinstalationtransactionpr.State _state = new deviceinstalationtransactionpr.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public deviceinstalationtransactionpr Consultardeviceinstalationtransactionpr()
		{
		    _log.Traceo("Ingresa a Metodo Consultar deviceinstalationtransactionpr", "0");
			List<deviceinstalationtransactionpr.Data> lstdeviceinstalationtransactionpr = new List<deviceinstalationtransactionpr.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalationtransactionpr_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					deviceinstalationtransactionpr.Data _deviceinstalationtransactionpr= new deviceinstalationtransactionpr.Data();
					lstdeviceinstalationtransactionpr.Add(_deviceinstalationtransactionpr);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar deviceinstalationtransactionpr", _state.error.ToString());
				return new deviceinstalationtransactionpr(_state, lstdeviceinstalationtransactionpr);
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
			return new deviceinstalationtransactionpr(_state);
		}
		public deviceinstalationtransactionpr Buscardeviceinstalationtransactionpr(deviceinstalationtransactionpr.Data _deviceinstalationtransactionprData)
		{
			List<deviceinstalationtransactionpr.Data> lstdeviceinstalationtransactionpr = new List<deviceinstalationtransactionpr.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar deviceinstalationtransactionpr", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalationtransactionpr_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					deviceinstalationtransactionpr.Data _deviceinstalationtransactionpr= new deviceinstalationtransactionpr.Data();
					lstdeviceinstalationtransactionpr.Add(_deviceinstalationtransactionpr);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar deviceinstalationtransactionpr", _state.error.ToString());
				return new deviceinstalationtransactionpr(_state, lstdeviceinstalationtransactionpr);
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
			return new deviceinstalationtransactionpr(_state);
		}
		public deviceinstalationtransactionpr.State Insertardeviceinstalationtransactionpr(deviceinstalationtransactionpr.Data _deviceinstalationtransactionpr)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar deviceinstalationtransactionpr", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalationtransactionpr_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _deviceinstalationtransactionpr.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@enabled", _deviceinstalationtransactionpr.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _deviceinstalationtransactionpr.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _deviceinstalationtransactionpr.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _deviceinstalationtransactionpr.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _deviceinstalationtransactionpr.updateuser);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _deviceinstalationtransactionpr.locationidentification);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _deviceinstalationtransactionpr.provideridentification);
				SqlCmd.Parameters.AddWithValue("@providerdeviceidentification", _deviceinstalationtransactionpr.providerdeviceidentification);
				SqlCmd.Parameters.AddWithValue("@providerlocationidentification", _deviceinstalationtransactionpr.providerlocationidentification);
				SqlCmd.Parameters.AddWithValue("@providersequencenumber", _deviceinstalationtransactionpr.providersequencenumber);
				SqlCmd.Parameters.AddWithValue("@lasttransactiontimestamp", _deviceinstalationtransactionpr.lasttransactiontimestamp);
				SqlCmd.Parameters.AddWithValue("@transactionidentification", _deviceinstalationtransactionpr.transactionidentification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar deviceinstalationtransactionpr", _state.error.ToString());
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
		public deviceinstalationtransactionpr.State Actualizardeviceinstalationtransactionpr(deviceinstalationtransactionpr.Data _deviceinstalationtransactionpr)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar deviceinstalationtransactionpr", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalationtransactionpr_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _deviceinstalationtransactionpr.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@enabled", _deviceinstalationtransactionpr.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _deviceinstalationtransactionpr.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _deviceinstalationtransactionpr.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _deviceinstalationtransactionpr.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _deviceinstalationtransactionpr.updateuser);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _deviceinstalationtransactionpr.locationidentification);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _deviceinstalationtransactionpr.provideridentification);
				SqlCmd.Parameters.AddWithValue("@providerdeviceidentification", _deviceinstalationtransactionpr.providerdeviceidentification);
				SqlCmd.Parameters.AddWithValue("@providerlocationidentification", _deviceinstalationtransactionpr.providerlocationidentification);
				SqlCmd.Parameters.AddWithValue("@providersequencenumber", _deviceinstalationtransactionpr.providersequencenumber);
				SqlCmd.Parameters.AddWithValue("@lasttransactiontimestamp", _deviceinstalationtransactionpr.lasttransactiontimestamp);
				SqlCmd.Parameters.AddWithValue("@transactionidentification", _deviceinstalationtransactionpr.transactionidentification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar deviceinstalationtransactionpr", _state.error.ToString());
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
		public deviceinstalationtransactionpr.State Eliminardeviceinstalationtransactionpr(deviceinstalationtransactionpr.Data _deviceinstalationtransactionpr)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar deviceinstalationtransactionpr", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalationtransactionpr_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar deviceinstalationtransactionpr", _state.error.ToString());
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
