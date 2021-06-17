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
	public class dayofweekDataAccess
	{
		dayofweek.State _state = new dayofweek.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public dayofweek Consultardayofweek()
		{
		    _log.Traceo("Ingresa a Metodo Consultar dayofweek", "0");
			List<dayofweek.Data> lstdayofweek = new List<dayofweek.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_dayofweek_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					dayofweek.Data _dayofweek= new dayofweek.Data();
					_dayofweek.id = Convert.ToInt32(rdr["id"].ToString());
					lstdayofweek.Add(_dayofweek);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar dayofweek", _state.error.ToString());
				return new dayofweek(_state, lstdayofweek);
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
			return new dayofweek(_state);
		}
		public dayofweek Buscardayofweek(dayofweek.Data _dayofweekData)
		{
			List<dayofweek.Data> lstdayofweek = new List<dayofweek.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar dayofweek", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_dayofweek_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _dayofweekData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					dayofweek.Data _dayofweek= new dayofweek.Data();
					_dayofweek.id = Convert.ToInt32(rdr["id"].ToString());
					lstdayofweek.Add(_dayofweek);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar dayofweek", _state.error.ToString());
				return new dayofweek(_state, lstdayofweek);
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
			return new dayofweek(_state);
		}
		public dayofweek.State Insertardayofweek(dayofweek.Data _dayofweek)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar dayofweek", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_dayofweek_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _dayofweek.id);
				SqlCmd.Parameters.AddWithValue("@description", _dayofweek.description);
				SqlCmd.Parameters.AddWithValue("@calendarversionid", _dayofweek.calendarversionid);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _dayofweek.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _dayofweek.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _dayofweek.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _dayofweek.updateuser);
				SqlCmd.Parameters.AddWithValue("@orden", _dayofweek.orden);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar dayofweek", _state.error.ToString());
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
		public dayofweek.State Actualizardayofweek(dayofweek.Data _dayofweek)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar dayofweek", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_dayofweek_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _dayofweek.id);
				SqlCmd.Parameters.AddWithValue("@description", _dayofweek.description);
				SqlCmd.Parameters.AddWithValue("@calendarversionid", _dayofweek.calendarversionid);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _dayofweek.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _dayofweek.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _dayofweek.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _dayofweek.updateuser);
				SqlCmd.Parameters.AddWithValue("@orden", _dayofweek.orden);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar dayofweek", _state.error.ToString());
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
		public dayofweek.State Eliminardayofweek(dayofweek.Data _dayofweek)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar dayofweek", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_dayofweek_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _dayofweek.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar dayofweek", _state.error.ToString());
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
