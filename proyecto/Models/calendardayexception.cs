using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class calendardayexception
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public calendardayexception(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public calendardayexception(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 id{ get; set; }
			public DateTime day{ get; set; }
			public System.String description{ get; set; }
			public System.Int32 calendarversionid{ get; set; }
			public System.DateTime createtimestamp{ get; set; }
			public System.DateTime updatetimestamp{ get; set; }
			public System.String createuser{ get; set; }
			public System.String updateuser{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
