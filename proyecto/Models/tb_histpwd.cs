using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class tb_histpwd
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public tb_histpwd(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public tb_histpwd(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String nombre_usuario{ get; set; }
			public System.DateTime creacion{ get; set; }
			public System.String hash{ get; set; }
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
