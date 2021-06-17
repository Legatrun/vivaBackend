using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace proyecto.Models
{
	public class ModulosDataAccess
	{
		Modulos.State _state = new Modulos.State();
		private Conexion Base = new Conexion();
		public Modulos ConsultarModulos()
		{
			List<Modulos.Data> lstModulos = new List<Modulos.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Modulos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Modulos.Data _Modulos= new Modulos.Data();
					_Modulos.idmodulo = (System.Int32)rdr["idmodulo"];
					_Modulos.descripcion = !rdr.IsDBNull(1) ? (System.String)rdr["descripcion"] : "";
					lstModulos.Add(_Modulos);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Modulos(_state, lstModulos);
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
			return new Modulos(_state);
		}
		public Modulos BuscarModulos(System.Int32 idmodulo)
		{
			List<Modulos.Data> lstModulos = new List<Modulos.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Modulos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idmodulo", idmodulo);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Modulos.Data _Modulos= new Modulos.Data();
					_Modulos.idmodulo = (System.Int32)rdr["idmodulo"];
					_Modulos.descripcion = !rdr.IsDBNull(1) ? (System.String)rdr["descripcion"] : "";
					lstModulos.Add(_Modulos);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				return new Modulos(_state, lstModulos);
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
			return new Modulos(_state);
		}

		//public Modulos BuscarModulosXAplicacion(System.Int32 idaplicacion)
		//{
		//	List<Modulos.Data> lstModulos = new List<Modulos.Data>();
		//	try
		//	{
		//		MySqlConnection SqlCnn;
		//		SqlCnn = Base.AbrirConexionMySql();
		//		MySqlCommand SqlCmd = new MySqlCommand("Proc_Modulos_SearchXAplicacion", SqlCnn);
		//		SqlCmd.CommandType = CommandType.StoredProcedure;
		//		SqlCmd.Parameters.AddWithValue("@idaplicacion", idaplicacion);
		//		MySqlDataReader rdr = SqlCmd.ExecuteReader();
		//		while (rdr.Read())
		//		{
		//			Modulos.Data _Modulos = new Modulos.Data();
		//			_Modulos.idmodulo = (System.Int32)rdr["idmodulo"];
		//			_Modulos.descripcion = !rdr.IsDBNull(1) ? (System.String)rdr["descripcion"] : "";
		//			lstModulos.Add(_Modulos);
		//		}
		//		Base.CerrarConexionMySql(SqlCnn);
		//		_state.error = 0;
		//		_state.descripcion = "Operacion Realizada";
		//		return new Modulos(_state, lstModulos);
		//	}
		//	catch (SqlException XcpSQL)
		//	{
		//		foreach (SqlError se in XcpSQL.Errors)
		//		{
		//			if (se.Number <= 50000)
		//			{
		//				_state.error = -1;
		//				_state.descripcion = se.Message;
		//			}
		//			else
		//			{
		//				_state.error = -2;
		//				_state.descripcion = "Error en Operacion de Consulta de Datos";
		//			}
		//		}
		//	}
		//	catch (Exception Ex)
		//	{
		//		_state.error = -3;
		//		_state.descripcion = Ex.Message;
		//	}
		//	return new Modulos(_state);
		//}

		public Modulos.State InsertarModulos(Modulos.Data _Modulos)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Modulos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIdModulo = new SqlParameter();
				pIdModulo.ParameterName = "@IdModulo";
				pIdModulo.Value = 0;
				SqlCmd.Parameters.Add(pIdModulo);
				pIdModulo.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _Modulos.descripcion);

				SqlCmd.ExecuteNonQuery();
				_Modulos.idmodulo = (System.Int32)pIdModulo.Value;
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
               // _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
			}
			return _state;
		}
		public Modulos.State ActualizarModulos(Modulos.Data _Modulos)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Modulos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idmodulo", _Modulos.idmodulo);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Modulos.descripcion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
               // _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
			}
			return _state;
		}
		public Modulos.State EliminarModulos(Modulos.Data _Modulos)
		{
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_Modulos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idmodulo", _Modulos.idmodulo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
               // _log.Error(_state.descripcion, _state.error.ToString());
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
