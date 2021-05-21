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
    [RoutePrefix("api/Agencias")]
    public class AgenciasController: ApiController
	{
		AgenciasDataAccess objAgencias = new AgenciasDataAccess();

        [HttpPost]
        [Route("Consultar")]
        public Agencias Consultar()
		{
			return objAgencias.ConsultarAgencias();
		}

        [HttpPost]
        [Route("Buscar")]
        public Agencias Buscar([FromBody] Agencias.Data data)
		{
			return objAgencias.BuscarAgencias(data.id_agencia);
		}

		public Agencias.State Post([FromBody] Agencias.Data data)
		{
			return objAgencias.InsertarAgencias(data);
		}

		public Agencias.State Put([FromBody] Agencias.Data data)
		{
			return objAgencias.ActualizarAgencias(data);
		}

		public Agencias.State Delete([FromBody] Agencias.Data data)
		{
			return objAgencias.EliminarAgencias(data);
		}
	}
}
