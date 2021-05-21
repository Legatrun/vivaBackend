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
	[RoutePrefix("api/Operaciones")]
	public class OperacionesController: ApiController
	{
		OperacionesDataAccess objOperaciones = new OperacionesDataAccess();
		[HttpPost]
		[Route("Consultar")]
		public Operaciones Consultar()
		{
			return objOperaciones.ConsultarOperaciones();
		}
		[HttpPost]
		[Route("Buscar")]
		public Operaciones Buscar([FromBody] Operaciones.Data data)
		{
			return objOperaciones.BuscarOperaciones(data.idoperacion);
		}

		public Operaciones.State Post([FromBody] Operaciones.Data data)
		{
			return objOperaciones.InsertarOperaciones(data);
		}

		public Operaciones.State Put([FromBody] Operaciones.Data data)
		{
			return objOperaciones.ActualizarOperaciones(data);
		}

		public Operaciones.State Delete([FromBody] Operaciones.Data data)
		{
			return objOperaciones.EliminarOperaciones(data);
		}
	}
}
