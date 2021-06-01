using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace proyecto.Models
{
	public class ClienteDataAccess
	{
		Cliente.State _state = new Cliente.State();
		private Conexion Base = new Conexion();
		public Cliente ConsultarCliente()
		{
			List<Cliente.Data> lstCliente = new List<Cliente.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cliente_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Cliente.Data _Cliente= new Cliente.Data();
					_Cliente.idcliente = (System.Int32)rdr["idcliente"];
					_Cliente.ci = (System.String)rdr["ci"];
					_Cliente.telefono = (System.String)rdr["telefono"];
					_Cliente.nombre = (System.String)rdr["nombre"];
					lstCliente.Add(_Cliente);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Cliente(_state, lstCliente);
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
			return new Cliente(_state);
		}
		public Cliente BuscarCliente(System.Int32 idcliente)
		{
			List<Cliente.Data> lstCliente = new List<Cliente.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cliente_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcliente", idcliente);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Cliente.Data _Cliente= new Cliente.Data();
					_Cliente.idcliente = (System.Int32)rdr["idcliente"];
					_Cliente.ci = (System.String)rdr["ci"];
					_Cliente.telefono = (System.String)rdr["telefono"];
					_Cliente.nombre = (System.String)rdr["nombre"];
					lstCliente.Add(_Cliente);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Cliente(_state, lstCliente);
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
			return new Cliente(_state);
		}
		public Cliente LoginCliente(System.String ci)
		{
			List<Cliente.Data> lstCliente = new List<Cliente.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("sp_Cliente_Search_Login", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@ci", ci);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Cliente.Data _Cliente = new Cliente.Data();
					_Cliente.idcliente = (System.Int32)rdr["idcliente"];
					_Cliente.ci = (System.String)rdr["ci"];
					_Cliente.telefono = (System.String)rdr["telefono"];
					_Cliente.nombre = (System.String)rdr["nombre"];
					lstCliente.Add(_Cliente);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Cliente(_state, lstCliente);
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
			return new Cliente(_state);
		}
		public Cliente.State InsertarCliente(Cliente.Data _Cliente)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cliente_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDCliente = new SqlParameter();
				pIDCliente.ParameterName = "@IDCliente";
				pIDCliente.Value = 0;
				SqlCmd.Parameters.Add(pIDCliente);
				pIDCliente.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@ci", _Cliente.ci);
				SqlCmd.Parameters.AddWithValue("@telefono", _Cliente.telefono);
				SqlCmd.Parameters.AddWithValue("@nombre", _Cliente.nombre);

				SqlCmd.ExecuteNonQuery();
				_Cliente.idcliente = (System.Int32)pIDCliente.Value;
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
		public Cliente.State ActualizarCliente(Cliente.Data _Cliente)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cliente_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcliente", _Cliente.idcliente);
				SqlCmd.Parameters.AddWithValue("@ci", _Cliente.ci);
				SqlCmd.Parameters.AddWithValue("@telefono", _Cliente.telefono);
				SqlCmd.Parameters.AddWithValue("@nombre", _Cliente.nombre);

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
		public Cliente.State EliminarCliente(Cliente.Data _Cliente)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cliente_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcliente", _Cliente.idcliente);

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
