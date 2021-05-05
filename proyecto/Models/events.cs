using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class events
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public events(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public events(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 type{ get; set; }
			public System.String deviceidentification{ get; set; }
			public System.String locationidentification{ get; set; }
			public System.DateTime createtimestamp{ get; set; }
			public System.String reason{ get; set; }
			public System.String operationname{ get; set; }
			public System.String servicename{ get; set; }
			public System.Int32 sequencenumber{ get; set; }
			public System.DateTime notifytimestamp{ get; set; }
			public System.String text{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
