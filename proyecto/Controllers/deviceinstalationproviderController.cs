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
	[RoutePrefix("api/deviceinstalationprovider")]
	public class deviceinstalationproviderController: ApiController
	{
		deviceinstalationproviderDataAccess objdeviceinstalationprovider = new deviceinstalationproviderDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public deviceinstalationprovider Consultar()
		{
			return objdeviceinstalationprovider.Consultardeviceinstalationprovider();
		}
       [HttpPost]
       [Route("Buscar")]
		public deviceinstalationprovider Buscar([FromBody] deviceinstalationprovider.Data data)
		{
			return objdeviceinstalationprovider.Buscardeviceinstalationprovider(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public deviceinstalationprovider.State Insertar([FromBody] deviceinstalationprovider.Data data)
		{
			return objdeviceinstalationprovider.Insertardeviceinstalationprovider(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public deviceinstalationprovider.State Actualizar([FromBody] deviceinstalationprovider.Data data)
		{
			return objdeviceinstalationprovider.Actualizardeviceinstalationprovider(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public deviceinstalationprovider.State Eliminar([FromBody] deviceinstalationprovider.Data data)
		{
			return objdeviceinstalationprovider.Eliminardeviceinstalationprovider(data);
		}
	}
}
