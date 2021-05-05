using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class tb_usuarios
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public tb_usuarios(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public tb_usuarios(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String nombre_usuario{ get; set; }
			public System.String nombre{ get; set; }
			public System.String apellido{ get; set; }
			public System.String email{ get; set; }
			public System.String tel{ get; set; }
			public System.String telmovil{ get; set; }
			public System.String hash{ get; set; }
			public System.Int32 idgrupo{ get; set; }
			public System.Int32 idperfil{ get; set; }
			public System.String aplicacion{ get; set; }
			public System.Int32 enabled{ get; set; }
			public System.String config{ get; set; }
			public System.String notas{ get; set; }
			public System.Int32 cambiar_pwd{ get; set; }
			public System.Int32 estado{ get; set; }
			public System.DateTime create_timestamp{ get; set; }
			public System.String usuario_creacion { get; set; }
			public System.String usuario_modif { get; set; }
			public System.DateTime ultimo_acceso{ get; set; }
			public System.DateTime fec_modificacion{ get; set; }
			public System.String usua_modificacion{ get; set; }
			public System.Int32 intentos{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
