using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class GrpUsrRolesInstituciones
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public GrpUsrRolesInstituciones(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public GrpUsrRolesInstituciones(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 idgrpusuariorolinstitucion{ get; set; }
			public System.Int32 idgrpusuario{ get; set; }
			public System.Int32 idinstitucionrol{ get; set; }
			public System.Boolean estado { get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
