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
	[RoutePrefix("api/devicetypes")]
	public class devicetypesController: ApiController
	{
		devicetypesDataAccess objdevicetypes = new devicetypesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public devicetypes Consultar()
		{
			return objdevicetypes.Consultardevicetypes();
		}
       [HttpPost]
       [Route("Buscar")]
		public devicetypes Buscar([FromBody] devicetypes.Data data)
		{
			return objdevicetypes.Buscardevicetypes(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public devicetypes.State Insertar([FromBody] devicetypes.Data data)
		{
			return objdevicetypes.Insertardevicetypes(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public devicetypes.State Actualizar([FromBody] devicetypes.Data data)
		{
			return objdevicetypes.Actualizardevicetypes(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public devicetypes.State Eliminar([FromBody] devicetypes.Data data)
		{
			return objdevicetypes.Eliminardevicetypes(data);
		}
	}
}
