using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
using MySql.Data.MySqlClient;
namespace proyecto.Models
{
	public class applicationdefinitionDataAccess
	{
		applicationdefinition.State _state = new applicationdefinition.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public applicationdefinition Consultarapplicationdefinition()
		{
		    _log.Traceo("Ingresa a Metodo Consultar applicationdefinition", "0");
			List<applicationdefinition.Data> lstapplicationdefinition = new List<applicationdefinition.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_applicationdefinition_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					applicationdefinition.Data _applicationdefinition= new applicationdefinition.Data();
					_applicationdefinition.identification = Convert.ToString(rdr["identification"].ToString());
					lstapplicationdefinition.Add(_applicationdefinition);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar applicationdefinition", _state.error.ToString());
				return new applicationdefinition(_state, lstapplicationdefinition);
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
			return new applicationdefinition(_state);
		}
		public applicationdefinition Buscarapplicationdefinition(applicationdefinition.Data _applicationdefinitionData)
		{
			List<applicationdefinition.Data> lstapplicationdefinition = new List<applicationdefinition.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar applicationdefinition", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_applicationdefinition_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _applicationdefinitionData.identification);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					applicationdefinition.Data _applicationdefinition= new applicationdefinition.Data();
					_applicationdefinition.identification = Convert.ToString(rdr["identification"].ToString());
					lstapplicationdefinition.Add(_applicationdefinition);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar applicationdefinition", _state.error.ToString());
				return new applicationdefinition(_state, lstapplicationdefinition);
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
			return new applicationdefinition(_state);
		}
		public applicationdefinition.State Insertarapplicationdefinition(applicationdefinition.Data _applicationdefinition)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar applicationdefinition", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_applicationdefinition_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _applicationdefinition.identification);
				SqlCmd.Parameters.AddWithValue("@description", _applicationdefinition.description);
				SqlCmd.Parameters.AddWithValue("@type", _applicationdefinition.type);
				SqlCmd.Parameters.AddWithValue("@enabled", _applicationdefinition.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _applicationdefinition.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _applicationdefinition.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _applicationdefinition.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _applicationdefinition.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _applicationdefinition.configuration);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar applicationdefinition", _state.error.ToString());
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
		public applicationdefinition.State Actualizarapplicationdefinition(applicationdefinition.Data _applicationdefinition)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar applicationdefinition", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_applicationdefinition_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _applicationdefinition.identification);
				SqlCmd.Parameters.AddWithValue("@description", _applicationdefinition.description);
				SqlCmd.Parameters.AddWithValue("@type", _applicationdefinition.type);
				SqlCmd.Parameters.AddWithValue("@enabled", _applicationdefinition.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _applicationdefinition.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _applicationdefinition.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _applicationdefinition.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _applicationdefinition.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _applicationdefinition.configuration);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar applicationdefinition", _state.error.ToString());
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
		public applicationdefinition.State Eliminarapplicationdefinition(applicationdefinition.Data _applicationdefinition)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar applicationdefinition", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_applicationdefinition_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _applicationdefinition.identification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar applicationdefinition", _state.error.ToString());
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
