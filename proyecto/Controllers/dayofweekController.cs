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
	[RoutePrefix("api/dayofweek")]
	public class dayofweekController: ApiController
	{
		dayofweekDataAccess objdayofweek = new dayofweekDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public dayofweek Consultar()
		{
			return objdayofweek.Consultardayofweek();
		}
       [HttpPost]
       [Route("Buscar")]
		public dayofweek Buscar([FromBody] dayofweek.Data data)
		{
			return objdayofweek.Buscardayofweek(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public dayofweek.State Insertar([FromBody] dayofweek.Data data)
		{
			return objdayofweek.Insertardayofweek(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public dayofweek.State Actualizar([FromBody] dayofweek.Data data)
		{
			return objdayofweek.Actualizardayofweek(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public dayofweek.State Eliminar([FromBody] dayofweek.Data data)
		{
			return objdayofweek.Eliminardayofweek(data);
		}
	}
}
