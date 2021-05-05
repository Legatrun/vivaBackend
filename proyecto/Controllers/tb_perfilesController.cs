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
	[RoutePrefix("api/tb_perfiles")]
	public class tb_perfilesController: ApiController
	{
		tb_perfilesDataAccess objtb_perfiles = new tb_perfilesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public tb_perfiles Consultar()
		{
			return objtb_perfiles.Consultartb_perfiles();
		}
       [HttpPost]
       [Route("Buscar")]
		public tb_perfiles Buscar([FromBody] tb_perfiles.Data data)
		{
			return objtb_perfiles.Buscartb_perfiles(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public tb_perfiles.State Insertar([FromBody] tb_perfiles.Data data)
		{
			return objtb_perfiles.Insertartb_perfiles(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public tb_perfiles.State Actualizar([FromBody] tb_perfiles.Data data)
		{
			return objtb_perfiles.Actualizartb_perfiles(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public tb_perfiles.State Eliminar([FromBody] tb_perfiles.Data data)
		{
			return objtb_perfiles.Eliminartb_perfiles(data);
		}
	}
}
