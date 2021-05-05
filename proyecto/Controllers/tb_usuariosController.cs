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
	[RoutePrefix("api/tb_usuarios")]
	public class tb_usuariosController: ApiController
	{
		tb_usuariosDataAccess objtb_usuarios = new tb_usuariosDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public tb_usuarios Consultar()
		{
			return objtb_usuarios.Consultartb_usuarios();
		}
       [HttpPost]
       [Route("Buscar")]
		public tb_usuarios Buscar([FromBody] tb_usuarios.Data data)
		{
			return objtb_usuarios.Buscartb_usuarios(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public tb_usuarios.State Insertar([FromBody] tb_usuarios.Data data)
		{
			return objtb_usuarios.Insertartb_usuarios(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public tb_usuarios.State Actualizar([FromBody] tb_usuarios.Data data)
		{
			return objtb_usuarios.Actualizartb_usuarios(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public tb_usuarios.State Eliminar([FromBody] tb_usuarios.Data data)
		{
			return objtb_usuarios.Eliminartb_usuarios(data);
		}
	}
}
