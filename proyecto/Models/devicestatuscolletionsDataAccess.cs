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
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletions_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicestatuscolletions.Data _devicestatuscolletions= new devicestatuscolletions.Data();
					_devicestatuscolletions.id = Convert.ToInt32(rdr["id"].ToString());
					_devicestatuscolletions.createtimestamp = !rdr.IsDBNull(1) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_devicestatuscolletions.updatetimestamp = !rdr.IsDBNull(2) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_devicestatuscolletions.deviceidentification = !rdr.IsDBNull(3) ? Convert.ToString(rdr["deviceidentification"].ToString()) : "";
					_devicestatuscolletions.locationidentification = !rdr.IsDBNull(4) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
					_devicestatuscolletions.servicename = !rdr.IsDBNull(5) ? Convert.ToString(rdr["servicename"].ToString()) : "";
					_devicestatuscolletions.operationname = !rdr.IsDBNull(6) ? Convert.ToString(rdr["operationname"].ToString()) : "";
					_devicestatuscolletions.sequencenumber = !rdr.IsDBNull(7) ? Convert.ToInt32(rdr["sequencenumber"].ToString()) : (System.Int32)0;
					_devicestatuscolletions.transporttimestamp = !rdr.IsDBNull(8) ? Convert.ToDateTime(rdr["transporttimestamp"].ToString()) : System.DateTime.Now;
					_devicestatuscolletions.provideridentification = !rdr.IsDBNull(9) ? Convert.ToString(rdr["provideridentification"].ToString()) : "";
					_devicestatuscolletions.providertransactionid = !rdr.IsDBNull(10) ? Convert.ToString(rdr["providertransactionid"].ToString()) : "";
					_devicestatuscolletions.devicetransactionid = !rdr.IsDBNull(11) ? Convert.ToString(rdr["devicetransactionid"].ToString()) : "";
					_devicestatuscolletions.status = !rdr.IsDBNull(12) ? Convert.ToString(rdr["status"].ToString()) : "";
					_devicestatuscolletions.batchnumber = !rdr.IsDBNull(13) ? Convert.ToInt32(rdr["batchnumber"].ToString()) : (System.Int32)0;
					_devicestatuscolletions.transactionid = !rdr.IsDBNull(14) ? Convert.ToInt32(rdr["transactionid"].ToString()) : (System.Int32)0;
					_devicestatuscolletions.alarm = !rdr.IsDBNull(15) ? Convert.ToString(rdr["alarm"].ToString()) : "";
					_devicestatuscolletions.devicestatus = !rdr.IsDBNull(16) ? Convert.ToInt32(rdr["devicestatus"].ToString()) : (System.Int32)0;
					_devicestatuscolletions.operatingmode = !rdr.IsDBNull(17) ? Convert.ToString(rdr["operatingmode"].ToString()) : "";
					_devicestatuscolletions.alarmid = !rdr.IsDBNull(18) ? Convert.ToString(rdr["alarmid"].ToString()) : "";
					_devicestatuscolletions.aceptordetail = !rdr.IsDBNull(19) ? Convert.ToString(rdr["aceptordetail"].ToString()) : "";
					_devicestatuscolletions.changerdetail = !rdr.IsDBNull(20) ? Convert.ToString(rdr["changerdetail"].ToString()) : "";
					_devicestatuscolletions.returndetail = !rdr.IsDBNull(21) ? Convert.ToString(rdr["returndetail"].ToString()) : "";
					_devicestatuscolletions.operativeday = !rdr.IsDBNull(22) ? Convert.ToString(rdr["operativeday"].ToString()) : "";
					_devicestatuscolletions.totaltx = !rdr.IsDBNull(23) ? Convert.ToString(rdr["totaltx"].ToString()) : "";
					_devicestatuscolletions.totalamount = !rdr.IsDBNull(24) ? Convert.ToString(rdr["totalamount"].ToString()) : "";
					_devicestatuscolletions.totalaccepted = !rdr.IsDBNull(25) ? Convert.ToString(rdr["totalaccepted"].ToString()) : "";
					_devicestatuscolletions.totalreturned = !rdr.IsDBNull(26) ? Convert.ToString(rdr["totalreturned"].ToString()) : "";
					_devicestatuscolletions.totalavailable = !rdr.IsDBNull(27) ? Convert.ToString(rdr["totalavailable"].ToString()) : "";
					_devicestatuscolletions.totalgivenamount = !rdr.IsDBNull(28) ? Convert.ToString(rdr["totalgivenamount"].ToString()) : "";
					_devicestatuscolletions.totaldebtamount = !rdr.IsDBNull(29) ? Convert.ToString(rdr["totaldebtamount"].ToString()) : "";
					_devicestatuscolletions.totalrefilloperations = !rdr.IsDBNull(30) ? Convert.ToString(rdr["totalrefilloperations"].ToString()) : "";
					_devicestatuscolletions.totalrefillamount = !rdr.IsDBNull(31) ? Convert.ToString(rdr["totalrefillamount"].ToString()) : "";
					_devicestatuscolletions.totalcollectoperations = !rdr.IsDBNull(32) ? Convert.ToString(rdr["totalcollectoperations"].ToString()) : "";
					_devicestatuscolletions.totalcollectamount = !rdr.IsDBNull(33) ? Convert.ToString(rdr["totalcollectamount"].ToString()) : "";
					_devicestatuscolletions.totallocks = !rdr.IsDBNull(34) ? Convert.ToString(rdr["totallocks"].ToString()) : "";
					_devicestatuscolletions.opentime = !rdr.IsDBNull(35) ? Convert.ToString(rdr["opentime"].ToString()) : "";
					_devicestatuscolletions.closetime = !rdr.IsDBNull(36) ? Convert.ToString(rdr["closetime"].ToString()) : "";
					_devicestatuscolletions.vdmstatus = !rdr.IsDBNull(37) ? Convert.ToString(rdr["vdmstatus"].ToString()) : "";
					_devicestatuscolletions.powerstatus = !rdr.IsDBNull(38) ? Convert.ToString(rdr["powerstatus"].ToString()) : "";
					_devicestatuscolletions.scannerstatus = !rdr.IsDBNull(39) ? Convert.ToString(rdr["scannerstatus"].ToString()) : "";
					_devicestatuscolletions.motionsensorstatus = !rdr.IsDBNull(40) ? Convert.ToString(rdr["motionsensorstatus"].ToString()) : "";
					_devicestatuscolletions.printerstatus = !rdr.IsDBNull(41) ? Convert.ToString(rdr["printerstatus"].ToString()) : "";
					_devicestatuscolletions.cashacceptorstatus = !rdr.IsDBNull(42) ? Convert.ToString(rdr["cashacceptorstatus"].ToString()) : "";
					_devicestatuscolletions.cashchangerstatus = !rdr.IsDBNull(43) ? Convert.ToString(rdr["cashchangerstatus"].ToString()) : "";
					_devicestatuscolletions.coinacceptorstatus = !rdr.IsDBNull(44) ? Convert.ToString(rdr["coinacceptorstatus"].ToString()) : "";
					_devicestatuscolletions.coinchangerstatus = !rdr.IsDBNull(45) ? Convert.ToString(rdr["coinchangerstatus"].ToString()) : "";
					_devicestatuscolletions.devicestatusdetail = !rdr.IsDBNull(46) ? Convert.ToString(rdr["devicestatusdetail"].ToString()) : "";
					_devicestatuscolletions.totalcardsdelivered = !rdr.IsDBNull(47) ? Convert.ToString(rdr["totalcardsdelivered"].ToString()) : "";
					_devicestatuscolletions.totalcardrefilloperations = !rdr.IsDBNull(48) ? Convert.ToString(rdr["totalcardrefilloperations"].ToString()) : "";
					_devicestatuscolletions.totalcardrefillamount = !rdr.IsDBNull(49) ? Convert.ToString(rdr["totalcardrefillamount"].ToString()) : "";
					_devicestatuscolletions.totalcardcollectoperations = !rdr.IsDBNull(50) ? Convert.ToString(rdr["totalcardcollectoperations"].ToString()) : "";
					_devicestatuscolletions.totalcardcollectamount = !rdr.IsDBNull(51) ? Convert.ToString(rdr["totalcardcollectamount"].ToString()) : "";
					_devicestatuscolletions.carddispenserstatus = !rdr.IsDBNull(52) ? Convert.ToString(rdr["carddispenserstatus"].ToString()) : "";
					_devicestatuscolletions.cardreaderstatus = !rdr.IsDBNull(53) ? Convert.ToString(rdr["cardreaderstatus"].ToString()) : "";
					_devicestatuscolletions.carddispensercount = !rdr.IsDBNull(54) ? Convert.ToString(rdr["carddispensercount"].ToString()) : "";
					lstdevicestatuscolletions.Add(_devicestatuscolletions);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar devicestatuscolletions", _state.error.ToString());
				return new devicestatuscolletions(_state, lstdevicestatuscolletions);
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
			return new devicestatuscolletions(_state);
		}
		public devicestatuscolletions Buscardevicestatuscolletions(devicestatuscolletions.Data _devicestatuscolletionsData)
		{
			List<devicestatuscolletions.Data> lstdevicestatuscolletions = new List<devicestatuscolletions.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar devicestatuscolletions", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletions_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@pID", _devicestatuscolletionsData.id);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					devicestatuscolletions.Data _devicestatuscolletions= new devicestatuscolletions.Data();
					_devicestatuscolletions.id = Convert.ToInt32(rdr["id"].ToString());
					_devicestatuscolletions.createtimestamp = !rdr.IsDBNull(1) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_devicestatuscolletions.updatetimestamp = !rdr.IsDBNull(2) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_devicestatuscolletions.deviceidentification = !rdr.IsDBNull(3) ? Convert.ToString(rdr["deviceidentification"].ToString()) : "";
					_devicestatuscolletions.locationidentification = !rdr.IsDBNull(4) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
					_devicestatuscolletions.servicename = !rdr.IsDBNull(5) ? Convert.ToString(rdr["servicename"].ToString()) : "";
					_devicestatuscolletions.operationname = !rdr.IsDBNull(6) ? Convert.ToString(rdr["operationname"].ToString()) : "";
					_devicestatuscolletions.sequencenumber = !rdr.IsDBNull(7) ? Convert.ToInt32(rdr["sequencenumber"].ToString()) : (System.Int32)0;
					_devicestatuscolletions.transporttimestamp = !rdr.IsDBNull(8) ? Convert.ToDateTime(rdr["transporttimestamp"].ToString()) : System.DateTime.Now;
					_devicestatuscolletions.provideridentification = !rdr.IsDBNull(9) ? Convert.ToString(rdr["provideridentification"].ToString()) : "";
					_devicestatuscolletions.providertransactionid = !rdr.IsDBNull(10) ? Convert.ToString(rdr["providertransactionid"].ToString()) : "";
					_devicestatuscolletions.devicetransactionid = !rdr.IsDBNull(11) ? Convert.ToString(rdr["devicetransactionid"].ToString()) : "";
					_devicestatuscolletions.status = !rdr.IsDBNull(12) ? Convert.ToString(rdr["status"].ToString()) : "";
					_devicestatuscolletions.batchnumber = !rdr.IsDBNull(13) ? Convert.ToInt32(rdr["batchnumber"].ToString()) : (System.Int32)0;
					_devicestatuscolletions.transactionid = !rdr.IsDBNull(14) ? Convert.ToInt32(rdr["transactionid"].ToString()) : (System.Int32)0;
					_devicestatuscolletions.alarm = !rdr.IsDBNull(15) ? Convert.ToString(rdr["alarm"].ToString()) : "";
					_devicestatuscolletions.devicestatus = !rdr.IsDBNull(16) ? Convert.ToInt32(rdr["devicestatus"].ToString()) : (System.Int32)0;
					_devicestatuscolletions.operatingmode = !rdr.IsDBNull(17) ? Convert.ToString(rdr["operatingmode"].ToString()) : "";
					_devicestatuscolletions.alarmid = !rdr.IsDBNull(18) ? Convert.ToString(rdr["alarmid"].ToString()) : "";
					_devicestatuscolletions.aceptordetail = !rdr.IsDBNull(19) ? Convert.ToString(rdr["aceptordetail"].ToString()) : "";
					_devicestatuscolletions.changerdetail = !rdr.IsDBNull(20) ? Convert.ToString(rdr["changerdetail"].ToString()) : "";
					_devicestatuscolletions.returndetail = !rdr.IsDBNull(21) ? Convert.ToString(rdr["returndetail"].ToString()) : "";
					_devicestatuscolletions.operativeday = !rdr.IsDBNull(22) ? Convert.ToString(rdr["operativeday"].ToString()) : "";
					_devicestatuscolletions.totaltx = !rdr.IsDBNull(23) ? Convert.ToString(rdr["totaltx"].ToString()) : "";
					_devicestatuscolletions.totalamount = !rdr.IsDBNull(24) ? Convert.ToString(rdr["totalamount"].ToString()) : "";
					_devicestatuscolletions.totalaccepted = !rdr.IsDBNull(25) ? Convert.ToString(rdr["totalaccepted"].ToString()) : "";
					_devicestatuscolletions.totalreturned = !rdr.IsDBNull(26) ? Convert.ToString(rdr["totalreturned"].ToString()) : "";
					_devicestatuscolletions.totalavailable = !rdr.IsDBNull(27) ? Convert.ToString(rdr["totalavailable"].ToString()) : "";
					_devicestatuscolletions.totalgivenamount = !rdr.IsDBNull(28) ? Convert.ToString(rdr["totalgivenamount"].ToString()) : "";
					_devicestatuscolletions.totaldebtamount = !rdr.IsDBNull(29) ? Convert.ToString(rdr["totaldebtamount"].ToString()) : "";
					_devicestatuscolletions.totalrefilloperations = !rdr.IsDBNull(30) ? Convert.ToString(rdr["totalrefilloperations"].ToString()) : "";
					_devicestatuscolletions.totalrefillamount = !rdr.IsDBNull(31) ? Convert.ToString(rdr["totalrefillamount"].ToString()) : "";
					_devicestatuscolletions.totalcollectoperations = !rdr.IsDBNull(32) ? Convert.ToString(rdr["totalcollectoperations"].ToString()) : "";
					_devicestatuscolletions.totalcollectamount = !rdr.IsDBNull(33) ? Convert.ToString(rdr["totalcollectamount"].ToString()) : "";
					_devicestatuscolletions.totallocks = !rdr.IsDBNull(34) ? Convert.ToString(rdr["totallocks"].ToString()) : "";
					_devicestatuscolletions.opentime = !rdr.IsDBNull(35) ? Convert.ToString(rdr["opentime"].ToString()) : "";
					_devicestatuscolletions.closetime = !rdr.IsDBNull(36) ? Convert.ToString(rdr["closetime"].ToString()) : "";
					_devicestatuscolletions.vdmstatus = !rdr.IsDBNull(37) ? Convert.ToString(rdr["vdmstatus"].ToString()) : "";
					_devicestatuscolletions.powerstatus = !rdr.IsDBNull(38) ? Convert.ToString(rdr["powerstatus"].ToString()) : "";
					_devicestatuscolletions.scannerstatus = !rdr.IsDBNull(39) ? Convert.ToString(rdr["scannerstatus"].ToString()) : "";
					_devicestatuscolletions.motionsensorstatus = !rdr.IsDBNull(40) ? Convert.ToString(rdr["motionsensorstatus"].ToString()) : "";
					_devicestatuscolletions.printerstatus = !rdr.IsDBNull(41) ? Convert.ToString(rdr["printerstatus"].ToString()) : "";
					_devicestatuscolletions.cashacceptorstatus = !rdr.IsDBNull(42) ? Convert.ToString(rdr["cashacceptorstatus"].ToString()) : "";
					_devicestatuscolletions.cashchangerstatus = !rdr.IsDBNull(43) ? Convert.ToString(rdr["cashchangerstatus"].ToString()) : "";
					_devicestatuscolletions.coinacceptorstatus = !rdr.IsDBNull(44) ? Convert.ToString(rdr["coinacceptorstatus"].ToString()) : "";
					_devicestatuscolletions.coinchangerstatus = !rdr.IsDBNull(45) ? Convert.ToString(rdr["coinchangerstatus"].ToString()) : "";
					_devicestatuscolletions.devicestatusdetail = !rdr.IsDBNull(46) ? Convert.ToString(rdr["devicestatusdetail"].ToString()) : "";
					_devicestatuscolletions.totalcardsdelivered = !rdr.IsDBNull(47) ? Convert.ToString(rdr["totalcardsdelivered"].ToString()) : "";
					_devicestatuscolletions.totalcardrefilloperations = !rdr.IsDBNull(48) ? Convert.ToString(rdr["totalcardrefilloperations"].ToString()) : "";
					_devicestatuscolletions.totalcardrefillamount = !rdr.IsDBNull(49) ? Convert.ToString(rdr["totalcardrefillamount"].ToString()) : "";
					_devicestatuscolletions.totalcardcollectoperations = !rdr.IsDBNull(50) ? Convert.ToString(rdr["totalcardcollectoperations"].ToString()) : "";
					_devicestatuscolletions.totalcardcollectamount = !rdr.IsDBNull(51) ? Convert.ToString(rdr["totalcardcollectamount"].ToString()) : "";
					_devicestatuscolletions.carddispenserstatus = !rdr.IsDBNull(52) ? Convert.ToString(rdr["carddispenserstatus"].ToString()) : "";
					_devicestatuscolletions.cardreaderstatus = !rdr.IsDBNull(53) ? Convert.ToString(rdr["cardreaderstatus"].ToString()) : "";
					_devicestatuscolletions.carddispensercount = !rdr.IsDBNull(54) ? Convert.ToString(rdr["carddispensercount"].ToString()) : "";
					lstdevicestatuscolletions.Add(_devicestatuscolletions);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar devicestatuscolletions", _state.error.ToString());
				return new devicestatuscolletions(_state, lstdevicestatuscolletions);
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
			return new devicestatuscolletions(_state);
		}
		public devicestatuscolletions.State Insertardevicestatuscolletions(devicestatuscolletions.Data _devicestatuscolletions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar devicestatuscolletions", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletions_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlParameter pID = new MySqlParameter();
				pID.ParameterName = "@ID";
				pID.Value = 0;
				SqlCmd.Parameters.Add(pID);
				pID.Direction = System.Data.ParameterDirection.Output;
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
				_devicestatuscolletions.id = (System.Int32)pID.Value;
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar devicestatuscolletions", _state.error.ToString());
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
		public devicestatuscolletions.State Actualizardevicestatuscolletions(devicestatuscolletions.Data _devicestatuscolletions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar devicestatuscolletions", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletions_Update", SqlCnn);
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
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar devicestatuscolletions", _state.error.ToString());
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
		public devicestatuscolletions.State Eliminardevicestatuscolletions(devicestatuscolletions.Data _devicestatuscolletions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar devicestatuscolletions", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_devicestatuscolletions_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _devicestatuscolletions.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar devicestatuscolletions", _state.error.ToString());
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
