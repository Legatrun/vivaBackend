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
	[RoutePrefix("api/transactiondefinition")]
	public class transactiondefinitionController: ApiController
	{
		transactiondefinitionDataAccess objtransactiondefinition = new transactiondefinitionDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public transactiondefinition Consultar()
		{
			return objtransactiondefinition.Consultartransactiondefinition();
		}
       [HttpPost]
       [Route("Buscar")]
		public transactiondefinition Buscar([FromBody] transactiondefinition.Data data)
		{
			return objtransactiondefinition.Buscartransactiondefinition(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public transactiondefinition.State Insertar([FromBody] transactiondefinition.Data data)
		{
			return objtransactiondefinition.Insertartransactiondefinition(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public transactiondefinition.State Actualizar([FromBody] transactiondefinition.Data data)
		{
			return objtransactiondefinition.Actualizartransactiondefinition(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public transactiondefinition.State Eliminar([FromBody] transactiondefinition.Data data)
		{
			return objtransactiondefinition.Eliminartransactiondefinition(data);
		}
	}
}
