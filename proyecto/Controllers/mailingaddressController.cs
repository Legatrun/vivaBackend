using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using proyecto.Models;

namespace proyecto.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api/mailingaddress")]
	public class mailingaddressController: ApiController
	{
		mailingaddressDataAccess objmailingaddress = new mailingaddressDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public mailingaddress Consultar()
		{
			return objmailingaddress.Consultarmailingaddress();
		}
       [HttpPost]
       [Route("Buscar")]
		public mailingaddress Buscar([FromBody] mailingaddress.Data data)
		{
			return objmailingaddress.Buscarmailingaddress(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public mailingaddress.State Insertar([FromBody] mailingaddress.Data data)
		{
			return objmailingaddress.Insertarmailingaddress(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public mailingaddress.State Actualizar([FromBody] mailingaddress.Data data)
		{
			return objmailingaddress.Actualizarmailingaddress(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public mailingaddress.State Eliminar([FromBody] mailingaddress.Data data)
		{
			return objmailingaddress.Eliminarmailingaddress(data);
		}
	}
}
