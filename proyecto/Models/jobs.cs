using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class jobs
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public jobs(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public jobs(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String jobname{ get; set; }
			public System.DateTime jobstarttimestamp{ get; set; }
			public System.DateTime jobendtimestamp{ get; set; }
			public System.Int32 jobstatus{ get; set; }
			public System.String jobcommand{ get; set; }
			public System.Int32 jobreturncode{ get; set; }
			public System.String joboutputfile{ get; set; }
			public System.String userid{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
