using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class deviceresumeprocessDataAccess
	{
		deviceresumeprocess.State _state = new deviceresumeprocess.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public deviceresumeprocess Consultardeviceresumeprocess()
		{
		    _log.Traceo("Ingresa a Metodo Consultar deviceresumeprocess", "0");
			List<deviceresumeprocess.Data> lstdeviceresumeprocess = new List<deviceresumeprocess.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceresumeprocess_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					deviceresumeprocess.Data _deviceresumeprocess= new deviceresumeprocess.Data();
					_deviceresumeprocess.id = Convert.ToInt32(rdr["id"].ToString());
					lstdeviceresumeprocess.Add(_deviceresumeprocess);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar deviceresumeprocess", _state.error.ToString());
				return new deviceresumeprocess(_state, lstdeviceresumeprocess);
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
			return new deviceresumeprocess(_state);
		}
		public deviceresumeprocess Buscardeviceresumeprocess(deviceresumeprocess.Data _deviceresumeprocessData)
		{
			List<deviceresumeprocess.Data> lstdeviceresumeprocess = new List<deviceresumeprocess.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar deviceresumeprocess", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceresumeprocess_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _deviceresumeprocessData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					deviceresumeprocess.Data _deviceresumeprocess= new deviceresumeprocess.Data();
					_deviceresumeprocess.id = Convert.ToInt32(rdr["id"].ToString());
					lstdeviceresumeprocess.Add(_deviceresumeprocess);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar deviceresumeprocess", _state.error.ToString());
				return new deviceresumeprocess(_state, lstdeviceresumeprocess);
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
			return new deviceresumeprocess(_state);
		}
		public deviceresumeprocess.State Insertardeviceresumeprocess(deviceresumeprocess.Data _deviceresumeprocess)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar deviceresumeprocess", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceresumeprocess_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _deviceresumeprocess.id);
				SqlCmd.Parameters.AddWithValue("@datefrom", _deviceresumeprocess.datefrom);
				SqlCmd.Parameters.AddWithValue("@dateuntil", _deviceresumeprocess.dateuntil);
				SqlCmd.Parameters.AddWithValue("@dateprocess", _deviceresumeprocess.dateprocess);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar deviceresumeprocess", _state.error.ToString());
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
		public deviceresumeprocess.State Actualizardeviceresumeprocess(deviceresumeprocess.Data _deviceresumeprocess)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar deviceresumeprocess", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceresumeprocess_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _deviceresumeprocess.id);
				SqlCmd.Parameters.AddWithValue("@datefrom", _deviceresumeprocess.datefrom);
				SqlCmd.Parameters.AddWithValue("@dateuntil", _deviceresumeprocess.dateuntil);
				SqlCmd.Parameters.AddWithValue("@dateprocess", _deviceresumeprocess.dateprocess);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar deviceresumeprocess", _state.error.ToString());
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
		public deviceresumeprocess.State Eliminardeviceresumeprocess(deviceresumeprocess.Data _deviceresumeprocess)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar deviceresumeprocess", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_deviceresumeprocess_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _deviceresumeprocess.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar deviceresumeprocess", _state.error.ToString());
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
