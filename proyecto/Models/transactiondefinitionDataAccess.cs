using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class transactiondefinitionDataAccess
	{
		transactiondefinition.State _state = new transactiondefinition.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public transactiondefinition Consultartransactiondefinition()
		{
		    _log.Traceo("Ingresa a Metodo Consultar transactiondefinition", "0");
			List<transactiondefinition.Data> lsttransactiondefinition = new List<transactiondefinition.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_transactiondefinition_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					transactiondefinition.Data _transactiondefinition= new transactiondefinition.Data();
					_transactiondefinition.identification = Convert.ToString(rdr["identification"].ToString());
					lsttransactiondefinition.Add(_transactiondefinition);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar transactiondefinition", _state.error.ToString());
				return new transactiondefinition(_state, lsttransactiondefinition);
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
			return new transactiondefinition(_state);
		}
		public transactiondefinition Buscartransactiondefinition(transactiondefinition.Data _transactiondefinitionData)
		{
			List<transactiondefinition.Data> lsttransactiondefinition = new List<transactiondefinition.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar transactiondefinition", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_transactiondefinition_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _transactiondefinitionData.identification);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					transactiondefinition.Data _transactiondefinition= new transactiondefinition.Data();
					_transactiondefinition.identification = Convert.ToString(rdr["identification"].ToString());
					lsttransactiondefinition.Add(_transactiondefinition);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar transactiondefinition", _state.error.ToString());
				return new transactiondefinition(_state, lsttransactiondefinition);
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
			return new transactiondefinition(_state);
		}
		public transactiondefinition.State Insertartransactiondefinition(transactiondefinition.Data _transactiondefinition)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar transactiondefinition", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_transactiondefinition_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _transactiondefinition.identification);
				SqlCmd.Parameters.AddWithValue("@description", _transactiondefinition.description);
				SqlCmd.Parameters.AddWithValue("@type", _transactiondefinition.type);
				SqlCmd.Parameters.AddWithValue("@enabled", _transactiondefinition.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _transactiondefinition.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _transactiondefinition.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _transactiondefinition.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _transactiondefinition.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _transactiondefinition.configuration);
				SqlCmd.Parameters.AddWithValue("@servicename", _transactiondefinition.servicename);
				SqlCmd.Parameters.AddWithValue("@operationname", _transactiondefinition.operationname);
				SqlCmd.Parameters.AddWithValue("@hlabel", _transactiondefinition.hlabel);
				SqlCmd.Parameters.AddWithValue("@vlabel", _transactiondefinition.vlabel);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar transactiondefinition", _state.error.ToString());
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
		public transactiondefinition.State Actualizartransactiondefinition(transactiondefinition.Data _transactiondefinition)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar transactiondefinition", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_transactiondefinition_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _transactiondefinition.identification);
				SqlCmd.Parameters.AddWithValue("@description", _transactiondefinition.description);
				SqlCmd.Parameters.AddWithValue("@type", _transactiondefinition.type);
				SqlCmd.Parameters.AddWithValue("@enabled", _transactiondefinition.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _transactiondefinition.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _transactiondefinition.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _transactiondefinition.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _transactiondefinition.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _transactiondefinition.configuration);
				SqlCmd.Parameters.AddWithValue("@servicename", _transactiondefinition.servicename);
				SqlCmd.Parameters.AddWithValue("@operationname", _transactiondefinition.operationname);
				SqlCmd.Parameters.AddWithValue("@hlabel", _transactiondefinition.hlabel);
				SqlCmd.Parameters.AddWithValue("@vlabel", _transactiondefinition.vlabel);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar transactiondefinition", _state.error.ToString());
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
		public transactiondefinition.State Eliminartransactiondefinition(transactiondefinition.Data _transactiondefinition)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar transactiondefinition", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_transactiondefinition_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _transactiondefinition.identification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar transactiondefinition", _state.error.ToString());
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
