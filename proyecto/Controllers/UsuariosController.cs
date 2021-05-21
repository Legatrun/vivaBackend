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
	[RoutePrefix("api/Usuarios")]
	public class UsuariosController: ApiController
	{
		UsuariosDataAccess objUsuarios = new UsuariosDataAccess();

		[HttpPost]
		[Route("Consultar")]
		public Usuarios Consultar()
		{
			return objUsuarios.ConsultarUsuarios();
		}
		//public Usuarios Get(System.Int32 idusuario)
		//{
		//	return objUsuarios.BuscarUsuarios(idusuario);
		//}
		[HttpPost]
		[Route("Buscar")]
		public Usuarios Buscar([FromBody] Usuarios.Data data)
		{
			return objUsuarios.LoginUsuarios(data.nombre, data.password);
		}
		[HttpPost]
		[Route("BuscarXInstitucion")]
		public Usuarios BuscarXInstitucion([FromBody] Usuarios.Data data)
		{
			return objUsuarios.BuscarUsuariosXInstitucion(data.idinstitucion);
		}

		public Usuarios.State Post([FromBody] Usuarios.Data data)
		{
			return objUsuarios.InsertarUsuarios(data);
		}

		public Usuarios.State Put([FromBody] Usuarios.Data data)
		{
			return objUsuarios.ActualizarUsuarios(data);
		}

		public Usuarios.State Delete([FromBody] Usuarios.Data data)
		{
			return objUsuarios.EliminarUsuarios(data);
		}
	}
}
