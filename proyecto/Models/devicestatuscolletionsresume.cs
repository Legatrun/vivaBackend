using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class devicestatuscolletionsresume
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public devicestatuscolletionsresume(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public devicestatuscolletionsresume(State error)
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
			public System.String provideridentification{ get; set; }
			public System.String providertransactionid{ get; set; }
			public System.String devicetransactionid{ get; set; }
			public System.Int32 batchnumber{ get; set; }
			public System.Int32 transactionid{ get; set; }
			public System.String alarm{ get; set; }
			public System.Int32 devicestatus{ get; set; }
			public System.String operatingmode{ get; set; }
			public System.String alarmid{ get; set; }
			public System.String aceptordetail{ get; set; }
			public System.String changerdetail{ get; set; }
			public System.String returndetail{ get; set; }
			public System.String operativeday{ get; set; }
			public System.String totaltx{ get; set; }
			public System.String totalamount{ get; set; }
			public System.String totalaccepted{ get; set; }
			public System.String totalreturned{ get; set; }
			public System.String totalavailable{ get; set; }
			public System.String totalgivenamount{ get; set; }
			public System.String totaldebtamount{ get; set; }
			public System.String totalrefilloperations{ get; set; }
			public System.String totalrefillamount{ get; set; }
			public System.String totalcollectoperations{ get; set; }
			public System.String totalcollectamount{ get; set; }
			public System.String totallocks{ get; set; }
			public System.String opentime{ get; set; }
			public System.String closetime{ get; set; }
			public System.String vdmstatus{ get; set; }
			public System.String powerstatus{ get; set; }
			public System.String scannerstatus{ get; set; }
			public System.String motionsensorstatus{ get; set; }
			public System.String printerstatus{ get; set; }
			public System.String cashacceptorstatus{ get; set; }
			public System.String cashchangerstatus{ get; set; }
			public System.String coinacceptorstatus{ get; set; }
			public System.String coinchangerstatus{ get; set; }
			public System.String devicestatusdetail{ get; set; }
			public System.Int32 processid{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
