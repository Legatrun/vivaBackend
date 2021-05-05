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
	[RoutePrefix("api/devicealarms")]
	public class devicealarmsController: ApiController
	{
		devicealarmsDataAccess objdevicealarms = new devicealarmsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public devicealarms Consultar()
		{
			return objdevicealarms.Consultardevicealarms();
		}
       [HttpPost]
       [Route("Buscar")]
		public devicealarms Buscar([FromBody] devicealarms.Data data)
		{
			return objdevicealarms.Buscardevicealarms(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public devicealarms.State Insertar([FromBody] devicealarms.Data data)
		{
			return objdevicealarms.Insertardevicealarms(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public devicealarms.State Actualizar([FromBody] devicealarms.Data data)
		{
			return objdevicealarms.Actualizardevicealarms(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public devicealarms.State Eliminar([FromBody] devicealarms.Data data)
		{
			return objdevicealarms.Eliminardevicealarms(data);
		}
	}
}
