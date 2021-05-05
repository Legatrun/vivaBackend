using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class calendardayexceptionDataAccess
	{
		calendardayexception.State _state = new calendardayexception.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public calendardayexception Consultarcalendardayexception()
		{
		    _log.Traceo("Ingresa a Metodo Consultar calendardayexception", "0");
			List<calendardayexception.Data> lstcalendardayexception = new List<calendardayexception.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_calendardayexception_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					calendardayexception.Data _calendardayexception= new calendardayexception.Data();
					_calendardayexception.id = Convert.ToInt32(rdr["id"].ToString());
					lstcalendardayexception.Add(_calendardayexception);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar calendardayexception", _state.error.ToString());
				return new calendardayexception(_state, lstcalendardayexception);
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
			return new calendardayexception(_state);
		}
		public calendardayexception Buscarcalendardayexception(calendardayexception.Data _calendardayexceptionData)
		{
			List<calendardayexception.Data> lstcalendardayexception = new List<calendardayexception.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar calendardayexception", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_calendardayexception_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendardayexceptionData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					calendardayexception.Data _calendardayexception= new calendardayexception.Data();
					_calendardayexception.id = Convert.ToInt32(rdr["id"].ToString());
					lstcalendardayexception.Add(_calendardayexception);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar calendardayexception", _state.error.ToString());
				return new calendardayexception(_state, lstcalendardayexception);
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
			return new calendardayexception(_state);
		}
		public calendardayexception.State Insertarcalendardayexception(calendardayexception.Data _calendardayexception)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar calendardayexception", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_calendardayexception_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendardayexception.id);
				SqlCmd.Parameters.AddWithValue("@day", _calendardayexception.day);
				SqlCmd.Parameters.AddWithValue("@description", _calendardayexception.description);
				SqlCmd.Parameters.AddWithValue("@calendarversionid", _calendardayexception.calendarversionid);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _calendardayexception.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _calendardayexception.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _calendardayexception.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _calendardayexception.updateuser);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar calendardayexception", _state.error.ToString());
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
		public calendardayexception.State Actualizarcalendardayexception(calendardayexception.Data _calendardayexception)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar calendardayexception", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_calendardayexception_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendardayexception.id);
				SqlCmd.Parameters.AddWithValue("@day", _calendardayexception.day);
				SqlCmd.Parameters.AddWithValue("@description", _calendardayexception.description);
				SqlCmd.Parameters.AddWithValue("@calendarversionid", _calendardayexception.calendarversionid);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _calendardayexception.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _calendardayexception.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _calendardayexception.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _calendardayexception.updateuser);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar calendardayexception", _state.error.ToString());
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
		public calendardayexception.State Eliminarcalendardayexception(calendardayexception.Data _calendardayexception)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar calendardayexception", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_calendardayexception_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendardayexception.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar calendardayexception", _state.error.ToString());
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
