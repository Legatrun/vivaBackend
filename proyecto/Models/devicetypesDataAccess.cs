using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicetypes_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicetypes.Data _devicetypes= new devicetypes.Data();
					_devicetypes.identification = Convert.ToString(rdr["identification"].ToString());
					_devicetypes.identification = Convert.ToString(rdr["description"].ToString());
					_devicetypes.identification = Convert.ToString(rdr["enabled"].ToString());
					_devicetypes.identification = Convert.ToString(rdr["configuration"].ToString());
					lstdevicetypes.Add(_devicetypes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar devicetypes", _state.error.ToString());
				return new devicetypes(_state, lstdevicetypes);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicetypes_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devicetypesData.identification);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicetypes.Data _devicetypes= new devicetypes.Data();
					_devicetypes.identification = Convert.ToString(rdr["identification"].ToString());
					lstdevicetypes.Add(_devicetypes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar devicetypes", _state.error.ToString());
				return new devicetypes(_state, lstdevicetypes);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicetypes_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devicetypes.identification);
				SqlCmd.Parameters.AddWithValue("@description", _devicetypes.description);
				SqlCmd.Parameters.AddWithValue("@enabled", _devicetypes.enabled);
				//SqlCmd.Parameters.AddWithValue("@createtimestamp", _devicetypes.createtimestamp);
				//SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devicetypes.updatetimestamp);
				//SqlCmd.Parameters.AddWithValue("@createuser", _devicetypes.createuser);
				//SqlCmd.Parameters.AddWithValue("@updateuser", _devicetypes.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _devicetypes.configuration);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar devicetypes", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Insertar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicetypes_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devicetypes.identification);
				SqlCmd.Parameters.AddWithValue("@description", _devicetypes.description);
				SqlCmd.Parameters.AddWithValue("@enabled", _devicetypes.enabled);
				//SqlCmd.Parameters.AddWithValue("@createtimestamp", _devicetypes.createtimestamp);
				//SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devicetypes.updatetimestamp);
				//SqlCmd.Parameters.AddWithValue("@createuser", _devicetypes.createuser);
				//SqlCmd.Parameters.AddWithValue("@updateuser", _devicetypes.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _devicetypes.configuration);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar devicetypes", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Actualizar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicetypes_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devicetypes.identification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar devicetypes", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Eliminar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
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
