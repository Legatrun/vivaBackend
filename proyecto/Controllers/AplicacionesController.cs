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
	[RoutePrefix("api/Aplicaciones")]
	public class AplicacionesController: ApiController
	{
		AplicacionesDataAccess objAplicaciones = new AplicacionesDataAccess();
		[HttpPost]
		[Route("Consultar")]
		public Aplicaciones Consultar()
		{
			return objAplicaciones.ConsultarAplicaciones();
		}
		[HttpPost]
		[Route("Buscar")]
		public Aplicaciones Buscar([FromBody] Aplicaciones.Data data)
		{
			return objAplicaciones.BuscarAplicaciones(data.idaplicacion);
		}
		[HttpPost]
		[Route("Autenticar")]
		public Aplicaciones Autenticar([FromBody] Aplicaciones.Data data)
		{
			return objAplicaciones.AutenticarUser(data.nombre, data.password);
		}

		public Aplicaciones.State Post([FromBody] Aplicaciones.Data data)
		{
			return objAplicaciones.InsertarAplicaciones(data);
		}

		public Aplicaciones.State Put([FromBody] Aplicaciones.Data data)
		{
			return objAplicaciones.ActualizarAplicaciones(data);
		}

		public Aplicaciones.State Delete([FromBody] Aplicaciones.Data data)
		{
			return objAplicaciones.EliminarAplicaciones(data);
		}
	}
}
