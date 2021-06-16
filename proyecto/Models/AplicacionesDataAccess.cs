using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace proyecto.Models
{
	public class AplicacionesDataAccess
	{
		Aplicaciones.State _state = new Aplicaciones.State();
		private Conexion Base = new Conexion();
		public Aplicaciones ConsultarAplicaciones()
		{
			List<Aplicaciones.Data> lstAplicaciones = new List<Aplicaciones.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Aplicaciones_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Aplicaciones.Data _Aplicaciones= new Aplicaciones.Data();
					_Aplicaciones.idaplicacion = (System.Int32)rdr["idaplicacion"];
					_Aplicaciones.nombre = !rdr.IsDBNull(1) ? (System.String)rdr["nombre"] : "";
					_Aplicaciones.descripcion = !rdr.IsDBNull(2) ? (System.String)rdr["descripcion"] : "";
					lstAplicaciones.Add(_Aplicaciones);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Aplicaciones(_state, lstAplicaciones);
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
			return new Aplicaciones(_state);
		}
		public Aplicaciones BuscarAplicaciones(System.Int32 idaplicacion)
		{
			List<Aplicaciones.Data> lstAplicaciones = new List<Aplicaciones.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Aplicaciones_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idaplicacion", idaplicacion);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Aplicaciones.Data _Aplicaciones= new Aplicaciones.Data();
					_Aplicaciones.idaplicacion = (System.Int32)rdr["idaplicacion"];
					_Aplicaciones.nombre = !rdr.IsDBNull(1) ? (System.String)rdr["nombre"] : "";
					_Aplicaciones.descripcion = !rdr.IsDBNull(2) ? (System.String)rdr["descripcion"] : "";
					lstAplicaciones.Add(_Aplicaciones);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Aplicaciones(_state, lstAplicaciones);
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
			return new Aplicaciones(_state);
		}
		public Aplicaciones AutenticarUser(System.String nombre, System.String password)
		{
			List<Aplicaciones.Data> lstAplicaciones = new List<Aplicaciones.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("sp_AutenticarUsuario", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@nombre", nombre);
				SqlCmd.Parameters.AddWithValue("@password", password);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Aplicaciones.Data _Aplicaciones = new Aplicaciones.Data();
					_Aplicaciones.idaplicacion = (System.Int32)rdr["idaplicacion"];
					_Aplicaciones.nombre = !rdr.IsDBNull(1) ? (System.String)rdr["nombre"] : "";
					_Aplicaciones.descripcion = !rdr.IsDBNull(2) ? (System.String)rdr["descripcion"] : "";
					lstAplicaciones.Add(_Aplicaciones);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Aplicaciones(_state, lstAplicaciones);
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
			return new Aplicaciones(_state);
		}
		public Aplicaciones.State InsertarAplicaciones(Aplicaciones.Data _Aplicaciones)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Aplicaciones_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIdAplicacion = new SqlParameter();
				pIdAplicacion.ParameterName = "@IdAplicacion";
				pIdAplicacion.Value = 0;
				SqlCmd.Parameters.Add(pIdAplicacion);
				pIdAplicacion.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@nombre", _Aplicaciones.nombre);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Aplicaciones.descripcion);

				SqlCmd.ExecuteNonQuery();
				_Aplicaciones.idaplicacion = (System.Int32)pIdAplicacion.Value;
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
		public Aplicaciones.State ActualizarAplicaciones(Aplicaciones.Data _Aplicaciones)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Aplicaciones_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idaplicacion", _Aplicaciones.idaplicacion);
				SqlCmd.Parameters.AddWithValue("@nombre", _Aplicaciones.nombre);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Aplicaciones.descripcion);

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
		public Aplicaciones.State EliminarAplicaciones(Aplicaciones.Data _Aplicaciones)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Aplicaciones_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idaplicacion", _Aplicaciones.idaplicacion);

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
