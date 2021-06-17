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
	public class devicestatuscolletionsresumeDataAccess
	{
		devicestatuscolletionsresume.State _state = new devicestatuscolletionsresume.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public devicestatuscolletionsresume Consultardevicestatuscolletionsresume()
		{
		    _log.Traceo("Ingresa a Metodo Consultar devicestatuscolletionsresume", "0");
			List<devicestatuscolletionsresume.Data> lstdevicestatuscolletionsresume = new List<devicestatuscolletionsresume.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletionsresume_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicestatuscolletionsresume.Data _devicestatuscolletionsresume= new devicestatuscolletionsresume.Data();
					_devicestatuscolletionsresume.id = Convert.ToInt32(rdr["id"].ToString());
					_devicestatuscolletionsresume.createtimestamp = Convert.ToDateTime(rdr["createtimestamp"].ToString());
					_devicestatuscolletionsresume.locationidentification = Convert.ToString(rdr["locationidentification"].ToString());
					_devicestatuscolletionsresume.deviceidentification = Convert.ToString(rdr["deviceidentification"].ToString());
					_devicestatuscolletionsresume.alarm = Convert.ToString(rdr["alarm"].ToString());
					_devicestatuscolletionsresume.devicestatus = Convert.ToInt32(rdr["devicestatus"].ToString());
					_devicestatuscolletionsresume.devicestatusdetail = Convert.ToString(rdr["devicestatusdetail"].ToString());
					_devicestatuscolletionsresume.operatingmode = Convert.ToString(rdr["operatingmode"].ToString());
					_devicestatuscolletionsresume.operationname = Convert.ToString(rdr["operationname"].ToString());

                    lstdevicestatuscolletionsresume.Add(_devicestatuscolletionsresume);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar devicestatuscolletionsresume", _state.error.ToString());
				return new devicestatuscolletionsresume(_state, lstdevicestatuscolletionsresume);
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
			return new devicestatuscolletionsresume(_state);
		}
        public devicestatuscolletionsresume Consultardevicestatuscolletionsresumeprovider()
        {
            _log.Traceo("Ingresa a Metodo Consultar Consultardevicestatuscolletionsresumeprovider", "0");
            List<devicestatuscolletionsresume.Data> lstdevicestatuscolletionsresume = new List<devicestatuscolletionsresume.Data>();
            try
            {
                MySqlConnection SqlCnn;
                SqlCnn = Base.AbrirConexionMySql();
                MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletionsresumeprovider_Select", SqlCnn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader rdr = SqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    devicestatuscolletionsresume.Data _devicestatuscolletionsresume = new devicestatuscolletionsresume.Data();
                    _devicestatuscolletionsresume.locationidentification = Convert.ToString(rdr["locationidentification"].ToString());
                    _devicestatuscolletionsresume.deviceidentification = Convert.ToString(rdr["deviceidentification"].ToString());
                    _devicestatuscolletionsresume.createtimestamp = Convert.ToDateTime(rdr["createtimestamp"].ToString());
                    _devicestatuscolletionsresume.alarm = Convert.ToString(rdr["alarm"].ToString());
                    _devicestatuscolletionsresume.devicestatus = Convert.ToInt32(rdr["devicestatus"].ToString());
                    _devicestatuscolletionsresume.devicestatusdetail = Convert.ToString(rdr["devicestatusdetail"].ToString());
                    _devicestatuscolletionsresume.operatingmode = Convert.ToString(rdr["operatingmode"].ToString());
                    _devicestatuscolletionsresume.operationname = Convert.ToString(rdr["operationname"].ToString());

                    lstdevicestatuscolletionsresume.Add(_devicestatuscolletionsresume);
                }
                Base.CerrarConexionMySql(SqlCnn);
                _state.error = 0;
                _state.descripcion = "Operacion Realizada";
                _log.Traceo(_state.descripcion + " Operacion Consultar Consultardevicestatuscolletionsresumeprovider", _state.error.ToString());
                return new devicestatuscolletionsresume(_state, lstdevicestatuscolletionsresume);
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
            return new devicestatuscolletionsresume(_state);
        }

        public devicestatuscolletionsresume Buscardevicestatuscolletionsresume(devicestatuscolletionsresume.Data _devicestatuscolletionsresumeData)
		{
			List<devicestatuscolletionsresume.Data> lstdevicestatuscolletionsresume = new List<devicestatuscolletionsresume.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar devicestatuscolletionsresume", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletionsresume_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicestatuscolletionsresumeData.id);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicestatuscolletionsresume.Data _devicestatuscolletionsresume= new devicestatuscolletionsresume.Data();
					_devicestatuscolletionsresume.id = Convert.ToInt32(rdr["id"].ToString());
					lstdevicestatuscolletionsresume.Add(_devicestatuscolletionsresume);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar devicestatuscolletionsresume", _state.error.ToString());
				return new devicestatuscolletionsresume(_state, lstdevicestatuscolletionsresume);
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
			return new devicestatuscolletionsresume(_state);
		}
		public devicestatuscolletionsresume.State Insertardevicestatuscolletionsresume(devicestatuscolletionsresume.Data _devicestatuscolletionsresume)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar devicestatuscolletionsresume", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletionsresume_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicestatuscolletionsresume.id);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _devicestatuscolletionsresume.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devicestatuscolletionsresume.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _devicestatuscolletionsresume.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _devicestatuscolletionsresume.locationidentification);
				SqlCmd.Parameters.AddWithValue("@servicename", _devicestatuscolletionsresume.servicename);
				SqlCmd.Parameters.AddWithValue("@operationname", _devicestatuscolletionsresume.operationname);
				SqlCmd.Parameters.AddWithValue("@sequencenumber", _devicestatuscolletionsresume.sequencenumber);
				SqlCmd.Parameters.AddWithValue("@transporttimestamp", _devicestatuscolletionsresume.transporttimestamp);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _devicestatuscolletionsresume.provideridentification);
				SqlCmd.Parameters.AddWithValue("@providertransactionid", _devicestatuscolletionsresume.providertransactionid);
				SqlCmd.Parameters.AddWithValue("@devicetransactionid", _devicestatuscolletionsresume.devicetransactionid);
				SqlCmd.Parameters.AddWithValue("@batchnumber", _devicestatuscolletionsresume.batchnumber);
				SqlCmd.Parameters.AddWithValue("@transactionid", _devicestatuscolletionsresume.transactionid);
				SqlCmd.Parameters.AddWithValue("@alarm", _devicestatuscolletionsresume.alarm);
				SqlCmd.Parameters.AddWithValue("@devicestatus", _devicestatuscolletionsresume.devicestatus);
				SqlCmd.Parameters.AddWithValue("@operatingmode", _devicestatuscolletionsresume.operatingmode);
				SqlCmd.Parameters.AddWithValue("@alarmid", _devicestatuscolletionsresume.alarmid);
				SqlCmd.Parameters.AddWithValue("@aceptordetail", _devicestatuscolletionsresume.aceptordetail);
				SqlCmd.Parameters.AddWithValue("@changerdetail", _devicestatuscolletionsresume.changerdetail);
				SqlCmd.Parameters.AddWithValue("@returndetail", _devicestatuscolletionsresume.returndetail);
				SqlCmd.Parameters.AddWithValue("@operativeday", _devicestatuscolletionsresume.operativeday);
				SqlCmd.Parameters.AddWithValue("@totaltx", _devicestatuscolletionsresume.totaltx);
				SqlCmd.Parameters.AddWithValue("@totalamount", _devicestatuscolletionsresume.totalamount);
				SqlCmd.Parameters.AddWithValue("@totalaccepted", _devicestatuscolletionsresume.totalaccepted);
				SqlCmd.Parameters.AddWithValue("@totalreturned", _devicestatuscolletionsresume.totalreturned);
				SqlCmd.Parameters.AddWithValue("@totalavailable", _devicestatuscolletionsresume.totalavailable);
				SqlCmd.Parameters.AddWithValue("@totalgivenamount", _devicestatuscolletionsresume.totalgivenamount);
				SqlCmd.Parameters.AddWithValue("@totaldebtamount", _devicestatuscolletionsresume.totaldebtamount);
				SqlCmd.Parameters.AddWithValue("@totalrefilloperations", _devicestatuscolletionsresume.totalrefilloperations);
				SqlCmd.Parameters.AddWithValue("@totalrefillamount", _devicestatuscolletionsresume.totalrefillamount);
				SqlCmd.Parameters.AddWithValue("@totalcollectoperations", _devicestatuscolletionsresume.totalcollectoperations);
				SqlCmd.Parameters.AddWithValue("@totalcollectamount", _devicestatuscolletionsresume.totalcollectamount);
				SqlCmd.Parameters.AddWithValue("@totallocks", _devicestatuscolletionsresume.totallocks);
				SqlCmd.Parameters.AddWithValue("@opentime", _devicestatuscolletionsresume.opentime);
				SqlCmd.Parameters.AddWithValue("@closetime", _devicestatuscolletionsresume.closetime);
				SqlCmd.Parameters.AddWithValue("@vdmstatus", _devicestatuscolletionsresume.vdmstatus);
				SqlCmd.Parameters.AddWithValue("@powerstatus", _devicestatuscolletionsresume.powerstatus);
				SqlCmd.Parameters.AddWithValue("@scannerstatus", _devicestatuscolletionsresume.scannerstatus);
				SqlCmd.Parameters.AddWithValue("@motionsensorstatus", _devicestatuscolletionsresume.motionsensorstatus);
				SqlCmd.Parameters.AddWithValue("@printerstatus", _devicestatuscolletionsresume.printerstatus);
				SqlCmd.Parameters.AddWithValue("@cashacceptorstatus", _devicestatuscolletionsresume.cashacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@cashchangerstatus", _devicestatuscolletionsresume.cashchangerstatus);
				SqlCmd.Parameters.AddWithValue("@coinacceptorstatus", _devicestatuscolletionsresume.coinacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@coinchangerstatus", _devicestatuscolletionsresume.coinchangerstatus);
				SqlCmd.Parameters.AddWithValue("@devicestatusdetail", _devicestatuscolletionsresume.devicestatusdetail);
				SqlCmd.Parameters.AddWithValue("@processid", _devicestatuscolletionsresume.processid);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar devicestatuscolletionsresume", _state.error.ToString());
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
		public devicestatuscolletionsresume.State Actualizardevicestatuscolletionsresume(devicestatuscolletionsresume.Data _devicestatuscolletionsresume)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar devicestatuscolletionsresume", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletionsresume_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicestatuscolletionsresume.id);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _devicestatuscolletionsresume.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devicestatuscolletionsresume.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _devicestatuscolletionsresume.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _devicestatuscolletionsresume.locationidentification);
				SqlCmd.Parameters.AddWithValue("@servicename", _devicestatuscolletionsresume.servicename);
				SqlCmd.Parameters.AddWithValue("@operationname", _devicestatuscolletionsresume.operationname);
				SqlCmd.Parameters.AddWithValue("@sequencenumber", _devicestatuscolletionsresume.sequencenumber);
				SqlCmd.Parameters.AddWithValue("@transporttimestamp", _devicestatuscolletionsresume.transporttimestamp);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _devicestatuscolletionsresume.provideridentification);
				SqlCmd.Parameters.AddWithValue("@providertransactionid", _devicestatuscolletionsresume.providertransactionid);
				SqlCmd.Parameters.AddWithValue("@devicetransactionid", _devicestatuscolletionsresume.devicetransactionid);
				SqlCmd.Parameters.AddWithValue("@batchnumber", _devicestatuscolletionsresume.batchnumber);
				SqlCmd.Parameters.AddWithValue("@transactionid", _devicestatuscolletionsresume.transactionid);
				SqlCmd.Parameters.AddWithValue("@alarm", _devicestatuscolletionsresume.alarm);
				SqlCmd.Parameters.AddWithValue("@devicestatus", _devicestatuscolletionsresume.devicestatus);
				SqlCmd.Parameters.AddWithValue("@operatingmode", _devicestatuscolletionsresume.operatingmode);
				SqlCmd.Parameters.AddWithValue("@alarmid", _devicestatuscolletionsresume.alarmid);
				SqlCmd.Parameters.AddWithValue("@aceptordetail", _devicestatuscolletionsresume.aceptordetail);
				SqlCmd.Parameters.AddWithValue("@changerdetail", _devicestatuscolletionsresume.changerdetail);
				SqlCmd.Parameters.AddWithValue("@returndetail", _devicestatuscolletionsresume.returndetail);
				SqlCmd.Parameters.AddWithValue("@operativeday", _devicestatuscolletionsresume.operativeday);
				SqlCmd.Parameters.AddWithValue("@totaltx", _devicestatuscolletionsresume.totaltx);
				SqlCmd.Parameters.AddWithValue("@totalamount", _devicestatuscolletionsresume.totalamount);
				SqlCmd.Parameters.AddWithValue("@totalaccepted", _devicestatuscolletionsresume.totalaccepted);
				SqlCmd.Parameters.AddWithValue("@totalreturned", _devicestatuscolletionsresume.totalreturned);
				SqlCmd.Parameters.AddWithValue("@totalavailable", _devicestatuscolletionsresume.totalavailable);
				SqlCmd.Parameters.AddWithValue("@totalgivenamount", _devicestatuscolletionsresume.totalgivenamount);
				SqlCmd.Parameters.AddWithValue("@totaldebtamount", _devicestatuscolletionsresume.totaldebtamount);
				SqlCmd.Parameters.AddWithValue("@totalrefilloperations", _devicestatuscolletionsresume.totalrefilloperations);
				SqlCmd.Parameters.AddWithValue("@totalrefillamount", _devicestatuscolletionsresume.totalrefillamount);
				SqlCmd.Parameters.AddWithValue("@totalcollectoperations", _devicestatuscolletionsresume.totalcollectoperations);
				SqlCmd.Parameters.AddWithValue("@totalcollectamount", _devicestatuscolletionsresume.totalcollectamount);
				SqlCmd.Parameters.AddWithValue("@totallocks", _devicestatuscolletionsresume.totallocks);
				SqlCmd.Parameters.AddWithValue("@opentime", _devicestatuscolletionsresume.opentime);
				SqlCmd.Parameters.AddWithValue("@closetime", _devicestatuscolletionsresume.closetime);
				SqlCmd.Parameters.AddWithValue("@vdmstatus", _devicestatuscolletionsresume.vdmstatus);
				SqlCmd.Parameters.AddWithValue("@powerstatus", _devicestatuscolletionsresume.powerstatus);
				SqlCmd.Parameters.AddWithValue("@scannerstatus", _devicestatuscolletionsresume.scannerstatus);
				SqlCmd.Parameters.AddWithValue("@motionsensorstatus", _devicestatuscolletionsresume.motionsensorstatus);
				SqlCmd.Parameters.AddWithValue("@printerstatus", _devicestatuscolletionsresume.printerstatus);
				SqlCmd.Parameters.AddWithValue("@cashacceptorstatus", _devicestatuscolletionsresume.cashacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@cashchangerstatus", _devicestatuscolletionsresume.cashchangerstatus);
				SqlCmd.Parameters.AddWithValue("@coinacceptorstatus", _devicestatuscolletionsresume.coinacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@coinchangerstatus", _devicestatuscolletionsresume.coinchangerstatus);
				SqlCmd.Parameters.AddWithValue("@devicestatusdetail", _devicestatuscolletionsresume.devicestatusdetail);
				SqlCmd.Parameters.AddWithValue("@processid", _devicestatuscolletionsresume.processid);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar devicestatuscolletionsresume", _state.error.ToString());
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
		public devicestatuscolletionsresume.State Eliminardevicestatuscolletionsresume(devicestatuscolletionsresume.Data _devicestatuscolletionsresume)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar devicestatuscolletionsresume", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletionsresume_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicestatuscolletionsresume.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar devicestatuscolletionsresume", _state.error.ToString());
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
