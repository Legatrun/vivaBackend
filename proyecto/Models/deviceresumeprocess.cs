using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class deviceresumeprocess
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public deviceresumeprocess(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public deviceresumeprocess(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 id{ get; set; }
			public System.DateTime datefrom{ get; set; }
			public System.DateTime dateuntil{ get; set; }
			public System.DateTime dateprocess{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
