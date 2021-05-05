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
	[RoutePrefix("api/tb_params")]
	public class tb_paramsController: ApiController
	{
		tb_paramsDataAccess objtb_params = new tb_paramsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public tb_params Consultar()
		{
			return objtb_params.Consultartb_params();
		}
       [HttpPost]
       [Route("Buscar")]
		public tb_params Buscar([FromBody] tb_params.Data data)
		{
			return objtb_params.Buscartb_params(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public tb_params.State Insertar([FromBody] tb_params.Data data)
		{
			return objtb_params.Insertartb_params(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public tb_params.State Actualizar([FromBody] tb_params.Data data)
		{
			return objtb_params.Actualizartb_params(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public tb_params.State Eliminar([FromBody] tb_params.Data data)
		{
			return objtb_params.Eliminartb_params(data);
		}
	}
}
