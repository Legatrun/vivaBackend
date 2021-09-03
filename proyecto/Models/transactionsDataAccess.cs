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
	public class transactionsDataAccess
	{
		transactions.State _state = new transactions.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public transactions Consultartransactions()
		{
		    _log.Traceo("Ingresa a Metodo Consultar transactions", "0");
			List<transactions.Data> lsttransactions = new List<transactions.Data>();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_transactions_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					transactions.Data _transactions= new transactions.Data();
					_transactions.id = Convert.ToInt32(rdr["id"].ToString());
					_transactions.createtimestamp = !rdr.IsDBNull(1) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_transactions.updatetimestamp = !rdr.IsDBNull(2) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_transactions.deviceidentification = !rdr.IsDBNull(3) ? Convert.ToString(rdr["deviceidentification"].ToString()) : "";
					_transactions.locationidentification = !rdr.IsDBNull(4) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
					_transactions.servicename = !rdr.IsDBNull(5) ? Convert.ToString(rdr["servicename"].ToString()) : "";
					_transactions.operationname = !rdr.IsDBNull(6) ? Convert.ToString(rdr["operationname"].ToString()) : "";
					_transactions.sequencenumber = !rdr.IsDBNull(7) ? Convert.ToInt32(rdr["sequencenumber"].ToString()) : (System.Int32)0;
					_transactions.transporttimestamp = !rdr.IsDBNull(8) ? Convert.ToDateTime(rdr["transporttimestamp"].ToString()) : System.DateTime.Now;
					_transactions.payloadrequest = !rdr.IsDBNull(9) ? Convert.ToString(rdr["payloadrequest"].ToString()) : "";
					_transactions.payloadanswer = !rdr.IsDBNull(10) ? Convert.ToString(rdr["payloadanswer"].ToString()) : "";
					_transactions.resultcode = !rdr.IsDBNull(11) ? Convert.ToInt32(rdr["resultcode"].ToString()) : (System.Int32)0;
					_transactions.resultmessage = !rdr.IsDBNull(12) ? Convert.ToString(rdr["resultmessage"].ToString()) : "";
					_transactions.provideridentification = !rdr.IsDBNull(13) ? Convert.ToString(rdr["provideridentification"].ToString()) : "";
					_transactions.providertransactionid = !rdr.IsDBNull(14) ? Convert.ToString(rdr["providertransactionid"].ToString()) : "";
					_transactions.devicetransactionid = !rdr.IsDBNull(15) ? Convert.ToString(rdr["devicetransactionid"].ToString()) : "";
					_transactions.providerresultcode = !rdr.IsDBNull(16) ? Convert.ToString(rdr["providerresultcode"].ToString()) : "";
					_transactions.providerresultmessage = !rdr.IsDBNull(17) ? Convert.ToString(rdr["providerresultmessage"].ToString()) : "";
					_transactions.batchnumber = !rdr.IsDBNull(18) ? Convert.ToInt32(rdr["batchnumber"].ToString()) : (System.Int32)0;
					_transactions.syncstatus = !rdr.IsDBNull(19) ? Convert.ToInt32(rdr["syncstatus"].ToString()) : (System.Int32)0;
					_transactions.synctimestamp = !rdr.IsDBNull(20) ? Convert.ToDateTime(rdr["synctimestamp"].ToString()) : System.DateTime.Now;
					_transactions.deviceidentificationprovider = !rdr.IsDBNull(21) ? Convert.ToString(rdr["deviceidentificationprovider"].ToString()) : "";
					_transactions.locationidentificationprovider = !rdr.IsDBNull(22) ? Convert.ToString(rdr["locationidentificationprovider"].ToString()) : "";
					_transactions.customernumber = !rdr.IsDBNull(23) ? Convert.ToString(rdr["customernumber"].ToString()) : "";
					_transactions.amount = !rdr.IsDBNull(24) ? Convert.ToDecimal(rdr["amount"].ToString()) : (System.Decimal)0;
					_transactions.amountentered = !rdr.IsDBNull(25) ? Convert.ToDecimal(rdr["amountentered"].ToString()) : (System.Decimal)0;
					_transactions.amountreturned = !rdr.IsDBNull(26) ? Convert.ToDecimal(rdr["amountreturned"].ToString()) : (System.Decimal)0;
					_transactions.amountticketundelivered = !rdr.IsDBNull(27) ? Convert.ToDecimal(rdr["amountticketundelivered"].ToString()) : (System.Decimal)0;
					_transactions.operationstatus = !rdr.IsDBNull(28) ? Convert.ToInt32(rdr["operationstatus"].ToString()) : (System.Int32)0;
					_transactions.amountentereddetail = !rdr.IsDBNull(29) ? Convert.ToString(rdr["amountentereddetail"].ToString()) : "";
					_transactions.amountreturneddetail = !rdr.IsDBNull(30) ? Convert.ToString(rdr["amountreturneddetail"].ToString()) : "";
					_transactions.amountticketundelivereddetail = !rdr.IsDBNull(31) ? Convert.ToString(rdr["amountticketundelivereddetail"].ToString()) : "";
					_transactions.transactionidentification = !rdr.IsDBNull(32) ? Convert.ToString(rdr["transactionidentification"].ToString()) : "";
					_transactions.customercode = !rdr.IsDBNull(33) ? Convert.ToString(rdr["customercode"].ToString()) : "";
					_transactions.canceled = !rdr.IsDBNull(34) ? Convert.ToInt32(rdr["canceled"].ToString()) : (System.Int32)0;
					_transactions.canceledtimestamp = !rdr.IsDBNull(35) ? Convert.ToDateTime(rdr["canceledtimestamp"].ToString()) : System.DateTime.Now;
					_transactions.providersequencenumber = !rdr.IsDBNull(36) ? Convert.ToInt32(rdr["providersequencenumber"].ToString()) : (System.Int32)0;
					_transactions.cardsdispensed = !rdr.IsDBNull(37) ? Convert.ToInt32(rdr["cardsdispensed"].ToString()) : (System.Int32)0;
					lsttransactions.Add(_transactions);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar transactions", _state.error.ToString());
				return new transactions(_state, lsttransactions);
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
			return new transactions(_state);
		}
        public transactions ConsultartransactionsPorPaginacion(transactions.Data transactionsData)
        {
            _log.Traceo("Ingresa a Metodo Consultar por Paginacion transactions", "0");
            List<transactions.Data> lsttransactions = new List<transactions.Data>();
            transactions.Pagination _transactionsPagination = new transactions.Pagination();
            try
            {
                MySqlConnection SqlCnn;
                SqlCnn = Base.AbrirConexionMySql();
                MySqlCommand SqlCmd = new MySqlCommand("Proc_transactions_Select_Pagination", SqlCnn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@initPagination", transactionsData.initPagination);
                SqlCmd.Parameters.AddWithValue("@quantityPagination", transactionsData.quantityPagination);
                MySqlDataReader rdr = SqlCmd.ExecuteReader();
                var number = transactionsData.initPagination;
                while (rdr.Read())
                {
                    transactions.Data _transactions = new transactions.Data();
                    _transactions.id = Convert.ToInt32(rdr["id"].ToString());
                    _transactions.createtimestamp = !rdr.IsDBNull(1) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
                    _transactions.updatetimestamp = !rdr.IsDBNull(2) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
                    _transactions.deviceidentification = !rdr.IsDBNull(3) ? Convert.ToString(rdr["deviceidentification"].ToString()) : "";
                    _transactions.locationidentification = !rdr.IsDBNull(4) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
                    _transactions.servicename = !rdr.IsDBNull(5) ? Convert.ToString(rdr["servicename"].ToString()) : "";
                    _transactions.operationname = !rdr.IsDBNull(6) ? Convert.ToString(rdr["operationname"].ToString()) : "";
                    _transactions.sequencenumber = !rdr.IsDBNull(7) ? Convert.ToInt32(rdr["sequencenumber"].ToString()) : (System.Int32)0;
                    _transactions.transporttimestamp = !rdr.IsDBNull(8) ? Convert.ToDateTime(rdr["transporttimestamp"].ToString()) : System.DateTime.Now;
                    _transactions.payloadrequest = !rdr.IsDBNull(9) ? Convert.ToString(rdr["payloadrequest"].ToString()) : "";
                    _transactions.payloadanswer = !rdr.IsDBNull(10) ? Convert.ToString(rdr["payloadanswer"].ToString()) : "";
                    _transactions.resultcode = !rdr.IsDBNull(11) ? Convert.ToInt32(rdr["resultcode"].ToString()) : (System.Int32)0;
                    _transactions.resultmessage = !rdr.IsDBNull(12) ? Convert.ToString(rdr["resultmessage"].ToString()) : "";
                    _transactions.provideridentification = !rdr.IsDBNull(13) ? Convert.ToString(rdr["provideridentification"].ToString()) : "";
                    _transactions.providertransactionid = !rdr.IsDBNull(14) ? Convert.ToString(rdr["providertransactionid"].ToString()) : "";
                    _transactions.devicetransactionid = !rdr.IsDBNull(15) ? Convert.ToString(rdr["devicetransactionid"].ToString()) : "";
                    _transactions.providerresultcode = !rdr.IsDBNull(16) ? Convert.ToString(rdr["providerresultcode"].ToString()) : "";
                    _transactions.providerresultmessage = !rdr.IsDBNull(17) ? Convert.ToString(rdr["providerresultmessage"].ToString()) : "";
                    _transactions.batchnumber = !rdr.IsDBNull(18) ? Convert.ToInt32(rdr["batchnumber"].ToString()) : (System.Int32)0;
                    _transactions.syncstatus = !rdr.IsDBNull(19) ? Convert.ToInt32(rdr["syncstatus"].ToString()) : (System.Int32)0;
                    _transactions.synctimestamp = !rdr.IsDBNull(20) ? Convert.ToDateTime(rdr["synctimestamp"].ToString()) : System.DateTime.Now;
                    _transactions.deviceidentificationprovider = !rdr.IsDBNull(21) ? Convert.ToString(rdr["deviceidentificationprovider"].ToString()) : "";
                    _transactions.locationidentificationprovider = !rdr.IsDBNull(22) ? Convert.ToString(rdr["locationidentificationprovider"].ToString()) : "";
                    _transactions.customernumber = !rdr.IsDBNull(23) ? Convert.ToString(rdr["customernumber"].ToString()) : "";
                    _transactions.amount = !rdr.IsDBNull(24) ? Convert.ToDecimal(rdr["amount"].ToString()) : (System.Decimal)0;
                    _transactions.amountentered = !rdr.IsDBNull(25) ? Convert.ToDecimal(rdr["amountentered"].ToString()) : (System.Decimal)0;
                    _transactions.amountreturned = !rdr.IsDBNull(26) ? Convert.ToDecimal(rdr["amountreturned"].ToString()) : (System.Decimal)0;
                    _transactions.amountticketundelivered = !rdr.IsDBNull(27) ? Convert.ToDecimal(rdr["amountticketundelivered"].ToString()) : (System.Decimal)0;
                    _transactions.operationstatus = !rdr.IsDBNull(28) ? Convert.ToInt32(rdr["operationstatus"].ToString()) : (System.Int32)0;
                    _transactions.amountentereddetail = !rdr.IsDBNull(29) ? Convert.ToString(rdr["amountentereddetail"].ToString()) : "";
                    _transactions.amountreturneddetail = !rdr.IsDBNull(30) ? Convert.ToString(rdr["amountreturneddetail"].ToString()) : "";
                    _transactions.amountticketundelivereddetail = !rdr.IsDBNull(31) ? Convert.ToString(rdr["amountticketundelivereddetail"].ToString()) : "";
                    _transactions.transactionidentification = !rdr.IsDBNull(32) ? Convert.ToString(rdr["transactionidentification"].ToString()) : "";
                    _transactions.customercode = !rdr.IsDBNull(33) ? Convert.ToString(rdr["customercode"].ToString()) : "";
                    _transactions.canceled = !rdr.IsDBNull(34) ? Convert.ToInt32(rdr["canceled"].ToString()) : (System.Int32)0;
                    _transactions.canceledtimestamp = !rdr.IsDBNull(35) ? Convert.ToDateTime(rdr["canceledtimestamp"].ToString()) : System.DateTime.Now;
                    _transactions.providersequencenumber = !rdr.IsDBNull(36) ? Convert.ToInt32(rdr["providersequencenumber"].ToString()) : (System.Int32)0;
                    _transactions.cardsdispensed = !rdr.IsDBNull(37) ? Convert.ToInt32(rdr["cardsdispensed"].ToString()) : (System.Int32)0;
                    _transactions.numberOfItemPagination = number++;
                    _transactionsPagination.itemsLengthPagination = !rdr.IsDBNull(38) ? Convert.ToInt32(rdr["TotalItems"].ToString()) : 0;
                    lsttransactions.Add(_transactions);
                }
                _transactionsPagination.initPagination = transactionsData.initPagination;
                _transactionsPagination.quantityPagination = transactionsData.quantityPagination;
                _transactionsPagination.itemsPerPagePagination = lsttransactions.Count;
                Base.CerrarConexionMySql(SqlCnn);
                _state.error = 0;
                _state.descripcion = "Operacion Realizada";
                _log.Traceo(_state.descripcion + " Operacion Buscar batches", _state.error.ToString());
                return new transactions(_state, lsttransactions, _transactionsPagination);
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
            return new transactions(_state);
        }


		public transactions ConsultartransactionsPorFiltro(transactions.Data transactionsData)
		{
			List<transactions.Data> lsttransactions = new List<transactions.Data>();
			transactions.Pagination _transactionsPagination = new transactions.Pagination();
			try
			{
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_transactions_Select_Filter", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@LOCATIONIDENTIFICATION", transactionsData.locationidentification);
				SqlCmd.Parameters.AddWithValue("@DEVICEIDENTIFICATION", transactionsData.deviceidentification);
                SqlCmd.Parameters.AddWithValue("@OPENTIMESTAMP", transactionsData.opentimestamp);
                SqlCmd.Parameters.AddWithValue("@CLOSETIMESTAMP", transactionsData.closetimestamp);
                SqlCmd.Parameters.AddWithValue("@OPERATIONNAME", transactionsData.operationname);
				SqlCmd.Parameters.AddWithValue("@initPagination", transactionsData.initPagination);
				SqlCmd.Parameters.AddWithValue("@quantityPagination", transactionsData.quantityPagination);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				var number = transactionsData.initPagination;
				while (rdr.Read())
				{
					transactions.Data _transactions = new transactions.Data();
					_transactions.createtimestamp = !rdr.IsDBNull(rdr.GetOrdinal("createtimestamp")) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : Convert.ToDateTime("01/01/2000");
                    _transactions.locationidentification = !rdr.IsDBNull(rdr.GetOrdinal("locationidentification")) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
                    _transactions.deviceidentification = !rdr.IsDBNull(rdr.GetOrdinal("deviceidentification")) ? Convert.ToString(rdr["deviceidentification"].ToString()) : "";
                    _transactions.operationname = !rdr.IsDBNull(rdr.GetOrdinal("operationname")) ? Convert.ToString(rdr["operationname"].ToString()) : "";
                    _transactions.customernumber = !rdr.IsDBNull(rdr.GetOrdinal("customernumber")) ? Convert.ToString(rdr["customernumber"].ToString()) : "";
                    _transactions.transactionidentification = !rdr.IsDBNull(rdr.GetOrdinal("transactionidentification")) ? Convert.ToString(rdr["transactionidentification"].ToString()) : "";
                    _transactions.amount = !rdr.IsDBNull(rdr.GetOrdinal("amount")) ? Convert.ToDecimal(rdr["amount"].ToString()) : (System.Decimal)0;
                    _transactions.resultcode = !rdr.IsDBNull(rdr.GetOrdinal("resultcode")) ? Convert.ToInt32(rdr["resultcode"].ToString()) : (System.Int32)0;
                    _transactions.amountreturned = !rdr.IsDBNull(rdr.GetOrdinal("amountreturned")) ? Convert.ToDecimal(rdr["amountreturned"].ToString()) : (System.Decimal)0;
                    _transactions.amountticketundelivered = !rdr.IsDBNull(rdr.GetOrdinal("amountticketundelivered")) ? Convert.ToDecimal(rdr["amountticketundelivered"].ToString()) : (System.Decimal)0;
                    _transactions.amountreturneddetail = !rdr.IsDBNull(rdr.GetOrdinal("amountentereddetail")) ? Convert.ToString(rdr["amountentereddetail"].ToString()) : "";
                    _transactions.amountticketundelivereddetail = !rdr.IsDBNull(rdr.GetOrdinal("amountticketundelivereddetail")) ? Convert.ToString(rdr["amountticketundelivereddetail"].ToString()) : "";
					_transactions.numberOfItemPagination = number++;
					lsttransactions.Add(_transactions);
				}
				_transactionsPagination.initPagination = transactionsData.initPagination;
				_transactionsPagination.quantityPagination = transactionsData.quantityPagination;
				_transactionsPagination.itemsPerPagePagination = lsttransactions.Count;
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar batches", _state.error.ToString());
				return new transactions(_state, lsttransactions, _transactionsPagination);
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
			return new transactions(_state);
		}

		public transactions Buscartransactions(transactions.Data _transactionsData)
		{
			List<transactions.Data> lsttransactions = new List<transactions.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar transactions", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_transactions_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@pID", _transactionsData.id);
				MySqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					transactions.Data _transactions= new transactions.Data();
					_transactions.id = Convert.ToInt32(rdr["id"].ToString());
					_transactions.createtimestamp = !rdr.IsDBNull(1) ? Convert.ToDateTime(rdr["createtimestamp"].ToString()) : System.DateTime.Now;
					_transactions.updatetimestamp = !rdr.IsDBNull(2) ? Convert.ToDateTime(rdr["updatetimestamp"].ToString()) : System.DateTime.Now;
					_transactions.deviceidentification = !rdr.IsDBNull(3) ? Convert.ToString(rdr["deviceidentification"].ToString()) : "";
					_transactions.locationidentification = !rdr.IsDBNull(4) ? Convert.ToString(rdr["locationidentification"].ToString()) : "";
					_transactions.servicename = !rdr.IsDBNull(5) ? Convert.ToString(rdr["servicename"].ToString()) : "";
					_transactions.operationname = !rdr.IsDBNull(6) ? Convert.ToString(rdr["operationname"].ToString()) : "";
					_transactions.sequencenumber = !rdr.IsDBNull(7) ? Convert.ToInt32(rdr["sequencenumber"].ToString()) : (System.Int32)0;
					_transactions.transporttimestamp = !rdr.IsDBNull(8) ? Convert.ToDateTime(rdr["transporttimestamp"].ToString()) : System.DateTime.Now;
					_transactions.payloadrequest = !rdr.IsDBNull(9) ? Convert.ToString(rdr["payloadrequest"].ToString()) : "";
					_transactions.payloadanswer = !rdr.IsDBNull(10) ? Convert.ToString(rdr["payloadanswer"].ToString()) : "";
					_transactions.resultcode = !rdr.IsDBNull(11) ? Convert.ToInt32(rdr["resultcode"].ToString()) : (System.Int32)0;
					_transactions.resultmessage = !rdr.IsDBNull(12) ? Convert.ToString(rdr["resultmessage"].ToString()) : "";
					_transactions.provideridentification = !rdr.IsDBNull(13) ? Convert.ToString(rdr["provideridentification"].ToString()) : "";
					_transactions.providertransactionid = !rdr.IsDBNull(14) ? Convert.ToString(rdr["providertransactionid"].ToString()) : "";
					_transactions.devicetransactionid = !rdr.IsDBNull(15) ? Convert.ToString(rdr["devicetransactionid"].ToString()) : "";
					_transactions.providerresultcode = !rdr.IsDBNull(16) ? Convert.ToString(rdr["providerresultcode"].ToString()) : "";
					_transactions.providerresultmessage = !rdr.IsDBNull(17) ? Convert.ToString(rdr["providerresultmessage"].ToString()) : "";
					_transactions.batchnumber = !rdr.IsDBNull(18) ? Convert.ToInt32(rdr["batchnumber"].ToString()) : (System.Int32)0;
					_transactions.syncstatus = !rdr.IsDBNull(19) ? Convert.ToInt32(rdr["syncstatus"].ToString()) : (System.Int32)0;
					_transactions.synctimestamp = !rdr.IsDBNull(20) ? Convert.ToDateTime(rdr["synctimestamp"].ToString()) : System.DateTime.Now;
					_transactions.deviceidentificationprovider = !rdr.IsDBNull(21) ? Convert.ToString(rdr["deviceidentificationprovider"].ToString()) : "";
					_transactions.locationidentificationprovider = !rdr.IsDBNull(22) ? Convert.ToString(rdr["locationidentificationprovider"].ToString()) : "";
					_transactions.customernumber = !rdr.IsDBNull(23) ? Convert.ToString(rdr["customernumber"].ToString()) : "";
					_transactions.amount = !rdr.IsDBNull(24) ? Convert.ToDecimal(rdr["amount"].ToString()) : (System.Decimal)0;
					_transactions.amountentered = !rdr.IsDBNull(25) ? Convert.ToDecimal(rdr["amountentered"].ToString()) : (System.Decimal)0;
					_transactions.amountreturned = !rdr.IsDBNull(26) ? Convert.ToDecimal(rdr["amountreturned"].ToString()) : (System.Decimal)0;
					_transactions.amountticketundelivered = !rdr.IsDBNull(27) ? Convert.ToDecimal(rdr["amountticketundelivered"].ToString()) : (System.Decimal)0;
					_transactions.operationstatus = !rdr.IsDBNull(28) ? Convert.ToInt32(rdr["operationstatus"].ToString()) : (System.Int32)0;
					_transactions.amountentereddetail = !rdr.IsDBNull(29) ? Convert.ToString(rdr["amountentereddetail"].ToString()) : "";
					_transactions.amountreturneddetail = !rdr.IsDBNull(30) ? Convert.ToString(rdr["amountreturneddetail"].ToString()) : "";
					_transactions.amountticketundelivereddetail = !rdr.IsDBNull(31) ? Convert.ToString(rdr["amountticketundelivereddetail"].ToString()) : "";
					_transactions.transactionidentification = !rdr.IsDBNull(32) ? Convert.ToString(rdr["transactionidentification"].ToString()) : "";
					_transactions.customercode = !rdr.IsDBNull(33) ? Convert.ToString(rdr["customercode"].ToString()) : "";
					_transactions.canceled = !rdr.IsDBNull(34) ? Convert.ToInt32(rdr["canceled"].ToString()) : (System.Int32)0;
					_transactions.canceledtimestamp = !rdr.IsDBNull(35) ? Convert.ToDateTime(rdr["canceledtimestamp"].ToString()) : System.DateTime.Now;
					_transactions.providersequencenumber = !rdr.IsDBNull(36) ? Convert.ToInt32(rdr["providersequencenumber"].ToString()) : (System.Int32)0;
					_transactions.cardsdispensed = !rdr.IsDBNull(37) ? Convert.ToInt32(rdr["cardsdispensed"].ToString()) : (System.Int32)0;
					lsttransactions.Add(_transactions);
				}
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar transactions", _state.error.ToString());
				return new transactions(_state, lsttransactions);
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
			return new transactions(_state);
		}
		public transactions.State Insertartransactions(transactions.Data _transactions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar transactions", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_transactions_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				MySqlParameter pID = new MySqlParameter();
				pID.ParameterName = "@ID";
				pID.Value = 0;
				SqlCmd.Parameters.Add(pID);
				pID.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _transactions.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _transactions.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _transactions.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _transactions.locationidentification);
				SqlCmd.Parameters.AddWithValue("@servicename", _transactions.servicename);
				SqlCmd.Parameters.AddWithValue("@operationname", _transactions.operationname);
				SqlCmd.Parameters.AddWithValue("@sequencenumber", _transactions.sequencenumber);
				SqlCmd.Parameters.AddWithValue("@transporttimestamp", _transactions.transporttimestamp);
				SqlCmd.Parameters.AddWithValue("@payloadrequest", _transactions.payloadrequest);
				SqlCmd.Parameters.AddWithValue("@payloadanswer", _transactions.payloadanswer);
				SqlCmd.Parameters.AddWithValue("@resultcode", _transactions.resultcode);
				SqlCmd.Parameters.AddWithValue("@resultmessage", _transactions.resultmessage);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _transactions.provideridentification);
				SqlCmd.Parameters.AddWithValue("@providertransactionid", _transactions.providertransactionid);
				SqlCmd.Parameters.AddWithValue("@devicetransactionid", _transactions.devicetransactionid);
				SqlCmd.Parameters.AddWithValue("@providerresultcode", _transactions.providerresultcode);
				SqlCmd.Parameters.AddWithValue("@providerresultmessage", _transactions.providerresultmessage);
				SqlCmd.Parameters.AddWithValue("@batchnumber", _transactions.batchnumber);
				SqlCmd.Parameters.AddWithValue("@syncstatus", _transactions.syncstatus);
				SqlCmd.Parameters.AddWithValue("@synctimestamp", _transactions.synctimestamp);
				SqlCmd.Parameters.AddWithValue("@deviceidentificationprovider", _transactions.deviceidentificationprovider);
				SqlCmd.Parameters.AddWithValue("@locationidentificationprovider", _transactions.locationidentificationprovider);
				SqlCmd.Parameters.AddWithValue("@customernumber", _transactions.customernumber);
				SqlCmd.Parameters.AddWithValue("@amount", _transactions.amount);
				SqlCmd.Parameters.AddWithValue("@amountentered", _transactions.amountentered);
				SqlCmd.Parameters.AddWithValue("@amountreturned", _transactions.amountreturned);
				SqlCmd.Parameters.AddWithValue("@amountticketundelivered", _transactions.amountticketundelivered);
				SqlCmd.Parameters.AddWithValue("@operationstatus", _transactions.operationstatus);
				SqlCmd.Parameters.AddWithValue("@amountentereddetail", _transactions.amountentereddetail);
				SqlCmd.Parameters.AddWithValue("@amountreturneddetail", _transactions.amountreturneddetail);
				SqlCmd.Parameters.AddWithValue("@amountticketundelivereddetail", _transactions.amountticketundelivereddetail);
				SqlCmd.Parameters.AddWithValue("@transactionidentification", _transactions.transactionidentification);
				SqlCmd.Parameters.AddWithValue("@customercode", _transactions.customercode);
				SqlCmd.Parameters.AddWithValue("@canceled", _transactions.canceled);
				SqlCmd.Parameters.AddWithValue("@canceledtimestamp", _transactions.canceledtimestamp);
				SqlCmd.Parameters.AddWithValue("@providersequencenumber", _transactions.providersequencenumber);
				SqlCmd.Parameters.AddWithValue("@cardsdispensed", _transactions.cardsdispensed);

				SqlCmd.ExecuteNonQuery();
				_transactions.id = (System.Int32)pID.Value;
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar transactions", _state.error.ToString());
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
		public transactions.State Actualizartransactions(transactions.Data _transactions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar transactions", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_transactions_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _transactions.id);
				SqlCmd.Parameters.AddWithValue("@createtimestamp", _transactions.createtimestamp);
				SqlCmd.Parameters.AddWithValue("@updatetimestamp", _transactions.updatetimestamp);
				SqlCmd.Parameters.AddWithValue("@deviceidentification", _transactions.deviceidentification);
				SqlCmd.Parameters.AddWithValue("@locationidentification", _transactions.locationidentification);
				SqlCmd.Parameters.AddWithValue("@servicename", _transactions.servicename);
				SqlCmd.Parameters.AddWithValue("@operationname", _transactions.operationname);
				SqlCmd.Parameters.AddWithValue("@sequencenumber", _transactions.sequencenumber);
				SqlCmd.Parameters.AddWithValue("@transporttimestamp", _transactions.transporttimestamp);
				SqlCmd.Parameters.AddWithValue("@payloadrequest", _transactions.payloadrequest);
				SqlCmd.Parameters.AddWithValue("@payloadanswer", _transactions.payloadanswer);
				SqlCmd.Parameters.AddWithValue("@resultcode", _transactions.resultcode);
				SqlCmd.Parameters.AddWithValue("@resultmessage", _transactions.resultmessage);
				SqlCmd.Parameters.AddWithValue("@provideridentification", _transactions.provideridentification);
				SqlCmd.Parameters.AddWithValue("@providertransactionid", _transactions.providertransactionid);
				SqlCmd.Parameters.AddWithValue("@devicetransactionid", _transactions.devicetransactionid);
				SqlCmd.Parameters.AddWithValue("@providerresultcode", _transactions.providerresultcode);
				SqlCmd.Parameters.AddWithValue("@providerresultmessage", _transactions.providerresultmessage);
				SqlCmd.Parameters.AddWithValue("@batchnumber", _transactions.batchnumber);
				SqlCmd.Parameters.AddWithValue("@syncstatus", _transactions.syncstatus);
				SqlCmd.Parameters.AddWithValue("@synctimestamp", _transactions.synctimestamp);
				SqlCmd.Parameters.AddWithValue("@deviceidentificationprovider", _transactions.deviceidentificationprovider);
				SqlCmd.Parameters.AddWithValue("@locationidentificationprovider", _transactions.locationidentificationprovider);
				SqlCmd.Parameters.AddWithValue("@customernumber", _transactions.customernumber);
				SqlCmd.Parameters.AddWithValue("@amount", _transactions.amount);
				SqlCmd.Parameters.AddWithValue("@amountentered", _transactions.amountentered);
				SqlCmd.Parameters.AddWithValue("@amountreturned", _transactions.amountreturned);
				SqlCmd.Parameters.AddWithValue("@amountticketundelivered", _transactions.amountticketundelivered);
				SqlCmd.Parameters.AddWithValue("@operationstatus", _transactions.operationstatus);
				SqlCmd.Parameters.AddWithValue("@amountentereddetail", _transactions.amountentereddetail);
				SqlCmd.Parameters.AddWithValue("@amountreturneddetail", _transactions.amountreturneddetail);
				SqlCmd.Parameters.AddWithValue("@amountticketundelivereddetail", _transactions.amountticketundelivereddetail);
				SqlCmd.Parameters.AddWithValue("@transactionidentification", _transactions.transactionidentification);
				SqlCmd.Parameters.AddWithValue("@customercode", _transactions.customercode);
				SqlCmd.Parameters.AddWithValue("@canceled", _transactions.canceled);
				SqlCmd.Parameters.AddWithValue("@canceledtimestamp", _transactions.canceledtimestamp);
				SqlCmd.Parameters.AddWithValue("@providersequencenumber", _transactions.providersequencenumber);
				SqlCmd.Parameters.AddWithValue("@cardsdispensed", _transactions.cardsdispensed);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar transactions", _state.error.ToString());
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
		public transactions.State Eliminartransactions(transactions.Data _transactions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar transactions", "0");
				MySqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexionMySql();
				MySqlCommand SqlCmd = new MySqlCommand("Proc_transactions_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _transactions.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexionMySql(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar transactions", _state.error.ToString());
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

        public transactions.Pagination Countertransactions()
        {
            transactions.Pagination _transactions = new transactions.Pagination();
            try
            {
                _log.Traceo("Ingresa a Metodo Counter batches", "0");
                MySqlConnection SqlCnn;
                SqlCnn = Base.AbrirConexionMySql();
                MySqlCommand SqlCmd = new MySqlCommand("Proc_batches_Count", SqlCnn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader rdr = SqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    _transactions.itemsLengthPagination = Convert.ToInt32(rdr["itemsLength"].ToString());
                }
                Base.CerrarConexionMySql(SqlCnn);
                _state.error = 0;
                _state.descripcion = "Operacion Realizada";
                _log.Traceo(_state.descripcion + " Operacion Counter batches", _state.error.ToString());
                return _transactions;
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
            return _transactions;
        }
    }
}
