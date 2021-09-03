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
	public class batchesDataAccess
	{
		batches.State _state = new batches.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public batches Consultarbatches()
		{
		    _log.Traceo("Ingresa a Metodo Consultar batches", "0");
			List<batches.Data> lstbatches = new List<batches.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_batches_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					batches.Data _batches= new batches.Data();
					_batches.id = Convert.ToInt32(rdr["id"].ToString());
					_batches.createtimestamp = !rdr.IsDBNull(1) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_batches.updatetimestamp = !rdr.IsDBNull(2) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_batches.deviceidentification = !rdr.IsDBNull(3) ? Convert.ToString(rdr["deviceidentification"].ToString()) : "";
					_batches.locationidentification = !rdr.IsDBNull(4) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
					_batches.payloadrequest = !rdr.IsDBNull(5) ? Convert.ToString(rdr["payloadrequest"].ToString()) : "";
					_batches.provideridentification = !rdr.IsDBNull(6) ? Convert.ToString(rdr["provideridentification"].ToString()) : "";
					_batches.devicestatus = !rdr.IsDBNull(7) ? Convert.ToString(rdr["devicestatus"].ToString()) : "";
					_batches.number_ = !rdr.IsDBNull(8) ? Convert.ToInt32(rdr["number_"].ToString()) : (System.Int32)0;
					_batches.status = Convert.ToInt32(rdr["status"].ToString());
					_batches.opentimestamp = !rdr.IsDBNull(10) ? Convert.ToDateTime(rdr["opentimestamp"].ToString()) : System.DateTime.Now;
					_batches.closetimestamp = !rdr.IsDBNull(11) ? Convert.ToDateTime(rdr["closetimestamp"].ToString()) : System.DateTime.Now;
					_batches.syncstatus = !rdr.IsDBNull(12) ? Convert.ToInt32(rdr["syncstatus"].ToString()) : (System.Int32)0;
					_batches.synctimestamp = !rdr.IsDBNull(13) ? Convert.ToDateTime(rdr["synctimestamp"].ToString()) : System.DateTime.Now;
					_batches.operativeday = !rdr.IsDBNull(14) ? Convert.ToString(rdr["operativeday"].ToString()) : "";
					_batches.totaltx = !rdr.IsDBNull(15) ? Convert.ToString(rdr["totaltx"].ToString()) : "";
					_batches.totalamount = !rdr.IsDBNull(16) ? Convert.ToString(rdr["totalamount"].ToString()) : "";
					_batches.totalaccepted = !rdr.IsDBNull(17) ? Convert.ToString(rdr["totalaccepted"].ToString()) : "";
					_batches.totalreturned = !rdr.IsDBNull(18) ? Convert.ToString(rdr["totalreturned"].ToString()) : "";
					_batches.totalavailable = !rdr.IsDBNull(19) ? Convert.ToString(rdr["totalavailable"].ToString()) : "";
					_batches.totalgivenamount = !rdr.IsDBNull(20) ? Convert.ToString(rdr["totalgivenamount"].ToString()) : "";
					_batches.totaldebtamount = !rdr.IsDBNull(21) ? Convert.ToString(rdr["totaldebtamount"].ToString()) : "";
					_batches.totalrefilloperations = !rdr.IsDBNull(22) ? Convert.ToString(rdr["totalrefilloperations"].ToString()) : "";
					_batches.totalrefillamount = !rdr.IsDBNull(23) ? Convert.ToString(rdr["totalrefillamount"].ToString()) : "";
					_batches.totalcollectoperations = !rdr.IsDBNull(24) ? Convert.ToString(rdr["totalcollectoperations"].ToString()) : "";
					_batches.totalcollectamount = !rdr.IsDBNull(25) ? Convert.ToString(rdr["totalcollectamount"].ToString()) : "";
					_batches.totalcardsdelivered = !rdr.IsDBNull(26) ? Convert.ToString(rdr["totalcardsdelivered"].ToString()) : "";
					_batches.totalcardrefilloperations = !rdr.IsDBNull(27) ? Convert.ToString(rdr["totalcardrefilloperations"].ToString()) : "";
					_batches.totalcardrefillamount = !rdr.IsDBNull(28) ? Convert.ToString(rdr["totalcardrefillamount"].ToString()) : "";
					_batches.totalcardcollectoperations = !rdr.IsDBNull(29) ? Convert.ToString(rdr["totalcardcollectoperations"].ToString()) : "";
					_batches.totalcardcollectamount = !rdr.IsDBNull(30) ? Convert.ToString(rdr["totalcardcollectamount"].ToString()) : "";
					_batches.carddispenserstatus = !rdr.IsDBNull(31) ? Convert.ToString(rdr["carddispenserstatus"].ToString()) : "";
					_batches.totallocks = !rdr.IsDBNull(32) ? Convert.ToString(rdr["totallocks"].ToString()) : "";
					_batches.opentime = !rdr.IsDBNull(33) ? Convert.ToString(rdr["opentime"].ToString()) : "";
					_batches.closetime = !rdr.IsDBNull(34) ? Convert.ToString(rdr["closetime"].ToString()) : "";
					_batches.scannerstatus = !rdr.IsDBNull(35) ? Convert.ToString(rdr["scannerstatus"].ToString()) : "";
					_batches.motionsensorstatus = !rdr.IsDBNull(36) ? Convert.ToString(rdr["motionsensorstatus"].ToString()) : "";
					_batches.printerstatus = !rdr.IsDBNull(37) ? Convert.ToString(rdr["printerstatus"].ToString()) : "";
					_batches.cashacceptorstatus = !rdr.IsDBNull(38) ? Convert.ToString(rdr["cashacceptorstatus"].ToString()) : "";
					_batches.cashchangerstatus = !rdr.IsDBNull(39) ? Convert.ToString(rdr["cashchangerstatus"].ToString()) : "";
					_batches.coinacceptorstatus = !rdr.IsDBNull(40) ? Convert.ToString(rdr["coinacceptorstatus"].ToString()) : "";
					_batches.coinchangerstatus = !rdr.IsDBNull(41) ? Convert.ToString(rdr["coinchangerstatus"].ToString()) : "";
					_batches.cardreaderstatus = !rdr.IsDBNull(42) ? Convert.ToString(rdr["cardreaderstatus"].ToString()) : "";
					_batches.blockreason = !rdr.IsDBNull(43) ? Convert.ToString(rdr["blockreason"].ToString()) : "";
					_batches.blockstatus = !rdr.IsDBNull(44) ? Convert.ToString(rdr["blockstatus"].ToString()) : "";
					_batches.aceptor_000005 = !rdr.IsDBNull(45) ? Convert.ToString(rdr["aceptor_000005"].ToString()) : "";
					_batches.aceptor_000010 = !rdr.IsDBNull(46) ? Convert.ToString(rdr["aceptor_000010"].ToString()) : "";
					_batches.aceptor_000025 = !rdr.IsDBNull(47) ? Convert.ToString(rdr["aceptor_000025"].ToString()) : "";
					_batches.aceptor_000050 = !rdr.IsDBNull(48) ? Convert.ToString(rdr["aceptor_000050"].ToString()) : "";
					_batches.aceptor_000100 = !rdr.IsDBNull(49) ? Convert.ToString(rdr["aceptor_000100"].ToString()) : "";
					_batches.aceptor_000200 = !rdr.IsDBNull(50) ? Convert.ToString(rdr["aceptor_000200"].ToString()) : "";
					_batches.aceptor_000500 = !rdr.IsDBNull(51) ? Convert.ToString(rdr["aceptor_000500"].ToString()) : "";
					_batches.aceptor_001000 = !rdr.IsDBNull(52) ? Convert.ToString(rdr["aceptor_001000"].ToString()) : "";
					_batches.aceptor_002000 = !rdr.IsDBNull(53) ? Convert.ToString(rdr["aceptor_002000"].ToString()) : "";
					_batches.aceptor_005000 = !rdr.IsDBNull(54) ? Convert.ToString(rdr["aceptor_005000"].ToString()) : "";
					_batches.aceptor_010000 = !rdr.IsDBNull(55) ? Convert.ToString(rdr["aceptor_010000"].ToString()) : "";
					_batches.changer_000005 = !rdr.IsDBNull(56) ? Convert.ToString(rdr["changer_000005"].ToString()) : "";
					_batches.changer_000010 = !rdr.IsDBNull(57) ? Convert.ToString(rdr["changer_000010"].ToString()) : "";
					_batches.changer_000025 = !rdr.IsDBNull(58) ? Convert.ToString(rdr["changer_000025"].ToString()) : "";
					_batches.changer_000050 = !rdr.IsDBNull(59) ? Convert.ToString(rdr["changer_000050"].ToString()) : "";
					_batches.changer_000100 = !rdr.IsDBNull(60) ? Convert.ToString(rdr["changer_000100"].ToString()) : "";
					_batches.changer_000200 = !rdr.IsDBNull(61) ? Convert.ToString(rdr["changer_000200"].ToString()) : "";
					_batches.changer_000500 = !rdr.IsDBNull(62) ? Convert.ToString(rdr["changer_000500"].ToString()) : "";
					_batches.changer_001000 = !rdr.IsDBNull(63) ? Convert.ToString(rdr["changer_001000"].ToString()) : "";
					_batches.changer_002000 = !rdr.IsDBNull(64) ? Convert.ToString(rdr["changer_002000"].ToString()) : "";
					_batches.changer_005000 = !rdr.IsDBNull(65) ? Convert.ToString(rdr["changer_005000"].ToString()) : "";
					_batches.changer_010000 = !rdr.IsDBNull(66) ? Convert.ToString(rdr["changer_010000"].ToString()) : "";
					_batches.return_000005 = !rdr.IsDBNull(67) ? Convert.ToString(rdr["return_000005"].ToString()) : "";
					_batches.return_000010 = !rdr.IsDBNull(68) ? Convert.ToString(rdr["return_000010"].ToString()) : "";
					_batches.return_000025 = !rdr.IsDBNull(69) ? Convert.ToString(rdr["return_000025"].ToString()) : "";
					_batches.return_000050 = !rdr.IsDBNull(70) ? Convert.ToString(rdr["return_000050"].ToString()) : "";
					_batches.return_000100 = !rdr.IsDBNull(71) ? Convert.ToString(rdr["return_000100"].ToString()) : "";
					_batches.return_000200 = !rdr.IsDBNull(72) ? Convert.ToString(rdr["return_000200"].ToString()) : "";
					_batches.return_000500 = !rdr.IsDBNull(73) ? Convert.ToString(rdr["return_000500"].ToString()) : "";
					_batches.return_001000 = !rdr.IsDBNull(74) ? Convert.ToString(rdr["return_001000"].ToString()) : "";
					_batches.return_002000 = !rdr.IsDBNull(75) ? Convert.ToString(rdr["return_002000"].ToString()) : "";
					_batches.return_005000 = !rdr.IsDBNull(76) ? Convert.ToString(rdr["return_005000"].ToString()) : "";
					_batches.return_010000 = !rdr.IsDBNull(77) ? Convert.ToString(rdr["return_010000"].ToString()) : "";
					_batches.return_066666 = !rdr.IsDBNull(78) ? Convert.ToString(rdr["return_066666"].ToString()) : "";
					_batches.aceptor_100000 = !rdr.IsDBNull(79) ? Convert.ToString(rdr["aceptor_100000"].ToString()) : "";
					_batches.aceptor_200000 = !rdr.IsDBNull(80) ? Convert.ToString(rdr["aceptor_200000"].ToString()) : "";
					_batches.aceptor_500000 = !rdr.IsDBNull(81) ? Convert.ToString(rdr["aceptor_500000"].ToString()) : "";
					_batches.aceptor_1000000 = !rdr.IsDBNull(82) ? Convert.ToString(rdr["aceptor_1000000"].ToString()) : "";
					_batches.changer_100000 = !rdr.IsDBNull(83) ? Convert.ToString(rdr["changer_100000"].ToString()) : "";
					_batches.changer_200000 = !rdr.IsDBNull(84) ? Convert.ToString(rdr["changer_200000"].ToString()) : "";
					_batches.changer_500000 = !rdr.IsDBNull(85) ? Convert.ToString(rdr["changer_500000"].ToString()) : "";
					_batches.changer_1000000 = !rdr.IsDBNull(86) ? Convert.ToString(rdr["changer_1000000"].ToString()) : "";
					_batches.return_100000 = !rdr.IsDBNull(87) ? Convert.ToString(rdr["return_100000"].ToString()) : "";
					_batches.return_1000000 = !rdr.IsDBNull(88) ? Convert.ToString(rdr["return_1000000"].ToString()) : "";
					_batches.return_500000 = !rdr.IsDBNull(89) ? Convert.ToString(rdr["return_500000"].ToString()) : "";
					_batches.return_200000 = !rdr.IsDBNull(90) ? Convert.ToString(rdr["return_200000"].ToString()) : "";
					_batches.aceptordetail = !rdr.IsDBNull(91) ? Convert.ToString(rdr["aceptordetail"].ToString()) : "";
					_batches.changerdetail = !rdr.IsDBNull(92) ? Convert.ToString(rdr["changerdetail"].ToString()) : "";
					_batches.returndetail = !rdr.IsDBNull(93) ? Convert.ToString(rdr["returndetail"].ToString()) : "";
					lstbatches.Add(_batches);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar batches", _state.error.ToString());
				return new batches(_state, lstbatches);
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
			return new batches(_state);
		}
		public batches Buscarbatches(batches.Data _batchesData)
		{
			List<batches.Data> lstbatches = new List<batches.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar batches", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_batches_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@pID", _batchesData.id);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					batches.Data _batches= new batches.Data();
					_batches.id = Convert.ToInt32(rdr["id"].ToString());
					_batches.createtimestamp = !rdr.IsDBNull(1) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_batches.updatetimestamp = !rdr.IsDBNull(2) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_batches.deviceidentification = !rdr.IsDBNull(3) ? Convert.ToString(rdr["deviceidentification"].ToString()) : "";
					_batches.locationidentification = !rdr.IsDBNull(4) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
					_batches.payloadrequest = !rdr.IsDBNull(5) ? Convert.ToString(rdr["payloadrequest"].ToString()) : "";
					_batches.provideridentification = !rdr.IsDBNull(6) ? Convert.ToString(rdr["provideridentification"].ToString()) : "";
					_batches.devicestatus = !rdr.IsDBNull(7) ? Convert.ToString(rdr["devicestatus"].ToString()) : "";
					_batches.number_ = !rdr.IsDBNull(8) ? Convert.ToInt32(rdr["number_"].ToString()) : (System.Int32)0;
					_batches.status = Convert.ToInt32(rdr["status"].ToString());
					_batches.opentimestamp = !rdr.IsDBNull(10) ? Convert.ToDateTime(rdr["opentimestamp"].ToString()) : System.DateTime.Now;
					_batches.closetimestamp = !rdr.IsDBNull(11) ? Convert.ToDateTime(rdr["closetimestamp"].ToString()) : System.DateTime.Now;
					_batches.syncstatus = !rdr.IsDBNull(12) ? Convert.ToInt32(rdr["syncstatus"].ToString()) : (System.Int32)0;
					_batches.synctimestamp = !rdr.IsDBNull(13) ? Convert.ToDateTime(rdr["synctimestamp"].ToString()) : System.DateTime.Now;
					_batches.operativeday = !rdr.IsDBNull(14) ? Convert.ToString(rdr["operativeday"].ToString()) : "";
					_batches.totaltx = !rdr.IsDBNull(15) ? Convert.ToString(rdr["totaltx"].ToString()) : "";
					_batches.totalamount = !rdr.IsDBNull(16) ? Convert.ToString(rdr["totalamount"].ToString()) : "";
					_batches.totalaccepted = !rdr.IsDBNull(17) ? Convert.ToString(rdr["totalaccepted"].ToString()) : "";
					_batches.totalreturned = !rdr.IsDBNull(18) ? Convert.ToString(rdr["totalreturned"].ToString()) : "";
					_batches.totalavailable = !rdr.IsDBNull(19) ? Convert.ToString(rdr["totalavailable"].ToString()) : "";
					_batches.totalgivenamount = !rdr.IsDBNull(20) ? Convert.ToString(rdr["totalgivenamount"].ToString()) : "";
					_batches.totaldebtamount = !rdr.IsDBNull(21) ? Convert.ToString(rdr["totaldebtamount"].ToString()) : "";
					_batches.totalrefilloperations = !rdr.IsDBNull(22) ? Convert.ToString(rdr["totalrefilloperations"].ToString()) : "";
					_batches.totalrefillamount = !rdr.IsDBNull(23) ? Convert.ToString(rdr["totalrefillamount"].ToString()) : "";
					_batches.totalcollectoperations = !rdr.IsDBNull(24) ? Convert.ToString(rdr["totalcollectoperations"].ToString()) : "";
					_batches.totalcollectamount = !rdr.IsDBNull(25) ? Convert.ToString(rdr["totalcollectamount"].ToString()) : "";
					_batches.totalcardsdelivered = !rdr.IsDBNull(26) ? Convert.ToString(rdr["totalcardsdelivered"].ToString()) : "";
					_batches.totalcardrefilloperations = !rdr.IsDBNull(27) ? Convert.ToString(rdr["totalcardrefilloperations"].ToString()) : "";
					_batches.totalcardrefillamount = !rdr.IsDBNull(28) ? Convert.ToString(rdr["totalcardrefillamount"].ToString()) : "";
					_batches.totalcardcollectoperations = !rdr.IsDBNull(29) ? Convert.ToString(rdr["totalcardcollectoperations"].ToString()) : "";
					_batches.totalcardcollectamount = !rdr.IsDBNull(30) ? Convert.ToString(rdr["totalcardcollectamount"].ToString()) : "";
					_batches.carddispenserstatus = !rdr.IsDBNull(31) ? Convert.ToString(rdr["carddispenserstatus"].ToString()) : "";
					_batches.totallocks = !rdr.IsDBNull(32) ? Convert.ToString(rdr["totallocks"].ToString()) : "";
					_batches.opentime = !rdr.IsDBNull(33) ? Convert.ToString(rdr["opentime"].ToString()) : "";
					_batches.closetime = !rdr.IsDBNull(34) ? Convert.ToString(rdr["closetime"].ToString()) : "";
					_batches.scannerstatus = !rdr.IsDBNull(35) ? Convert.ToString(rdr["scannerstatus"].ToString()) : "";
					_batches.motionsensorstatus = !rdr.IsDBNull(36) ? Convert.ToString(rdr["motionsensorstatus"].ToString()) : "";
					_batches.printerstatus = !rdr.IsDBNull(37) ? Convert.ToString(rdr["printerstatus"].ToString()) : "";
					_batches.cashacceptorstatus = !rdr.IsDBNull(38) ? Convert.ToString(rdr["cashacceptorstatus"].ToString()) : "";
					_batches.cashchangerstatus = !rdr.IsDBNull(39) ? Convert.ToString(rdr["cashchangerstatus"].ToString()) : "";
					_batches.coinacceptorstatus = !rdr.IsDBNull(40) ? Convert.ToString(rdr["coinacceptorstatus"].ToString()) : "";
					_batches.coinchangerstatus = !rdr.IsDBNull(41) ? Convert.ToString(rdr["coinchangerstatus"].ToString()) : "";
					_batches.cardreaderstatus = !rdr.IsDBNull(42) ? Convert.ToString(rdr["cardreaderstatus"].ToString()) : "";
					_batches.blockreason = !rdr.IsDBNull(43) ? Convert.ToString(rdr["blockreason"].ToString()) : "";
					_batches.blockstatus = !rdr.IsDBNull(44) ? Convert.ToString(rdr["blockstatus"].ToString()) : "";
					_batches.aceptor_000005 = !rdr.IsDBNull(45) ? Convert.ToString(rdr["aceptor_000005"].ToString()) : "";
					_batches.aceptor_000010 = !rdr.IsDBNull(46) ? Convert.ToString(rdr["aceptor_000010"].ToString()) : "";
					_batches.aceptor_000025 = !rdr.IsDBNull(47) ? Convert.ToString(rdr["aceptor_000025"].ToString()) : "";
					_batches.aceptor_000050 = !rdr.IsDBNull(48) ? Convert.ToString(rdr["aceptor_000050"].ToString()) : "";
					_batches.aceptor_000100 = !rdr.IsDBNull(49) ? Convert.ToString(rdr["aceptor_000100"].ToString()) : "";
					_batches.aceptor_000200 = !rdr.IsDBNull(50) ? Convert.ToString(rdr["aceptor_000200"].ToString()) : "";
					_batches.aceptor_000500 = !rdr.IsDBNull(51) ? Convert.ToString(rdr["aceptor_000500"].ToString()) : "";
					_batches.aceptor_001000 = !rdr.IsDBNull(52) ? Convert.ToString(rdr["aceptor_001000"].ToString()) : "";
					_batches.aceptor_002000 = !rdr.IsDBNull(53) ? Convert.ToString(rdr["aceptor_002000"].ToString()) : "";
					_batches.aceptor_005000 = !rdr.IsDBNull(54) ? Convert.ToString(rdr["aceptor_005000"].ToString()) : "";
					_batches.aceptor_010000 = !rdr.IsDBNull(55) ? Convert.ToString(rdr["aceptor_010000"].ToString()) : "";
					_batches.changer_000005 = !rdr.IsDBNull(56) ? Convert.ToString(rdr["changer_000005"].ToString()) : "";
					_batches.changer_000010 = !rdr.IsDBNull(57) ? Convert.ToString(rdr["changer_000010"].ToString()) : "";
					_batches.changer_000025 = !rdr.IsDBNull(58) ? Convert.ToString(rdr["changer_000025"].ToString()) : "";
					_batches.changer_000050 = !rdr.IsDBNull(59) ? Convert.ToString(rdr["changer_000050"].ToString()) : "";
					_batches.changer_000100 = !rdr.IsDBNull(60) ? Convert.ToString(rdr["changer_000100"].ToString()) : "";
					_batches.changer_000200 = !rdr.IsDBNull(61) ? Convert.ToString(rdr["changer_000200"].ToString()) : "";
					_batches.changer_000500 = !rdr.IsDBNull(62) ? Convert.ToString(rdr["changer_000500"].ToString()) : "";
					_batches.changer_001000 = !rdr.IsDBNull(63) ? Convert.ToString(rdr["changer_001000"].ToString()) : "";
					_batches.changer_002000 = !rdr.IsDBNull(64) ? Convert.ToString(rdr["changer_002000"].ToString()) : "";
					_batches.changer_005000 = !rdr.IsDBNull(65) ? Convert.ToString(rdr["changer_005000"].ToString()) : "";
					_batches.changer_010000 = !rdr.IsDBNull(66) ? Convert.ToString(rdr["changer_010000"].ToString()) : "";
					_batches.return_000005 = !rdr.IsDBNull(67) ? Convert.ToString(rdr["return_000005"].ToString()) : "";
					_batches.return_000010 = !rdr.IsDBNull(68) ? Convert.ToString(rdr["return_000010"].ToString()) : "";
					_batches.return_000025 = !rdr.IsDBNull(69) ? Convert.ToString(rdr["return_000025"].ToString()) : "";
					_batches.return_000050 = !rdr.IsDBNull(70) ? Convert.ToString(rdr["return_000050"].ToString()) : "";
					_batches.return_000100 = !rdr.IsDBNull(71) ? Convert.ToString(rdr["return_000100"].ToString()) : "";
					_batches.return_000200 = !rdr.IsDBNull(72) ? Convert.ToString(rdr["return_000200"].ToString()) : "";
					_batches.return_000500 = !rdr.IsDBNull(73) ? Convert.ToString(rdr["return_000500"].ToString()) : "";
					_batches.return_001000 = !rdr.IsDBNull(74) ? Convert.ToString(rdr["return_001000"].ToString()) : "";
					_batches.return_002000 = !rdr.IsDBNull(75) ? Convert.ToString(rdr["return_002000"].ToString()) : "";
					_batches.return_005000 = !rdr.IsDBNull(76) ? Convert.ToString(rdr["return_005000"].ToString()) : "";
					_batches.return_010000 = !rdr.IsDBNull(77) ? Convert.ToString(rdr["return_010000"].ToString()) : "";
					_batches.return_066666 = !rdr.IsDBNull(78) ? Convert.ToString(rdr["return_066666"].ToString()) : "";
					_batches.aceptor_100000 = !rdr.IsDBNull(79) ? Convert.ToString(rdr["aceptor_100000"].ToString()) : "";
					_batches.aceptor_200000 = !rdr.IsDBNull(80) ? Convert.ToString(rdr["aceptor_200000"].ToString()) : "";
					_batches.aceptor_500000 = !rdr.IsDBNull(81) ? Convert.ToString(rdr["aceptor_500000"].ToString()) : "";
					_batches.aceptor_1000000 = !rdr.IsDBNull(82) ? Convert.ToString(rdr["aceptor_1000000"].ToString()) : "";
					_batches.changer_100000 = !rdr.IsDBNull(83) ? Convert.ToString(rdr["changer_100000"].ToString()) : "";
					_batches.changer_200000 = !rdr.IsDBNull(84) ? Convert.ToString(rdr["changer_200000"].ToString()) : "";
					_batches.changer_500000 = !rdr.IsDBNull(85) ? Convert.ToString(rdr["changer_500000"].ToString()) : "";
					_batches.changer_1000000 = !rdr.IsDBNull(86) ? Convert.ToString(rdr["changer_1000000"].ToString()) : "";
					_batches.return_100000 = !rdr.IsDBNull(87) ? Convert.ToString(rdr["return_100000"].ToString()) : "";
					_batches.return_1000000 = !rdr.IsDBNull(88) ? Convert.ToString(rdr["return_1000000"].ToString()) : "";
					_batches.return_500000 = !rdr.IsDBNull(89) ? Convert.ToString(rdr["return_500000"].ToString()) : "";
					_batches.return_200000 = !rdr.IsDBNull(90) ? Convert.ToString(rdr["return_200000"].ToString()) : "";
					_batches.aceptordetail = !rdr.IsDBNull(91) ? Convert.ToString(rdr["aceptordetail"].ToString()) : "";
					_batches.changerdetail = !rdr.IsDBNull(92) ? Convert.ToString(rdr["changerdetail"].ToString()) : "";
					_batches.returndetail = !rdr.IsDBNull(93) ? Convert.ToString(rdr["returndetail"].ToString()) : "";
					lstbatches.Add(_batches);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar batches", _state.error.ToString());
				return new batches(_state, lstbatches);
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
			return new batches(_state);
		}
        public batches ConsultarPorPaginacion(batches.Data _batchesData)
        {
            List<batches.Data> lstbatches = new List<batches.Data>();
            batches.Pagination _batchesPagination = new batches.Pagination();
            try
            {
                _log.Traceo("Ingresa a Metodo Consultar por Paghinacion batches", "0");
                MySqlConnection SqlCnn;
                SqlCnn = Base.AbrirConexionMySql();
                MySqlCommand SqlCmd = new MySqlCommand("Proc_batches_Select_Pagination", SqlCnn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@initPagination", _batchesData.initPagination);
                SqlCmd.Parameters.AddWithValue("@quantityPagination", _batchesData.quantityPagination);     
                MySqlDataReader rdr = SqlCmd.ExecuteReader();
                var number = _batchesData.initPagination;
                while (rdr.Read())
                {
                    batches.Data _batches = new batches.Data();
                    _batches.id = Convert.ToInt32(rdr["id"].ToString());
                    _batches.createtimestamp = !rdr.IsDBNull(1) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
                    _batches.updatetimestamp = !rdr.IsDBNull(2) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
                    _batches.deviceidentification = !rdr.IsDBNull(3) ? Convert.ToString(rdr["deviceidentification"].ToString()) : "";
                    _batches.locationidentification = !rdr.IsDBNull(4) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
                    _batches.payloadrequest = !rdr.IsDBNull(5) ? Convert.ToString(rdr["payloadrequest"].ToString()) : "";
                    _batches.provideridentification = !rdr.IsDBNull(6) ? Convert.ToString(rdr["provideridentification"].ToString()) : "";
                    _batches.devicestatus = !rdr.IsDBNull(7) ? Convert.ToString(rdr["devicestatus"].ToString()) : "";
                    _batches.number_ = !rdr.IsDBNull(8) ? Convert.ToInt32(rdr["number_"].ToString()) : (System.Int32)0;
                    _batches.status = Convert.ToInt32(rdr["status"].ToString());
                    _batches.opentimestamp = !rdr.IsDBNull(10) ? Convert.ToDateTime(rdr["opentimestamp"].ToString()) : System.DateTime.Now;
                    _batches.closetimestamp = !rdr.IsDBNull(11) ? Convert.ToDateTime(rdr["closetimestamp"].ToString()) : System.DateTime.Now;
                    _batches.syncstatus = !rdr.IsDBNull(12) ? Convert.ToInt32(rdr["syncstatus"].ToString()) : (System.Int32)0;
                    _batches.synctimestamp = !rdr.IsDBNull(13) ? Convert.ToDateTime(rdr["synctimestamp"].ToString()) : System.DateTime.Now;
                    _batches.operativeday = !rdr.IsDBNull(14) ? Convert.ToString(rdr["operativeday"].ToString()) : "";
                    _batches.totaltx = !rdr.IsDBNull(15) ? Convert.ToString(rdr["totaltx"].ToString()) : "";
                    _batches.totalamount = !rdr.IsDBNull(16) ? Convert.ToString(rdr["totalamount"].ToString()) : "";
                    _batches.totalaccepted = !rdr.IsDBNull(17) ? Convert.ToString(rdr["totalaccepted"].ToString()) : "";
                    _batches.totalreturned = !rdr.IsDBNull(18) ? Convert.ToString(rdr["totalreturned"].ToString()) : "";
                    _batches.totalavailable = !rdr.IsDBNull(19) ? Convert.ToString(rdr["totalavailable"].ToString()) : "";
                    _batches.totalgivenamount = !rdr.IsDBNull(20) ? Convert.ToString(rdr["totalgivenamount"].ToString()) : "";
                    _batches.totaldebtamount = !rdr.IsDBNull(21) ? Convert.ToString(rdr["totaldebtamount"].ToString()) : "";
                    _batches.totalrefilloperations = !rdr.IsDBNull(22) ? Convert.ToString(rdr["totalrefilloperations"].ToString()) : "";
                    _batches.totalrefillamount = !rdr.IsDBNull(23) ? Convert.ToString(rdr["totalrefillamount"].ToString()) : "";
                    _batches.totalcollectoperations = !rdr.IsDBNull(24) ? Convert.ToString(rdr["totalcollectoperations"].ToString()) : "";
                    _batches.totalcollectamount = !rdr.IsDBNull(25) ? Convert.ToString(rdr["totalcollectamount"].ToString()) : "";
                    _batches.totalcardsdelivered = !rdr.IsDBNull(26) ? Convert.ToString(rdr["totalcardsdelivered"].ToString()) : "";
                    _batches.totalcardrefilloperations = !rdr.IsDBNull(27) ? Convert.ToString(rdr["totalcardrefilloperations"].ToString()) : "";
                    _batches.totalcardrefillamount = !rdr.IsDBNull(28) ? Convert.ToString(rdr["totalcardrefillamount"].ToString()) : "";
                    _batches.totalcardcollectoperations = !rdr.IsDBNull(29) ? Convert.ToString(rdr["totalcardcollectoperations"].ToString()) : "";
                    _batches.totalcardcollectamount = !rdr.IsDBNull(30) ? Convert.ToString(rdr["totalcardcollectamount"].ToString()) : "";
                    _batches.carddispenserstatus = !rdr.IsDBNull(31) ? Convert.ToString(rdr["carddispenserstatus"].ToString()) : "";
                    _batches.totallocks = !rdr.IsDBNull(32) ? Convert.ToString(rdr["totallocks"].ToString()) : "";
                    _batches.opentime = !rdr.IsDBNull(33) ? Convert.ToString(rdr["opentime"].ToString()) : "";
                    _batches.closetime = !rdr.IsDBNull(34) ? Convert.ToString(rdr["closetime"].ToString()) : "";
                    _batches.scannerstatus = !rdr.IsDBNull(35) ? Convert.ToString(rdr["scannerstatus"].ToString()) : "";
                    _batches.motionsensorstatus = !rdr.IsDBNull(36) ? Convert.ToString(rdr["motionsensorstatus"].ToString()) : "";
                    _batches.printerstatus = !rdr.IsDBNull(37) ? Convert.ToString(rdr["printerstatus"].ToString()) : "";
                    _batches.cashacceptorstatus = !rdr.IsDBNull(38) ? Convert.ToString(rdr["cashacceptorstatus"].ToString()) : "";
                    _batches.cashchangerstatus = !rdr.IsDBNull(39) ? Convert.ToString(rdr["cashchangerstatus"].ToString()) : "";
                    _batches.coinacceptorstatus = !rdr.IsDBNull(40) ? Convert.ToString(rdr["coinacceptorstatus"].ToString()) : "";
                    _batches.coinchangerstatus = !rdr.IsDBNull(41) ? Convert.ToString(rdr["coinchangerstatus"].ToString()) : "";
                    _batches.cardreaderstatus = !rdr.IsDBNull(42) ? Convert.ToString(rdr["cardreaderstatus"].ToString()) : "";
                    _batches.blockreason = !rdr.IsDBNull(43) ? Convert.ToString(rdr["blockreason"].ToString()) : "";
                    _batches.blockstatus = !rdr.IsDBNull(44) ? Convert.ToString(rdr["blockstatus"].ToString()) : "";
                    _batches.aceptor_000005 = !rdr.IsDBNull(45) ? Convert.ToString(rdr["aceptor_000005"].ToString()) : "";
                    _batches.aceptor_000010 = !rdr.IsDBNull(46) ? Convert.ToString(rdr["aceptor_000010"].ToString()) : "";
                    _batches.aceptor_000025 = !rdr.IsDBNull(47) ? Convert.ToString(rdr["aceptor_000025"].ToString()) : "";
                    _batches.aceptor_000050 = !rdr.IsDBNull(48) ? Convert.ToString(rdr["aceptor_000050"].ToString()) : "";
                    _batches.aceptor_000100 = !rdr.IsDBNull(49) ? Convert.ToString(rdr["aceptor_000100"].ToString()) : "";
                    _batches.aceptor_000200 = !rdr.IsDBNull(50) ? Convert.ToString(rdr["aceptor_000200"].ToString()) : "";
                    _batches.aceptor_000500 = !rdr.IsDBNull(51) ? Convert.ToString(rdr["aceptor_000500"].ToString()) : "";
                    _batches.aceptor_001000 = !rdr.IsDBNull(52) ? Convert.ToString(rdr["aceptor_001000"].ToString()) : "";
                    _batches.aceptor_002000 = !rdr.IsDBNull(53) ? Convert.ToString(rdr["aceptor_002000"].ToString()) : "";
                    _batches.aceptor_005000 = !rdr.IsDBNull(54) ? Convert.ToString(rdr["aceptor_005000"].ToString()) : "";
                    _batches.aceptor_010000 = !rdr.IsDBNull(55) ? Convert.ToString(rdr["aceptor_010000"].ToString()) : "";
                    _batches.changer_000005 = !rdr.IsDBNull(56) ? Convert.ToString(rdr["changer_000005"].ToString()) : "";
                    _batches.changer_000010 = !rdr.IsDBNull(57) ? Convert.ToString(rdr["changer_000010"].ToString()) : "";
                    _batches.changer_000025 = !rdr.IsDBNull(58) ? Convert.ToString(rdr["changer_000025"].ToString()) : "";
                    _batches.changer_000050 = !rdr.IsDBNull(59) ? Convert.ToString(rdr["changer_000050"].ToString()) : "";
                    _batches.changer_000100 = !rdr.IsDBNull(60) ? Convert.ToString(rdr["changer_000100"].ToString()) : "";
                    _batches.changer_000200 = !rdr.IsDBNull(61) ? Convert.ToString(rdr["changer_000200"].ToString()) : "";
                    _batches.changer_000500 = !rdr.IsDBNull(62) ? Convert.ToString(rdr["changer_000500"].ToString()) : "";
                    _batches.changer_001000 = !rdr.IsDBNull(63) ? Convert.ToString(rdr["changer_001000"].ToString()) : "";
                    _batches.changer_002000 = !rdr.IsDBNull(64) ? Convert.ToString(rdr["changer_002000"].ToString()) : "";
                    _batches.changer_005000 = !rdr.IsDBNull(65) ? Convert.ToString(rdr["changer_005000"].ToString()) : "";
                    _batches.changer_010000 = !rdr.IsDBNull(66) ? Convert.ToString(rdr["changer_010000"].ToString()) : "";
                    _batches.return_000005 = !rdr.IsDBNull(67) ? Convert.ToString(rdr["return_000005"].ToString()) : "";
                    _batches.return_000010 = !rdr.IsDBNull(68) ? Convert.ToString(rdr["return_000010"].ToString()) : "";
                    _batches.return_000025 = !rdr.IsDBNull(69) ? Convert.ToString(rdr["return_000025"].ToString()) : "";
                    _batches.return_000050 = !rdr.IsDBNull(70) ? Convert.ToString(rdr["return_000050"].ToString()) : "";
                    _batches.return_000100 = !rdr.IsDBNull(71) ? Convert.ToString(rdr["return_000100"].ToString()) : "";
                    _batches.return_000200 = !rdr.IsDBNull(72) ? Convert.ToString(rdr["return_000200"].ToString()) : "";
                    _batches.return_000500 = !rdr.IsDBNull(73) ? Convert.ToString(rdr["return_000500"].ToString()) : "";
                    _batches.return_001000 = !rdr.IsDBNull(74) ? Convert.ToString(rdr["return_001000"].ToString()) : "";
                    _batches.return_002000 = !rdr.IsDBNull(75) ? Convert.ToString(rdr["return_002000"].ToString()) : "";
                    _batches.return_005000 = !rdr.IsDBNull(76) ? Convert.ToString(rdr["return_005000"].ToString()) : "";
                    _batches.return_010000 = !rdr.IsDBNull(77) ? Convert.ToString(rdr["return_010000"].ToString()) : "";
                    _batches.return_066666 = !rdr.IsDBNull(78) ? Convert.ToString(rdr["return_066666"].ToString()) : "";
                    _batches.aceptor_100000 = !rdr.IsDBNull(79) ? Convert.ToString(rdr["aceptor_100000"].ToString()) : "";
                    _batches.aceptor_200000 = !rdr.IsDBNull(80) ? Convert.ToString(rdr["aceptor_200000"].ToString()) : "";
                    _batches.aceptor_500000 = !rdr.IsDBNull(81) ? Convert.ToString(rdr["aceptor_500000"].ToString()) : "";
                    _batches.aceptor_1000000 = !rdr.IsDBNull(82) ? Convert.ToString(rdr["aceptor_1000000"].ToString()) : "";
                    _batches.changer_100000 = !rdr.IsDBNull(83) ? Convert.ToString(rdr["changer_100000"].ToString()) : "";
                    _batches.changer_200000 = !rdr.IsDBNull(84) ? Convert.ToString(rdr["changer_200000"].ToString()) : "";
                    _batches.changer_500000 = !rdr.IsDBNull(85) ? Convert.ToString(rdr["changer_500000"].ToString()) : "";
                    _batches.changer_1000000 = !rdr.IsDBNull(86) ? Convert.ToString(rdr["changer_1000000"].ToString()) : "";
                    _batches.return_100000 = !rdr.IsDBNull(87) ? Convert.ToString(rdr["return_100000"].ToString()) : "";
                    _batches.return_1000000 = !rdr.IsDBNull(88) ? Convert.ToString(rdr["return_1000000"].ToString()) : "";
                    _batches.return_500000 = !rdr.IsDBNull(89) ? Convert.ToString(rdr["return_500000"].ToString()) : "";
                    _batches.return_200000 = !rdr.IsDBNull(90) ? Convert.ToString(rdr["return_200000"].ToString()) : "";
                    _batches.aceptordetail = !rdr.IsDBNull(91) ? Convert.ToString(rdr["aceptordetail"].ToString()) : "";
                    _batches.changerdetail = !rdr.IsDBNull(92) ? Convert.ToString(rdr["changerdetail"].ToString()) : "";
                    _batches.returndetail = !rdr.IsDBNull(93) ? Convert.ToString(rdr["returndetail"].ToString()) : "";
                    _batches.numberOfItemPagination = number++;
                    _batchesPagination.itemsLengthPagination = !rdr.IsDBNull(94) ? Convert.ToInt32(rdr["TotalItems"].ToString()) : 0;
                    lstbatches.Add(_batches);
                }
                _batchesPagination.initPagination = _batchesData.initPagination;
                _batchesPagination.quantityPagination = _batchesData.quantityPagination;
                _batchesPagination.itemsPerPagePagination = lstbatches.Count;
                Base.CerrarConexionMySql(SqlCnn);
                _state.error = 0;
                _state.descripcion = "Operacion Realizada";
                _log.Traceo(_state.descripcion + " Operacion Buscar batches", _state.error.ToString());
                return new batches(_state, lstbatches, _batchesPagination);
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
            return new batches(_state);
        }
		public batches ConsultarPorPaginacion_filter(batches.Data batchesData)
		{
			List<batches.Data> lstbatches = new List<batches.Data>();
			batches.Pagination _batchesPagination = new batches.Pagination();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_batches_Select_Pagination_Filter", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@LOCATIONIDENTIFICATION", batchesData.locationidentification);
				SqlCmd.Parameters.AddWithValue("@DEVICEIDENTIFICATION", batchesData.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@INITPAGINATION", batchesData.initPagination);
				SqlCmd.Parameters.AddWithValue("@QUANTITYPAGINATION", batchesData.quantityPagination);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				var number = batchesData.initPagination;
				while (rdr.Read())
				{
					batches.Data _batches = new batches.Data();
					_batches.createtimestamp = !rdr.IsDBNull(rdr.GetOrdinal("createtimestamp")) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : Convert.ToDateTime("01/01/2000");
					_batches.updatetimestamp = !rdr.IsDBNull(rdr.GetOrdinal("updatetimestamp")) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : Convert.ToDateTime("01/01/2000");
					_batches.deviceidentification = !rdr.IsDBNull(rdr.GetOrdinal("deviceidentification")) ? Convert.ToString(rdr["deviceidentification"].ToString()) : "";
					_batches.locationidentification = !rdr.IsDBNull(rdr.GetOrdinal("deviceidentification")) ? Convert.ToString(rdr["locationidentification"].ToString()):"";
					_batches.number_ = !rdr.IsDBNull(rdr.GetOrdinal("number_")) ? Convert.ToInt32(rdr["number_"].ToString()) : (System.Int32)0;
					_batches.status = Convert.ToInt32(rdr["status"].ToString());
                    _batches.opentimestamp = !rdr.IsDBNull(rdr.GetOrdinal("opentimestamp")) ? Convert.ToDateTime(rdr["opentimestamp"].ToString()) : Convert.ToDateTime("01/01/2000");
					_batches.closetimestamp = !rdr.IsDBNull(rdr.GetOrdinal("closetimestamp")) ? Convert.ToDateTime(rdr["closetimestamp"].ToString()) : Convert.ToDateTime(rdr["opentimestamp"].ToString());
					_batches.numberOfItemPagination = number++;
					_batchesPagination.itemsLengthPagination = !rdr.IsDBNull(rdr.GetOrdinal("TotalItems")) ? Convert.ToInt32(rdr["TotalItems"].ToString()) : 0;
					//_batchesPagination.itemsLengthPagination = !rdr.IsDBNull(rdr.GetOrdinal("number_")) ? Convert.ToInt32(rdr["number_"].ToString()) : (System.Int32)0;
					lstbatches.Add(_batches);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_batchesPagination.initPagination = batchesData.initPagination;
				_batchesPagination.quantityPagination = batchesData.quantityPagination;
				_batchesPagination.itemsPerPagePagination = lstbatches.Count;
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar batches", _state.error.ToString());
				return new batches(_state, lstbatches, _batchesPagination);
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
			return new batches(_state);
		}
		public batches.State Insertarbatches(batches.Data _batches)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar batches", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_batches_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlParameter pID = new MySqlParameter();
				pID.ParameterName = "@ID";
				pID.Value = 0;
				SqlCmd.Parameters.Add(pID);
				pID.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _batches.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _batches.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _batches.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _batches.locationidentification);
				SqlCmd.Parameters.AddWithValue("@payloadrequest", _batches.payloadrequest);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _batches.provideridentification);
				SqlCmd.Parameters.AddWithValue("@devicestatus", _batches.devicestatus);
				SqlCmd.Parameters.AddWithValue("@number_", _batches.number_);
				SqlCmd.Parameters.AddWithValue("@status", _batches.status);
				SqlCmd.Parameters.AddWithValue("@opentimestamp", _batches.opentimestamp);
				SqlCmd.Parameters.AddWithValue("@closetimestamp", _batches.closetimestamp);
				SqlCmd.Parameters.AddWithValue("@syncstatus", _batches.syncstatus);
				SqlCmd.Parameters.AddWithValue("@synctimestamp", _batches.synctimestamp);
				SqlCmd.Parameters.AddWithValue("@operativeday", _batches.operativeday);
				SqlCmd.Parameters.AddWithValue("@totaltx", _batches.totaltx);
				SqlCmd.Parameters.AddWithValue("@totalamount", _batches.totalamount);
				SqlCmd.Parameters.AddWithValue("@totalaccepted", _batches.totalaccepted);
				SqlCmd.Parameters.AddWithValue("@totalreturned", _batches.totalreturned);
				SqlCmd.Parameters.AddWithValue("@totalavailable", _batches.totalavailable);
				SqlCmd.Parameters.AddWithValue("@totalgivenamount", _batches.totalgivenamount);
				SqlCmd.Parameters.AddWithValue("@totaldebtamount", _batches.totaldebtamount);
				SqlCmd.Parameters.AddWithValue("@totalrefilloperations", _batches.totalrefilloperations);
				SqlCmd.Parameters.AddWithValue("@totalrefillamount", _batches.totalrefillamount);
				SqlCmd.Parameters.AddWithValue("@totalcollectoperations", _batches.totalcollectoperations);
				SqlCmd.Parameters.AddWithValue("@totalcollectamount", _batches.totalcollectamount);
				SqlCmd.Parameters.AddWithValue("@totalcardsdelivered", _batches.totalcardsdelivered);
				SqlCmd.Parameters.AddWithValue("@totalcardrefilloperations", _batches.totalcardrefilloperations);
				SqlCmd.Parameters.AddWithValue("@totalcardrefillamount", _batches.totalcardrefillamount);
				SqlCmd.Parameters.AddWithValue("@totalcardcollectoperations", _batches.totalcardcollectoperations);
				SqlCmd.Parameters.AddWithValue("@totalcardcollectamount", _batches.totalcardcollectamount);
				SqlCmd.Parameters.AddWithValue("@carddispenserstatus", _batches.carddispenserstatus);
				SqlCmd.Parameters.AddWithValue("@totallocks", _batches.totallocks);
				SqlCmd.Parameters.AddWithValue("@opentime", _batches.opentime);
				SqlCmd.Parameters.AddWithValue("@closetime", _batches.closetime);
				SqlCmd.Parameters.AddWithValue("@scannerstatus", _batches.scannerstatus);
				SqlCmd.Parameters.AddWithValue("@motionsensorstatus", _batches.motionsensorstatus);
				SqlCmd.Parameters.AddWithValue("@printerstatus", _batches.printerstatus);
				SqlCmd.Parameters.AddWithValue("@cashacceptorstatus", _batches.cashacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@cashchangerstatus", _batches.cashchangerstatus);
				SqlCmd.Parameters.AddWithValue("@coinacceptorstatus", _batches.coinacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@coinchangerstatus", _batches.coinchangerstatus);
				SqlCmd.Parameters.AddWithValue("@cardreaderstatus", _batches.cardreaderstatus);
				SqlCmd.Parameters.AddWithValue("@blockreason", _batches.blockreason);
				SqlCmd.Parameters.AddWithValue("@blockstatus", _batches.blockstatus);
				SqlCmd.Parameters.AddWithValue("@aceptor_000005", _batches.aceptor_000005);
				SqlCmd.Parameters.AddWithValue("@aceptor_000010", _batches.aceptor_000010);
				SqlCmd.Parameters.AddWithValue("@aceptor_000025", _batches.aceptor_000025);
				SqlCmd.Parameters.AddWithValue("@aceptor_000050", _batches.aceptor_000050);
				SqlCmd.Parameters.AddWithValue("@aceptor_000100", _batches.aceptor_000100);
				SqlCmd.Parameters.AddWithValue("@aceptor_000200", _batches.aceptor_000200);
				SqlCmd.Parameters.AddWithValue("@aceptor_000500", _batches.aceptor_000500);
				SqlCmd.Parameters.AddWithValue("@aceptor_001000", _batches.aceptor_001000);
				SqlCmd.Parameters.AddWithValue("@aceptor_002000", _batches.aceptor_002000);
				SqlCmd.Parameters.AddWithValue("@aceptor_005000", _batches.aceptor_005000);
				SqlCmd.Parameters.AddWithValue("@aceptor_010000", _batches.aceptor_010000);
				SqlCmd.Parameters.AddWithValue("@changer_000005", _batches.changer_000005);
				SqlCmd.Parameters.AddWithValue("@changer_000010", _batches.changer_000010);
				SqlCmd.Parameters.AddWithValue("@changer_000025", _batches.changer_000025);
				SqlCmd.Parameters.AddWithValue("@changer_000050", _batches.changer_000050);
				SqlCmd.Parameters.AddWithValue("@changer_000100", _batches.changer_000100);
				SqlCmd.Parameters.AddWithValue("@changer_000200", _batches.changer_000200);
				SqlCmd.Parameters.AddWithValue("@changer_000500", _batches.changer_000500);
				SqlCmd.Parameters.AddWithValue("@changer_001000", _batches.changer_001000);
				SqlCmd.Parameters.AddWithValue("@changer_002000", _batches.changer_002000);
				SqlCmd.Parameters.AddWithValue("@changer_005000", _batches.changer_005000);
				SqlCmd.Parameters.AddWithValue("@changer_010000", _batches.changer_010000);
				SqlCmd.Parameters.AddWithValue("@return_000005", _batches.return_000005);
				SqlCmd.Parameters.AddWithValue("@return_000010", _batches.return_000010);
				SqlCmd.Parameters.AddWithValue("@return_000025", _batches.return_000025);
				SqlCmd.Parameters.AddWithValue("@return_000050", _batches.return_000050);
				SqlCmd.Parameters.AddWithValue("@return_000100", _batches.return_000100);
				SqlCmd.Parameters.AddWithValue("@return_000200", _batches.return_000200);
				SqlCmd.Parameters.AddWithValue("@return_000500", _batches.return_000500);
				SqlCmd.Parameters.AddWithValue("@return_001000", _batches.return_001000);
				SqlCmd.Parameters.AddWithValue("@return_002000", _batches.return_002000);
				SqlCmd.Parameters.AddWithValue("@return_005000", _batches.return_005000);
				SqlCmd.Parameters.AddWithValue("@return_010000", _batches.return_010000);
				SqlCmd.Parameters.AddWithValue("@return_066666", _batches.return_066666);
				SqlCmd.Parameters.AddWithValue("@aceptor_100000", _batches.aceptor_100000);
				SqlCmd.Parameters.AddWithValue("@aceptor_200000", _batches.aceptor_200000);
				SqlCmd.Parameters.AddWithValue("@aceptor_500000", _batches.aceptor_500000);
				SqlCmd.Parameters.AddWithValue("@aceptor_1000000", _batches.aceptor_1000000);
				SqlCmd.Parameters.AddWithValue("@changer_100000", _batches.changer_100000);
				SqlCmd.Parameters.AddWithValue("@changer_200000", _batches.changer_200000);
				SqlCmd.Parameters.AddWithValue("@changer_500000", _batches.changer_500000);
				SqlCmd.Parameters.AddWithValue("@changer_1000000", _batches.changer_1000000);
				SqlCmd.Parameters.AddWithValue("@return_100000", _batches.return_100000);
				SqlCmd.Parameters.AddWithValue("@return_1000000", _batches.return_1000000);
				SqlCmd.Parameters.AddWithValue("@return_500000", _batches.return_500000);
				SqlCmd.Parameters.AddWithValue("@return_200000", _batches.return_200000);
				SqlCmd.Parameters.AddWithValue("@aceptordetail", _batches.aceptordetail);
				SqlCmd.Parameters.AddWithValue("@changerdetail", _batches.changerdetail);
				SqlCmd.Parameters.AddWithValue("@returndetail", _batches.returndetail);

				SqlCmd.ExecuteNonQuery();
				_batches.id = (System.Int32)pID.Value;
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar batches", _state.error.ToString());
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
		public batches.State Actualizarbatches(batches.Data _batches)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar batches", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_batches_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _batches.id);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _batches.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _batches.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _batches.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _batches.locationidentification);
				SqlCmd.Parameters.AddWithValue("@payloadrequest", _batches.payloadrequest);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _batches.provideridentification);
				SqlCmd.Parameters.AddWithValue("@devicestatus", _batches.devicestatus);
				SqlCmd.Parameters.AddWithValue("@number_", _batches.number_);
				SqlCmd.Parameters.AddWithValue("@status", _batches.status);
				SqlCmd.Parameters.AddWithValue("@opentimestamp", _batches.opentimestamp);
				SqlCmd.Parameters.AddWithValue("@closetimestamp", _batches.closetimestamp);
				SqlCmd.Parameters.AddWithValue("@syncstatus", _batches.syncstatus);
				SqlCmd.Parameters.AddWithValue("@synctimestamp", _batches.synctimestamp);
				SqlCmd.Parameters.AddWithValue("@operativeday", _batches.operativeday);
				SqlCmd.Parameters.AddWithValue("@totaltx", _batches.totaltx);
				SqlCmd.Parameters.AddWithValue("@totalamount", _batches.totalamount);
				SqlCmd.Parameters.AddWithValue("@totalaccepted", _batches.totalaccepted);
				SqlCmd.Parameters.AddWithValue("@totalreturned", _batches.totalreturned);
				SqlCmd.Parameters.AddWithValue("@totalavailable", _batches.totalavailable);
				SqlCmd.Parameters.AddWithValue("@totalgivenamount", _batches.totalgivenamount);
				SqlCmd.Parameters.AddWithValue("@totaldebtamount", _batches.totaldebtamount);
				SqlCmd.Parameters.AddWithValue("@totalrefilloperations", _batches.totalrefilloperations);
				SqlCmd.Parameters.AddWithValue("@totalrefillamount", _batches.totalrefillamount);
				SqlCmd.Parameters.AddWithValue("@totalcollectoperations", _batches.totalcollectoperations);
				SqlCmd.Parameters.AddWithValue("@totalcollectamount", _batches.totalcollectamount);
				SqlCmd.Parameters.AddWithValue("@totalcardsdelivered", _batches.totalcardsdelivered);
				SqlCmd.Parameters.AddWithValue("@totalcardrefilloperations", _batches.totalcardrefilloperations);
				SqlCmd.Parameters.AddWithValue("@totalcardrefillamount", _batches.totalcardrefillamount);
				SqlCmd.Parameters.AddWithValue("@totalcardcollectoperations", _batches.totalcardcollectoperations);
				SqlCmd.Parameters.AddWithValue("@totalcardcollectamount", _batches.totalcardcollectamount);
				SqlCmd.Parameters.AddWithValue("@carddispenserstatus", _batches.carddispenserstatus);
				SqlCmd.Parameters.AddWithValue("@totallocks", _batches.totallocks);
				SqlCmd.Parameters.AddWithValue("@opentime", _batches.opentime);
				SqlCmd.Parameters.AddWithValue("@closetime", _batches.closetime);
				SqlCmd.Parameters.AddWithValue("@scannerstatus", _batches.scannerstatus);
				SqlCmd.Parameters.AddWithValue("@motionsensorstatus", _batches.motionsensorstatus);
				SqlCmd.Parameters.AddWithValue("@printerstatus", _batches.printerstatus);
				SqlCmd.Parameters.AddWithValue("@cashacceptorstatus", _batches.cashacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@cashchangerstatus", _batches.cashchangerstatus);
				SqlCmd.Parameters.AddWithValue("@coinacceptorstatus", _batches.coinacceptorstatus);
				SqlCmd.Parameters.AddWithValue("@coinchangerstatus", _batches.coinchangerstatus);
				SqlCmd.Parameters.AddWithValue("@cardreaderstatus", _batches.cardreaderstatus);
				SqlCmd.Parameters.AddWithValue("@blockreason", _batches.blockreason);
				SqlCmd.Parameters.AddWithValue("@blockstatus", _batches.blockstatus);
				SqlCmd.Parameters.AddWithValue("@aceptor_000005", _batches.aceptor_000005);
				SqlCmd.Parameters.AddWithValue("@aceptor_000010", _batches.aceptor_000010);
				SqlCmd.Parameters.AddWithValue("@aceptor_000025", _batches.aceptor_000025);
				SqlCmd.Parameters.AddWithValue("@aceptor_000050", _batches.aceptor_000050);
				SqlCmd.Parameters.AddWithValue("@aceptor_000100", _batches.aceptor_000100);
				SqlCmd.Parameters.AddWithValue("@aceptor_000200", _batches.aceptor_000200);
				SqlCmd.Parameters.AddWithValue("@aceptor_000500", _batches.aceptor_000500);
				SqlCmd.Parameters.AddWithValue("@aceptor_001000", _batches.aceptor_001000);
				SqlCmd.Parameters.AddWithValue("@aceptor_002000", _batches.aceptor_002000);
				SqlCmd.Parameters.AddWithValue("@aceptor_005000", _batches.aceptor_005000);
				SqlCmd.Parameters.AddWithValue("@aceptor_010000", _batches.aceptor_010000);
				SqlCmd.Parameters.AddWithValue("@changer_000005", _batches.changer_000005);
				SqlCmd.Parameters.AddWithValue("@changer_000010", _batches.changer_000010);
				SqlCmd.Parameters.AddWithValue("@changer_000025", _batches.changer_000025);
				SqlCmd.Parameters.AddWithValue("@changer_000050", _batches.changer_000050);
				SqlCmd.Parameters.AddWithValue("@changer_000100", _batches.changer_000100);
				SqlCmd.Parameters.AddWithValue("@changer_000200", _batches.changer_000200);
				SqlCmd.Parameters.AddWithValue("@changer_000500", _batches.changer_000500);
				SqlCmd.Parameters.AddWithValue("@changer_001000", _batches.changer_001000);
				SqlCmd.Parameters.AddWithValue("@changer_002000", _batches.changer_002000);
				SqlCmd.Parameters.AddWithValue("@changer_005000", _batches.changer_005000);
				SqlCmd.Parameters.AddWithValue("@changer_010000", _batches.changer_010000);
				SqlCmd.Parameters.AddWithValue("@return_000005", _batches.return_000005);
				SqlCmd.Parameters.AddWithValue("@return_000010", _batches.return_000010);
				SqlCmd.Parameters.AddWithValue("@return_000025", _batches.return_000025);
				SqlCmd.Parameters.AddWithValue("@return_000050", _batches.return_000050);
				SqlCmd.Parameters.AddWithValue("@return_000100", _batches.return_000100);
				SqlCmd.Parameters.AddWithValue("@return_000200", _batches.return_000200);
				SqlCmd.Parameters.AddWithValue("@return_000500", _batches.return_000500);
				SqlCmd.Parameters.AddWithValue("@return_001000", _batches.return_001000);
				SqlCmd.Parameters.AddWithValue("@return_002000", _batches.return_002000);
				SqlCmd.Parameters.AddWithValue("@return_005000", _batches.return_005000);
				SqlCmd.Parameters.AddWithValue("@return_010000", _batches.return_010000);
				SqlCmd.Parameters.AddWithValue("@return_066666", _batches.return_066666);
				SqlCmd.Parameters.AddWithValue("@aceptor_100000", _batches.aceptor_100000);
				SqlCmd.Parameters.AddWithValue("@aceptor_200000", _batches.aceptor_200000);
				SqlCmd.Parameters.AddWithValue("@aceptor_500000", _batches.aceptor_500000);
				SqlCmd.Parameters.AddWithValue("@aceptor_1000000", _batches.aceptor_1000000);
				SqlCmd.Parameters.AddWithValue("@changer_100000", _batches.changer_100000);
				SqlCmd.Parameters.AddWithValue("@changer_200000", _batches.changer_200000);
				SqlCmd.Parameters.AddWithValue("@changer_500000", _batches.changer_500000);
				SqlCmd.Parameters.AddWithValue("@changer_1000000", _batches.changer_1000000);
				SqlCmd.Parameters.AddWithValue("@return_100000", _batches.return_100000);
				SqlCmd.Parameters.AddWithValue("@return_1000000", _batches.return_1000000);
				SqlCmd.Parameters.AddWithValue("@return_500000", _batches.return_500000);
				SqlCmd.Parameters.AddWithValue("@return_200000", _batches.return_200000);
				SqlCmd.Parameters.AddWithValue("@aceptordetail", _batches.aceptordetail);
				SqlCmd.Parameters.AddWithValue("@changerdetail", _batches.changerdetail);
				SqlCmd.Parameters.AddWithValue("@returndetail", _batches.returndetail);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar batches", _state.error.ToString());
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
		public batches.State Eliminarbatches(batches.Data _batches)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar batches", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_batches_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _batches.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar batches", _state.error.ToString());
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
