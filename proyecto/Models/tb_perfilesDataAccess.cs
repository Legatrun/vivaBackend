using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class tb_perfilesDataAccess
	{
		tb_perfiles.State _state = new tb_perfiles.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public tb_perfiles Consultartb_perfiles()
		{
		    _log.Traceo("Ingresa a Metodo Consultar tb_perfiles", "0");
			List<tb_perfiles.Data> lsttb_perfiles = new List<tb_perfiles.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_perfiles_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tb_perfiles.Data _tb_perfiles= new tb_perfiles.Data();
					_tb_perfiles.id = Convert.ToInt32(rdr["id"].ToString());
					lsttb_perfiles.Add(_tb_perfiles);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar tb_perfiles", _state.error.ToString());
				return new tb_perfiles(_state, lsttb_perfiles);
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
			return new tb_perfiles(_state);
		}
		public tb_perfiles Buscartb_perfiles(tb_perfiles.Data _tb_perfilesData)
		{
			List<tb_perfiles.Data> lsttb_perfiles = new List<tb_perfiles.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar tb_perfiles", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_perfiles_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_perfilesData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tb_perfiles.Data _tb_perfiles= new tb_perfiles.Data();
					_tb_perfiles.id = Convert.ToInt32(rdr["id"].ToString());
					lsttb_perfiles.Add(_tb_perfiles);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar tb_perfiles", _state.error.ToString());
				return new tb_perfiles(_state, lsttb_perfiles);
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
			return new tb_perfiles(_state);
		}
		public tb_perfiles.State Insertartb_perfiles(tb_perfiles.Data _tb_perfiles)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar tb_perfiles", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_perfiles_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_perfiles.id);
				SqlCmd.Parameters.AddWithValue("@descripcion", _tb_perfiles.descripcion);
				SqlCmd.Parameters.AddWithValue("@create_timestamp", _tb_perfiles.create_timestamp);
				SqlCmd.Parameters.AddWithValue("@fec_modificacion", _tb_perfiles.fec_modificacion);
				SqlCmd.Parameters.AddWithValue("@usua_modificacion", _tb_perfiles.usua_modificacion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar tb_perfiles", _state.error.ToString());
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
		public tb_perfiles.State Actualizartb_perfiles(tb_perfiles.Data _tb_perfiles)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar tb_perfiles", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_perfiles_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_perfiles.id);
				SqlCmd.Parameters.AddWithValue("@descripcion", _tb_perfiles.descripcion);
				SqlCmd.Parameters.AddWithValue("@create_timestamp", _tb_perfiles.create_timestamp);
				SqlCmd.Parameters.AddWithValue("@fec_modificacion", _tb_perfiles.fec_modificacion);
				SqlCmd.Parameters.AddWithValue("@usua_modificacion", _tb_perfiles.usua_modificacion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar tb_perfiles", _state.error.ToString());
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
		public tb_perfiles.State Eliminartb_perfiles(tb_perfiles.Data _tb_perfiles)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar tb_perfiles", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tb_perfiles_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _tb_perfiles.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar tb_perfiles", _state.error.ToString());
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
