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
	[RoutePrefix("api/batches")]
	public class batchesController: ApiController
	{
		batchesDataAccess objbatches = new batchesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public batches Consultar()
		{
			return objbatches.Consultarbatches();
		}
       [HttpPost]
       [Route("Buscar")]
		public batches Buscar([FromBody] batches.Data data)
		{
			return objbatches.Buscarbatches(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public batches.State Insertar([FromBody] batches.Data data)
		{
			return objbatches.Insertarbatches(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public batches.State Actualizar([FromBody] batches.Data data)
		{
			return objbatches.Actualizarbatches(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public batches.State Eliminar([FromBody] batches.Data data)
		{
			return objbatches.Eliminarbatches(data);
		}
	}
}
