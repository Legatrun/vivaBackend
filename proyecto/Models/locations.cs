using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class locations
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public locations(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public locations(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String identification{ get; set; }
			public System.String description{ get; set; }
			public System.String type{ get; set; }
			public System.Int32 enabled{ get; set; }
			public System.DateTime createtimestamp{ get; set; }
			public System.DateTime updatetimestamp{ get; set; }
			public System.String createuser{ get; set; }
			public System.String updateuser{ get; set; }
			public System.String address{ get; set; }
			public System.String zipcode{ get; set; }
			public System.String city{ get; set; }
			public System.String city_code{ get; set; }
			public System.String state{ get; set; }
			public System.String state_code{ get; set; }
			public System.String country{ get; set; }
			public System.String identificationprovider{ get; set; }
			public System.String email{ get; set; }
			public System.String areacode{ get; set; }
			public System.String geocoordinates{ get; set; }
			public System.String replanishmentemail{ get; set; }
			public System.Int32 calendarid{ get; set; }
			public System.Int32 locationtypeid{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
