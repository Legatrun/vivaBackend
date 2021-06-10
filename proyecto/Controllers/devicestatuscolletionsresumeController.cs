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
	[RoutePrefix("api/devicestatuscolletionsresume")]
	public class devicestatuscolletionsresumeController: ApiController
	{
		devicestatuscolletionsresumeDataAccess objdevicestatuscolletionsresume = new devicestatuscolletionsresumeDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public devicestatuscolletionsresume Consultar()
		{
			return objdevicestatuscolletionsresume.Consultardevicestatuscolletionsresume();
		}
        [HttpPost]
        [Route("ConsultarPorProvider")]
        public devicestatuscolletionsresume ConsultarPorProvider()
        {
            return objdevicestatuscolletionsresume.Consultardevicestatuscolletionsresumeprovider();
        }
        [HttpPost]
       [Route("Buscar")]
		public devicestatuscolletionsresume Buscar([FromBody] devicestatuscolletionsresume.Data data)
		{
			return objdevicestatuscolletionsresume.Buscardevicestatuscolletionsresume(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public devicestatuscolletionsresume.State Insertar([FromBody] devicestatuscolletionsresume.Data data)
		{
			return objdevicestatuscolletionsresume.Insertardevicestatuscolletionsresume(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public devicestatuscolletionsresume.State Actualizar([FromBody] devicestatuscolletionsresume.Data data)
		{
			return objdevicestatuscolletionsresume.Actualizardevicestatuscolletionsresume(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public devicestatuscolletionsresume.State Eliminar([FromBody] devicestatuscolletionsresume.Data data)
		{
			return objdevicestatuscolletionsresume.Eliminardevicestatuscolletionsresume(data);
		}
	}
}
