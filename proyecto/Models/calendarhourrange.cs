using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class calendarhourrange
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public calendarhourrange(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public calendarhourrange(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 id{ get; set; }
			public System.Int32 fromhour{ get; set; }
			public System.Int32 fromminute{ get; set; }
			public System.Int32 untilhour{ get; set; }
			public System.Int32 untilminute{ get; set; }
			public System.Int32 calendardayexceptionid{ get; set; }
			public System.Int32 dayofweekid{ get; set; }
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
