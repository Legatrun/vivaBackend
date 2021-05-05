using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class tb_params
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public tb_params(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public tb_params(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String clave{ get; set; }
			public System.String valor{ get; set; }
			public System.DateTime create_timestamp{ get; set; }
			public System.DateTime fec_modificacion{ get; set; }
			public System.String usua_modificacion{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
