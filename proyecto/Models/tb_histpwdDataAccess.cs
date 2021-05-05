using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class tb_histpwdDataAccess
	{
		tb_histpwd.State _state = new tb_histpwd.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public tb_histpwd Consultartb_histpwd()
		{
		    _log.Traceo("Ingresa a Metodo Consultar tb_histpwd", "0");
			List<tb_histpwd.Data> lsttb_histpwd = new List<tb_histpwd.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_histpwd_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tb_histpwd.Data _tb_histpwd= new tb_histpwd.Data();
					_tb_histpwd.nombre_usuario = Convert.ToString(rdr["nombre_usuario"].ToString());
					lsttb_histpwd.Add(_tb_histpwd);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar tb_histpwd", _state.error.ToString());
				return new tb_histpwd(_state, lsttb_histpwd);
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
			return new tb_histpwd(_state);
		}
		public tb_histpwd Buscartb_histpwd(tb_histpwd.Data _tb_histpwdData)
		{
			List<tb_histpwd.Data> lsttb_histpwd = new List<tb_histpwd.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar tb_histpwd", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_histpwd_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@nombre_usuario", _tb_histpwdData.nombre_usuario);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tb_histpwd.Data _tb_histpwd= new tb_histpwd.Data();
					_tb_histpwd.nombre_usuario = Convert.ToString(rdr["nombre_usuario"].ToString());
					lsttb_histpwd.Add(_tb_histpwd);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar tb_histpwd", _state.error.ToString());
				return new tb_histpwd(_state, lsttb_histpwd);
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
			return new tb_histpwd(_state);
		}
		public tb_histpwd.State Insertartb_histpwd(tb_histpwd.Data _tb_histpwd)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar tb_histpwd", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_histpwd_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@nombre_usuario", _tb_histpwd.nombre_usuario);
				SqlCmd.Parameters.AddWithValue("@creacion", _tb_histpwd.creacion);
				SqlCmd.Parameters.AddWithValue("@hash", _tb_histpwd.hash);
				SqlCmd.Parameters.AddWithValue("@fec_modificacion", _tb_histpwd.fec_modificacion);
				SqlCmd.Parameters.AddWithValue("@usua_modificacion", _tb_histpwd.usua_modificacion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar tb_histpwd", _state.error.ToString());
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
		public tb_histpwd.State Actualizartb_histpwd(tb_histpwd.Data _tb_histpwd)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar tb_histpwd", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_histpwd_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@nombre_usuario", _tb_histpwd.nombre_usuario);
				SqlCmd.Parameters.AddWithValue("@creacion", _tb_histpwd.creacion);
				SqlCmd.Parameters.AddWithValue("@hash", _tb_histpwd.hash);
				SqlCmd.Parameters.AddWithValue("@fec_modificacion", _tb_histpwd.fec_modificacion);
				SqlCmd.Parameters.AddWithValue("@usua_modificacion", _tb_histpwd.usua_modificacion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar tb_histpwd", _state.error.ToString());
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
		public tb_histpwd.State Eliminartb_histpwd(tb_histpwd.Data _tb_histpwd)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar tb_histpwd", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_histpwd_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@nombre_usuario", _tb_histpwd.nombre_usuario);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar tb_histpwd", _state.error.ToString());
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
