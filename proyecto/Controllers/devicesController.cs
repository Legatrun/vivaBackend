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
	[RoutePrefix("api/devices")]
	public class devicesController: ApiController
	{
		devicesDataAccess objdevices = new devicesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public devices Consultar()
		{
			return objdevices.Consultardevices();
		}
       [HttpPost]
       [Route("Buscar")]
		public devices Buscar([FromBody] devices.Data data)
		{
			return objdevices.Buscardevices(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public devices.State Insertar([FromBody] devices.Data data)
		{
			return objdevices.Insertardevices(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public devices.State Actualizar([FromBody] devices.Data data)
		{
			return objdevices.Actualizardevices(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public devices.State Eliminar([FromBody] devices.Data data)
		{
			return objdevices.Eliminardevices(data);
		}
	}
}
