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
	public class calendarhourrangeDataAccess
	{
		calendarhourrange.State _state = new calendarhourrange.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public calendarhourrange Consultarcalendarhourrange()
		{
		    _log.Traceo("Ingresa a Metodo Consultar calendarhourrange", "0");
			List<calendarhourrange.Data> lstcalendarhourrange = new List<calendarhourrange.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_calendarhourrange_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					calendarhourrange.Data _calendarhourrange= new calendarhourrange.Data();
					_calendarhourrange.id = Convert.ToInt32(rdr["id"].ToString());
					lstcalendarhourrange.Add(_calendarhourrange);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar calendarhourrange", _state.error.ToString());
				return new calendarhourrange(_state, lstcalendarhourrange);
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
			return new calendarhourrange(_state);
		}
		public calendarhourrange Buscarcalendarhourrange(calendarhourrange.Data _calendarhourrangeData)
		{
			List<calendarhourrange.Data> lstcalendarhourrange = new List<calendarhourrange.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar calendarhourrange", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_calendarhourrange_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendarhourrangeData.id);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					calendarhourrange.Data _calendarhourrange= new calendarhourrange.Data();
					_calendarhourrange.id = Convert.ToInt32(rdr["id"].ToString());
					lstcalendarhourrange.Add(_calendarhourrange);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar calendarhourrange", _state.error.ToString());
				return new calendarhourrange(_state, lstcalendarhourrange);
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
			return new calendarhourrange(_state);
		}
		public calendarhourrange.State Insertarcalendarhourrange(calendarhourrange.Data _calendarhourrange)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar calendarhourrange", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_calendarhourrange_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendarhourrange.id);
				SqlCmd.Parameters.AddWithValue("@fromhour", _calendarhourrange.fromhour);
				SqlCmd.Parameters.AddWithValue("@fromminute", _calendarhourrange.fromminute);
				SqlCmd.Parameters.AddWithValue("@untilhour", _calendarhourrange.untilhour);
				SqlCmd.Parameters.AddWithValue("@untilminute", _calendarhourrange.untilminute);
				SqlCmd.Parameters.AddWithValue("@calendardayexceptionid", _calendarhourrange.calendardayexceptionid);
				SqlCmd.Parameters.AddWithValue("@dayofweekid", _calendarhourrange.dayofweekid);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _calendarhourrange.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _calendarhourrange.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _calendarhourrange.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _calendarhourrange.updateuser);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar calendarhourrange", _state.error.ToString());
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
		public calendarhourrange.State Actualizarcalendarhourrange(calendarhourrange.Data _calendarhourrange)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar calendarhourrange", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_calendarhourrange_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendarhourrange.id);
				SqlCmd.Parameters.AddWithValue("@fromhour", _calendarhourrange.fromhour);
				SqlCmd.Parameters.AddWithValue("@fromminute", _calendarhourrange.fromminute);
				SqlCmd.Parameters.AddWithValue("@untilhour", _calendarhourrange.untilhour);
				SqlCmd.Parameters.AddWithValue("@untilminute", _calendarhourrange.untilminute);
				SqlCmd.Parameters.AddWithValue("@calendardayexceptionid", _calendarhourrange.calendardayexceptionid);
				SqlCmd.Parameters.AddWithValue("@dayofweekid", _calendarhourrange.dayofweekid);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _calendarhourrange.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _calendarhourrange.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _calendarhourrange.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _calendarhourrange.updateuser);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar calendarhourrange", _state.error.ToString());
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
		public calendarhourrange.State Eliminarcalendarhourrange(calendarhourrange.Data _calendarhourrange)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar calendarhourrange", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_calendarhourrange_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendarhourrange.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar calendarhourrange", _state.error.ToString());
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
