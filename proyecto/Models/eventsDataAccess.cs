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
	public class eventsDataAccess
	{
		events.State _state = new events.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public events Consultarevents()
		{
		    _log.Traceo("Ingresa a Metodo Consultar events", "0");
			List<events.Data> lstevents = new List<events.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_events_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					events.Data _events= new events.Data();
					_events.type = Convert.ToInt32(rdr["type"].ToString());
					_events.deviceidentification = Convert.ToString(rdr["deviceidentification"].ToString());
					_events.locationidentification = Convert.ToString(rdr["locationidentification"].ToString());
					_events.createtimestamp = Convert.ToDateTime(rdr["createtimestamp"].ToString());
					_events.reason = Convert.ToString(rdr["reason"].ToString());
					_events.operationname = Convert.ToString(rdr["operationname"].ToString());
					_events.servicename = Convert.ToString(rdr["servicename"].ToString());
					_events.sequencenumber = Convert.ToInt32(rdr["sequencenumber"].ToString());
					lstevents.Add(_events);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar events", _state.error.ToString());
				return new events(_state, lstevents);
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new events(_state);
		}
		public events Buscarevents(events.Data _eventsData)
		{
			List<events.Data> lstevents = new List<events.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar events", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_events_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@type", _eventsData.type);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _eventsData.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _eventsData.locationidentification);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _eventsData.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@reason", _eventsData.reason);
				SqlCmd.Parameters.AddWithValue("@operationname", _eventsData.operationname);
				SqlCmd.Parameters.AddWithValue("@servicename", _eventsData.servicename);
				SqlCmd.Parameters.AddWithValue("@sequencenumber", _eventsData.sequencenumber);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					events.Data _events= new events.Data();
					_events.type = Convert.ToInt32(rdr["type"].ToString());
					_events.deviceidentification = Convert.ToString(rdr["deviceidentification"].ToString());
					_events.locationidentification = Convert.ToString(rdr["locationidentification"].ToString());
					_events.createtimestamp = Convert.ToDateTime(rdr["createtimestamp"].ToString());
					_events.reason = Convert.ToString(rdr["reason"].ToString());
					_events.operationname = Convert.ToString(rdr["operationname"].ToString());
					_events.servicename = Convert.ToString(rdr["servicename"].ToString());
					_events.sequencenumber = Convert.ToInt32(rdr["sequencenumber"].ToString());
					lstevents.Add(_events);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar events", _state.error.ToString());
				return new events(_state, lstevents);
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new events(_state);
		}
		public events.State Insertarevents(events.Data _events)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar events", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_events_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@type", _events.type);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _events.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _events.locationidentification);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _events.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@reason", _events.reason);
				SqlCmd.Parameters.AddWithValue("@operationname", _events.operationname);
				SqlCmd.Parameters.AddWithValue("@servicename", _events.servicename);
				SqlCmd.Parameters.AddWithValue("@sequencenumber", _events.sequencenumber);
				SqlCmd.Parameters.AddWithValue("@notifytimestamp", _events.notifytimestamp);
				SqlCmd.Parameters.AddWithValue("@text", _events.text);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar events", _state.error.ToString());
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
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
		public events.State Actualizarevents(events.Data _events)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar events", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_events_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@type", _events.type);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _events.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _events.locationidentification);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _events.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@reason", _events.reason);
				SqlCmd.Parameters.AddWithValue("@operationname", _events.operationname);
				SqlCmd.Parameters.AddWithValue("@servicename", _events.servicename);
				SqlCmd.Parameters.AddWithValue("@sequencenumber", _events.sequencenumber);
				SqlCmd.Parameters.AddWithValue("@notifytimestamp", _events.notifytimestamp);
				SqlCmd.Parameters.AddWithValue("@text", _events.text);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar events", _state.error.ToString());
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
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
		public events.State Eliminarevents(events.Data _events)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar events", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_events_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@type", _events.type);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _events.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _events.locationidentification);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _events.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@reason", _events.reason);
				SqlCmd.Parameters.AddWithValue("@operationname", _events.operationname);
				SqlCmd.Parameters.AddWithValue("@servicename", _events.servicename);
				SqlCmd.Parameters.AddWithValue("@sequencenumber", _events.sequencenumber);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar events", _state.error.ToString());
			}
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
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
