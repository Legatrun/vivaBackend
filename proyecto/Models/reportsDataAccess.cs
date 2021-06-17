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
	public class reportsDataAccess
	{
		reports.State _state = new reports.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public reports Consultarreports()
		{
		    _log.Traceo("Ingresa a Metodo Consultar reports", "0");
			List<reports.Data> lstreports = new List<reports.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_reports_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					reports.Data _reports= new reports.Data();
					_reports.id = Convert.ToInt32(rdr["id"].ToString());
					_reports.reportname = Convert.ToString(rdr["reportname"].ToString());
					_reports.description = !rdr.IsDBNull(2) ? Convert.ToString(rdr["description"].ToString()) : "";
					_reports.url = !rdr.IsDBNull(3) ? Convert.ToString(rdr["url"].ToString()) : "";
					lstreports.Add(_reports);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar reports", _state.error.ToString());
				return new reports(_state, lstreports);
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
			return new reports(_state);
		}
		public reports Buscarreports(reports.Data _reportsData)
		{
			List<reports.Data> lstreports = new List<reports.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar reports", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_reports_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _reportsData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					reports.Data _reports= new reports.Data();
					_reports.id = Convert.ToInt32(rdr["id"].ToString());
					_reports.reportname = Convert.ToString(rdr["reportname"].ToString());
					_reports.description = !rdr.IsDBNull(2) ? Convert.ToString(rdr["description"].ToString()) : "";
					_reports.url = !rdr.IsDBNull(3) ? Convert.ToString(rdr["url"].ToString()) : "";
					lstreports.Add(_reports);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar reports", _state.error.ToString());
				return new reports(_state, lstreports);
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
			return new reports(_state);
		}
		public reports.State Insertarreports(reports.Data _reports)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar reports", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_reports_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pID = new SqlParameter();
				pID.ParameterName = "@ID";
				pID.Value = 0;
				SqlCmd.Parameters.Add(pID);
				pID.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@reportname", _reports.reportname);
				SqlCmd.Parameters.AddWithValue("@description", _reports.description);
				SqlCmd.Parameters.AddWithValue("@url", _reports.url);

				SqlCmd.ExecuteNonQuery();
				_reports.id = (System.Int32)pID.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar reports", _state.error.ToString());
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
		public reports.State Actualizarreports(reports.Data _reports)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar reports", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_reports_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _reports.id);
				SqlCmd.Parameters.AddWithValue("@reportname", _reports.reportname);
				SqlCmd.Parameters.AddWithValue("@description", _reports.description);
				SqlCmd.Parameters.AddWithValue("@url", _reports.url);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar reports", _state.error.ToString());
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
		public reports.State Eliminarreports(reports.Data _reports)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar reports", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_reports_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _reports.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar reports", _state.error.ToString());
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
