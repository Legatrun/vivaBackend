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
	[RoutePrefix("api/calendarversion")]
	public class calendarversionController: ApiController
	{
		calendarversionDataAccess objcalendarversion = new calendarversionDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public calendarversion Consultar()
		{
			return objcalendarversion.Consultarcalendarversion();
		}
       [HttpPost]
       [Route("Buscar")]
		public calendarversion Buscar([FromBody] calendarversion.Data data)
		{
			return objcalendarversion.Buscarcalendarversion(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public calendarversion.State Insertar([FromBody] calendarversion.Data data)
		{
			return objcalendarversion.Insertarcalendarversion(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public calendarversion.State Actualizar([FromBody] calendarversion.Data data)
		{
			return objcalendarversion.Actualizarcalendarversion(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public calendarversion.State Eliminar([FromBody] calendarversion.Data data)
		{
			return objcalendarversion.Eliminarcalendarversion(data);
		}
	}
}
