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
	[RoutePrefix("api/Grupo")]
	public class GrupoController: ApiController
	{
		GrupoDataAccess objGrupo = new GrupoDataAccess();

		[HttpPost]
		[Route("Consultar")]
		public Grupo Consultar()
		{
			return objGrupo.ConsultarGrupo();
		}
		[HttpPost]
		[Route("Buscar")]
		public Grupo Buscar([FromBody] Grupo.Data data)
		{
			return objGrupo.BuscarGrupo(data.idgrupo);
		}
		[HttpPost]
		[Route("BuscarGrupoXInstitucion")]
		public Grupo BuscarGrupoXInstitucion([FromBody] Grupo.Data data)
		{
			return objGrupo.BuscarGrupoXInstitucion(data.idinstitucion);
		}

		public Grupo.State Post([FromBody] Grupo.Data data)
		{
			return objGrupo.InsertarGrupo(data);
		}

		public Grupo.State Put([FromBody] Grupo.Data data)
		{
			return objGrupo.ActualizarGrupo(data);
		}

		public Grupo.State Delete([FromBody] Grupo.Data data)
		{
			return objGrupo.EliminarGrupo(data);
		}
	}
}
