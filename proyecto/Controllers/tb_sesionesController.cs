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
	[RoutePrefix("api/tb_sesiones")]
	public class tb_sesionesController: ApiController
	{
		tb_sesionesDataAccess objtb_sesiones = new tb_sesionesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public tb_sesiones Consultar()
		{
			return objtb_sesiones.Consultartb_sesiones();
		}
       [HttpPost]
       [Route("Buscar")]
		public tb_sesiones Buscar([FromBody] tb_sesiones.Data data)
		{
			return objtb_sesiones.Buscartb_sesiones(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public tb_sesiones.State Insertar([FromBody] tb_sesiones.Data data)
		{
			return objtb_sesiones.Insertartb_sesiones(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public tb_sesiones.State Actualizar([FromBody] tb_sesiones.Data data)
		{
			return objtb_sesiones.Actualizartb_sesiones(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public tb_sesiones.State Eliminar([FromBody] tb_sesiones.Data data)
		{
			return objtb_sesiones.Eliminartb_sesiones(data);
		}
	}
}
