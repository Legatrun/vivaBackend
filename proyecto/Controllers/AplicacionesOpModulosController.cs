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
    [RoutePrefix("api/AplicacionesOpModulos")]
    public class AplicacionesOpModulosController: ApiController
	{
		AplicacionesOpModulosDataAccess objAplicacionesOpModulos = new AplicacionesOpModulosDataAccess();

        [HttpPost]
        [Route("Consultar")]
        public AplicacionesOpModulos Consultar()
		{
			return objAplicacionesOpModulos.ConsultarAplicacionesOpModulos();
		}

        [HttpPost]
        [Route("Buscar")]
        public AplicacionesOpModulos Buscar([FromBody] AplicacionesOpModulos.Data data)
		{
			return objAplicacionesOpModulos.BuscarAplicacionesOpModulos(data.idaplicacionesopmodulos);
		}

        [HttpPost]
        [Route("BuscarXAplicacion")]
        public AplicacionesOpModulos BuscarXAplicacion([FromBody] AplicacionesOpModulos.Data data, System.Int32 idrol)
		{
			return objAplicacionesOpModulos.BuscarAplicacionesOpModulosXAplicacion(data.idaplicacion, idrol);
		}

		public AplicacionesOpModulos.State Post([FromBody] AplicacionesOpModulos.Data data)
		{
			return objAplicacionesOpModulos.InsertarAplicacionesOpModulos(data);
		}

		public AplicacionesOpModulos.State Put([FromBody] AplicacionesOpModulos.Data data)
		{
			return objAplicacionesOpModulos.ActualizarAplicacionesOpModulos(data);
		}

		public AplicacionesOpModulos.State Delete([FromBody] AplicacionesOpModulos.Data data)
		{
			return objAplicacionesOpModulos.EliminarAplicacionesOpModulos(data);
		}
	}
}
