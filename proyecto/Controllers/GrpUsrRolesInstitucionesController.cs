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
	[RoutePrefix("api/GrpUsrRolesInstituciones")]
	public class GrpUsrRolesInstitucionesController: ApiController
	{
		GrpUsrRolesInstitucionesDataAccess objGrpUsrRolesInstituciones = new GrpUsrRolesInstitucionesDataAccess();
		[HttpPost]
		[Route("Consultar")]
		public GrpUsrRolesInstituciones Consultar()
		{
			return objGrpUsrRolesInstituciones.ConsultarGrpUsrRolesInstituciones();
		}
		//public GrpUsrRolesInstituciones Get(System.Int32 idgrpusuariorolinstitucion)
		//{
		//	return objGrpUsrRolesInstituciones.BuscarGrpUsrRolesInstituciones(idgrpusuariorolinstitucion);
		//}
		[HttpPost]
		[Route("Buscar")]
		public GrpUsrRolesInstituciones Buscar([FromBody] GrpUsrRolesInstituciones.Data data)
		{
			return objGrpUsrRolesInstituciones.BuscarGrpUsrRolesInstitucionesXInstitucion(data.idinstitucionrol);
		}

		public GrpUsrRolesInstituciones.State Post([FromBody] GrpUsrRolesInstituciones.Data data)
		{
			return objGrpUsrRolesInstituciones.InsertarGrpUsrRolesInstituciones(data);
		}

		public GrpUsrRolesInstituciones.State Put([FromBody] GrpUsrRolesInstituciones.Data data)
		{
			return objGrpUsrRolesInstituciones.ActualizarGrpUsrRolesInstituciones(data);
		}

		public GrpUsrRolesInstituciones.State Delete([FromBody] GrpUsrRolesInstituciones.Data data)
		{
			return objGrpUsrRolesInstituciones.EliminarGrpUsrRolesInstituciones(data);
		}
	}
}
