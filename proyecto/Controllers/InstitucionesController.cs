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
    [RoutePrefix("api/Instituciones")]
    public class InstitucionesController: ApiController
	{
		InstitucionesDataAccess objInstituciones = new InstitucionesDataAccess();

        [HttpPost]
        [Route("Consultar")]
        public Instituciones Consultar()
		{
			return objInstituciones.ConsultarInstituciones();
		}

        [HttpPost]
        [Route("Buscar")]
        public Instituciones Buscar([FromBody] Instituciones.Data data)
		{
			return objInstituciones.BuscarInstituciones(data.idinstitucion);
		}

		public Instituciones.State Post([FromBody] Instituciones.Data data)
		{
			return objInstituciones.InsertarInstituciones(data);
		}

		public Instituciones.State Put([FromBody] Instituciones.Data data)
		{
			return objInstituciones.ActualizarInstituciones(data);
		}

		public Instituciones.State Delete([FromBody] Instituciones.Data data)
		{
			return objInstituciones.EliminarInstituciones(data);
		}
	}
}
