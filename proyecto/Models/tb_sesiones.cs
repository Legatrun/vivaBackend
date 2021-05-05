using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class tb_sesiones
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public tb_sesiones(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public tb_sesiones(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String id{ get; set; }
			public System.String nombre_usuario{ get; set; }
			public System.String datos{ get; set; }
			public System.DateTime ultimo_acceso{ get; set; }
			public System.DateTime creacion{ get; set; }
			public System.DateTime fec_modificacion{ get; set; }
			public System.String usua_modificacion{ get; set; }
			public System.Int32 estado{ get; set; }
			public System.String ip{ get; set; }
			public System.DateTime cierre{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
