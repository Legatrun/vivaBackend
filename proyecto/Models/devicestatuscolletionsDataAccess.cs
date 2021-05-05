using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class devicestatuscolletionsDataAccess
	{
		devicestatuscolletions.State _state = new devicestatuscolletions.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public devicestatuscolletions Consultardevicestatuscolletions()
		{
		    _log.Traceo("Ingresa a Metodo Consultar devicestatuscolletions", "0");
			List<devicestatuscolletions.Data> lstdevicestatuscolletions = new List<devicestatuscolletions.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicestatuscolletions_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicestatuscolletions.Data _devicestatuscolletions= new devicestatuscolletions.Data();
					_devicestatuscolletions.id = Convert.ToInt32(rdr["id"].ToString());
					lstdevicestatuscolletions.Add(_devicestatuscolletions);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar devicestatuscolletions", _state.error.ToString());
				return new devicestatuscolletions(_state, lstdevicestatuscolletions);
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
			return new devicestatuscolletions(_state);
		}
		public devicestatuscolletions Buscardevicestatuscolletions(devicestatuscolletions.Data _devicestatuscolletionsData)
		{
			List<devicestatuscolletions.Data> lstdevicestatuscolletions = new List<devicestatuscolletions.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar devicestatuscolletions", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicestatuscolletions_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicestatuscolletionsData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicestatuscolletions.Data _devicestatuscolletions= new devicestatuscolletions.Data();
					_devicestatuscolletions.id = Convert.ToInt32(rdr["id"].ToString());
					lstdevicestatuscolletions.Add(_devicestatuscolletions);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar devicestatuscolletions", _state.error.ToString());
				return new devicestatuscolletions(_state, lstdevicestatuscolletions);
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
			return new devicestatuscolletions(_state);
		}
		public devicestatuscolletions.State Insertardevicestatuscolletions(devicestatuscolletions.Data _devicestatuscolletions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar devicestatuscolletions", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicestatuscolletions_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicestatuscolletions.id);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _devicestatuscolletions.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devicestatuscolletions.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _devicestatuscolletions.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _devicestatuscolletions.locationidentification);
				SqlCmd.Parameters.AddWithValue("@servicename", _devicestatuscolletions.servicename);
				SqlCmd.Parameters.AddWithValue("@operationname", _devicestatuscolletions.operationname);
				SqlCmd.Parameters.AddWithValue("@sequencenumber", _devicestatuscolletions.sequencenumber);
				SqlCmd.Parameters.AddWithValue("@transporttimestamp", _devicestatuscolletions.transporttimestamp);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _devicestatuscolletions.provideridentification);
				SqlCmd.Parameters.AddWithValue("@providertransactionid", _devicestatuscolletions.providertransactionid);
				SqlCmd.Parameters.AddWithValue("@devicetransactionid", _devicestatuscolletions.devicetransactionid);
				SqlCmd.Parameters.AddWithValue("@status", _devicestatuscolletions.status);
				SqlCmd.Parameters.AddWithValue("@batchnumber", _devicestatuscolletions.batchnumber);
				SqlCmd.Parameters.AddWithValue("@transactionid", _devicestatuscolletions.transactionid);
				SqlCmd.Parameters.AddWithValue("@alarm", _devicestatuscolletions.alarm);
				SqlCmd.Parameters.AddWithValue("@devicestatus", _devicestatuscolletions.devicestatus);
				SqlCmd.Parameters.AddWithValue("@operatingmode", _devicestatuscolletions.operatingmode);
				SqlCmd.Parameters.AddWithValue("@alarmid", _devicestatuscolletions.alarmid);
				SqlCmd.Parameters.AddWithValue("@aceptordetail", _devicestatuscolletions.aceptordetail);
				SqlCmd.Parameters.AddWithValue("@changerdetail", _devicestatuscolletions.changerdetail);
				SqlCmd.Parameters.AddWithValue("@returndetail", _devicestatuscolletions.returndetail);
				SqlCmd.Parameters.AddWithValue("@operativeday", _devicestatuscolletions.operativeday);
				SqlCmd.Parameters.AddWithValue("@totaltx", _devicestatuscolletions.totaltx);
				SqlCmd.Parameters.AddWithValue("@totalamount", _devicestatuscolletions.totalamount);
				SqlCmd.Parameters.AddWithValue("@totalaccepted", _devicestatuscolletions.totalaccepted);
				SqlCmd.Parameters.AddWithValue("@totalreturned", _devicestatuscolletions.totalreturned);
				SqlCmd.Parameters.AddWithValue("@totalavailable", _devicestatuscolletions.totalavailable);
				SqlCmd.Parameters.AddWithValue("@totalgivenamount", _devicestatuscolletions.totalgivenamount);
				SqlCmd.Parameters.AddWithValue("@totaldebtamount", _devicestatuscolletions.totaldebtamount);
				SqlCmd.Parameters.AddWithValue("@totalrefilloperations", _devicestatuscolletions.totalrefilloperations);
				SqlCmd.Parameters.AddWithValue("@totalrefillamount", _devicestatuscolletions.totalrefillamount);
				SqlCmd.Parameters.AddWithValue("@totalcollectoperations", _devicestatuscolletions.totalcollectoperations);
				SqlCmd.Parameters.AddWithValue("@totalcollectamount", _devicestatuscolletions.totalcollectamount);
				SqlCmd.Parameters.AddWithValue("@totallocks", _devicestatuscolletions.totallocks);
				SqlCmd.Parameters.AddWithValue("@opentime", _devicestatuscolletions.opentime);
				SqlCmd.Parameters.AddWithValue("@closetime", _devicestatuscolletions.closetime);
				SqlCmd.Parameters.AddWithValue("@vdmstatus", _devicestatuscolletions.vdmstatus);
				SqlCmd.Parameters.AddWithValue("@powerstatus", _devicestatuscolletions.powerstatus);
				SqlCmd.Parameters.AddWithValue("@scannerstatus", _devicestatuscolletions.scannerstatus);
				SqlCmd.Parameters.AddWithValue("@motionsensorstatus", _devicestatuscolletions.motionsensorstatus);
				SqlCmd.Parameters.AddWithValue("@printerstatus", _devicestatuscolletions.printerstatus);
				SqlCmd.Parameters.AddWithValue("@cashacceptorstatus", _devicestatuscolletions.cashacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@cashchangerstatus", _devicestatuscolletions.cashchangerstatus);
				SqlCmd.Parameters.AddWithValue("@coinacceptorstatus", _devicestatuscolletions.coinacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@coinchangerstatus", _devicestatuscolletions.coinchangerstatus);
				SqlCmd.Parameters.AddWithValue("@devicestatusdetail", _devicestatuscolletions.devicestatusdetail);
				SqlCmd.Parameters.AddWithValue("@totalcardsdelivered", _devicestatuscolletions.totalcardsdelivered);
				SqlCmd.Parameters.AddWithValue("@totalcardrefilloperations", _devicestatuscolletions.totalcardrefilloperations);
				SqlCmd.Parameters.AddWithValue("@totalcardrefillamount", _devicestatuscolletions.totalcardrefillamount);
				SqlCmd.Parameters.AddWithValue("@totalcardcollectoperations", _devicestatuscolletions.totalcardcollectoperations);
				SqlCmd.Parameters.AddWithValue("@totalcardcollectamount", _devicestatuscolletions.totalcardcollectamount);
				SqlCmd.Parameters.AddWithValue("@carddispenserstatus", _devicestatuscolletions.carddispenserstatus);
				SqlCmd.Parameters.AddWithValue("@cardreaderstatus", _devicestatuscolletions.cardreaderstatus);
				SqlCmd.Parameters.AddWithValue("@carddispensercount", _devicestatuscolletions.carddispensercount);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar devicestatuscolletions", _state.error.ToString());
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
		public devicestatuscolletions.State Actualizardevicestatuscolletions(devicestatuscolletions.Data _devicestatuscolletions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar devicestatuscolletions", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicestatuscolletions_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicestatuscolletions.id);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _devicestatuscolletions.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devicestatuscolletions.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _devicestatuscolletions.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _devicestatuscolletions.locationidentification);
				SqlCmd.Parameters.AddWithValue("@servicename", _devicestatuscolletions.servicename);
				SqlCmd.Parameters.AddWithValue("@operationname", _devicestatuscolletions.operationname);
				SqlCmd.Parameters.AddWithValue("@sequencenumber", _devicestatuscolletions.sequencenumber);
				SqlCmd.Parameters.AddWithValue("@transporttimestamp", _devicestatuscolletions.transporttimestamp);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _devicestatuscolletions.provideridentification);
				SqlCmd.Parameters.AddWithValue("@providertransactionid", _devicestatuscolletions.providertransactionid);
				SqlCmd.Parameters.AddWithValue("@devicetransactionid", _devicestatuscolletions.devicetransactionid);
				SqlCmd.Parameters.AddWithValue("@status", _devicestatuscolletions.status);
				SqlCmd.Parameters.AddWithValue("@batchnumber", _devicestatuscolletions.batchnumber);
				SqlCmd.Parameters.AddWithValue("@transactionid", _devicestatuscolletions.transactionid);
				SqlCmd.Parameters.AddWithValue("@alarm", _devicestatuscolletions.alarm);
				SqlCmd.Parameters.AddWithValue("@devicestatus", _devicestatuscolletions.devicestatus);
				SqlCmd.Parameters.AddWithValue("@operatingmode", _devicestatuscolletions.operatingmode);
				SqlCmd.Parameters.AddWithValue("@alarmid", _devicestatuscolletions.alarmid);
				SqlCmd.Parameters.AddWithValue("@aceptordetail", _devicestatuscolletions.aceptordetail);
				SqlCmd.Parameters.AddWithValue("@changerdetail", _devicestatuscolletions.changerdetail);
				SqlCmd.Parameters.AddWithValue("@returndetail", _devicestatuscolletions.returndetail);
				SqlCmd.Parameters.AddWithValue("@operativeday", _devicestatuscolletions.operativeday);
				SqlCmd.Parameters.AddWithValue("@totaltx", _devicestatuscolletions.totaltx);
				SqlCmd.Parameters.AddWithValue("@totalamount", _devicestatuscolletions.totalamount);
				SqlCmd.Parameters.AddWithValue("@totalaccepted", _devicestatuscolletions.totalaccepted);
				SqlCmd.Parameters.AddWithValue("@totalreturned", _devicestatuscolletions.totalreturned);
				SqlCmd.Parameters.AddWithValue("@totalavailable", _devicestatuscolletions.totalavailable);
				SqlCmd.Parameters.AddWithValue("@totalgivenamount", _devicestatuscolletions.totalgivenamount);
				SqlCmd.Parameters.AddWithValue("@totaldebtamount", _devicestatuscolletions.totaldebtamount);
				SqlCmd.Parameters.AddWithValue("@totalrefilloperations", _devicestatuscolletions.totalrefilloperations);
				SqlCmd.Parameters.AddWithValue("@totalrefillamount", _devicestatuscolletions.totalrefillamount);
				SqlCmd.Parameters.AddWithValue("@totalcollectoperations", _devicestatuscolletions.totalcollectoperations);
				SqlCmd.Parameters.AddWithValue("@totalcollectamount", _devicestatuscolletions.totalcollectamount);
				SqlCmd.Parameters.AddWithValue("@totallocks", _devicestatuscolletions.totallocks);
				SqlCmd.Parameters.AddWithValue("@opentime", _devicestatuscolletions.opentime);
				SqlCmd.Parameters.AddWithValue("@closetime", _devicestatuscolletions.closetime);
				SqlCmd.Parameters.AddWithValue("@vdmstatus", _devicestatuscolletions.vdmstatus);
				SqlCmd.Parameters.AddWithValue("@powerstatus", _devicestatuscolletions.powerstatus);
				SqlCmd.Parameters.AddWithValue("@scannerstatus", _devicestatuscolletions.scannerstatus);
				SqlCmd.Parameters.AddWithValue("@motionsensorstatus", _devicestatuscolletions.motionsensorstatus);
				SqlCmd.Parameters.AddWithValue("@printerstatus", _devicestatuscolletions.printerstatus);
				SqlCmd.Parameters.AddWithValue("@cashacceptorstatus", _devicestatuscolletions.cashacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@cashchangerstatus", _devicestatuscolletions.cashchangerstatus);
				SqlCmd.Parameters.AddWithValue("@coinacceptorstatus", _devicestatuscolletions.coinacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@coinchangerstatus", _devicestatuscolletions.coinchangerstatus);
				SqlCmd.Parameters.AddWithValue("@devicestatusdetail", _devicestatuscolletions.devicestatusdetail);
				SqlCmd.Parameters.AddWithValue("@totalcardsdelivered", _devicestatuscolletions.totalcardsdelivered);
				SqlCmd.Parameters.AddWithValue("@totalcardrefilloperations", _devicestatuscolletions.totalcardrefilloperations);
				SqlCmd.Parameters.AddWithValue("@totalcardrefillamount", _devicestatuscolletions.totalcardrefillamount);
				SqlCmd.Parameters.AddWithValue("@totalcardcollectoperations", _devicestatuscolletions.totalcardcollectoperations);
				SqlCmd.Parameters.AddWithValue("@totalcardcollectamount", _devicestatuscolletions.totalcardcollectamount);
				SqlCmd.Parameters.AddWithValue("@carddispenserstatus", _devicestatuscolletions.carddispenserstatus);
				SqlCmd.Parameters.AddWithValue("@cardreaderstatus", _devicestatuscolletions.cardreaderstatus);
				SqlCmd.Parameters.AddWithValue("@carddispensercount", _devicestatuscolletions.carddispensercount);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar devicestatuscolletions", _state.error.ToString());
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
		public devicestatuscolletions.State Eliminardevicestatuscolletions(devicestatuscolletions.Data _devicestatuscolletions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar devicestatuscolletions", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_devicestatuscolletions_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicestatuscolletions.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar devicestatuscolletions", _state.error.ToString());
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
