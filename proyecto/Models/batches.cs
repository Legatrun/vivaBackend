using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class batches
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();
		public Pagination _pagination = new Pagination();

		public batches(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
        public batches(State error, List<Data> data, Pagination pagination)
		{
			_error = error;
			_data = data;
			_pagination = pagination;
		}
		public batches(State error)
		{           
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 id{ get; set; }
			public System.DateTime createtimestamp{ get; set; }
			public System.DateTime updatetimestamp{ get; set; }
			public System.String deviceidentification{ get; set; }
			public System.String locationidentification{ get; set; }
			public System.String payloadrequest{ get; set; }
			public System.String provideridentification{ get; set; }
			public System.String devicestatus{ get; set; }
			public System.Int32 number_{ get; set; }
			public System.Int32 status{ get; set; }
			public System.DateTime opentimestamp{ get; set; }
			public System.DateTime closetimestamp{ get; set; }
			public System.Int32 syncstatus{ get; set; }
			public System.DateTime synctimestamp{ get; set; }
			public System.String operativeday{ get; set; }
			public System.String totaltx{ get; set; }
			public System.String totalamount{ get; set; }
			public System.String totalaccepted{ get; set; }
			public System.String totalreturned{ get; set; }
			public System.String totalavailable{ get; set; }
			public System.String totalgivenamount{ get; set; }
			public System.String totaldebtamount{ get; set; }
			public System.String totalrefilloperations{ get; set; }
			public System.String totalrefillamount{ get; set; }
			public System.String totalcollectoperations{ get; set; }
			public System.String totalcollectamount{ get; set; }
			public System.String totalcardsdelivered{ get; set; }
			public System.String totalcardrefilloperations{ get; set; }
			public System.String totalcardrefillamount{ get; set; }
			public System.String totalcardcollectoperations{ get; set; }
			public System.String totalcardcollectamount{ get; set; }
			public System.String carddispenserstatus{ get; set; }
			public System.String totallocks{ get; set; }
			public System.String opentime{ get; set; }
			public System.String closetime{ get; set; }
			public System.String scannerstatus{ get; set; }
			public System.String motionsensorstatus{ get; set; }
			public System.String printerstatus{ get; set; }
			public System.String cashacceptorstatus{ get; set; }
			public System.String cashchangerstatus{ get; set; }
			public System.String coinacceptorstatus{ get; set; }
			public System.String coinchangerstatus{ get; set; }
			public System.String cardreaderstatus{ get; set; }
			public System.String blockreason{ get; set; }
			public System.String blockstatus{ get; set; }
			public System.String aceptor_000005{ get; set; }
			public System.String aceptor_000010{ get; set; }
			public System.String aceptor_000025{ get; set; }
			public System.String aceptor_000050{ get; set; }
			public System.String aceptor_000100{ get; set; }
			public System.String aceptor_000200{ get; set; }
			public System.String aceptor_000500{ get; set; }
			public System.String aceptor_001000{ get; set; }
			public System.String aceptor_002000{ get; set; }
			public System.String aceptor_005000{ get; set; }
			public System.String aceptor_010000{ get; set; }
			public System.String changer_000005{ get; set; }
			public System.String changer_000010{ get; set; }
			public System.String changer_000025{ get; set; }
			public System.String changer_000050{ get; set; }
			public System.String changer_000100{ get; set; }
			public System.String changer_000200{ get; set; }
			public System.String changer_000500{ get; set; }
			public System.String changer_001000{ get; set; }
			public System.String changer_002000{ get; set; }
			public System.String changer_005000{ get; set; }
			public System.String changer_010000{ get; set; }
			public System.String return_000005{ get; set; }
			public System.String return_000010{ get; set; }
			public System.String return_000025{ get; set; }
			public System.String return_000050{ get; set; }
			public System.String return_000100{ get; set; }
			public System.String return_000200{ get; set; }
			public System.String return_000500{ get; set; }
			public System.String return_001000{ get; set; }
			public System.String return_002000{ get; set; }
			public System.String return_005000{ get; set; }
			public System.String return_010000{ get; set; }
			public System.String return_066666{ get; set; }
			public System.String aceptor_100000{ get; set; }
			public System.String aceptor_200000{ get; set; }
			public System.String aceptor_500000{ get; set; }
			public System.String aceptor_1000000{ get; set; }
			public System.String changer_100000{ get; set; }
			public System.String changer_200000{ get; set; }
			public System.String changer_500000{ get; set; }
			public System.String changer_1000000{ get; set; }
			public System.String return_100000{ get; set; }
			public System.String return_1000000{ get; set; }
			public System.String return_500000{ get; set; }
			public System.String return_200000{ get; set; }
			public System.String aceptordetail{ get; set; }
			public System.String changerdetail{ get; set; }
			public System.String returndetail{ get; set; }
            public System.Int32 numberOfItemPagination { get; set; }
            public System.Int32 initPagination { get; set; }
            public System.Int32 quantityPagination { get; set; }
        }
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
        public class Pagination
        {
            public System.Int32 initPagination { get; set; }
            public System.Int32 quantityPagination { get; set; }
            public System.Int32 itemsPerPagePagination { get; set; }
            public System.Int32 itemsLengthPagination { get; set; }
        }
    }
}
