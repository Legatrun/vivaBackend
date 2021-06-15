using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace proyecto.Models
{
	public class UsuariosDataAccess
	{
		Usuarios.State _state = new Usuarios.State();
		private Conexion Base = new Conexion();
		public Usuarios ConsultarUsuarios()
		{
			List<Usuarios.Data> lstUsuarios = new List<Usuarios.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Usuarios_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Usuarios.Data _Usuarios= new Usuarios.Data();
					_Usuarios.idusuario = (System.Int32)rdr["idusuario"];
					_Usuarios.nombre = !rdr.IsDBNull(1) ? (System.String)rdr["nombre"] : "";
					_Usuarios.email = !rdr.IsDBNull(2) ? (System.String)rdr["email"] : "";
					_Usuarios.password = !rdr.IsDBNull(3) ? (System.String)rdr["password"] : "";
					_Usuarios.fechacreacion = !rdr.IsDBNull(4) ? (System.DateTime)rdr["fechacreacion"] : System.DateTime.Now;
					_Usuarios.usrdominio = !rdr.IsDBNull(5) ? (System.Boolean)rdr["usrdominio"] : true;
					_Usuarios.idinstitucion = (System.Int32)rdr["idinstitucion"];
					lstUsuarios.Add(_Usuarios);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Usuarios(_state, lstUsuarios);
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
			return new Usuarios(_state);
		}
		public Usuarios BuscarUsuarios(System.Int32 idusuario)
		{
			List<Usuarios.Data> lstUsuarios = new List<Usuarios.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Usuarios_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", idusuario);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Usuarios.Data _Usuarios= new Usuarios.Data();
					_Usuarios.idusuario = (System.Int32)rdr["idusuario"];
					_Usuarios.nombre = !rdr.IsDBNull(1) ? (System.String)rdr["nombre"] : "";
					_Usuarios.email = !rdr.IsDBNull(2) ? (System.String)rdr["email"] : "";
					_Usuarios.password = !rdr.IsDBNull(3) ? (System.String)rdr["password"] : "";
					_Usuarios.fechacreacion = !rdr.IsDBNull(4) ? (System.DateTime)rdr["fechacreacion"] : System.DateTime.Now;
					_Usuarios.usrdominio = !rdr.IsDBNull(5) ? (System.Boolean)rdr["usrdominio"] : true;
					_Usuarios.idinstitucion = (System.Int32)rdr["idinstitucion"];
					lstUsuarios.Add(_Usuarios);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Usuarios(_state, lstUsuarios);
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
			return new Usuarios(_state);
		}

		public Usuarios BuscarUsuariosXInstitucion(System.Int32 idinstitucion)
		{
			List<Usuarios.Data> lstUsuarios = new List<Usuarios.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Usuarios_SearchXInstitucion", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinstitucion", idinstitucion);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Usuarios.Data _Usuarios= new Usuarios.Data();
					_Usuarios.idusuario = (System.Int32)rdr["idusuario"];
					_Usuarios.nombre = !rdr.IsDBNull(1) ? (System.String)rdr["nombre"] : "";
					_Usuarios.email = !rdr.IsDBNull(2) ? (System.String)rdr["email"] : "";
					_Usuarios.password = !rdr.IsDBNull(3) ? (System.String)rdr["password"] : "";
					_Usuarios.fechacreacion = !rdr.IsDBNull(4) ? (System.DateTime)rdr["fechacreacion"] : System.DateTime.Now;
					_Usuarios.usrdominio = !rdr.IsDBNull(5) ? (System.Boolean)rdr["usrdominio"] : true;
					_Usuarios.idinstitucion = (System.Int32)rdr["idinstitucion"];
					lstUsuarios.Add(_Usuarios);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Usuarios(_state, lstUsuarios);
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
			return new Usuarios(_state);
		}

		public Usuarios LoginUsuarios(System.String nombre, System.String password)
		{
			List<Usuarios.Data> lstUsuarios = new List<Usuarios.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("sp_Usuarios_Login", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@nombre", nombre);
				SqlCmd.Parameters.AddWithValue("@password", password);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Usuarios.Data _Usuarios = new Usuarios.Data();
					_Usuarios.nombre = !rdr.IsDBNull(1) ? (System.String)rdr["nombre"] : "";
					_Usuarios.email = !rdr.IsDBNull(2) ? (System.String)rdr["email"] : "";
					_Usuarios.fechacreacion = !rdr.IsDBNull(3) ? (System.DateTime)rdr["fechacreacion"] : System.DateTime.Now;
					_Usuarios.usrdominio = !rdr.IsDBNull(4) ? (System.Boolean)rdr["usrdominio"] : true;
					_Usuarios.idinstitucion = (System.Int32)rdr["idinstitucion"];
					lstUsuarios.Add(_Usuarios);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Usuarios(_state, lstUsuarios);
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
			return new Usuarios(_state);
		}
		public Usuarios.State InsertarUsuarios(Usuarios.Data _Usuarios)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Usuarios_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIdUsuario = new SqlParameter();
				pIdUsuario.ParameterName = "@IdUsuario";
				pIdUsuario.Value = 0;
				SqlCmd.Parameters.Add(pIdUsuario);
				pIdUsuario.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@nombre", _Usuarios.nombre);
				SqlCmd.Parameters.AddWithValue("@email", _Usuarios.email);
				SqlCmd.Parameters.AddWithValue("@password", _Usuarios.password);
				SqlCmd.Parameters.AddWithValue("@fechacreacion", _Usuarios.fechacreacion);
				SqlCmd.Parameters.AddWithValue("@usrdominio", _Usuarios.usrdominio);
				SqlCmd.Parameters.AddWithValue("@idinstitucion", _Usuarios.idinstitucion);

				SqlCmd.ExecuteNonQuery();
				_Usuarios.idusuario = (System.Int32)pIdUsuario.Value;
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
		public Usuarios.State ActualizarUsuarios(Usuarios.Data _Usuarios)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Usuarios_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _Usuarios.idusuario);
				SqlCmd.Parameters.AddWithValue("@nombre", _Usuarios.nombre);
				SqlCmd.Parameters.AddWithValue("@email", _Usuarios.email);
				SqlCmd.Parameters.AddWithValue("@password", _Usuarios.password);
				SqlCmd.Parameters.AddWithValue("@fechacreacion", _Usuarios.fechacreacion);
				SqlCmd.Parameters.AddWithValue("@usrdominio", _Usuarios.usrdominio);
				SqlCmd.Parameters.AddWithValue("@idinstitucion", _Usuarios.idinstitucion);

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
		public Usuarios.State EliminarUsuarios(Usuarios.Data _Usuarios)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Usuarios_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idusuario", _Usuarios.idusuario);

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
