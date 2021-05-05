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
	[RoutePrefix("api/devicestatuscolletions")]
	public class devicestatuscolletionsController: ApiController
	{
		devicestatuscolletionsDataAccess objdevicestatuscolletions = new devicestatuscolletionsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public devicestatuscolletions Consultar()
		{
			return objdevicestatuscolletions.Consultardevicestatuscolletions();
		}
       [HttpPost]
       [Route("Buscar")]
		public devicestatuscolletions Buscar([FromBody] devicestatuscolletions.Data data)
		{
			return objdevicestatuscolletions.Buscardevicestatuscolletions(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public devicestatuscolletions.State Insertar([FromBody] devicestatuscolletions.Data data)
		{
			return objdevicestatuscolletions.Insertardevicestatuscolletions(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public devicestatuscolletions.State Actualizar([FromBody] devicestatuscolletions.Data data)
		{
			return objdevicestatuscolletions.Actualizardevicestatuscolletions(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public devicestatuscolletions.State Eliminar([FromBody] devicestatuscolletions.Data data)
		{
			return objdevicestatuscolletions.Eliminardevicestatuscolletions(data);
		}
	}
}
