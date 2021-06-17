using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace proyecto.Models
{
	public class InstitucionesRolesDataAccess
	{
		InstitucionesRoles.State _state = new InstitucionesRoles.State();
		private Conexion Base = new Conexion();
		public InstitucionesRoles ConsultarInstitucionesRoles()
		{
			List<InstitucionesRoles.Data> lstInstitucionesRoles = new List<InstitucionesRoles.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_InstitucionesRoles_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					InstitucionesRoles.Data _InstitucionesRoles= new InstitucionesRoles.Data();
					_InstitucionesRoles.idinstitucionrol = (System.Int32)rdr["idinstitucionrol"];
					_InstitucionesRoles.idinstitucion = !rdr.IsDBNull(1) ? (System.Int32)rdr["idinstitucion"] : (System.Int32)0;
					_InstitucionesRoles.idrol = !rdr.IsDBNull(2) ? (System.Int32)rdr["idrol"] : (System.Int32)0;
					lstInstitucionesRoles.Add(_InstitucionesRoles);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new InstitucionesRoles(_state, lstInstitucionesRoles);
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
			return new InstitucionesRoles(_state);
		}
		public InstitucionesRoles BuscarInstitucionesRoles(System.Int32 idinstitucionrol)
		{
			List<InstitucionesRoles.Data> lstInstitucionesRoles = new List<InstitucionesRoles.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_InstitucionesRoles_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucionrol", idinstitucionrol);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					InstitucionesRoles.Data _InstitucionesRoles= new InstitucionesRoles.Data();
					_InstitucionesRoles.idinstitucionrol = (System.Int32)rdr["idinstitucionrol"];
					_InstitucionesRoles.idinstitucion = !rdr.IsDBNull(1) ? (System.Int32)rdr["idinstitucion"] : (System.Int32)0;
					_InstitucionesRoles.idrol = !rdr.IsDBNull(2) ? (System.Int32)rdr["idrol"] : (System.Int32)0;
					lstInstitucionesRoles.Add(_InstitucionesRoles);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new InstitucionesRoles(_state, lstInstitucionesRoles);
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
			return new InstitucionesRoles(_state);
		}

		public InstitucionesRoles BuscarInstitucionesRolesXInstitucion(System.Int32 idinstitucion)
		{
			List<InstitucionesRoles.Data> lstInstitucionesRoles = new List<InstitucionesRoles.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("sp_InstitucionesRoles_SearchXInstitucion", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucion", idinstitucion);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					InstitucionesRoles.Data _InstitucionesRoles = new InstitucionesRoles.Data();
					_InstitucionesRoles.idinstitucionrol = (System.Int32)rdr["idinstitucionrol"];
					_InstitucionesRoles.idinstitucion = !rdr.IsDBNull(1) ? (System.Int32)rdr["idinstitucion"] : (System.Int32)0;
					_InstitucionesRoles.idrol = !rdr.IsDBNull(2) ? (System.Int32)rdr["idrol"] : (System.Int32)0;
					lstInstitucionesRoles.Add(_InstitucionesRoles);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new InstitucionesRoles(_state, lstInstitucionesRoles);
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
			return new InstitucionesRoles(_state);
		}

		public InstitucionesRoles.State InsertarInstitucionesRoles(InstitucionesRoles.Data _InstitucionesRoles)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_InstitucionesRoles_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDInstitucionRol = new SqlParameter();
				pIDInstitucionRol.ParameterName = "@IDInstitucionRol";
				pIDInstitucionRol.Value = 0;
				SqlCmd.Parameters.Add(pIDInstitucionRol);
				pIDInstitucionRol.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idinstitucion", _InstitucionesRoles.idinstitucion);
				SqlCmd.Parameters.AddWithValue("@idrol", _InstitucionesRoles.idrol);

				SqlCmd.ExecuteNonQuery();
				_InstitucionesRoles.idinstitucionrol = (System.Int32)pIDInstitucionRol.Value;
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
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
			return _state;
		}
		public InstitucionesRoles.State ActualizarInstitucionesRoles(InstitucionesRoles.Data _InstitucionesRoles)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_InstitucionesRoles_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucionrol", _InstitucionesRoles.idinstitucionrol);
				SqlCmd.Parameters.AddWithValue("@idinstitucion", _InstitucionesRoles.idinstitucion);
				SqlCmd.Parameters.AddWithValue("@idrol", _InstitucionesRoles.idrol);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
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
			return _state;
		}
		public InstitucionesRoles.State EliminarInstitucionesRoles(InstitucionesRoles.Data _InstitucionesRoles)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_InstitucionesRoles_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucionrol", _InstitucionesRoles.idinstitucionrol);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
              //  _log.Error(_state.descripcion, _state.error.ToString());
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
