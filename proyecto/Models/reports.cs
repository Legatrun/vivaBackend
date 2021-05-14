using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class reports
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public reports(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public reports(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 id{ get; set; }
			public System.String reportname{ get; set; }
			public System.String description{ get; set; }
			public System.String url{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
