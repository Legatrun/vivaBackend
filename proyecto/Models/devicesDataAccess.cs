using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class devicesDataAccess
	{
		devices.State _state = new devices.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public devices Consultardevices()
		{
		    _log.Traceo("Ingresa a Metodo Consultar devices", "0");
			List<devices.Data> lstdevices = new List<devices.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devices_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devices.Data _devices= new devices.Data();
					_devices.identification = Convert.ToString(rdr["identification"].ToString());
					_devices.description = Convert.ToString(rdr["description"].ToString());
					_devices.devicetypeidentification = Convert.ToString(rdr["devicetypeidentification"].ToString());
					_devices.enabled = Convert.ToInt32(rdr["enabled"].ToString());
					lstdevices.Add(_devices);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar devices", _state.error.ToString());
				return new devices(_state, lstdevices);
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
			return new devices(_state);
		}
		public devices Buscardevices(devices.Data _devicesData)
		{
			List<devices.Data> lstdevices = new List<devices.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar devices", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devices_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devicesData.identification);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devices.Data _devices= new devices.Data();
					_devices.identification = Convert.ToString(rdr["identification"].ToString());
					lstdevices.Add(_devices);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar devices", _state.error.ToString());
				return new devices(_state, lstdevices);
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
			return new devices(_state);
		}
		public devices.State Insertardevices(devices.Data _devices)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar devices", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devices_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devices.identification);
				SqlCmd.Parameters.AddWithValue("@description", _devices.description);
				SqlCmd.Parameters.AddWithValue("@devicetypeidentification", _devices.devicetypeidentification);
				SqlCmd.Parameters.AddWithValue("@enabled", _devices.enabled);
				//SqlCmd.Parameters.AddWithValue("@createtimestamp", _devices.createtimestamp);
				//SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devices.updatetimestamp);
				//SqlCmd.Parameters.AddWithValue("@createuser", _devices.createuser);
				//SqlCmd.Parameters.AddWithValue("@updateuser", _devices.updateuser);
				//SqlCmd.Parameters.AddWithValue("@configuration", _devices.configuration);
				//SqlCmd.Parameters.AddWithValue("@identificationprovider", _devices.identificationprovider);
				//SqlCmd.Parameters.AddWithValue("@locationidentification", _devices.locationidentification);
				//SqlCmd.Parameters.AddWithValue("@coinacceptordenoms", _devices.coinacceptordenoms);
				//SqlCmd.Parameters.AddWithValue("@cashacceptordenoms", _devices.cashacceptordenoms);
				//SqlCmd.Parameters.AddWithValue("@maxamountodispense", _devices.maxamountodispense);
				//SqlCmd.Parameters.AddWithValue("@maxbillstodispense", _devices.maxbillstodispense);
				//SqlCmd.Parameters.AddWithValue("@maxcoinstodispense", _devices.maxcoinstodispense);
				//SqlCmd.Parameters.AddWithValue("@video_intro", _devices.video_intro);
				//SqlCmd.Parameters.AddWithValue("@video_insert_cash", _devices.video_insert_cash);
				//SqlCmd.Parameters.AddWithValue("@video_take_cash", _devices.video_take_cash);
				//SqlCmd.Parameters.AddWithValue("@video_take_cash_chash_receipt", _devices.video_take_cash_chash_receipt);
				//SqlCmd.Parameters.AddWithValue("@video_read_barcode", _devices.video_read_barcode);
				//SqlCmd.Parameters.AddWithValue("@payment_success", _devices.payment_success);
				//SqlCmd.Parameters.AddWithValue("@payment_cancel", _devices.payment_cancel);
				//SqlCmd.Parameters.AddWithValue("@final_success", _devices.final_success);
				//SqlCmd.Parameters.AddWithValue("@cashacceptorfullalarm", _devices.cashacceptorfullalarm);
				//SqlCmd.Parameters.AddWithValue("@cashacceptorfulllimit", _devices.cashacceptorfulllimit);
				//SqlCmd.Parameters.AddWithValue("@coinacceptorfullalarm", _devices.coinacceptorfullalarm);
				//SqlCmd.Parameters.AddWithValue("@coinacceptorfulllimit", _devices.coinacceptorfulllimit);
				//SqlCmd.Parameters.AddWithValue("@cashchangeremptyalarm", _devices.cashchangeremptyalarm);
				//SqlCmd.Parameters.AddWithValue("@cashchangeremptylimit", _devices.cashchangeremptylimit);
				//SqlCmd.Parameters.AddWithValue("@cashchangersecuritystock", _devices.cashchangersecuritystock);
				//SqlCmd.Parameters.AddWithValue("@coinchangeremptyalarm", _devices.coinchangeremptyalarm);
				//SqlCmd.Parameters.AddWithValue("@coinchangeremptylimit", _devices.coinchangeremptylimit);
				//SqlCmd.Parameters.AddWithValue("@coinchangersecuritystock", _devices.coinchangersecuritystock);
				//SqlCmd.Parameters.AddWithValue("@carddispenseremptylimit", _devices.carddispenseremptylimit);
				//SqlCmd.Parameters.AddWithValue("@carddispenseremptyalarm", _devices.carddispenseremptyalarm);
				//SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition1", _devices.emptydenomblockcondition1);
				//SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition2", _devices.emptydenomblockcondition2);
				//SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition3", _devices.emptydenomblockcondition3);
				//SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition4", _devices.emptydenomblockcondition4);
				//SqlCmd.Parameters.AddWithValue("@totalchangeemptyalarm", _devices.totalchangeemptyalarm);
				//SqlCmd.Parameters.AddWithValue("@totalchangeemptylimit", _devices.totalchangeemptylimit);
				//SqlCmd.Parameters.AddWithValue("@scp_statusinterval", _devices.scp_statusinterval);
				//SqlCmd.Parameters.AddWithValue("@sct_step", _devices.sct_step);
				//SqlCmd.Parameters.AddWithValue("@sct_changevalidatoramount", _devices.sct_changevalidatoramount);
				//SqlCmd.Parameters.AddWithValue("@sct_finishscreentimeout", _devices.sct_finishscreentimeout);
				//SqlCmd.Parameters.AddWithValue("@cashchangerfill", _devices.cashchangerfill);
				//SqlCmd.Parameters.AddWithValue("@coinchangerfill", _devices.coinchangerfill);
				//SqlCmd.Parameters.AddWithValue("@coinchangerdenoms", _devices.coinchangerdenoms);
				//SqlCmd.Parameters.AddWithValue("@cashchangerdenoms", _devices.cashchangerdenoms);
				//SqlCmd.Parameters.AddWithValue("@lastreporttimestamp", _devices.lastreporttimestamp);
				//SqlCmd.Parameters.AddWithValue("@laststatusreported", _devices.laststatusreported);
				//SqlCmd.Parameters.AddWithValue("@serviceuser", _devices.serviceuser);
				//SqlCmd.Parameters.AddWithValue("@operatorcode", _devices.operatorcode);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar devices", _state.error.ToString());
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
		public devices.State Actualizardevices(devices.Data _devices)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar devices", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devices_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devices.identification);
				SqlCmd.Parameters.AddWithValue("@description", _devices.description);
				SqlCmd.Parameters.AddWithValue("@devicetypeidentification", _devices.devicetypeidentification);
				SqlCmd.Parameters.AddWithValue("@enabled", _devices.enabled);
				//SqlCmd.Parameters.AddWithValue("@createtimestamp", _devices.createtimestamp);
				//SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devices.updatetimestamp);
				//SqlCmd.Parameters.AddWithValue("@createuser", _devices.createuser);
				//SqlCmd.Parameters.AddWithValue("@updateuser", _devices.updateuser);
				//SqlCmd.Parameters.AddWithValue("@configuration", _devices.configuration);
				//SqlCmd.Parameters.AddWithValue("@identificationprovider", _devices.identificationprovider);
				//SqlCmd.Parameters.AddWithValue("@locationidentification", _devices.locationidentification);
				//SqlCmd.Parameters.AddWithValue("@coinacceptordenoms", _devices.coinacceptordenoms);
				//SqlCmd.Parameters.AddWithValue("@cashacceptordenoms", _devices.cashacceptordenoms);
				//SqlCmd.Parameters.AddWithValue("@maxamountodispense", _devices.maxamountodispense);
				//SqlCmd.Parameters.AddWithValue("@maxbillstodispense", _devices.maxbillstodispense);
				//SqlCmd.Parameters.AddWithValue("@maxcoinstodispense", _devices.maxcoinstodispense);
				//SqlCmd.Parameters.AddWithValue("@video_intro", _devices.video_intro);
				//SqlCmd.Parameters.AddWithValue("@video_insert_cash", _devices.video_insert_cash);
				//SqlCmd.Parameters.AddWithValue("@video_take_cash", _devices.video_take_cash);
				//SqlCmd.Parameters.AddWithValue("@video_take_cash_chash_receipt", _devices.video_take_cash_chash_receipt);
				//SqlCmd.Parameters.AddWithValue("@video_read_barcode", _devices.video_read_barcode);
				//SqlCmd.Parameters.AddWithValue("@payment_success", _devices.payment_success);
				//SqlCmd.Parameters.AddWithValue("@payment_cancel", _devices.payment_cancel);
				//SqlCmd.Parameters.AddWithValue("@final_success", _devices.final_success);
				//SqlCmd.Parameters.AddWithValue("@cashacceptorfullalarm", _devices.cashacceptorfullalarm);
				//SqlCmd.Parameters.AddWithValue("@cashacceptorfulllimit", _devices.cashacceptorfulllimit);
				//SqlCmd.Parameters.AddWithValue("@coinacceptorfullalarm", _devices.coinacceptorfullalarm);
				//SqlCmd.Parameters.AddWithValue("@coinacceptorfulllimit", _devices.coinacceptorfulllimit);
				//SqlCmd.Parameters.AddWithValue("@cashchangeremptyalarm", _devices.cashchangeremptyalarm);
				//SqlCmd.Parameters.AddWithValue("@cashchangeremptylimit", _devices.cashchangeremptylimit);
				//SqlCmd.Parameters.AddWithValue("@cashchangersecuritystock", _devices.cashchangersecuritystock);
				//SqlCmd.Parameters.AddWithValue("@coinchangeremptyalarm", _devices.coinchangeremptyalarm);
				//SqlCmd.Parameters.AddWithValue("@coinchangeremptylimit", _devices.coinchangeremptylimit);
				//SqlCmd.Parameters.AddWithValue("@coinchangersecuritystock", _devices.coinchangersecuritystock);
				//SqlCmd.Parameters.AddWithValue("@carddispenseremptylimit", _devices.carddispenseremptylimit);
				//SqlCmd.Parameters.AddWithValue("@carddispenseremptyalarm", _devices.carddispenseremptyalarm);
				//SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition1", _devices.emptydenomblockcondition1);
				//SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition2", _devices.emptydenomblockcondition2);
				//SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition3", _devices.emptydenomblockcondition3);
				//SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition4", _devices.emptydenomblockcondition4);
				//SqlCmd.Parameters.AddWithValue("@totalchangeemptyalarm", _devices.totalchangeemptyalarm);
				//SqlCmd.Parameters.AddWithValue("@totalchangeemptylimit", _devices.totalchangeemptylimit);
				//SqlCmd.Parameters.AddWithValue("@scp_statusinterval", _devices.scp_statusinterval);
				//SqlCmd.Parameters.AddWithValue("@sct_step", _devices.sct_step);
				//SqlCmd.Parameters.AddWithValue("@sct_changevalidatoramount", _devices.sct_changevalidatoramount);
				//SqlCmd.Parameters.AddWithValue("@sct_finishscreentimeout", _devices.sct_finishscreentimeout);
				//SqlCmd.Parameters.AddWithValue("@cashchangerfill", _devices.cashchangerfill);
				//SqlCmd.Parameters.AddWithValue("@coinchangerfill", _devices.coinchangerfill);
				//SqlCmd.Parameters.AddWithValue("@coinchangerdenoms", _devices.coinchangerdenoms);
				//SqlCmd.Parameters.AddWithValue("@cashchangerdenoms", _devices.cashchangerdenoms);
				//SqlCmd.Parameters.AddWithValue("@lastreporttimestamp", _devices.lastreporttimestamp);
				//SqlCmd.Parameters.AddWithValue("@laststatusreported", _devices.laststatusreported);
				//SqlCmd.Parameters.AddWithValue("@serviceuser", _devices.serviceuser);
				//SqlCmd.Parameters.AddWithValue("@operatorcode", _devices.operatorcode);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar devices", _state.error.ToString());
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
		public devices.State Eliminardevices(devices.Data _devices)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar devices", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devices_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devices.identification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar devices", _state.error.ToString());
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
