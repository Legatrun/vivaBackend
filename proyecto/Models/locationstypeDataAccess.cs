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
	public class locationstypeDataAccess
	{
		locationstype.State _state = new locationstype.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public locationstype Consultarlocationstype()
		{
		    _log.Traceo("Ingresa a Metodo Consultar locationstype", "0");
			List<locationstype.Data> lstlocationstype = new List<locationstype.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_locationstype_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					locationstype.Data _locationstype= new locationstype.Data();
					_locationstype.id = Convert.ToInt32(rdr["id"].ToString());
					_locationstype.identification = Convert.ToString(rdr["identification"].ToString());
					_locationstype.description = !rdr.IsDBNull(2) ? Convert.ToString(rdr["description"].ToString()) : "";
					_locationstype.calendarid = !rdr.IsDBNull(3) ? Convert.ToInt32(rdr["calendarid"].ToString()) : (System.Int32)0;
					_locationstype.createtimestamp = Convert.ToDateTime(rdr["createtimestamp"].ToString());
					_locationstype.updatetimestamp = !rdr.IsDBNull(5) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_locationstype.createuser = Convert.ToString(rdr["createuser"].ToString());
					_locationstype.updateuser = Convert.ToString(rdr["updateuser"].ToString());
					lstlocationstype.Add(_locationstype);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar locationstype", _state.error.ToString());
				return new locationstype(_state, lstlocationstype);
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new locationstype(_state);
		}
		public locationstype Buscarlocationstype(locationstype.Data _locationstypeData)
		{
			List<locationstype.Data> lstlocationstype = new List<locationstype.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar locationstype", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_locationstype_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@pID", _locationstypeData.id);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					locationstype.Data _locationstype= new locationstype.Data();
					_locationstype.id = Convert.ToInt32(rdr["id"].ToString());
					_locationstype.identification = Convert.ToString(rdr["identification"].ToString());
					_locationstype.description = !rdr.IsDBNull(2) ? Convert.ToString(rdr["description"].ToString()) : "";
					_locationstype.calendarid = !rdr.IsDBNull(3) ? Convert.ToInt32(rdr["calendarid"].ToString()) : (System.Int32)0;
					_locationstype.createtimestamp = Convert.ToDateTime(rdr["createtimestamp"].ToString());
					_locationstype.updatetimestamp = !rdr.IsDBNull(5) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_locationstype.createuser = Convert.ToString(rdr["createuser"].ToString());
					_locationstype.updateuser = Convert.ToString(rdr["updateuser"].ToString());
					lstlocationstype.Add(_locationstype);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar locationstype", _state.error.ToString());
				return new locationstype(_state, lstlocationstype);
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new locationstype(_state);
		}
		public locationstype.State Insertarlocationstype(locationstype.Data _locationstype)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar locationstype", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_locationstype_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlParameter pID = new MySqlParameter();
				pID.ParameterName = "@ID";
				pID.Value = 0;
				SqlCmd.Parameters.Add(pID);
				pID.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@identification", _locationstype.identification);
				SqlCmd.Parameters.AddWithValue("@description", _locationstype.description);
				SqlCmd.Parameters.AddWithValue("@calendarid", _locationstype.calendarid);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _locationstype.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _locationstype.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _locationstype.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _locationstype.updateuser);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar locationstype", _state.error.ToString());
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
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
		public locationstype.State Actualizarlocationstype(locationstype.Data _locationstype)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar locationstype", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_locationstype_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _locationstype.id);
				SqlCmd.Parameters.AddWithValue("@identification", _locationstype.identification);
				SqlCmd.Parameters.AddWithValue("@description", _locationstype.description);
				SqlCmd.Parameters.AddWithValue("@calendarid", _locationstype.calendarid);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _locationstype.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _locationstype.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _locationstype.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _locationstype.updateuser);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar locationstype", _state.error.ToString());
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
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
		public locationstype.State Eliminarlocationstype(locationstype.Data _locationstype)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar locationstype", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_locationstype_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _locationstype.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar locationstype", _state.error.ToString());
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
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
