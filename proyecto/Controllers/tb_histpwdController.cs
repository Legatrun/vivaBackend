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
	[RoutePrefix("api/tb_histpwd")]
	public class tb_histpwdController: ApiController
	{
		tb_histpwdDataAccess objtb_histpwd = new tb_histpwdDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public tb_histpwd Consultar()
		{
			return objtb_histpwd.Consultartb_histpwd();
		}
       [HttpPost]
       [Route("Buscar")]
		public tb_histpwd Buscar([FromBody] tb_histpwd.Data data)
		{
			return objtb_histpwd.Buscartb_histpwd(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public tb_histpwd.State Insertar([FromBody] tb_histpwd.Data data)
		{
			return objtb_histpwd.Insertartb_histpwd(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public tb_histpwd.State Actualizar([FromBody] tb_histpwd.Data data)
		{
			return objtb_histpwd.Actualizartb_histpwd(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public tb_histpwd.State Eliminar([FromBody] tb_histpwd.Data data)
		{
			return objtb_histpwd.Eliminartb_histpwd(data);
		}
	}
}
