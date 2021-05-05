using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class devices
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public devices(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public devices(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String identification{ get; set; }
			public System.String description{ get; set; }
			public System.String devicetypeidentification{ get; set; }
			public System.Int32 enabled{ get; set; }
			public System.DateTime createtimestamp{ get; set; }
			public System.DateTime updatetimestamp{ get; set; }
			public System.String createuser{ get; set; }
			public System.String updateuser{ get; set; }
			public System.String configuration{ get; set; }
			public System.String identificationprovider{ get; set; }
			public System.String locationidentification{ get; set; }
			public System.String coinacceptordenoms{ get; set; }
			public System.String cashacceptordenoms{ get; set; }
			public System.String maxamountodispense{ get; set; }
			public System.String maxbillstodispense{ get; set; }
			public System.String maxcoinstodispense{ get; set; }
			public System.String video_intro{ get; set; }
			public System.String video_insert_cash{ get; set; }
			public System.String video_take_cash{ get; set; }
			public System.String video_take_cash_chash_receipt{ get; set; }
			public System.String video_read_barcode{ get; set; }
			public System.String payment_success{ get; set; }
			public System.String payment_cancel{ get; set; }
			public System.String final_success{ get; set; }
			public System.String cashacceptorfullalarm{ get; set; }
			public System.String cashacceptorfulllimit{ get; set; }
			public System.String coinacceptorfullalarm{ get; set; }
			public System.String coinacceptorfulllimit{ get; set; }
			public System.String cashchangeremptyalarm{ get; set; }
			public System.String cashchangeremptylimit{ get; set; }
			public System.String cashchangersecuritystock{ get; set; }
			public System.String coinchangeremptyalarm{ get; set; }
			public System.String coinchangeremptylimit{ get; set; }
			public System.String coinchangersecuritystock{ get; set; }
			public System.String carddispenseremptylimit{ get; set; }
			public System.String carddispenseremptyalarm{ get; set; }
			public System.String emptydenomblockcondition1{ get; set; }
			public System.String emptydenomblockcondition2{ get; set; }
			public System.String emptydenomblockcondition3{ get; set; }
			public System.String emptydenomblockcondition4{ get; set; }
			public System.String totalchangeemptyalarm{ get; set; }
			public System.String totalchangeemptylimit{ get; set; }
			public System.String scp_statusinterval{ get; set; }
			public System.String sct_step{ get; set; }
			public System.String sct_changevalidatoramount{ get; set; }
			public System.String sct_finishscreentimeout{ get; set; }
			public System.String cashchangerfill{ get; set; }
			public System.String coinchangerfill{ get; set; }
			public System.String coinchangerdenoms{ get; set; }
			public System.String cashchangerdenoms{ get; set; }
			public System.DateTime lastreporttimestamp{ get; set; }
			public System.String laststatusreported{ get; set; }
			public System.String serviceuser{ get; set; }
			public System.String operatorcode{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
