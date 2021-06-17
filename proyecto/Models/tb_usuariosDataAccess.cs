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
	public class tb_usuariosDataAccess
	{
		tb_usuarios.State _state = new tb_usuarios.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public tb_usuarios Consultartb_usuarios()
		{
		    _log.Traceo("Ingresa a Metodo Consultar tb_usuarios", "0");
			List<tb_usuarios.Data> lsttb_usuarios = new List<tb_usuarios.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_usuarios_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tb_usuarios.Data _tb_usuarios= new tb_usuarios.Data();
					_tb_usuarios.nombre_usuario = Convert.ToString(rdr["nombre_usuario"].ToString());
					lsttb_usuarios.Add(_tb_usuarios);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar tb_usuarios", _state.error.ToString());
				return new tb_usuarios(_state, lsttb_usuarios);
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
			return new tb_usuarios(_state);
		}
		public tb_usuarios Buscartb_usuarios(tb_usuarios.Data _tb_usuariosData)
		{
			List<tb_usuarios.Data> lsttb_usuarios = new List<tb_usuarios.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar tb_usuarios", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_usuarios_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@nombre_usuario", _tb_usuariosData.nombre_usuario);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tb_usuarios.Data _tb_usuarios= new tb_usuarios.Data();
					_tb_usuarios.nombre_usuario = Convert.ToString(rdr["nombre_usuario"].ToString());
					lsttb_usuarios.Add(_tb_usuarios);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar tb_usuarios", _state.error.ToString());
				return new tb_usuarios(_state, lsttb_usuarios);
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
			return new tb_usuarios(_state);
		}
		public tb_usuarios.State Insertartb_usuarios(tb_usuarios.Data _tb_usuarios)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar tb_usuarios", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_usuarios_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@nombre_usuario", _tb_usuarios.nombre_usuario);
				SqlCmd.Parameters.AddWithValue("@nombre", _tb_usuarios.nombre);
				SqlCmd.Parameters.AddWithValue("@apellido", _tb_usuarios.apellido);
				SqlCmd.Parameters.AddWithValue("@email", _tb_usuarios.email);
				SqlCmd.Parameters.AddWithValue("@tel", _tb_usuarios.tel);
				SqlCmd.Parameters.AddWithValue("@telmovil", _tb_usuarios.telmovil);
				SqlCmd.Parameters.AddWithValue("@hash", _tb_usuarios.hash);
				SqlCmd.Parameters.AddWithValue("@idgrupo", _tb_usuarios.idgrupo);
				SqlCmd.Parameters.AddWithValue("@idperfil", _tb_usuarios.idperfil);
				SqlCmd.Parameters.AddWithValue("@aplicacion", _tb_usuarios.aplicacion);
				SqlCmd.Parameters.AddWithValue("@enabled", _tb_usuarios.enabled);
				SqlCmd.Parameters.AddWithValue("@config", _tb_usuarios.config);
				SqlCmd.Parameters.AddWithValue("@notas", _tb_usuarios.notas);
				SqlCmd.Parameters.AddWithValue("@cambiar_pwd", _tb_usuarios.cambiar_pwd);
				SqlCmd.Parameters.AddWithValue("@estado", _tb_usuarios.estado);
				SqlCmd.Parameters.AddWithValue("@create_timestamp", _tb_usuarios.create_timestamp);
				SqlCmd.Parameters.AddWithValue("@usuario_creacion", _tb_usuarios.usuario_creacion);
				SqlCmd.Parameters.AddWithValue("@usuario_modif", _tb_usuarios.usuario_modif);
				SqlCmd.Parameters.AddWithValue("@ultimo_acceso", _tb_usuarios.ultimo_acceso);
				SqlCmd.Parameters.AddWithValue("@fec_modificacion", _tb_usuarios.fec_modificacion);
				SqlCmd.Parameters.AddWithValue("@usua_modificacion", _tb_usuarios.usua_modificacion);
				SqlCmd.Parameters.AddWithValue("@intentos", _tb_usuarios.intentos);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar tb_usuarios", _state.error.ToString());
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
		public tb_usuarios.State Actualizartb_usuarios(tb_usuarios.Data _tb_usuarios)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar tb_usuarios", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_usuarios_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@nombre_usuario", _tb_usuarios.nombre_usuario);
				SqlCmd.Parameters.AddWithValue("@nombre", _tb_usuarios.nombre);
				SqlCmd.Parameters.AddWithValue("@apellido", _tb_usuarios.apellido);
				SqlCmd.Parameters.AddWithValue("@email", _tb_usuarios.email);
				SqlCmd.Parameters.AddWithValue("@tel", _tb_usuarios.tel);
				SqlCmd.Parameters.AddWithValue("@telmovil", _tb_usuarios.telmovil);
				SqlCmd.Parameters.AddWithValue("@hash", _tb_usuarios.hash);
				SqlCmd.Parameters.AddWithValue("@idgrupo", _tb_usuarios.idgrupo);
				SqlCmd.Parameters.AddWithValue("@idperfil", _tb_usuarios.idperfil);
				SqlCmd.Parameters.AddWithValue("@aplicacion", _tb_usuarios.aplicacion);
				SqlCmd.Parameters.AddWithValue("@enabled", _tb_usuarios.enabled);
				SqlCmd.Parameters.AddWithValue("@config", _tb_usuarios.config);
				SqlCmd.Parameters.AddWithValue("@notas", _tb_usuarios.notas);
				SqlCmd.Parameters.AddWithValue("@cambiar_pwd", _tb_usuarios.cambiar_pwd);
				SqlCmd.Parameters.AddWithValue("@estado", _tb_usuarios.estado);
				SqlCmd.Parameters.AddWithValue("@create_timestamp", _tb_usuarios.create_timestamp);
				SqlCmd.Parameters.AddWithValue("@usuario_creacion", _tb_usuarios.usuario_creacion);
				SqlCmd.Parameters.AddWithValue("@usuario_modif", _tb_usuarios.usuario_modif);
				SqlCmd.Parameters.AddWithValue("@ultimo_acceso", _tb_usuarios.ultimo_acceso);
				SqlCmd.Parameters.AddWithValue("@fec_modificacion", _tb_usuarios.fec_modificacion);
				SqlCmd.Parameters.AddWithValue("@usua_modificacion", _tb_usuarios.usua_modificacion);
				SqlCmd.Parameters.AddWithValue("@intentos", _tb_usuarios.intentos);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar tb_usuarios", _state.error.ToString());
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
		public tb_usuarios.State Eliminartb_usuarios(tb_usuarios.Data _tb_usuarios)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar tb_usuarios", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_usuarios_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@nombre_usuario", _tb_usuarios.nombre_usuario);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar tb_usuarios", _state.error.ToString());
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
