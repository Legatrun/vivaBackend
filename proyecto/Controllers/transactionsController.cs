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
	[RoutePrefix("api/transactions")]
	public class transactionsController: ApiController
	{
		transactionsDataAccess objtransactions = new transactionsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public transactions Consultar()
		{
			return objtransactions.Consultartransactions();
		}
       [HttpPost]
       [Route("Buscar")]
		public transactions Buscar([FromBody] transactions.Data data)
		{
			return objtransactions.Buscartransactions(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public transactions.State Insertar([FromBody] transactions.Data data)
		{
			return objtransactions.Insertartransactions(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public transactions.State Actualizar([FromBody] transactions.Data data)
		{
			return objtransactions.Actualizartransactions(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public transactions.State Eliminar([FromBody] transactions.Data data)
		{
			return objtransactions.Eliminartransactions(data);
		}
	}
}
