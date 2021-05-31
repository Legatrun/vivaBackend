using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class locationsDataAccess
	{
		locations.State _state = new locations.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public locations Consultarlocations()
		{
		    _log.Traceo("Ingresa a Metodo Consultar locations", "0");
			List<locations.Data> lstlocations = new List<locations.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_locations_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					locations.Data _locations= new locations.Data();
					_locations.identification = Convert.ToString(rdr["identification"].ToString());
					_locations.description = !rdr.IsDBNull(1) ? Convert.ToString(rdr["description"].ToString()) : "";
					_locations.type = !rdr.IsDBNull(2) ? Convert.ToString(rdr["type"].ToString()) : "";
					_locations.enabled = Convert.ToInt32(rdr["enabled"].ToString());
					_locations.createtimestamp = !rdr.IsDBNull(4) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_locations.updatetimestamp = !rdr.IsDBNull(5) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_locations.createuser = !rdr.IsDBNull(6) ? Convert.ToString(rdr["createuser"].ToString()) : "";
					_locations.updateuser = !rdr.IsDBNull(7) ? Convert.ToString(rdr["updateuser"].ToString()) : "";
					_locations.address = !rdr.IsDBNull(8) ? Convert.ToString(rdr["address"].ToString()) : "";
					_locations.zipcode = !rdr.IsDBNull(9) ? Convert.ToString(rdr["zipcode"].ToString()) : "";
					_locations.city = !rdr.IsDBNull(10) ? Convert.ToString(rdr["city"].ToString()) : "";
					_locations.city_code = !rdr.IsDBNull(11) ? Convert.ToString(rdr["city_code"].ToString()) : "";
					_locations.state = !rdr.IsDBNull(12) ? Convert.ToString(rdr["state"].ToString()) : "";
					_locations.state_code = !rdr.IsDBNull(13) ? Convert.ToString(rdr["state_code"].ToString()) : "";
					_locations.country = !rdr.IsDBNull(14) ? Convert.ToString(rdr["country"].ToString()) : "";
					_locations.identificationprovider = !rdr.IsDBNull(15) ? Convert.ToString(rdr["identificationprovider"].ToString()) : "";
					_locations.email = !rdr.IsDBNull(16) ? Convert.ToString(rdr["email"].ToString()) : "";
					_locations.areacode = !rdr.IsDBNull(17) ? Convert.ToString(rdr["areacode"].ToString()) : "";
					_locations.geocoordinates = !rdr.IsDBNull(18) ? Convert.ToString(rdr["geocoordinates"].ToString()) : "";
					_locations.replanishmentemail = !rdr.IsDBNull(19) ? Convert.ToString(rdr["replanishmentemail"].ToString()) : "";
					_locations.calendarid = !rdr.IsDBNull(20) ? Convert.ToInt32(rdr["calendarid"].ToString()) : (System.Int32)0;
					_locations.locationtypeid = !rdr.IsDBNull(21) ? Convert.ToInt32(rdr["locationtypeid"].ToString()) : (System.Int32)0;
					lstlocations.Add(_locations);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar locations", _state.error.ToString());
				return new locations(_state, lstlocations);
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new locations(_state);
		}
		public locations Buscarlocations(locations.Data _locationsData)
		{
			List<locations.Data> lstlocations = new List<locations.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar locations", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_locations_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("IDENTIFICATION", _locationsData.identification);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					locations.Data _locations= new locations.Data();
					_locations.identification = Convert.ToString(rdr["identification"].ToString());
					_locations.description = !rdr.IsDBNull(1) ? Convert.ToString(rdr["description"].ToString()) : "";
					_locations.type = !rdr.IsDBNull(2) ? Convert.ToString(rdr["type"].ToString()) : "";
					_locations.enabled = Convert.ToInt32(rdr["enabled"].ToString());
					_locations.createtimestamp = !rdr.IsDBNull(4) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_locations.updatetimestamp = !rdr.IsDBNull(5) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_locations.createuser = !rdr.IsDBNull(6) ? Convert.ToString(rdr["createuser"].ToString()) : "";
					_locations.updateuser = !rdr.IsDBNull(7) ? Convert.ToString(rdr["updateuser"].ToString()) : "";
					_locations.address = !rdr.IsDBNull(8) ? Convert.ToString(rdr["address"].ToString()) : "";
					_locations.zipcode = !rdr.IsDBNull(9) ? Convert.ToString(rdr["zipcode"].ToString()) : "";
					_locations.city = !rdr.IsDBNull(10) ? Convert.ToString(rdr["city"].ToString()) : "";
					_locations.city_code = !rdr.IsDBNull(11) ? Convert.ToString(rdr["city_code"].ToString()) : "";
					_locations.state = !rdr.IsDBNull(12) ? Convert.ToString(rdr["state"].ToString()) : "";
					_locations.state_code = !rdr.IsDBNull(13) ? Convert.ToString(rdr["state_code"].ToString()) : "";
					_locations.country = !rdr.IsDBNull(14) ? Convert.ToString(rdr["country"].ToString()) : "";
					_locations.identificationprovider = !rdr.IsDBNull(15) ? Convert.ToString(rdr["identificationprovider"].ToString()) : "";
					_locations.email = !rdr.IsDBNull(16) ? Convert.ToString(rdr["email"].ToString()) : "";
					_locations.areacode = !rdr.IsDBNull(17) ? Convert.ToString(rdr["areacode"].ToString()) : "";
					_locations.geocoordinates = !rdr.IsDBNull(18) ? Convert.ToString(rdr["geocoordinates"].ToString()) : "";
					_locations.replanishmentemail = !rdr.IsDBNull(19) ? Convert.ToString(rdr["replanishmentemail"].ToString()) : "";
					_locations.calendarid = !rdr.IsDBNull(20) ? Convert.ToInt32(rdr["calendarid"].ToString()) : (System.Int32)0;
					_locations.locationtypeid = !rdr.IsDBNull(21) ? Convert.ToInt32(rdr["locationtypeid"].ToString()) : (System.Int32)0;
					lstlocations.Add(_locations);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar locations", _state.error.ToString());
				return new locations(_state, lstlocations);
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new locations(_state);
		}
		public locations.State Insertarlocations(locations.Data _locations)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar locations", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_locations_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _locations.identification);
				SqlCmd.Parameters.AddWithValue("@description", _locations.description);
				SqlCmd.Parameters.AddWithValue("@type", _locations.type);
				SqlCmd.Parameters.AddWithValue("@enabled", _locations.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _locations.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _locations.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _locations.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _locations.updateuser);
				SqlCmd.Parameters.AddWithValue("@address", _locations.address);
				SqlCmd.Parameters.AddWithValue("@zipcode", _locations.zipcode);
				SqlCmd.Parameters.AddWithValue("@city", _locations.city);
				SqlCmd.Parameters.AddWithValue("@city_code", _locations.city_code);
				SqlCmd.Parameters.AddWithValue("@state", _locations.state);
				SqlCmd.Parameters.AddWithValue("@state_code", _locations.state_code);
				SqlCmd.Parameters.AddWithValue("@country", _locations.country);
				SqlCmd.Parameters.AddWithValue("@identificationprovider", _locations.identificationprovider);
				SqlCmd.Parameters.AddWithValue("@email", _locations.email);
				SqlCmd.Parameters.AddWithValue("@areacode", _locations.areacode);
				SqlCmd.Parameters.AddWithValue("@geocoordinates", _locations.geocoordinates);
				SqlCmd.Parameters.AddWithValue("@replanishmentemail", _locations.replanishmentemail);
				SqlCmd.Parameters.AddWithValue("@calendarid", _locations.calendarid);
				SqlCmd.Parameters.AddWithValue("@locationtypeid", _locations.locationtypeid);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar locations", _state.error.ToString());
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
		public locations.State Actualizarlocations(locations.Data _locations)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar locations", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_locations_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _locations.identification);
				SqlCmd.Parameters.AddWithValue("@description", _locations.description);
				SqlCmd.Parameters.AddWithValue("@type", _locations.type);
				SqlCmd.Parameters.AddWithValue("@enabled", _locations.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _locations.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _locations.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _locations.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _locations.updateuser);
				SqlCmd.Parameters.AddWithValue("@address", _locations.address);
				SqlCmd.Parameters.AddWithValue("@zipcode", _locations.zipcode);
				SqlCmd.Parameters.AddWithValue("@city", _locations.city);
				SqlCmd.Parameters.AddWithValue("@city_code", _locations.city_code);
				SqlCmd.Parameters.AddWithValue("@state", _locations.state);
				SqlCmd.Parameters.AddWithValue("@state_code", _locations.state_code);
				SqlCmd.Parameters.AddWithValue("@country", _locations.country);
				SqlCmd.Parameters.AddWithValue("@identificationprovider", _locations.identificationprovider);
				SqlCmd.Parameters.AddWithValue("@email", _locations.email);
				SqlCmd.Parameters.AddWithValue("@areacode", _locations.areacode);
				SqlCmd.Parameters.AddWithValue("@geocoordinates", _locations.geocoordinates);
				SqlCmd.Parameters.AddWithValue("@replanishmentemail", _locations.replanishmentemail);
				SqlCmd.Parameters.AddWithValue("@calendarid", _locations.calendarid);
				SqlCmd.Parameters.AddWithValue("@locationtypeid", _locations.locationtypeid);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar locations", _state.error.ToString());
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
		public locations.State Eliminarlocations(locations.Data _locations)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar locations", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_locations_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _locations.identification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar locations", _state.error.ToString());
			}
			catch (MySqlException XcpSQL)
			{
				_state.error = -2;
				_state.descripcion = "Error: "+XcpSQL.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
	}
}
