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
	[RoutePrefix("api/reports")]
	public class reportsController: ApiController
	{
		reportsDataAccess objreports = new reportsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public reports Consultar()
		{
			return objreports.Consultarreports();
		}
       [HttpPost]
       [Route("Buscar")]
		public reports Buscar([FromBody] reports.Data data)
		{
			return objreports.Buscarreports(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public reports.State Insertar([FromBody] reports.Data data)
		{
			return objreports.Insertarreports(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public reports.State Actualizar([FromBody] reports.Data data)
		{
			return objreports.Actualizarreports(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public reports.State Eliminar([FromBody] reports.Data data)
		{
			return objreports.Eliminarreports(data);
		}
	}
}
