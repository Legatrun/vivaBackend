using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class transactiondefinition
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public transactiondefinition(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public transactiondefinition(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String identification{ get; set; }
			public System.String description{ get; set; }
			public System.String type{ get; set; }
			public System.Int32 enabled{ get; set; }
			public System.DateTime createtimestamp{ get; set; }
			public System.DateTime updatetimestamp{ get; set; }
			public System.String createuser{ get; set; }
			public System.String updateuser{ get; set; }
			public System.String configuration{ get; set; }
			public System.String servicename{ get; set; }
			public System.String operationname{ get; set; }
			public System.String hlabel{ get; set; }
			public System.String vlabel{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
