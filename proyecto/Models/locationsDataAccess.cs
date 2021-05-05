using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_locations_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					locations.Data _locations= new locations.Data();
					_locations.identification = Convert.ToString(rdr["identification"].ToString());
					lstlocations.Add(_locations);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar locations", _state.error.ToString());
				return new locations(_state, lstlocations);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_locations_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _locationsData.identification);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					locations.Data _locations= new locations.Data();
					_locations.identification = Convert.ToString(rdr["identification"].ToString());
					lstlocations.Add(_locations);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar locations", _state.error.ToString());
				return new locations(_state, lstlocations);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_locations_Insert", SqlCnn);
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
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar locations", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Insertar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_locations_Update", SqlCnn);
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
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar locations", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Actualizar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_locations_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _locations.identification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar locations", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Eliminar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
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
