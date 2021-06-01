using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Agencias
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Agencias(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Agencias(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 id_agencia{ get; set; }
			public System.String cod_agencia{ get; set; }
			public System.String nombre{ get; set; }
			public System.Int16 idtipoagencia{ get; set; }
			public System.String ip_agencia{ get; set; }
			public System.String latitud{ get; set; }
			public System.String longitud{ get; set; }
			public System.Int32 idciudad { get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
