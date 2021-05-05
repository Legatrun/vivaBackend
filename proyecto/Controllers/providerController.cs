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
	[RoutePrefix("api/provider")]
	public class providerController: ApiController
	{
		providerDataAccess objprovider = new providerDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public provider Consultar()
		{
			return objprovider.Consultarprovider();
		}
       [HttpPost]
       [Route("Buscar")]
		public provider Buscar([FromBody] provider.Data data)
		{
			return objprovider.Buscarprovider(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public provider.State Insertar([FromBody] provider.Data data)
		{
			return objprovider.Insertarprovider(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public provider.State Actualizar([FromBody] provider.Data data)
		{
			return objprovider.Actualizarprovider(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public provider.State Eliminar([FromBody] provider.Data data)
		{
			return objprovider.Eliminarprovider(data);
		}
	}
}
