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
	[RoutePrefix("api/Cliente")]
	public class ClienteController: ApiController
	{
		ClienteDataAccess objCliente = new ClienteDataAccess();

		[HttpPost]
		[Route("Consultar")]
		public Cliente Consultar()
		{
			return objCliente.ConsultarCliente();
		}
		//public Cliente Get(System.Int32 idcliente)
		//{
		//	return objCliente.BuscarCliente(idcliente);
		//}
		[HttpPost]
		[Route("Buscar")]
		public Cliente Buscar([FromBody] Cliente.Data data)
		{
			return objCliente.LoginCliente(data.ci);
		}

		public Cliente.State Post([FromBody] Cliente.Data data)
		{
			return objCliente.InsertarCliente(data);
		}

		public Cliente.State Put([FromBody] Cliente.Data data)
		{
			return objCliente.ActualizarCliente(data);
		}

		public Cliente.State Delete([FromBody] Cliente.Data data)
		{
			return objCliente.EliminarCliente(data);
		}
	}
}
