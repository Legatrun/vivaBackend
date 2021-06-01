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
	[RoutePrefix("api/GrpUsuario")]
	public class GrpUsuarioController: ApiController
	{
		GrpUsuarioDataAccess objGrpUsuario = new GrpUsuarioDataAccess();

		[HttpPost]
		[Route("Consultar")]
		public GrpUsuario Consultar()
		{
			return objGrpUsuario.ConsultarGrpUsuario();
		}
		//public GrpUsuario Get(System.Int32 idgrpusuario)
		//{
		//	return objGrpUsuario.BuscarGrpUsuario(idgrpusuario);
		//}

		[HttpPost]
		[Route("Buscar")]
		public GrpUsuario Buscar([FromBody] GrpUsuario.Data data)
        {
            return objGrpUsuario.BuscarGrpUsuarioXUsuario(data.idusuario);
        }

        public GrpUsuario.State Post([FromBody] GrpUsuario.Data data)
		{
			return objGrpUsuario.InsertarGrpUsuario(data);
		}

		public GrpUsuario.State Put([FromBody] GrpUsuario.Data data)
		{
			return objGrpUsuario.ActualizarGrpUsuario(data);
		}

		public GrpUsuario.State Delete([FromBody] GrpUsuario.Data data)
		{
			return objGrpUsuario.EliminarGrpUsuario(data);
		}
	}
}
