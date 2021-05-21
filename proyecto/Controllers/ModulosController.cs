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
	[RoutePrefix("api/Modulos")]
	public class ModulosController: ApiController
	{
		ModulosDataAccess objModulos = new ModulosDataAccess();
		[HttpPost]
		[Route("Consultar")]
		public Modulos Consultar()
		{
			return objModulos.ConsultarModulos();
		}
  //      public Modulos Get(System.Int32 idaplicacion)
		//{
		//	return objModulos.BuscarModulosXAplicacion(idaplicacion);
		//}

		public Modulos.State Post([FromBody] Modulos.Data data)
		{
			return objModulos.InsertarModulos(data);
		}

		public Modulos.State Put([FromBody] Modulos.Data data)
		{
			return objModulos.ActualizarModulos(data);
		}

		public Modulos.State Delete([FromBody] Modulos.Data data)
		{
			return objModulos.EliminarModulos(data);
		}
	}
}
