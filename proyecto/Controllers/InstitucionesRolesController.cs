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
    [RoutePrefix("api/InstitucionesRoles")]
    public class InstitucionesRolesController: ApiController
	{
		InstitucionesRolesDataAccess objInstitucionesRoles = new InstitucionesRolesDataAccess();

        [HttpPost]
        [Route("Consultar")]
        public InstitucionesRoles Consultar()
		{
			return objInstitucionesRoles.ConsultarInstitucionesRoles();
		}

        [HttpPost]
        [Route("Buscar")]
        public InstitucionesRoles Buscar([FromBody] InstitucionesRoles.Data data)
        {
            return objInstitucionesRoles.BuscarInstitucionesRoles(data.idinstitucionrol);
        }

        [HttpPost]
        [Route("BuscarXInstitucion")]
        public InstitucionesRoles BuscarXInstitucion([FromBody] InstitucionesRoles.Data data)
        {
			return objInstitucionesRoles.BuscarInstitucionesRolesXInstitucion(data.idinstitucion);
        }

		public InstitucionesRoles.State Post([FromBody] InstitucionesRoles.Data data)
		{
			return objInstitucionesRoles.InsertarInstitucionesRoles(data);
		}

		public InstitucionesRoles.State Put([FromBody] InstitucionesRoles.Data data)
		{
			return objInstitucionesRoles.ActualizarInstitucionesRoles(data);
		}

		public InstitucionesRoles.State Delete([FromBody] InstitucionesRoles.Data data)
		{
			return objInstitucionesRoles.EliminarInstitucionesRoles(data);
		}
	}
}
