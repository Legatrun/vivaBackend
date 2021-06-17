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
	public class tb_gruposDataAccess
	{
		tb_grupos.State _state = new tb_grupos.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public tb_grupos Consultartb_grupos()
		{
		    _log.Traceo("Ingresa a Metodo Consultar tb_grupos", "0");
			List<tb_grupos.Data> lsttb_grupos = new List<tb_grupos.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_grupos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tb_grupos.Data _tb_grupos= new tb_grupos.Data();
					_tb_grupos.id = Convert.ToInt32(rdr["id"].ToString());
					lsttb_grupos.Add(_tb_grupos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar tb_grupos", _state.error.ToString());
				return new tb_grupos(_state, lsttb_grupos);
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
			return new tb_grupos(_state);
		}
		public tb_grupos Buscartb_grupos(tb_grupos.Data _tb_gruposData)
		{
			List<tb_grupos.Data> lsttb_grupos = new List<tb_grupos.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar tb_grupos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_grupos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_gruposData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tb_grupos.Data _tb_grupos= new tb_grupos.Data();
					_tb_grupos.id = Convert.ToInt32(rdr["id"].ToString());
					lsttb_grupos.Add(_tb_grupos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar tb_grupos", _state.error.ToString());
				return new tb_grupos(_state, lsttb_grupos);
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
			return new tb_grupos(_state);
		}
		public tb_grupos.State Insertartb_grupos(tb_grupos.Data _tb_grupos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar tb_grupos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_grupos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_grupos.id);
				SqlCmd.Parameters.AddWithValue("@descripcion", _tb_grupos.descripcion);
				SqlCmd.Parameters.AddWithValue("@create_timestamp", _tb_grupos.create_timestamp);
				SqlCmd.Parameters.AddWithValue("@fec_modificacion", _tb_grupos.fec_modificacion);
				SqlCmd.Parameters.AddWithValue("@usua_modificacion", _tb_grupos.usua_modificacion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar tb_grupos", _state.error.ToString());
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
		public tb_grupos.State Actualizartb_grupos(tb_grupos.Data _tb_grupos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar tb_grupos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_grupos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_grupos.id);
				SqlCmd.Parameters.AddWithValue("@descripcion", _tb_grupos.descripcion);
				SqlCmd.Parameters.AddWithValue("@create_timestamp", _tb_grupos.create_timestamp);
				SqlCmd.Parameters.AddWithValue("@fec_modificacion", _tb_grupos.fec_modificacion);
				SqlCmd.Parameters.AddWithValue("@usua_modificacion", _tb_grupos.usua_modificacion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar tb_grupos", _state.error.ToString());
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
		public tb_grupos.State Eliminartb_grupos(tb_grupos.Data _tb_grupos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar tb_grupos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_grupos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_grupos.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar tb_grupos", _state.error.ToString());
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
