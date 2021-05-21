using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrpUsrRolesInstituciones_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GrpUsrRolesInstituciones.Data _GrpUsrRolesInstituciones= new GrpUsrRolesInstituciones.Data();
					_GrpUsrRolesInstituciones.idgrpusuariorolinstitucion = (System.Int32)rdr["idgrpusuariorolinstitucion"];
					_GrpUsrRolesInstituciones.idgrpusuario = (System.Int32)rdr["idgrpusuario"];
					_GrpUsrRolesInstituciones.idinstitucionrol = (System.Int32)rdr["idinstitucionrol"];
					lstGrpUsrRolesInstituciones.Add(_GrpUsrRolesInstituciones);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new GrpUsrRolesInstituciones(_state, lstGrpUsrRolesInstituciones);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrpUsrRolesInstituciones_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrpusuariorolinstitucion", idgrpusuariorolinstitucion);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GrpUsrRolesInstituciones.Data _GrpUsrRolesInstituciones= new GrpUsrRolesInstituciones.Data();
					_GrpUsrRolesInstituciones.idgrpusuariorolinstitucion = (System.Int32)rdr["idgrpusuariorolinstitucion"];
					_GrpUsrRolesInstituciones.idgrpusuario = (System.Int32)rdr["idgrpusuario"];
					_GrpUsrRolesInstituciones.idinstitucionrol = (System.Int32)rdr["idinstitucionrol"];
					lstGrpUsrRolesInstituciones.Add(_GrpUsrRolesInstituciones);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new GrpUsrRolesInstituciones(_state, lstGrpUsrRolesInstituciones);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("sp_GrpUsrRolesInstituciones_SearchXInstitucion", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucion", idinstitucion);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GrpUsrRolesInstituciones.Data _GrpUsrRolesInstituciones = new GrpUsrRolesInstituciones.Data();
					_GrpUsrRolesInstituciones.idgrpusuariorolinstitucion = (System.Int32)rdr["idgrpusuariorolinstitucion"];
					_GrpUsrRolesInstituciones.idgrpusuario = (System.Int32)rdr["idgrpusuario"];
					_GrpUsrRolesInstituciones.idinstitucionrol = (System.Int32)rdr["idinstitucionrol"];
					lstGrpUsrRolesInstituciones.Add(_GrpUsrRolesInstituciones);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new GrpUsrRolesInstituciones(_state, lstGrpUsrRolesInstituciones);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrpUsrRolesInstituciones_Insert", SqlCnn);
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
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Insertar de Datos";
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrpUsrRolesInstituciones_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrpusuariorolinstitucion", _GrpUsrRolesInstituciones.idgrpusuariorolinstitucion);
				SqlCmd.Parameters.AddWithValue("@idgrpusuario", _GrpUsrRolesInstituciones.idgrpusuario);
				SqlCmd.Parameters.AddWithValue("@idinstitucionrol", _GrpUsrRolesInstituciones.idinstitucionrol);
				SqlCmd.Parameters.AddWithValue("@estado", _GrpUsrRolesInstituciones.estado);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Actualizar de Datos";
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrpUsrRolesInstituciones_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrpusuariorolinstitucion", _GrpUsrRolesInstituciones.idgrpusuariorolinstitucion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Eliminar de Datos";
					}
				}
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
