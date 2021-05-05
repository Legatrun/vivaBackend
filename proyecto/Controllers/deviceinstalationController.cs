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
	[RoutePrefix("api/deviceinstalation")]
	public class deviceinstalationController: ApiController
	{
		deviceinstalationDataAccess objdeviceinstalation = new deviceinstalationDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public deviceinstalation Consultar()
		{
			return objdeviceinstalation.Consultardeviceinstalation();
		}
       [HttpPost]
       [Route("Buscar")]
		public deviceinstalation Buscar([FromBody] deviceinstalation.Data data)
		{
			return objdeviceinstalation.Buscardeviceinstalation(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public deviceinstalation.State Insertar([FromBody] deviceinstalation.Data data)
		{
			return objdeviceinstalation.Insertardeviceinstalation(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public deviceinstalation.State Actualizar([FromBody] deviceinstalation.Data data)
		{
			return objdeviceinstalation.Actualizardeviceinstalation(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public deviceinstalation.State Eliminar([FromBody] deviceinstalation.Data data)
		{
			return objdeviceinstalation.Eliminardeviceinstalation(data);
		}
	}
}
