using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Usuarios
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Usuarios(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Usuarios(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 idusuario{ get; set; }
			public System.String nombre{ get; set; }
			public System.String email{ get; set; }
			public System.String password{ get; set; }
			public System.DateTime fechacreacion{ get; set; }
			public System.Boolean usrdominio{ get; set; }
			public System.Int32 idinstitucion{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
