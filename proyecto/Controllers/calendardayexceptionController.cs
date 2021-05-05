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
	[RoutePrefix("api/calendardayexception")]
	public class calendardayexceptionController: ApiController
	{
		calendardayexceptionDataAccess objcalendardayexception = new calendardayexceptionDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public calendardayexception Consultar()
		{
			return objcalendardayexception.Consultarcalendardayexception();
		}
       [HttpPost]
       [Route("Buscar")]
		public calendardayexception Buscar([FromBody] calendardayexception.Data data)
		{
			return objcalendardayexception.Buscarcalendardayexception(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public calendardayexception.State Insertar([FromBody] calendardayexception.Data data)
		{
			return objcalendardayexception.Insertarcalendardayexception(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public calendardayexception.State Actualizar([FromBody] calendardayexception.Data data)
		{
			return objcalendardayexception.Actualizarcalendardayexception(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public calendardayexception.State Eliminar([FromBody] calendardayexception.Data data)
		{
			return objcalendardayexception.Eliminarcalendardayexception(data);
		}
	}
}
