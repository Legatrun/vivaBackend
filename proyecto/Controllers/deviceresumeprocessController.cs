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
	[RoutePrefix("api/deviceresumeprocess")]
	public class deviceresumeprocessController: ApiController
	{
		deviceresumeprocessDataAccess objdeviceresumeprocess = new deviceresumeprocessDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public deviceresumeprocess Consultar()
		{
			return objdeviceresumeprocess.Consultardeviceresumeprocess();
		}
       [HttpPost]
       [Route("Buscar")]
		public deviceresumeprocess Buscar([FromBody] deviceresumeprocess.Data data)
		{
			return objdeviceresumeprocess.Buscardeviceresumeprocess(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public deviceresumeprocess.State Insertar([FromBody] deviceresumeprocess.Data data)
		{
			return objdeviceresumeprocess.Insertardeviceresumeprocess(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public deviceresumeprocess.State Actualizar([FromBody] deviceresumeprocess.Data data)
		{
			return objdeviceresumeprocess.Actualizardeviceresumeprocess(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public deviceresumeprocess.State Eliminar([FromBody] deviceresumeprocess.Data data)
		{
			return objdeviceresumeprocess.Eliminardeviceresumeprocess(data);
		}
	}
}
