using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
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
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_batches_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					batches.Data _batches= new batches.Data();
					_batches.id = Convert.ToInt32(rdr["id"].ToString());
					lstbatches.Add(_batches);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar batches", _state.error.ToString());
				return new batches(_state, lstbatches);
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
			return new batches(_state);
		}
		public batches Buscarbatches(batches.Data _batchesData)
		{
			List<batches.Data> lstbatches = new List<batches.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar batches", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_batches_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _batchesData.id);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					batches.Data _batches= new batches.Data();
					_batches.id = Convert.ToInt32(rdr["id"].ToString());
					lstbatches.Add(_batches);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar batches", _state.error.ToString());
				return new batches(_state, lstbatches);
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
			return new batches(_state);
		}
		public batches.State Insertarbatches(batches.Data _batches)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar batches", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_batches_Insert", SqlCnn);
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
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar batches", _state.error.ToString());
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
		public batches.State Actualizarbatches(batches.Data _batches)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar batches", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_batches_Update", SqlCnn);
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
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar batches", _state.error.ToString());
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
		public batches.State Eliminarbatches(batches.Data _batches)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar batches", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_batches_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@id", _batches.id);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar batches", _state.error.ToString());
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
