using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace proyecto.Models
{
	public class AplicacionesOpModulosDataAccess
	{
		AplicacionesOpModulos.State _state = new AplicacionesOpModulos.State();
		private Conexion Base = new Conexion();
		public AplicacionesOpModulos ConsultarAplicacionesOpModulos()
		{
			List<AplicacionesOpModulos.Data> lstAplicacionesOpModulos = new List<AplicacionesOpModulos.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_AplicacionesOpModulos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					AplicacionesOpModulos.Data _AplicacionesOpModulos= new AplicacionesOpModulos.Data();
					_AplicacionesOpModulos.idaplicacionesopmodulos = (System.Int32)rdr["idaplicacionesopmodulos"];
					_AplicacionesOpModulos.idaplicacion = (System.Int32)rdr["idaplicacion"];
					_AplicacionesOpModulos.idoperacion = (System.Int32)rdr["idoperacion"];
					_AplicacionesOpModulos.idmodulo = !rdr.IsDBNull(3) ? (System.Int32)rdr["idmodulo"] : (System.Int32)0;
					_AplicacionesOpModulos.activo = !rdr.IsDBNull(4) ? (System.Boolean)rdr["activo"] : false;
					_AplicacionesOpModulos.estado = !rdr.IsDBNull(5) ? (System.Boolean)rdr["estado"] : false;
					lstAplicacionesOpModulos.Add(_AplicacionesOpModulos);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new AplicacionesOpModulos(_state, lstAplicacionesOpModulos);
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
			return new AplicacionesOpModulos(_state);
		}
		public AplicacionesOpModulos BuscarAplicacionesOpModulos(System.Int32 idaplicacionesopmodulos)
		{
			List<AplicacionesOpModulos.Data> lstAplicacionesOpModulos = new List<AplicacionesOpModulos.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_AplicacionesOpModulos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idaplicacionesopmodulos", idaplicacionesopmodulos);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					AplicacionesOpModulos.Data _AplicacionesOpModulos= new AplicacionesOpModulos.Data();
					_AplicacionesOpModulos.idaplicacionesopmodulos = (System.Int32)rdr["idaplicacionesopmodulos"];
					_AplicacionesOpModulos.idaplicacion = (System.Int32)rdr["idaplicacion"];
					_AplicacionesOpModulos.idoperacion = (System.Int32)rdr["idoperacion"];
					_AplicacionesOpModulos.idmodulo = !rdr.IsDBNull(3) ? (System.Int32)rdr["idmodulo"] : (System.Int32)0;
					_AplicacionesOpModulos.activo = !rdr.IsDBNull(4) ? (System.Boolean)rdr["activo"] : false;
					_AplicacionesOpModulos.estado = !rdr.IsDBNull(5) ? (System.Boolean)rdr["estado"] : false;
					lstAplicacionesOpModulos.Add(_AplicacionesOpModulos);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new AplicacionesOpModulos(_state, lstAplicacionesOpModulos);
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
			return new AplicacionesOpModulos(_state);
		}

		public AplicacionesOpModulos BuscarAplicacionesOpModulosXAplicacion(System.Int32 idaplicacion, System.Int32 idrol)
		{
			List<AplicacionesOpModulos.Data> lstAplicacionesOpModulos = new List<AplicacionesOpModulos.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_AplicacionesOpModulos_SearchXAplicacion", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idaplicacion", idaplicacion);
				SqlCmd.Parameters.AddWithValue("@idrol", idrol);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					AplicacionesOpModulos.Data _AplicacionesOpModulos = new AplicacionesOpModulos.Data();
					_AplicacionesOpModulos.idaplicacionesopmodulos = (System.Int32)rdr["idaplicacionesopmodulos"];
					_AplicacionesOpModulos.idaplicacion = (System.Int32)rdr["idaplicacion"];
					_AplicacionesOpModulos.idoperacion = (System.Int32)rdr["idoperacion"];
					_AplicacionesOpModulos.idmodulo = !rdr.IsDBNull(3) ? (System.Int32)rdr["idmodulo"] : (System.Int32)0;
					_AplicacionesOpModulos.activo = !rdr.IsDBNull(5) ? (System.Boolean)rdr["activo"] : false;
					_AplicacionesOpModulos.estado = !rdr.IsDBNull(4) ? (System.Boolean)rdr["estado"] : false;
					lstAplicacionesOpModulos.Add(_AplicacionesOpModulos);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new AplicacionesOpModulos(_state, lstAplicacionesOpModulos);
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
			return new AplicacionesOpModulos(_state);
		}

		public AplicacionesOpModulos BuscarAplicacionesOpModulosXRol(System.Int32 idrol)
		{
			List<AplicacionesOpModulos.Data> lstAplicacionesOpModulos = new List<AplicacionesOpModulos.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_AplicacionesOpModulos_SearchXRol", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrol", idrol);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					AplicacionesOpModulos.Data _AplicacionesOpModulos = new AplicacionesOpModulos.Data();
					_AplicacionesOpModulos.idaplicacionesopmodulos = (System.Int32)rdr["idaplicacionesopmodulos"];
					_AplicacionesOpModulos.idaplicacion = (System.Int32)rdr["idaplicacion"];
					_AplicacionesOpModulos.idoperacion = (System.Int32)rdr["idoperacion"];
					_AplicacionesOpModulos.idmodulo = !rdr.IsDBNull(3) ? (System.Int32)rdr["idmodulo"] : (System.Int32)0;
					_AplicacionesOpModulos.activo = !rdr.IsDBNull(5) ? (System.Boolean)rdr["activo"] : false;
					_AplicacionesOpModulos.estado = !rdr.IsDBNull(4) ? (System.Boolean)rdr["estado"] : false;
					lstAplicacionesOpModulos.Add(_AplicacionesOpModulos);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new AplicacionesOpModulos(_state, lstAplicacionesOpModulos);
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
			return new AplicacionesOpModulos(_state);
		}
		public AplicacionesOpModulos.State InsertarAplicacionesOpModulos(AplicacionesOpModulos.Data _AplicacionesOpModulos)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_AplicacionesOpModulos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDAplicacionesOpModulos = new SqlParameter();
				pIDAplicacionesOpModulos.ParameterName = "@IDAplicacionesOpModulos";
				pIDAplicacionesOpModulos.Value = 0;
				SqlCmd.Parameters.Add(pIDAplicacionesOpModulos);
				pIDAplicacionesOpModulos.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idaplicacion", _AplicacionesOpModulos.idaplicacion);
				SqlCmd.Parameters.AddWithValue("@idoperacion", _AplicacionesOpModulos.idoperacion);
				SqlCmd.Parameters.AddWithValue("@idmodulo", _AplicacionesOpModulos.idmodulo);
				SqlCmd.Parameters.AddWithValue("@activo", _AplicacionesOpModulos.activo);
				SqlCmd.ExecuteNonQuery();
				_AplicacionesOpModulos.idaplicacionesopmodulos = (System.Int32)pIDAplicacionesOpModulos.Value;
				Base.CerrarConexionMySql(SqlCnn);
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
		public AplicacionesOpModulos.State ActualizarAplicacionesOpModulos(AplicacionesOpModulos.Data _AplicacionesOpModulos)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_AplicacionesOpModulos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idaplicacionesopmodulos", _AplicacionesOpModulos.idaplicacionesopmodulos);
				SqlCmd.Parameters.AddWithValue("@idaplicacion", _AplicacionesOpModulos.idaplicacion);
				SqlCmd.Parameters.AddWithValue("@idoperacion", _AplicacionesOpModulos.idoperacion);
				SqlCmd.Parameters.AddWithValue("@idmodulo", _AplicacionesOpModulos.idmodulo);
				SqlCmd.Parameters.AddWithValue("@activo", _AplicacionesOpModulos.activo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
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
		public AplicacionesOpModulos.State EliminarAplicacionesOpModulos(AplicacionesOpModulos.Data _AplicacionesOpModulos)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_AplicacionesOpModulos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idaplicacionesopmodulos", _AplicacionesOpModulos.idaplicacionesopmodulos);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
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
