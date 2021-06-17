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
	public class calendarversionDataAccess
	{
		calendarversion.State _state = new calendarversion.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public calendarversion Consultarcalendarversion()
		{
		    _log.Traceo("Ingresa a Metodo Consultar calendarversion", "0");
			List<calendarversion.Data> lstcalendarversion = new List<calendarversion.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_calendarversion_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					calendarversion.Data _calendarversion= new calendarversion.Data();
					_calendarversion.id = Convert.ToInt32(rdr["id"].ToString());
                    _calendarversion.description = rdr.IsDBNull(rdr.GetOrdinal("description")) ? "" : Convert.ToString(rdr["description"].ToString());
                    _calendarversion.validfrom = rdr.IsDBNull(rdr.GetOrdinal("validfrom")) ? Convert.ToDateTime("2021-01-01") : Convert.ToDateTime(rdr["validfrom"].ToString());
					_calendarversion.validuntil = rdr.IsDBNull(rdr.GetOrdinal("validuntil")) ? Convert.ToDateTime("2021-01-01") : Convert.ToDateTime(rdr["validuntil"].ToString());
                    _calendarversion.calendarid = rdr.IsDBNull(rdr.GetOrdinal("calendarid")) ? 0 : Convert.ToInt32(rdr["calendarid"].ToString());
					lstcalendarversion.Add(_calendarversion);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar calendarversion", _state.error.ToString());
				return new calendarversion(_state, lstcalendarversion);
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
			return new calendarversion(_state);
		}
		public calendarversion Buscarcalendarversion(calendarversion.Data _calendarversionData)
		{
			List<calendarversion.Data> lstcalendarversion = new List<calendarversion.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar calendarversion", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_calendarversion_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendarversionData.id);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					calendarversion.Data _calendarversion= new calendarversion.Data();
					_calendarversion.id = Convert.ToInt32(rdr["id"].ToString());
					lstcalendarversion.Add(_calendarversion);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar calendarversion", _state.error.ToString());
				return new calendarversion(_state, lstcalendarversion);
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
			return new calendarversion(_state);
		}
		public calendarversion.State Insertarcalendarversion(calendarversion.Data _calendarversion)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar calendarversion", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_calendarversion_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendarversion.id);
				SqlCmd.Parameters.AddWithValue("@description", _calendarversion.description);
				SqlCmd.Parameters.AddWithValue("@validfrom", _calendarversion.validfrom);
				SqlCmd.Parameters.AddWithValue("@validuntil", _calendarversion.validuntil);
				SqlCmd.Parameters.AddWithValue("@calendarid", _calendarversion.calendarid);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar calendarversion", _state.error.ToString());
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
		public calendarversion.State Actualizarcalendarversion(calendarversion.Data _calendarversion)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar calendarversion", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_calendarversion_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendarversion.id);
				SqlCmd.Parameters.AddWithValue("@description", _calendarversion.description);
				SqlCmd.Parameters.AddWithValue("@validfrom", _calendarversion.validfrom);
				SqlCmd.Parameters.AddWithValue("@validuntil", _calendarversion.validuntil);
				SqlCmd.Parameters.AddWithValue("@calendarid", _calendarversion.calendarid);
				
				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar calendarversion", _state.error.ToString());
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
		public calendarversion.State Eliminarcalendarversion(calendarversion.Data _calendarversion)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar calendarversion", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_calendarversion_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _calendarversion.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar calendarversion", _state.error.ToString());
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
