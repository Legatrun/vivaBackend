using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Grupo
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Grupo(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Grupo(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 idgrupo{ get; set; }
			public System.String descripcion{ get; set; }
			public int idinstitucion { get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
