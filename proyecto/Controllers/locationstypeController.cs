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
	[RoutePrefix("api/locationstype")]
	public class locationstypeController: ApiController
	{
		locationstypeDataAccess objlocationstype = new locationstypeDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public locationstype Consultar()
		{
			return objlocationstype.Consultarlocationstype();
		}
       [HttpPost]
       [Route("Buscar")]
		public locationstype Buscar([FromBody] locationstype.Data data)
		{
			return objlocationstype.Buscarlocationstype(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public locationstype.State Insertar([FromBody] locationstype.Data data)
		{
			return objlocationstype.Insertarlocationstype(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public locationstype.State Actualizar([FromBody] locationstype.Data data)
		{
			return objlocationstype.Actualizarlocationstype(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public locationstype.State Eliminar([FromBody] locationstype.Data data)
		{
			return objlocationstype.Eliminarlocationstype(data);
		}
	}
}
