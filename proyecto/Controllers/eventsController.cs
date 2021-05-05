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
	[RoutePrefix("api/events")]
	public class eventsController: ApiController
	{
		eventsDataAccess objevents = new eventsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public events Consultar()
		{
			return objevents.Consultarevents();
		}
       [HttpPost]
       [Route("Buscar")]
		public events Buscar([FromBody] events.Data data)
		{
			return objevents.Buscarevents(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public events.State Insertar([FromBody] events.Data data)
		{
			return objevents.Insertarevents(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public events.State Actualizar([FromBody] events.Data data)
		{
			return objevents.Actualizarevents(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public events.State Eliminar([FromBody] events.Data data)
		{
			return objevents.Eliminarevents(data);
		}
	}
}
