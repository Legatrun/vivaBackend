using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace proyecto.Models
{
	public class AgenciasDataAccess
	{
		Agencias.State _state = new Agencias.State();
		private Conexion Base = new Conexion();
		public Agencias ConsultarAgencias()
		{
			List<Agencias.Data> lstAgencias = new List<Agencias.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Agencias_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Agencias.Data _Agencias = new Agencias.Data();
					_Agencias.id_agencia = (System.Int32)rdr["id_agencia"];
					_Agencias.cod_agencia = (System.String)rdr["cod_agencia"];
					_Agencias.nombre = (System.String)rdr["nombre"];
					//_Agencias.id_distrito = !rdr.IsDBNull(3) ? (System.Int32)rdr["id_distrito"] : (System.Int32)0;
					_Agencias.idtipoagencia = !rdr.IsDBNull(3) ? (System.Int16)rdr["idtipoagencia"] : (System.Int16)0;
					//_Agencias.idsucursal = !rdr.IsDBNull(5) ? (System.Int32)rdr["idsucursal"] : (System.Int32)0;
					_Agencias.ip_agencia = (System.String)rdr["ip_agencia"];
					_Agencias.latitud = !rdr.IsDBNull(4) ? (System.String)rdr["latitud"] : "";
					_Agencias.longitud = !rdr.IsDBNull(5) ? (System.String)rdr["longitud"] : "";
					_Agencias.idciudad = !rdr.IsDBNull(6) ? (System.Int32)rdr["idciudad"] : 0;
					lstAgencias.Add(_Agencias);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Agencias(_state, lstAgencias);
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
			return new Agencias(_state);
		}

		public Agencias BuscarAgencias(System.Int32 id_agencia)
		{
			List<Agencias.Data> lstAgencias = new List<Agencias.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Agencias_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id_agencia", id_agencia);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Agencias.Data _Agencias= new Agencias.Data();
					_Agencias.id_agencia = (System.Int32)rdr["id_agencia"];
					_Agencias.cod_agencia = (System.String)rdr["cod_agencia"];
					_Agencias.nombre = (System.String)rdr["nombre"];
					_Agencias.idtipoagencia = !rdr.IsDBNull(4) ? (System.Int16)rdr["idtipoagencia"] : (System.Int16)0;
					_Agencias.ip_agencia = (System.String)rdr["ip_agencia"];
					//_Agencias.latitud = !rdr.IsDBNull(7) ? (System.String)rdr["latitud"] : "";
					//_Agencias.longitud = !rdr.IsDBNull(8) ? (System.String)rdr["longitud"] : "";
					lstAgencias.Add(_Agencias);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Agencias(_state, lstAgencias);
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
			return new Agencias(_state);
		}
		public Agencias.State InsertarAgencias(Agencias.Data _Agencias)
		{
			try
			{
                #region ObtieneIDAgencias de Manera Temporal
                SqlConnection SqlCnn_temp;
                SqlCnn_temp = Base.AbrirConexion();
                SqlCommand SqlCmd_temp = new SqlCommand("Select * From Agencias", SqlCnn_temp);
                SqlDataReader rdr_temp = SqlCmd_temp.ExecuteReader();
                int numRegistros = 0;
                while (rdr_temp.Read()) {
                    numRegistros++;
                }
                //int numRegistros = rdr_temp.FieldCount;
                SqlCnn_temp.Dispose();
                SqlCnn_temp.Close();
                #endregion

               SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Agencias_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@id_agencia", numRegistros+1);
				SqlCmd.Parameters.AddWithValue("@cod_agencia", _Agencias.cod_agencia);
				SqlCmd.Parameters.AddWithValue("@nombre", _Agencias.nombre);
				SqlCmd.Parameters.AddWithValue("@idtipoagencia", _Agencias.idtipoagencia);
				SqlCmd.Parameters.AddWithValue("@ip_agencia", _Agencias.ip_agencia);
				SqlCmd.Parameters.AddWithValue("@latitud", _Agencias.latitud);
				SqlCmd.Parameters.AddWithValue("@longitud", _Agencias.longitud);

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
		public Agencias.State ActualizarAgencias(Agencias.Data _Agencias)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Agencias_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id_agencia", _Agencias.id_agencia);
				SqlCmd.Parameters.AddWithValue("@cod_agencia", _Agencias.cod_agencia);
				SqlCmd.Parameters.AddWithValue("@nombre", _Agencias.nombre);
				SqlCmd.Parameters.AddWithValue("@idtipoagencia", _Agencias.idtipoagencia);
				SqlCmd.Parameters.AddWithValue("@ip_agencia", _Agencias.ip_agencia);
				SqlCmd.Parameters.AddWithValue("@latitud", _Agencias.latitud);
				SqlCmd.Parameters.AddWithValue("@longitud", _Agencias.longitud);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Agencias.idciudad);


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
		public Agencias.State EliminarAgencias(Agencias.Data _Agencias)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Agencias_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id_agencia", _Agencias.id_agencia);

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
