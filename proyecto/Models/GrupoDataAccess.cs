using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace proyecto.Models
{
	public class GrupoDataAccess
	{
		Grupo.State _state = new Grupo.State();
		private Conexion Base = new Conexion();
		public Grupo ConsultarGrupo()
		{
			List<Grupo.Data> lstGrupo = new List<Grupo.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Grupo_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Grupo.Data _Grupo= new Grupo.Data();
					_Grupo.idgrupo = (System.Int32)rdr["idgrupo"];
					_Grupo.descripcion = !rdr.IsDBNull(1) ? (System.String)rdr["descripcion"] : "";
					lstGrupo.Add(_Grupo);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Grupo(_state, lstGrupo);
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
			return new Grupo(_state);
		}
		public Grupo BuscarGrupo(System.Int32 idgrupo)
		{
			List<Grupo.Data> lstGrupo = new List<Grupo.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Grupo_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", idgrupo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Grupo.Data _Grupo= new Grupo.Data();
					_Grupo.idgrupo = (System.Int32)rdr["idgrupo"];
					_Grupo.descripcion = !rdr.IsDBNull(1) ? (System.String)rdr["descripcion"] : "";
					lstGrupo.Add(_Grupo);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Grupo(_state, lstGrupo);
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
			return new Grupo(_state);
		}

		public Grupo BuscarGrupoXInstitucion(System.Int32 idinstitucion)
		{
			List<Grupo.Data> lstGrupo = new List<Grupo.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Grupo_SearchXInstitucion", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucion", idinstitucion);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Grupo.Data _Grupo = new Grupo.Data();
					_Grupo.idgrupo = (System.Int32)rdr["idgrupo"];
					_Grupo.descripcion = !rdr.IsDBNull(1) ? (System.String)rdr["descripcion"] : "";
					lstGrupo.Add(_Grupo);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Grupo(_state, lstGrupo);
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
			return new Grupo(_state);
		}
		public Grupo.State InsertarGrupo(Grupo.Data _Grupo)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Grupo_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDGrupo = new SqlParameter();
				pIDGrupo.ParameterName = "@IDGrupo";
				pIDGrupo.Value = 0;
				SqlCmd.Parameters.Add(pIDGrupo);
				pIDGrupo.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _Grupo.descripcion);

				SqlCmd.ExecuteNonQuery();
				_Grupo.idgrupo = (System.Int32)pIDGrupo.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada | IDGrupo: " + _Grupo.idgrupo;
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
		public Grupo.State ActualizarGrupo(Grupo.Data _Grupo)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Grupo_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _Grupo.idgrupo);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Grupo.descripcion);

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
		public Grupo.State EliminarGrupo(Grupo.Data _Grupo)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Grupo_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _Grupo.idgrupo);

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
