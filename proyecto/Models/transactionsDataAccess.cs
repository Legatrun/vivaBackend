using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_transactions_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					transactions.Data _transactions= new transactions.Data();
					_transactions.id = Convert.ToInt32(rdr["id"].ToString());
					lsttransactions.Add(_transactions);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar transactions", _state.error.ToString());
				return new transactions(_state, lsttransactions);
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
			return new transactions(_state);
		}
		public transactions Buscartransactions(transactions.Data _transactionsData)
		{
			List<transactions.Data> lsttransactions = new List<transactions.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar transactions", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_transactions_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _transactionsData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					transactions.Data _transactions= new transactions.Data();
					_transactions.id = Convert.ToInt32(rdr["id"].ToString());
					lsttransactions.Add(_transactions);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar transactions", _state.error.ToString());
				return new transactions(_state, lsttransactions);
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
			return new transactions(_state);
		}
		public transactions.State Insertartransactions(transactions.Data _transactions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar transactions", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_transactions_Insert", SqlCnn);
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
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar transactions", _state.error.ToString());
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
		public transactions.State Actualizartransactions(transactions.Data _transactions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar transactions", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_transactions_Update", SqlCnn);
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
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar transactions", _state.error.ToString());
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
		public transactions.State Eliminartransactions(transactions.Data _transactions)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar transactions", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_transactions_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _transactions.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar transactions", _state.error.ToString());
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
