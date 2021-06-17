using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace proyecto.Models
{
	public class GrpUsrRolesInstitucionesDataAccess
	{
		GrpUsrRolesInstituciones.State _state = new GrpUsrRolesInstituciones.State();
		private Conexion Base = new Conexion();
		public GrpUsrRolesInstituciones ConsultarGrpUsrRolesInstituciones()
		{
			List<GrpUsrRolesInstituciones.Data> lstGrpUsrRolesInstituciones = new List<GrpUsrRolesInstituciones.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_GrpUsrRolesInstituciones_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GrpUsrRolesInstituciones.Data _GrpUsrRolesInstituciones= new GrpUsrRolesInstituciones.Data();
					_GrpUsrRolesInstituciones.idgrpusuariorolinstitucion = (System.Int32)rdr["idgrpusuariorolinstitucion"];
					_GrpUsrRolesInstituciones.idgrpusuario = (System.Int32)rdr["idgrpusuario"];
					_GrpUsrRolesInstituciones.idinstitucionrol = (System.Int32)rdr["idinstitucionrol"];
					lstGrpUsrRolesInstituciones.Add(_GrpUsrRolesInstituciones);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new GrpUsrRolesInstituciones(_state, lstGrpUsrRolesInstituciones);
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
			return new GrpUsrRolesInstituciones(_state);
		}
		public GrpUsrRolesInstituciones BuscarGrpUsrRolesInstituciones(System.Int32 idgrpusuariorolinstitucion)
		{
			List<GrpUsrRolesInstituciones.Data> lstGrpUsrRolesInstituciones = new List<GrpUsrRolesInstituciones.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_GrpUsrRolesInstituciones_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrpusuariorolinstitucion", idgrpusuariorolinstitucion);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GrpUsrRolesInstituciones.Data _GrpUsrRolesInstituciones= new GrpUsrRolesInstituciones.Data();
					_GrpUsrRolesInstituciones.idgrpusuariorolinstitucion = (System.Int32)rdr["idgrpusuariorolinstitucion"];
					_GrpUsrRolesInstituciones.idgrpusuario = (System.Int32)rdr["idgrpusuario"];
					_GrpUsrRolesInstituciones.idinstitucionrol = (System.Int32)rdr["idinstitucionrol"];
					lstGrpUsrRolesInstituciones.Add(_GrpUsrRolesInstituciones);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new GrpUsrRolesInstituciones(_state, lstGrpUsrRolesInstituciones);
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
             //   _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
			}
			return new GrpUsrRolesInstituciones(_state);
		}

		public GrpUsrRolesInstituciones BuscarGrpUsrRolesInstitucionesXInstitucion(System.Int32 idinstitucion)
		{
			List<GrpUsrRolesInstituciones.Data> lstGrpUsrRolesInstituciones = new List<GrpUsrRolesInstituciones.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("sp_GrpUsrRolesInstituciones_SearchXInstitucion", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucion", idinstitucion);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GrpUsrRolesInstituciones.Data _GrpUsrRolesInstituciones = new GrpUsrRolesInstituciones.Data();
					_GrpUsrRolesInstituciones.idgrpusuariorolinstitucion = (System.Int32)rdr["idgrpusuariorolinstitucion"];
					_GrpUsrRolesInstituciones.idgrpusuario = (System.Int32)rdr["idgrpusuario"];
					_GrpUsrRolesInstituciones.idinstitucionrol = (System.Int32)rdr["idinstitucionrol"];
					lstGrpUsrRolesInstituciones.Add(_GrpUsrRolesInstituciones);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new GrpUsrRolesInstituciones(_state, lstGrpUsrRolesInstituciones);
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
             //   _log.Error(_state.descripcion, _state.error.ToString());
            }

            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
			}
			return new GrpUsrRolesInstituciones(_state);
		}

		public GrpUsrRolesInstituciones.State InsertarGrpUsrRolesInstituciones(GrpUsrRolesInstituciones.Data _GrpUsrRolesInstituciones)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_GrpUsrRolesInstituciones_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDGrpUsuarioRolInstitucion = new SqlParameter();
				pIDGrpUsuarioRolInstitucion.ParameterName = "@IDGrpUsuarioRolInstitucion";
				pIDGrpUsuarioRolInstitucion.Value = 0;
				SqlCmd.Parameters.Add(pIDGrpUsuarioRolInstitucion);
				pIDGrpUsuarioRolInstitucion.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idgrpusuario", _GrpUsrRolesInstituciones.idgrpusuario);
				SqlCmd.Parameters.AddWithValue("@idinstitucionrol", _GrpUsrRolesInstituciones.idinstitucionrol);

				SqlCmd.ExecuteNonQuery();
				_GrpUsrRolesInstituciones.idgrpusuariorolinstitucion = (System.Int32)pIDGrpUsuarioRolInstitucion.Value;
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
		public GrpUsrRolesInstituciones.State ActualizarGrpUsrRolesInstituciones(GrpUsrRolesInstituciones.Data _GrpUsrRolesInstituciones)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_GrpUsrRolesInstituciones_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrpusuariorolinstitucion", _GrpUsrRolesInstituciones.idgrpusuariorolinstitucion);
				SqlCmd.Parameters.AddWithValue("@idgrpusuario", _GrpUsrRolesInstituciones.idgrpusuario);
				SqlCmd.Parameters.AddWithValue("@idinstitucionrol", _GrpUsrRolesInstituciones.idinstitucionrol);
				SqlCmd.Parameters.AddWithValue("@estado", _GrpUsrRolesInstituciones.estado);

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
		public GrpUsrRolesInstituciones.State EliminarGrpUsrRolesInstituciones(GrpUsrRolesInstituciones.Data _GrpUsrRolesInstituciones)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_GrpUsrRolesInstituciones_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrpusuariorolinstitucion", _GrpUsrRolesInstituciones.idgrpusuariorolinstitucion);

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
