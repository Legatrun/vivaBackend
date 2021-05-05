using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class deviceinstalationproviderDataAccess
	{
		deviceinstalationprovider.State _state = new deviceinstalationprovider.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public deviceinstalationprovider Consultardeviceinstalationprovider()
		{
		    _log.Traceo("Ingresa a Metodo Consultar deviceinstalationprovider", "0");
			List<deviceinstalationprovider.Data> lstdeviceinstalationprovider = new List<deviceinstalationprovider.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalationprovider_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					deviceinstalationprovider.Data _deviceinstalationprovider= new deviceinstalationprovider.Data();
					lstdeviceinstalationprovider.Add(_deviceinstalationprovider);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar deviceinstalationprovider", _state.error.ToString());
				return new deviceinstalationprovider(_state, lstdeviceinstalationprovider);
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
			return new deviceinstalationprovider(_state);
		}
		public deviceinstalationprovider Buscardeviceinstalationprovider(deviceinstalationprovider.Data _deviceinstalationproviderData)
		{
			List<deviceinstalationprovider.Data> lstdeviceinstalationprovider = new List<deviceinstalationprovider.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar deviceinstalationprovider", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalationprovider_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					deviceinstalationprovider.Data _deviceinstalationprovider= new deviceinstalationprovider.Data();
					lstdeviceinstalationprovider.Add(_deviceinstalationprovider);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar deviceinstalationprovider", _state.error.ToString());
				return new deviceinstalationprovider(_state, lstdeviceinstalationprovider);
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
			return new deviceinstalationprovider(_state);
		}
		public deviceinstalationprovider.State Insertardeviceinstalationprovider(deviceinstalationprovider.Data _deviceinstalationprovider)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar deviceinstalationprovider", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalationprovider_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _deviceinstalationprovider.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@enabled", _deviceinstalationprovider.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _deviceinstalationprovider.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _deviceinstalationprovider.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _deviceinstalationprovider.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _deviceinstalationprovider.updateuser);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _deviceinstalationprovider.locationidentification);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _deviceinstalationprovider.provideridentification);
				SqlCmd.Parameters.AddWithValue("@providerdeviceidentification", _deviceinstalationprovider.providerdeviceidentification);
				SqlCmd.Parameters.AddWithValue("@providerlocationidentification", _deviceinstalationprovider.providerlocationidentification);
				SqlCmd.Parameters.AddWithValue("@providersequencenumber", _deviceinstalationprovider.providersequencenumber);
				SqlCmd.Parameters.AddWithValue("@lasttransactiontimestamp", _deviceinstalationprovider.lasttransactiontimestamp);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar deviceinstalationprovider", _state.error.ToString());
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
		public deviceinstalationprovider.State Actualizardeviceinstalationprovider(deviceinstalationprovider.Data _deviceinstalationprovider)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar deviceinstalationprovider", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalationprovider_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _deviceinstalationprovider.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@enabled", _deviceinstalationprovider.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _deviceinstalationprovider.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _deviceinstalationprovider.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _deviceinstalationprovider.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _deviceinstalationprovider.updateuser);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _deviceinstalationprovider.locationidentification);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _deviceinstalationprovider.provideridentification);
				SqlCmd.Parameters.AddWithValue("@providerdeviceidentification", _deviceinstalationprovider.providerdeviceidentification);
				SqlCmd.Parameters.AddWithValue("@providerlocationidentification", _deviceinstalationprovider.providerlocationidentification);
				SqlCmd.Parameters.AddWithValue("@providersequencenumber", _deviceinstalationprovider.providersequencenumber);
				SqlCmd.Parameters.AddWithValue("@lasttransactiontimestamp", _deviceinstalationprovider.lasttransactiontimestamp);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar deviceinstalationprovider", _state.error.ToString());
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
		public deviceinstalationprovider.State Eliminardeviceinstalationprovider(deviceinstalationprovider.Data _deviceinstalationprovider)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar deviceinstalationprovider", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceinstalationprovider_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar deviceinstalationprovider", _state.error.ToString());
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
