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
	[RoutePrefix("api/deviceinstalationtransactionpr")]
	public class deviceinstalationtransactionprController: ApiController
	{
		deviceinstalationtransactionprDataAccess objdeviceinstalationtransactionpr = new deviceinstalationtransactionprDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public deviceinstalationtransactionpr Consultar()
		{
			return objdeviceinstalationtransactionpr.Consultardeviceinstalationtransactionpr();
		}
       [HttpPost]
       [Route("Buscar")]
		public deviceinstalationtransactionpr Buscar([FromBody] deviceinstalationtransactionpr.Data data)
		{
			return objdeviceinstalationtransactionpr.Buscardeviceinstalationtransactionpr(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public deviceinstalationtransactionpr.State Insertar([FromBody] deviceinstalationtransactionpr.Data data)
		{
			return objdeviceinstalationtransactionpr.Insertardeviceinstalationtransactionpr(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public deviceinstalationtransactionpr.State Actualizar([FromBody] deviceinstalationtransactionpr.Data data)
		{
			return objdeviceinstalationtransactionpr.Actualizardeviceinstalationtransactionpr(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public deviceinstalationtransactionpr.State Eliminar([FromBody] deviceinstalationtransactionpr.Data data)
		{
			return objdeviceinstalationtransactionpr.Eliminardeviceinstalationtransactionpr(data);
		}
	}
}
