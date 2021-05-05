using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class deviceinstalationprovider
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public deviceinstalationprovider(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public deviceinstalationprovider(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String deviceidentification{ get; set; }
			public System.Int32 enabled{ get; set; }
			public System.DateTime createtimestamp{ get; set; }
			public System.DateTime updatetimestamp{ get; set; }
			public System.String createuser{ get; set; }
			public System.String updateuser{ get; set; }
			public System.String locationidentification{ get; set; }
			public System.String provideridentification{ get; set; }
			public System.String providerdeviceidentification{ get; set; }
			public System.String providerlocationidentification{ get; set; }
			public System.Int32 providersequencenumber{ get; set; }
			public System.DateTime lasttransactiontimestamp{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
