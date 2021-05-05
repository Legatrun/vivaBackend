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
	[RoutePrefix("api/calendarhourrange")]
	public class calendarhourrangeController: ApiController
	{
		calendarhourrangeDataAccess objcalendarhourrange = new calendarhourrangeDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public calendarhourrange Consultar()
		{
			return objcalendarhourrange.Consultarcalendarhourrange();
		}
       [HttpPost]
       [Route("Buscar")]
		public calendarhourrange Buscar([FromBody] calendarhourrange.Data data)
		{
			return objcalendarhourrange.Buscarcalendarhourrange(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public calendarhourrange.State Insertar([FromBody] calendarhourrange.Data data)
		{
			return objcalendarhourrange.Insertarcalendarhourrange(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public calendarhourrange.State Actualizar([FromBody] calendarhourrange.Data data)
		{
			return objcalendarhourrange.Actualizarcalendarhourrange(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public calendarhourrange.State Eliminar([FromBody] calendarhourrange.Data data)
		{
			return objcalendarhourrange.Eliminarcalendarhourrange(data);
		}
	}
}
