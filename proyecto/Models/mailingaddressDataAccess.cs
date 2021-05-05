using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class mailingaddressDataAccess
	{
		mailingaddress.State _state = new mailingaddress.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public mailingaddress Consultarmailingaddress()
		{
		    _log.Traceo("Ingresa a Metodo Consultar mailingaddress", "0");
			List<mailingaddress.Data> lstmailingaddress = new List<mailingaddress.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_mailingaddress_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					mailingaddress.Data _mailingaddress= new mailingaddress.Data();
					_mailingaddress.id = Convert.ToInt32(rdr["id"].ToString());
					lstmailingaddress.Add(_mailingaddress);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar mailingaddress", _state.error.ToString());
				return new mailingaddress(_state, lstmailingaddress);
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
			return new mailingaddress(_state);
		}
		public mailingaddress Buscarmailingaddress(mailingaddress.Data _mailingaddressData)
		{
			List<mailingaddress.Data> lstmailingaddress = new List<mailingaddress.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar mailingaddress", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_mailingaddress_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _mailingaddressData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					mailingaddress.Data _mailingaddress= new mailingaddress.Data();
					_mailingaddress.id = Convert.ToInt32(rdr["id"].ToString());
					lstmailingaddress.Add(_mailingaddress);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar mailingaddress", _state.error.ToString());
				return new mailingaddress(_state, lstmailingaddress);
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
			return new mailingaddress(_state);
		}
		public mailingaddress.State Insertarmailingaddress(mailingaddress.Data _mailingaddress)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar mailingaddress", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_mailingaddress_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _mailingaddress.id);
				SqlCmd.Parameters.AddWithValue("@email", _mailingaddress.email);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _mailingaddress.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _mailingaddress.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _mailingaddress.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _mailingaddress.updateuser);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar mailingaddress", _state.error.ToString());
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
		public mailingaddress.State Actualizarmailingaddress(mailingaddress.Data _mailingaddress)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar mailingaddress", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_mailingaddress_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _mailingaddress.id);
				SqlCmd.Parameters.AddWithValue("@email", _mailingaddress.email);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _mailingaddress.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _mailingaddress.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _mailingaddress.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _mailingaddress.updateuser);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar mailingaddress", _state.error.ToString());
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
		public mailingaddress.State Eliminarmailingaddress(mailingaddress.Data _mailingaddress)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar mailingaddress", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_mailingaddress_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _mailingaddress.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar mailingaddress", _state.error.ToString());
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
