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
	[RoutePrefix("api/tb_grupos")]
	public class tb_gruposController: ApiController
	{
		tb_gruposDataAccess objtb_grupos = new tb_gruposDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public tb_grupos Consultar()
		{
			return objtb_grupos.Consultartb_grupos();
		}
       [HttpPost]
       [Route("Buscar")]
		public tb_grupos Buscar([FromBody] tb_grupos.Data data)
		{
			return objtb_grupos.Buscartb_grupos(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public tb_grupos.State Insertar([FromBody] tb_grupos.Data data)
		{
			return objtb_grupos.Insertartb_grupos(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public tb_grupos.State Actualizar([FromBody] tb_grupos.Data data)
		{
			return objtb_grupos.Actualizartb_grupos(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public tb_grupos.State Eliminar([FromBody] tb_grupos.Data data)
		{
			return objtb_grupos.Eliminartb_grupos(data);
		}
	}
}
