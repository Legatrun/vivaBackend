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
	[RoutePrefix("api/applicationdefinition")]
	public class applicationdefinitionController: ApiController
	{
		applicationdefinitionDataAccess objapplicationdefinition = new applicationdefinitionDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public applicationdefinition Consultar()
		{
			return objapplicationdefinition.Consultarapplicationdefinition();
		}
       [HttpPost]
       [Route("Buscar")]
		public applicationdefinition Buscar([FromBody] applicationdefinition.Data data)
		{
			return objapplicationdefinition.Buscarapplicationdefinition(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public applicationdefinition.State Insertar([FromBody] applicationdefinition.Data data)
		{
			return objapplicationdefinition.Insertarapplicationdefinition(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public applicationdefinition.State Actualizar([FromBody] applicationdefinition.Data data)
		{
			return objapplicationdefinition.Actualizarapplicationdefinition(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public applicationdefinition.State Eliminar([FromBody] applicationdefinition.Data data)
		{
			return objapplicationdefinition.Eliminarapplicationdefinition(data);
		}
	}
}
