using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace proyecto.Models
{
	public class RolesAplicacionesDataAccess
	{
		RolesAplicaciones.State _state = new RolesAplicaciones.State();
		private Conexion Base = new Conexion();
		public RolesAplicaciones ConsultarRolesAplicaciones()
		{
			List<RolesAplicaciones.Data> lstRolesAplicaciones = new List<RolesAplicaciones.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_RolesAplicaciones_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					RolesAplicaciones.Data _RolesAplicaciones= new RolesAplicaciones.Data();
					_RolesAplicaciones.idrolesaplicaciones = (System.Int32)rdr["idrolesaplicaciones"];
					_RolesAplicaciones.idrol = !rdr.IsDBNull(1) ? (System.Int32)rdr["idrol"] : (System.Int32)0;
					_RolesAplicaciones.idaplicacion = !rdr.IsDBNull(2) ? (System.Int32)rdr["idaplicacion"] : (System.Int32)0;
					lstRolesAplicaciones.Add(_RolesAplicaciones);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new RolesAplicaciones(_state, lstRolesAplicaciones);
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
			return new RolesAplicaciones(_state);
		}
		public RolesAplicaciones BuscarRolesAplicaciones(System.Int32 idrolesaplicaciones)
		{
			List<RolesAplicaciones.Data> lstRolesAplicaciones = new List<RolesAplicaciones.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_RolesAplicaciones_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrolesaplicaciones", idrolesaplicaciones);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					RolesAplicaciones.Data _RolesAplicaciones= new RolesAplicaciones.Data();
					_RolesAplicaciones.idrolesaplicaciones = (System.Int32)rdr["idrolesaplicaciones"];
					_RolesAplicaciones.idrol = !rdr.IsDBNull(1) ? (System.Int32)rdr["idrol"] : (System.Int32)0;
					_RolesAplicaciones.idaplicacion = !rdr.IsDBNull(2) ? (System.Int32)rdr["idaplicacion"] : (System.Int32)0;
					lstRolesAplicaciones.Add(_RolesAplicaciones);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new RolesAplicaciones(_state, lstRolesAplicaciones);
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
			return new RolesAplicaciones(_state);
		}
		public RolesAplicaciones BuscarRolesAplicacionesXRol(System.Int32 idrol)
		{
			List<RolesAplicaciones.Data> lstRolesAplicaciones = new List<RolesAplicaciones.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("sp_RolesAplicaciones_SearchXRol", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrol", idrol);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					RolesAplicaciones.Data _RolesAplicaciones = new RolesAplicaciones.Data();
					_RolesAplicaciones.idrolesaplicaciones = (System.Int32)rdr["idrolesaplicaciones"];
					_RolesAplicaciones.idrol = !rdr.IsDBNull(1) ? (System.Int32)rdr["idrol"] : (System.Int32)0;
					_RolesAplicaciones.idaplicacion = !rdr.IsDBNull(2) ? (System.Int32)rdr["idaplicacion"] : (System.Int32)0;
					lstRolesAplicaciones.Add(_RolesAplicaciones);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new RolesAplicaciones(_state, lstRolesAplicaciones);
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
			return new RolesAplicaciones(_state);
		}
		public RolesAplicaciones.State InsertarRolesAplicaciones(RolesAplicaciones.Data _RolesAplicaciones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_RolesAplicaciones_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDRolesAplicaciones = new SqlParameter();
				pIDRolesAplicaciones.ParameterName = "@IDRolesAplicaciones";
				pIDRolesAplicaciones.Value = 0;
				SqlCmd.Parameters.Add(pIDRolesAplicaciones);
				pIDRolesAplicaciones.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idrol", _RolesAplicaciones.idrol);
				SqlCmd.Parameters.AddWithValue("@idaplicacion", _RolesAplicaciones.idaplicacion);

				SqlCmd.ExecuteNonQuery();
				_RolesAplicaciones.idrolesaplicaciones = (System.Int32)pIDRolesAplicaciones.Value;
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
		public RolesAplicaciones.State ActualizarRolesAplicaciones(RolesAplicaciones.Data _RolesAplicaciones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_RolesAplicaciones_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrolesaplicaciones", _RolesAplicaciones.idrolesaplicaciones);
				SqlCmd.Parameters.AddWithValue("@idrol", _RolesAplicaciones.idrol);
				SqlCmd.Parameters.AddWithValue("@idaplicacion", _RolesAplicaciones.idaplicacion);

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
		public RolesAplicaciones.State EliminarRolesAplicaciones(RolesAplicaciones.Data _RolesAplicaciones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_RolesAplicaciones_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrolesaplicaciones", _RolesAplicaciones.idrolesaplicaciones);

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
