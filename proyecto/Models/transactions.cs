using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class transactions
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public transactions(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public transactions(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 id{ get; set; }
			public System.DateTime createtimestamp{ get; set; }
			public System.DateTime updatetimestamp{ get; set; }
			public System.String deviceidentification{ get; set; }
			public System.String locationidentification{ get; set; }
			public System.String servicename{ get; set; }
			public System.String operationname{ get; set; }
			public System.Int32 sequencenumber{ get; set; }
			public System.DateTime transporttimestamp{ get; set; }
			public System.String payloadrequest{ get; set; }
			public System.String payloadanswer{ get; set; }
			public System.Int32 resultcode{ get; set; }
			public System.String resultmessage{ get; set; }
			public System.String provideridentification{ get; set; }
			public System.String providertransactionid{ get; set; }
			public System.String devicetransactionid{ get; set; }
			public System.String providerresultcode{ get; set; }
			public System.String providerresultmessage{ get; set; }
			public System.Int32 batchnumber{ get; set; }
			public System.Int32 syncstatus{ get; set; }
			public System.DateTime synctimestamp{ get; set; }
			public System.String deviceidentificationprovider{ get; set; }
			public System.String locationidentificationprovider{ get; set; }
			public System.String customernumber{ get; set; }
			public System.Decimal amount{ get; set; }
			public System.Decimal amountentered{ get; set; }
			public System.Decimal amountreturned{ get; set; }
			public System.Decimal amountticketundelivered{ get; set; }
			public System.Int32 operationstatus{ get; set; }
			public System.String amountentereddetail{ get; set; }
			public System.String amountreturneddetail{ get; set; }
			public System.String amountticketundelivereddetail{ get; set; }
			public System.String transactionidentification{ get; set; }
			public System.String customercode{ get; set; }
			public System.Int32 canceled{ get; set; }
			public System.DateTime canceledtimestamp{ get; set; }
			public System.Int32 providersequencenumber{ get; set; }
			public System.Int32 cardsdispensed{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
