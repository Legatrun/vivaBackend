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
	[RoutePrefix("api/locations")]
	public class locationsController: ApiController
	{
		locationsDataAccess objlocations = new locationsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public locations Consultar()
		{
			return objlocations.Consultarlocations();
		}
       [HttpPost]
       [Route("Buscar")]
		public locations Buscar([FromBody] locations.Data data)
		{
			return objlocations.Buscarlocations(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public locations.State Insertar([FromBody] locations.Data data)
		{
			return objlocations.Insertarlocations(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public locations.State Actualizar([FromBody] locations.Data data)
		{
			return objlocations.Actualizarlocations(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public locations.State Eliminar([FromBody] locations.Data data)
		{
			return objlocations.Eliminarlocations(data);
		}
	}
}
