using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace proyecto.Models
{
	public class RolesDataAccess
	{
		Roles.State _state = new Roles.State();
		private Conexion Base = new Conexion();
		public Roles ConsultarRoles()
		{
			List<Roles.Data> lstRoles = new List<Roles.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Roles_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Roles.Data _Roles= new Roles.Data();
					_Roles.idrol = (System.Int32)rdr["idrol"];
					_Roles.descripcion = !rdr.IsDBNull(1) ? (System.String)rdr["descripcion"] : "";
					lstRoles.Add(_Roles);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Roles(_state, lstRoles);
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
               // _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
			}
			return new Roles(_state);
		}
		public Roles BuscarRoles(System.Int32 idrol)
		{
			List<Roles.Data> lstRoles = new List<Roles.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Roles_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrol", idrol);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Roles.Data _Roles= new Roles.Data();
					_Roles.idrol = (System.Int32)rdr["idrol"];
					_Roles.descripcion = !rdr.IsDBNull(1) ? (System.String)rdr["descripcion"] : "";
					lstRoles.Add(_Roles);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Roles(_state, lstRoles);
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
               // _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
			}
			return new Roles(_state);
		}
		public Roles.State InsertarRoles(Roles.Data _Roles)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Roles_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIdRol = new SqlParameter();
				pIdRol.ParameterName = "@IdRol";
				pIdRol.Value = 0;
				SqlCmd.Parameters.Add(pIdRol);
				pIdRol.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _Roles.descripcion);

				SqlCmd.ExecuteNonQuery();
				_Roles.idrol = (System.Int32)pIdRol.Value;
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                //_log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
			}
			return _state;
		}
		public Roles.State ActualizarRoles(Roles.Data _Roles)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Roles_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrol", _Roles.idrol);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Roles.descripcion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                //_log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
			}
			return _state;
		}
		public Roles.State EliminarRoles(Roles.Data _Roles)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Roles_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrol", _Roles.idrol);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                //_log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
			}
			return _state;
		}
	}
}
