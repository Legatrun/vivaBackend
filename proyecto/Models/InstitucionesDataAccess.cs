using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace proyecto.Models
{
	public class InstitucionesDataAccess
	{
		Instituciones.State _state = new Instituciones.State();
		private Conexion Base = new Conexion();
		public Instituciones ConsultarInstituciones()
		{
			List<Instituciones.Data> lstInstituciones = new List<Instituciones.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Instituciones_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Instituciones.Data _Instituciones= new Instituciones.Data();
					_Instituciones.idinstitucion = (System.Int32)rdr["idinstitucion"];
					_Instituciones.descripcion = !rdr.IsDBNull(1) ? (System.String)rdr["descripcion"] : "";
					lstInstituciones.Add(_Instituciones);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Instituciones(_state, lstInstituciones);
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
			return new Instituciones(_state);
		}
		public Instituciones BuscarInstituciones(System.Int32 idinstitucion)
		{
			List<Instituciones.Data> lstInstituciones = new List<Instituciones.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Instituciones_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucion", idinstitucion);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Instituciones.Data _Instituciones= new Instituciones.Data();
					_Instituciones.idinstitucion = (System.Int32)rdr["idinstitucion"];
					_Instituciones.descripcion = !rdr.IsDBNull(1) ? (System.String)rdr["descripcion"] : "";
					lstInstituciones.Add(_Instituciones);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Instituciones(_state, lstInstituciones);
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
			return new Instituciones(_state);
		}
		public Instituciones.State InsertarInstituciones(Instituciones.Data _Instituciones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Instituciones_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDInstitucion = new SqlParameter();
				pIDInstitucion.ParameterName = "@IDInstitucion";
				pIDInstitucion.Value = 0;
				SqlCmd.Parameters.Add(pIDInstitucion);
				pIDInstitucion.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _Instituciones.descripcion);

				SqlCmd.ExecuteNonQuery();
				_Instituciones.idinstitucion = (System.Int32)pIDInstitucion.Value;
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
		public Instituciones.State ActualizarInstituciones(Instituciones.Data _Instituciones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Instituciones_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucion", _Instituciones.idinstitucion);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Instituciones.descripcion);

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
		public Instituciones.State EliminarInstituciones(Instituciones.Data _Instituciones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionSeguridad();
				SqlCommand SqlCmd = new SqlCommand("Proc_Instituciones_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucion", _Instituciones.idinstitucion);

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
