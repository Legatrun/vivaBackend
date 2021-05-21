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
	[RoutePrefix("api/RolesAplicaciones")]
	public class RolesAplicacionesController: ApiController
	{
		RolesAplicacionesDataAccess objRolesAplicaciones = new RolesAplicacionesDataAccess();
		[HttpPost]
		[Route("Consultar")]
		public RolesAplicaciones Consultar()
		{
			return objRolesAplicaciones.ConsultarRolesAplicaciones();
		}
		//public RolesAplicaciones Get(System.Int32 idrolesaplicaciones)
		//{
		//	return objRolesAplicaciones.BuscarRolesAplicaciones(idrolesaplicaciones);
		//}
		[HttpPost]
		[Route("Buscar")]
		public RolesAplicaciones Buscar([FromBody] RolesAplicaciones.Data data)
		{
			return objRolesAplicaciones.BuscarRolesAplicacionesXRol(data.idrol);
		}

		public RolesAplicaciones.State Post([FromBody] RolesAplicaciones.Data data)
		{
			return objRolesAplicaciones.InsertarRolesAplicaciones(data);
		}

		public RolesAplicaciones.State Put([FromBody] RolesAplicaciones.Data data)
		{
			return objRolesAplicaciones.ActualizarRolesAplicaciones(data);
		}

		public RolesAplicaciones.State Delete([FromBody] RolesAplicaciones.Data data)
		{
			return objRolesAplicaciones.EliminarRolesAplicaciones(data);
		}
	}
}
