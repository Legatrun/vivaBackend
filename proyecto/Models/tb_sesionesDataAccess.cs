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
	public class tb_sesionesDataAccess
	{
		tb_sesiones.State _state = new tb_sesiones.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public tb_sesiones Consultartb_sesiones()
		{
		    _log.Traceo("Ingresa a Metodo Consultar tb_sesiones", "0");
			List<tb_sesiones.Data> lsttb_sesiones = new List<tb_sesiones.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_sesiones_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tb_sesiones.Data _tb_sesiones= new tb_sesiones.Data();
					_tb_sesiones.id = Convert.ToString(rdr["id"].ToString());
					lsttb_sesiones.Add(_tb_sesiones);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar tb_sesiones", _state.error.ToString());
				return new tb_sesiones(_state, lsttb_sesiones);
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
			return new tb_sesiones(_state);
		}
		public tb_sesiones Buscartb_sesiones(tb_sesiones.Data _tb_sesionesData)
		{
			List<tb_sesiones.Data> lsttb_sesiones = new List<tb_sesiones.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar tb_sesiones", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_sesiones_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_sesionesData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tb_sesiones.Data _tb_sesiones= new tb_sesiones.Data();
					_tb_sesiones.id = Convert.ToString(rdr["id"].ToString());
					lsttb_sesiones.Add(_tb_sesiones);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar tb_sesiones", _state.error.ToString());
				return new tb_sesiones(_state, lsttb_sesiones);
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
			return new tb_sesiones(_state);
		}
		public tb_sesiones.State Insertartb_sesiones(tb_sesiones.Data _tb_sesiones)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar tb_sesiones", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_sesiones_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_sesiones.id);
				SqlCmd.Parameters.AddWithValue("@nombre_usuario", _tb_sesiones.nombre_usuario);
				SqlCmd.Parameters.AddWithValue("@datos", _tb_sesiones.datos);
				SqlCmd.Parameters.AddWithValue("@ultimo_acceso", _tb_sesiones.ultimo_acceso);
				SqlCmd.Parameters.AddWithValue("@creacion", _tb_sesiones.creacion);
				SqlCmd.Parameters.AddWithValue("@fec_modificacion", _tb_sesiones.fec_modificacion);
				SqlCmd.Parameters.AddWithValue("@usua_modificacion", _tb_sesiones.usua_modificacion);
				SqlCmd.Parameters.AddWithValue("@estado", _tb_sesiones.estado);
				SqlCmd.Parameters.AddWithValue("@ip", _tb_sesiones.ip);
				SqlCmd.Parameters.AddWithValue("@cierre", _tb_sesiones.cierre);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar tb_sesiones", _state.error.ToString());
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
		public tb_sesiones.State Actualizartb_sesiones(tb_sesiones.Data _tb_sesiones)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar tb_sesiones", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_sesiones_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_sesiones.id);
				SqlCmd.Parameters.AddWithValue("@nombre_usuario", _tb_sesiones.nombre_usuario);
				SqlCmd.Parameters.AddWithValue("@datos", _tb_sesiones.datos);
				SqlCmd.Parameters.AddWithValue("@ultimo_acceso", _tb_sesiones.ultimo_acceso);
				SqlCmd.Parameters.AddWithValue("@creacion", _tb_sesiones.creacion);
				SqlCmd.Parameters.AddWithValue("@fec_modificacion", _tb_sesiones.fec_modificacion);
				SqlCmd.Parameters.AddWithValue("@usua_modificacion", _tb_sesiones.usua_modificacion);
				SqlCmd.Parameters.AddWithValue("@estado", _tb_sesiones.estado);
				SqlCmd.Parameters.AddWithValue("@ip", _tb_sesiones.ip);
				SqlCmd.Parameters.AddWithValue("@cierre", _tb_sesiones.cierre);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar tb_sesiones", _state.error.ToString());
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
		public tb_sesiones.State Eliminartb_sesiones(tb_sesiones.Data _tb_sesiones)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar tb_sesiones", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_sesiones_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_sesiones.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar tb_sesiones", _state.error.ToString());
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
