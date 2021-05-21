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
	[RoutePrefix("api/Roles")]
	public class RolesController: ApiController
	{
		RolesDataAccess objRoles = new RolesDataAccess();
		[HttpPost]
		[Route("Consultar")]
		public Roles Consultar()
		{
			return objRoles.ConsultarRoles();
		}
		[HttpPost]
		[Route("Buscar")]
		public Roles Buscar([FromBody] Roles.Data data)
		{
			return objRoles.BuscarRoles(data.idrol);
		}

		public Roles.State Post([FromBody] Roles.Data data)
		{
			return objRoles.InsertarRoles(data);
		}

		public Roles.State Put([FromBody] Roles.Data data)
		{
			return objRoles.ActualizarRoles(data);
		}

		public Roles.State Delete([FromBody] Roles.Data data)
		{
			return objRoles.EliminarRoles(data);
		}
	}
}
