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
	[RoutePrefix("api/calendar")]
	public class calendarController: ApiController
	{
		calendarDataAccess objcalendar = new calendarDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public calendar Consultar()
		{
			return objcalendar.Consultarcalendar();
		}
       [HttpPost]
       [Route("Buscar")]
		public calendar Buscar([FromBody] calendar.Data data)
		{
			return objcalendar.Buscarcalendar(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public calendar.State Insertar([FromBody] calendar.Data data)
		{
			return objcalendar.Insertarcalendar(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public calendar.State Actualizar([FromBody] calendar.Data data)
		{
			return objcalendar.Actualizarcalendar(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public calendar.State Eliminar([FromBody] calendar.Data data)
		{
			return objcalendar.Eliminarcalendar(data);
		}
	}
}
