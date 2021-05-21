using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace proyecto.Models
{
	public class GrpUsuarioDataAccess
	{
		GrpUsuario.State _state = new GrpUsuario.State();
		private Conexion Base = new Conexion();
		public GrpUsuario ConsultarGrpUsuario()
		{
			List<GrpUsuario.Data> lstGrpUsuario = new List<GrpUsuario.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrpUsuario_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GrpUsuario.Data _GrpUsuario= new GrpUsuario.Data();
					_GrpUsuario.idgrpusuario = (System.Int32)rdr["idgrpusuario"];
					_GrpUsuario.idgrupo = !rdr.IsDBNull(1) ? (System.Int32)rdr["idgrupo"] : (System.Int32)0;
					_GrpUsuario.idusuario = (System.Int32)rdr["idusuario"];
					lstGrpUsuario.Add(_GrpUsuario);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new GrpUsuario(_state, lstGrpUsuario);
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
			return new GrpUsuario(_state);
		}
		public GrpUsuario BuscarGrpUsuario(System.Int32 idgrpusuario)
		{
			List<GrpUsuario.Data> lstGrpUsuario = new List<GrpUsuario.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrpUsuario_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrpusuario", idgrpusuario);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GrpUsuario.Data _GrpUsuario= new GrpUsuario.Data();
					_GrpUsuario.idgrpusuario = (System.Int32)rdr["idgrpusuario"];
					_GrpUsuario.idgrupo = !rdr.IsDBNull(1) ? (System.Int32)rdr["idgrupo"] : (System.Int32)0;
					_GrpUsuario.idusuario = (System.Int32)rdr["idusuario"];
					lstGrpUsuario.Add(_GrpUsuario);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new GrpUsuario(_state, lstGrpUsuario);
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
			return new GrpUsuario(_state);
		}
		public GrpUsuario BuscarGrpUsuarioXUsuario(System.Int32 idusuario)
		{
			List<GrpUsuario.Data> lstGrpUsuario = new List<GrpUsuario.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("sp_GrpUsuario_SearchxUsuario", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", idusuario);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GrpUsuario.Data _GrpUsuario = new GrpUsuario.Data();
					_GrpUsuario.idgrpusuario = (System.Int32)rdr["idgrpusuario"];
					_GrpUsuario.idgrupo = !rdr.IsDBNull(1) ? (System.Int32)rdr["idgrupo"] : (System.Int32)0;
					_GrpUsuario.idusuario = (System.Int32)rdr["idusuario"];
					lstGrpUsuario.Add(_GrpUsuario);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new GrpUsuario(_state, lstGrpUsuario);
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
			return new GrpUsuario(_state);
		}
		public GrpUsuario.State InsertarGrpUsuario(GrpUsuario.Data _GrpUsuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrpUsuario_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDGrpUsuario = new SqlParameter();
				pIDGrpUsuario.ParameterName = "@IDGrpUsuario";
				pIDGrpUsuario.Value = 0;
				SqlCmd.Parameters.Add(pIDGrpUsuario);
				pIDGrpUsuario.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GrpUsuario.idgrupo);
				SqlCmd.Parameters.AddWithValue("@idusuario", _GrpUsuario.idusuario);

				SqlCmd.ExecuteNonQuery();
				_GrpUsuario.idgrpusuario = (System.Int32)pIDGrpUsuario.Value;
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
		public GrpUsuario.State ActualizarGrpUsuario(GrpUsuario.Data _GrpUsuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrpUsuario_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrpusuario", _GrpUsuario.idgrpusuario);
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GrpUsuario.idgrupo);
				SqlCmd.Parameters.AddWithValue("@idusuario", _GrpUsuario.idusuario);
				

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
		public GrpUsuario.State EliminarGrpUsuario(GrpUsuario.Data _GrpUsuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_GrpUsuario_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrpusuario", _GrpUsuario.idgrpusuario);

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
