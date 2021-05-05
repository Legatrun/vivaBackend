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
	[RoutePrefix("api/jobs")]
	public class jobsController: ApiController
	{
		jobsDataAccess objjobs = new jobsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public jobs Consultar()
		{
			return objjobs.Consultarjobs();
		}
       [HttpPost]
       [Route("Buscar")]
		public jobs Buscar([FromBody] jobs.Data data)
		{
			return objjobs.Buscarjobs(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public jobs.State Insertar([FromBody] jobs.Data data)
		{
			return objjobs.Insertarjobs(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public jobs.State Actualizar([FromBody] jobs.Data data)
		{
			return objjobs.Actualizarjobs(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public jobs.State Eliminar([FromBody] jobs.Data data)
		{
			return objjobs.Eliminarjobs(data);
		}
	}
}
