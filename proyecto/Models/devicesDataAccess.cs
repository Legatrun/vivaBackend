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
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devices_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devices.Data _devices= new devices.Data();
					_devices.identification = Convert.ToString(rdr["identification"].ToString());
					_devices.description = !rdr.IsDBNull(1) ? Convert.ToString(rdr["description"].ToString()) : "";
					_devices.devicetypeidentification = !rdr.IsDBNull(2) ? Convert.ToString(rdr["devicetypeidentification"].ToString()) : "";
					_devices.enabled = Convert.ToInt32(rdr["enabled"].ToString());
					_devices.createtimestamp = !rdr.IsDBNull(4) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_devices.updatetimestamp = !rdr.IsDBNull(5) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_devices.createuser = !rdr.IsDBNull(6) ? Convert.ToString(rdr["createuser"].ToString()) : "";
					_devices.updateuser = !rdr.IsDBNull(7) ? Convert.ToString(rdr["updateuser"].ToString()) : "";
					_devices.configuration = !rdr.IsDBNull(8) ? Convert.ToString(rdr["configuration"].ToString()) : "";
					_devices.identificationprovider = !rdr.IsDBNull(9) ? Convert.ToString(rdr["identificationprovider"].ToString()) : "";
					_devices.locationidentification = !rdr.IsDBNull(10) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
					_devices.coinacceptordenoms = !rdr.IsDBNull(11) ? Convert.ToString(rdr["coinacceptordenoms"].ToString()) : "";
					_devices.cashacceptordenoms = !rdr.IsDBNull(12) ? Convert.ToString(rdr["cashacceptordenoms"].ToString()) : "";
					_devices.maxamountodispense = !rdr.IsDBNull(13) ? Convert.ToString(rdr["maxamountodispense"].ToString()) : "";
					_devices.maxbillstodispense = !rdr.IsDBNull(14) ? Convert.ToString(rdr["maxbillstodispense"].ToString()) : "";
					_devices.maxcoinstodispense = !rdr.IsDBNull(15) ? Convert.ToString(rdr["maxcoinstodispense"].ToString()) : "";
					_devices.video_intro = !rdr.IsDBNull(16) ? Convert.ToString(rdr["video_intro"].ToString()) : "";
					_devices.video_insert_cash = !rdr.IsDBNull(17) ? Convert.ToString(rdr["video_insert_cash"].ToString()) : "";
					_devices.video_take_cash = !rdr.IsDBNull(18) ? Convert.ToString(rdr["video_take_cash"].ToString()) : "";
					_devices.video_take_cash_chash_receipt = !rdr.IsDBNull(19) ? Convert.ToString(rdr["video_take_cash_chash_receipt"].ToString()) : "";
					_devices.video_read_barcode = !rdr.IsDBNull(20) ? Convert.ToString(rdr["video_read_barcode"].ToString()) : "";
					_devices.payment_success = !rdr.IsDBNull(21) ? Convert.ToString(rdr["payment_success"].ToString()) : "";
					_devices.payment_cancel = !rdr.IsDBNull(22) ? Convert.ToString(rdr["payment_cancel"].ToString()) : "";
					_devices.final_success = !rdr.IsDBNull(23) ? Convert.ToString(rdr["final_success"].ToString()) : "";
					_devices.cashacceptorfullalarm = !rdr.IsDBNull(24) ? Convert.ToString(rdr["cashacceptorfullalarm"].ToString()) : "";
					_devices.cashacceptorfulllimit = !rdr.IsDBNull(25) ? Convert.ToString(rdr["cashacceptorfulllimit"].ToString()) : "";
					_devices.coinacceptorfullalarm = !rdr.IsDBNull(26) ? Convert.ToString(rdr["coinacceptorfullalarm"].ToString()) : "";
					_devices.coinacceptorfulllimit = !rdr.IsDBNull(27) ? Convert.ToString(rdr["coinacceptorfulllimit"].ToString()) : "";
					_devices.cashchangeremptyalarm = !rdr.IsDBNull(28) ? Convert.ToString(rdr["cashchangeremptyalarm"].ToString()) : "";
					_devices.cashchangeremptylimit = !rdr.IsDBNull(29) ? Convert.ToString(rdr["cashchangeremptylimit"].ToString()) : "";
					_devices.cashchangersecuritystock = !rdr.IsDBNull(30) ? Convert.ToString(rdr["cashchangersecuritystock"].ToString()) : "";
					_devices.coinchangeremptyalarm = !rdr.IsDBNull(31) ? Convert.ToString(rdr["coinchangeremptyalarm"].ToString()) : "";
					_devices.coinchangeremptylimit = !rdr.IsDBNull(32) ? Convert.ToString(rdr["coinchangeremptylimit"].ToString()) : "";
					_devices.coinchangersecuritystock = !rdr.IsDBNull(33) ? Convert.ToString(rdr["coinchangersecuritystock"].ToString()) : "";
					_devices.carddispenseremptylimit = !rdr.IsDBNull(34) ? Convert.ToString(rdr["carddispenseremptylimit"].ToString()) : "";
					_devices.carddispenseremptyalarm = !rdr.IsDBNull(35) ? Convert.ToString(rdr["carddispenseremptyalarm"].ToString()) : "";
					_devices.emptydenomblockcondition1 = !rdr.IsDBNull(36) ? Convert.ToString(rdr["emptydenomblockcondition1"].ToString()) : "";
					_devices.emptydenomblockcondition2 = !rdr.IsDBNull(37) ? Convert.ToString(rdr["emptydenomblockcondition2"].ToString()) : "";
					_devices.emptydenomblockcondition3 = !rdr.IsDBNull(38) ? Convert.ToString(rdr["emptydenomblockcondition3"].ToString()) : "";
					_devices.emptydenomblockcondition4 = !rdr.IsDBNull(39) ? Convert.ToString(rdr["emptydenomblockcondition4"].ToString()) : "";
					_devices.totalchangeemptyalarm = !rdr.IsDBNull(40) ? Convert.ToString(rdr["totalchangeemptyalarm"].ToString()) : "";
					_devices.totalchangeemptylimit = !rdr.IsDBNull(41) ? Convert.ToString(rdr["totalchangeemptylimit"].ToString()) : "";
					_devices.scp_statusinterval = !rdr.IsDBNull(42) ? Convert.ToString(rdr["scp_statusinterval"].ToString()) : "";
					_devices.sct_step = !rdr.IsDBNull(43) ? Convert.ToString(rdr["sct_step"].ToString()) : "";
					_devices.sct_changevalidatoramount = !rdr.IsDBNull(44) ? Convert.ToString(rdr["sct_changevalidatoramount"].ToString()) : "";
					_devices.sct_finishscreentimeout = !rdr.IsDBNull(45) ? Convert.ToString(rdr["sct_finishscreentimeout"].ToString()) : "";
					_devices.cashchangerfill = !rdr.IsDBNull(46) ? Convert.ToString(rdr["cashchangerfill"].ToString()) : "";
					_devices.coinchangerfill = !rdr.IsDBNull(47) ? Convert.ToString(rdr["coinchangerfill"].ToString()) : "";
					_devices.coinchangerdenoms = !rdr.IsDBNull(48) ? Convert.ToString(rdr["coinchangerdenoms"].ToString()) : "";
					_devices.cashchangerdenoms = !rdr.IsDBNull(49) ? Convert.ToString(rdr["cashchangerdenoms"].ToString()) : "";
					_devices.lastreporttimestamp = !rdr.IsDBNull(50) ? Convert.ToDateTime(rdr["lastreporttimestamp"].ToString()) : System.DateTime.Now;
					_devices.laststatusreported = !rdr.IsDBNull(51) ? Convert.ToString(rdr["laststatusreported"].ToString()) : "";
					_devices.serviceuser = !rdr.IsDBNull(52) ? Convert.ToString(rdr["serviceuser"].ToString()) : "";
					_devices.operatorcode = !rdr.IsDBNull(53) ? Convert.ToString(rdr["operatorcode"].ToString()) : "";
					lstdevices.Add(_devices);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar devices", _state.error.ToString());
				return new devices(_state, lstdevices);
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
			return new devices(_state);
		}
		public devices Buscardevices(devices.Data _devicesData)
		{
			List<devices.Data> lstdevices = new List<devices.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar devices", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devices_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@pIDENTIFICATION", _devicesData.identification);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devices.Data _devices= new devices.Data();
					_devices.identification = Convert.ToString(rdr["identification"].ToString());
					_devices.description = !rdr.IsDBNull(1) ? Convert.ToString(rdr["description"].ToString()) : "";
					_devices.devicetypeidentification = !rdr.IsDBNull(2) ? Convert.ToString(rdr["devicetypeidentification"].ToString()) : "";
					_devices.enabled = Convert.ToInt32(rdr["enabled"].ToString());
					_devices.createtimestamp = !rdr.IsDBNull(4) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_devices.updatetimestamp = !rdr.IsDBNull(5) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_devices.createuser = !rdr.IsDBNull(6) ? Convert.ToString(rdr["createuser"].ToString()) : "";
					_devices.updateuser = !rdr.IsDBNull(7) ? Convert.ToString(rdr["updateuser"].ToString()) : "";
					_devices.configuration = !rdr.IsDBNull(8) ? Convert.ToString(rdr["configuration"].ToString()) : "";
					_devices.identificationprovider = !rdr.IsDBNull(9) ? Convert.ToString(rdr["identificationprovider"].ToString()) : "";
					_devices.locationidentification = !rdr.IsDBNull(10) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
					_devices.coinacceptordenoms = !rdr.IsDBNull(11) ? Convert.ToString(rdr["coinacceptordenoms"].ToString()) : "";
					_devices.cashacceptordenoms = !rdr.IsDBNull(12) ? Convert.ToString(rdr["cashacceptordenoms"].ToString()) : "";
					_devices.maxamountodispense = !rdr.IsDBNull(13) ? Convert.ToString(rdr["maxamountodispense"].ToString()) : "";
					_devices.maxbillstodispense = !rdr.IsDBNull(14) ? Convert.ToString(rdr["maxbillstodispense"].ToString()) : "";
					_devices.maxcoinstodispense = !rdr.IsDBNull(15) ? Convert.ToString(rdr["maxcoinstodispense"].ToString()) : "";
					_devices.video_intro = !rdr.IsDBNull(16) ? Convert.ToString(rdr["video_intro"].ToString()) : "";
					_devices.video_insert_cash = !rdr.IsDBNull(17) ? Convert.ToString(rdr["video_insert_cash"].ToString()) : "";
					_devices.video_take_cash = !rdr.IsDBNull(18) ? Convert.ToString(rdr["video_take_cash"].ToString()) : "";
					_devices.video_take_cash_chash_receipt = !rdr.IsDBNull(19) ? Convert.ToString(rdr["video_take_cash_chash_receipt"].ToString()) : "";
					_devices.video_read_barcode = !rdr.IsDBNull(20) ? Convert.ToString(rdr["video_read_barcode"].ToString()) : "";
					_devices.payment_success = !rdr.IsDBNull(21) ? Convert.ToString(rdr["payment_success"].ToString()) : "";
					_devices.payment_cancel = !rdr.IsDBNull(22) ? Convert.ToString(rdr["payment_cancel"].ToString()) : "";
					_devices.final_success = !rdr.IsDBNull(23) ? Convert.ToString(rdr["final_success"].ToString()) : "";
					_devices.cashacceptorfullalarm = !rdr.IsDBNull(24) ? Convert.ToString(rdr["cashacceptorfullalarm"].ToString()) : "";
					_devices.cashacceptorfulllimit = !rdr.IsDBNull(25) ? Convert.ToString(rdr["cashacceptorfulllimit"].ToString()) : "";
					_devices.coinacceptorfullalarm = !rdr.IsDBNull(26) ? Convert.ToString(rdr["coinacceptorfullalarm"].ToString()) : "";
					_devices.coinacceptorfulllimit = !rdr.IsDBNull(27) ? Convert.ToString(rdr["coinacceptorfulllimit"].ToString()) : "";
					_devices.cashchangeremptyalarm = !rdr.IsDBNull(28) ? Convert.ToString(rdr["cashchangeremptyalarm"].ToString()) : "";
					_devices.cashchangeremptylimit = !rdr.IsDBNull(29) ? Convert.ToString(rdr["cashchangeremptylimit"].ToString()) : "";
					_devices.cashchangersecuritystock = !rdr.IsDBNull(30) ? Convert.ToString(rdr["cashchangersecuritystock"].ToString()) : "";
					_devices.coinchangeremptyalarm = !rdr.IsDBNull(31) ? Convert.ToString(rdr["coinchangeremptyalarm"].ToString()) : "";
					_devices.coinchangeremptylimit = !rdr.IsDBNull(32) ? Convert.ToString(rdr["coinchangeremptylimit"].ToString()) : "";
					_devices.coinchangersecuritystock = !rdr.IsDBNull(33) ? Convert.ToString(rdr["coinchangersecuritystock"].ToString()) : "";
					_devices.carddispenseremptylimit = !rdr.IsDBNull(34) ? Convert.ToString(rdr["carddispenseremptylimit"].ToString()) : "";
					_devices.carddispenseremptyalarm = !rdr.IsDBNull(35) ? Convert.ToString(rdr["carddispenseremptyalarm"].ToString()) : "";
					_devices.emptydenomblockcondition1 = !rdr.IsDBNull(36) ? Convert.ToString(rdr["emptydenomblockcondition1"].ToString()) : "";
					_devices.emptydenomblockcondition2 = !rdr.IsDBNull(37) ? Convert.ToString(rdr["emptydenomblockcondition2"].ToString()) : "";
					_devices.emptydenomblockcondition3 = !rdr.IsDBNull(38) ? Convert.ToString(rdr["emptydenomblockcondition3"].ToString()) : "";
					_devices.emptydenomblockcondition4 = !rdr.IsDBNull(39) ? Convert.ToString(rdr["emptydenomblockcondition4"].ToString()) : "";
					_devices.totalchangeemptyalarm = !rdr.IsDBNull(40) ? Convert.ToString(rdr["totalchangeemptyalarm"].ToString()) : "";
					_devices.totalchangeemptylimit = !rdr.IsDBNull(41) ? Convert.ToString(rdr["totalchangeemptylimit"].ToString()) : "";
					_devices.scp_statusinterval = !rdr.IsDBNull(42) ? Convert.ToString(rdr["scp_statusinterval"].ToString()) : "";
					_devices.sct_step = !rdr.IsDBNull(43) ? Convert.ToString(rdr["sct_step"].ToString()) : "";
					_devices.sct_changevalidatoramount = !rdr.IsDBNull(44) ? Convert.ToString(rdr["sct_changevalidatoramount"].ToString()) : "";
					_devices.sct_finishscreentimeout = !rdr.IsDBNull(45) ? Convert.ToString(rdr["sct_finishscreentimeout"].ToString()) : "";
					_devices.cashchangerfill = !rdr.IsDBNull(46) ? Convert.ToString(rdr["cashchangerfill"].ToString()) : "";
					_devices.coinchangerfill = !rdr.IsDBNull(47) ? Convert.ToString(rdr["coinchangerfill"].ToString()) : "";
					_devices.coinchangerdenoms = !rdr.IsDBNull(48) ? Convert.ToString(rdr["coinchangerdenoms"].ToString()) : "";
					_devices.cashchangerdenoms = !rdr.IsDBNull(49) ? Convert.ToString(rdr["cashchangerdenoms"].ToString()) : "";
					_devices.lastreporttimestamp = !rdr.IsDBNull(50) ? Convert.ToDateTime(rdr["lastreporttimestamp"].ToString()) : System.DateTime.Now;
					_devices.laststatusreported = !rdr.IsDBNull(51) ? Convert.ToString(rdr["laststatusreported"].ToString()) : "";
					_devices.serviceuser = !rdr.IsDBNull(52) ? Convert.ToString(rdr["serviceuser"].ToString()) : "";
					_devices.operatorcode = !rdr.IsDBNull(53) ? Convert.ToString(rdr["operatorcode"].ToString()) : "";
					lstdevices.Add(_devices);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar devices", _state.error.ToString());
				return new devices(_state, lstdevices);
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
			return new devices(_state);
		}
		public devices.State Insertardevices(devices.Data _devices)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar devices", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devices_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devices.identification);
				SqlCmd.Parameters.AddWithValue("@description", _devices.description);
				SqlCmd.Parameters.AddWithValue("@devicetypeidentification", _devices.devicetypeidentification);
				SqlCmd.Parameters.AddWithValue("@enabled", _devices.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _devices.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devices.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _devices.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _devices.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _devices.configuration);
				SqlCmd.Parameters.AddWithValue("@identificationprovider", _devices.identificationprovider);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _devices.locationidentification);
				SqlCmd.Parameters.AddWithValue("@coinacceptordenoms", _devices.coinacceptordenoms);
				SqlCmd.Parameters.AddWithValue("@cashacceptordenoms", _devices.cashacceptordenoms);
				SqlCmd.Parameters.AddWithValue("@maxamountodispense", _devices.maxamountodispense);
				SqlCmd.Parameters.AddWithValue("@maxbillstodispense", _devices.maxbillstodispense);
				SqlCmd.Parameters.AddWithValue("@maxcoinstodispense", _devices.maxcoinstodispense);
				SqlCmd.Parameters.AddWithValue("@video_intro", _devices.video_intro);
				SqlCmd.Parameters.AddWithValue("@video_insert_cash", _devices.video_insert_cash);
				SqlCmd.Parameters.AddWithValue("@video_take_cash", _devices.video_take_cash);
				SqlCmd.Parameters.AddWithValue("@video_take_cash_chash_receipt", _devices.video_take_cash_chash_receipt);
				SqlCmd.Parameters.AddWithValue("@video_read_barcode", _devices.video_read_barcode);
				SqlCmd.Parameters.AddWithValue("@payment_success", _devices.payment_success);
				SqlCmd.Parameters.AddWithValue("@payment_cancel", _devices.payment_cancel);
				SqlCmd.Parameters.AddWithValue("@final_success", _devices.final_success);
				SqlCmd.Parameters.AddWithValue("@cashacceptorfullalarm", _devices.cashacceptorfullalarm);
				SqlCmd.Parameters.AddWithValue("@cashacceptorfulllimit", _devices.cashacceptorfulllimit);
				SqlCmd.Parameters.AddWithValue("@coinacceptorfullalarm", _devices.coinacceptorfullalarm);
				SqlCmd.Parameters.AddWithValue("@coinacceptorfulllimit", _devices.coinacceptorfulllimit);
				SqlCmd.Parameters.AddWithValue("@cashchangeremptyalarm", _devices.cashchangeremptyalarm);
				SqlCmd.Parameters.AddWithValue("@cashchangeremptylimit", _devices.cashchangeremptylimit);
				SqlCmd.Parameters.AddWithValue("@cashchangersecuritystock", _devices.cashchangersecuritystock);
				SqlCmd.Parameters.AddWithValue("@coinchangeremptyalarm", _devices.coinchangeremptyalarm);
				SqlCmd.Parameters.AddWithValue("@coinchangeremptylimit", _devices.coinchangeremptylimit);
				SqlCmd.Parameters.AddWithValue("@coinchangersecuritystock", _devices.coinchangersecuritystock);
				SqlCmd.Parameters.AddWithValue("@carddispenseremptylimit", _devices.carddispenseremptylimit);
				SqlCmd.Parameters.AddWithValue("@carddispenseremptyalarm", _devices.carddispenseremptyalarm);
				SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition1", _devices.emptydenomblockcondition1);
				SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition2", _devices.emptydenomblockcondition2);
				SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition3", _devices.emptydenomblockcondition3);
				SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition4", _devices.emptydenomblockcondition4);
				SqlCmd.Parameters.AddWithValue("@totalchangeemptyalarm", _devices.totalchangeemptyalarm);
				SqlCmd.Parameters.AddWithValue("@totalchangeemptylimit", _devices.totalchangeemptylimit);
				SqlCmd.Parameters.AddWithValue("@scp_statusinterval", _devices.scp_statusinterval);
				SqlCmd.Parameters.AddWithValue("@sct_step", _devices.sct_step);
				SqlCmd.Parameters.AddWithValue("@sct_changevalidatoramount", _devices.sct_changevalidatoramount);
				SqlCmd.Parameters.AddWithValue("@sct_finishscreentimeout", _devices.sct_finishscreentimeout);
				SqlCmd.Parameters.AddWithValue("@cashchangerfill", _devices.cashchangerfill);
				SqlCmd.Parameters.AddWithValue("@coinchangerfill", _devices.coinchangerfill);
				SqlCmd.Parameters.AddWithValue("@coinchangerdenoms", _devices.coinchangerdenoms);
				SqlCmd.Parameters.AddWithValue("@cashchangerdenoms", _devices.cashchangerdenoms);
				SqlCmd.Parameters.AddWithValue("@lastreporttimestamp", _devices.lastreporttimestamp);
				SqlCmd.Parameters.AddWithValue("@laststatusreported", _devices.laststatusreported);
				SqlCmd.Parameters.AddWithValue("@serviceuser", _devices.serviceuser);
				SqlCmd.Parameters.AddWithValue("@operatorcode", _devices.operatorcode);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar devices", _state.error.ToString());
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
		public devices.State Actualizardevices(devices.Data _devices)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar devices", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devices_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devices.identification);
				SqlCmd.Parameters.AddWithValue("@description", _devices.description);
				SqlCmd.Parameters.AddWithValue("@devicetypeidentification", _devices.devicetypeidentification);
				SqlCmd.Parameters.AddWithValue("@enabled", _devices.enabled);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _devices.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _devices.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@createuser", _devices.createuser);
				SqlCmd.Parameters.AddWithValue("@updateuser", _devices.updateuser);
				SqlCmd.Parameters.AddWithValue("@configuration", _devices.configuration);
				SqlCmd.Parameters.AddWithValue("@identificationprovider", _devices.identificationprovider);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _devices.locationidentification);
				SqlCmd.Parameters.AddWithValue("@coinacceptordenoms", _devices.coinacceptordenoms);
				SqlCmd.Parameters.AddWithValue("@cashacceptordenoms", _devices.cashacceptordenoms);
				SqlCmd.Parameters.AddWithValue("@maxamountodispense", _devices.maxamountodispense);
				SqlCmd.Parameters.AddWithValue("@maxbillstodispense", _devices.maxbillstodispense);
				SqlCmd.Parameters.AddWithValue("@maxcoinstodispense", _devices.maxcoinstodispense);
				SqlCmd.Parameters.AddWithValue("@video_intro", _devices.video_intro);
				SqlCmd.Parameters.AddWithValue("@video_insert_cash", _devices.video_insert_cash);
				SqlCmd.Parameters.AddWithValue("@video_take_cash", _devices.video_take_cash);
				SqlCmd.Parameters.AddWithValue("@video_take_cash_chash_receipt", _devices.video_take_cash_chash_receipt);
				SqlCmd.Parameters.AddWithValue("@video_read_barcode", _devices.video_read_barcode);
				SqlCmd.Parameters.AddWithValue("@payment_success", _devices.payment_success);
				SqlCmd.Parameters.AddWithValue("@payment_cancel", _devices.payment_cancel);
				SqlCmd.Parameters.AddWithValue("@final_success", _devices.final_success);
				SqlCmd.Parameters.AddWithValue("@cashacceptorfullalarm", _devices.cashacceptorfullalarm);
				SqlCmd.Parameters.AddWithValue("@cashacceptorfulllimit", _devices.cashacceptorfulllimit);
				SqlCmd.Parameters.AddWithValue("@coinacceptorfullalarm", _devices.coinacceptorfullalarm);
				SqlCmd.Parameters.AddWithValue("@coinacceptorfulllimit", _devices.coinacceptorfulllimit);
				SqlCmd.Parameters.AddWithValue("@cashchangeremptyalarm", _devices.cashchangeremptyalarm);
				SqlCmd.Parameters.AddWithValue("@cashchangeremptylimit", _devices.cashchangeremptylimit);
				SqlCmd.Parameters.AddWithValue("@cashchangersecuritystock", _devices.cashchangersecuritystock);
				SqlCmd.Parameters.AddWithValue("@coinchangeremptyalarm", _devices.coinchangeremptyalarm);
				SqlCmd.Parameters.AddWithValue("@coinchangeremptylimit", _devices.coinchangeremptylimit);
				SqlCmd.Parameters.AddWithValue("@coinchangersecuritystock", _devices.coinchangersecuritystock);
				SqlCmd.Parameters.AddWithValue("@carddispenseremptylimit", _devices.carddispenseremptylimit);
				SqlCmd.Parameters.AddWithValue("@carddispenseremptyalarm", _devices.carddispenseremptyalarm);
				SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition1", _devices.emptydenomblockcondition1);
				SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition2", _devices.emptydenomblockcondition2);
				SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition3", _devices.emptydenomblockcondition3);
				SqlCmd.Parameters.AddWithValue("@emptydenomblockcondition4", _devices.emptydenomblockcondition4);
				SqlCmd.Parameters.AddWithValue("@totalchangeemptyalarm", _devices.totalchangeemptyalarm);
				SqlCmd.Parameters.AddWithValue("@totalchangeemptylimit", _devices.totalchangeemptylimit);
				SqlCmd.Parameters.AddWithValue("@scp_statusinterval", _devices.scp_statusinterval);
				SqlCmd.Parameters.AddWithValue("@sct_step", _devices.sct_step);
				SqlCmd.Parameters.AddWithValue("@sct_changevalidatoramount", _devices.sct_changevalidatoramount);
				SqlCmd.Parameters.AddWithValue("@sct_finishscreentimeout", _devices.sct_finishscreentimeout);
				SqlCmd.Parameters.AddWithValue("@cashchangerfill", _devices.cashchangerfill);
				SqlCmd.Parameters.AddWithValue("@coinchangerfill", _devices.coinchangerfill);
				SqlCmd.Parameters.AddWithValue("@coinchangerdenoms", _devices.coinchangerdenoms);
				SqlCmd.Parameters.AddWithValue("@cashchangerdenoms", _devices.cashchangerdenoms);
				SqlCmd.Parameters.AddWithValue("@lastreporttimestamp", _devices.lastreporttimestamp);
				SqlCmd.Parameters.AddWithValue("@laststatusreported", _devices.laststatusreported);
				SqlCmd.Parameters.AddWithValue("@serviceuser", _devices.serviceuser);
				SqlCmd.Parameters.AddWithValue("@operatorcode", _devices.operatorcode);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar devices", _state.error.ToString());
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
		public devices.State Eliminardevices(devices.Data _devices)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar devices", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devices_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@identification", _devices.identification);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar devices", _state.error.ToString());
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
