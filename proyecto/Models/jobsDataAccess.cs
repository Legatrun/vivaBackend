using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class jobsDataAccess
	{
		jobs.State _state = new jobs.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public jobs Consultarjobs()
		{
		    _log.Traceo("Ingresa a Metodo Consultar jobs", "0");
			List<jobs.Data> lstjobs = new List<jobs.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_jobs_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					jobs.Data _jobs= new jobs.Data();
					_jobs.jobname = Convert.ToString(rdr["jobname"].ToString());
					lstjobs.Add(_jobs);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar jobs", _state.error.ToString());
				return new jobs(_state, lstjobs);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new jobs(_state);
		}
		public jobs Buscarjobs(jobs.Data _jobsData)
		{
			List<jobs.Data> lstjobs = new List<jobs.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar jobs", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_jobs_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@jobname", _jobsData.jobname);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					jobs.Data _jobs= new jobs.Data();
					_jobs.jobname = Convert.ToString(rdr["jobname"].ToString());
					lstjobs.Add(_jobs);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar jobs", _state.error.ToString());
				return new jobs(_state, lstjobs);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new jobs(_state);
		}
		public jobs.State Insertarjobs(jobs.Data _jobs)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar jobs", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_jobs_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@jobname", _jobs.jobname);
				SqlCmd.Parameters.AddWithValue("@jobstarttimestamp", _jobs.jobstarttimestamp);
				SqlCmd.Parameters.AddWithValue("@jobendtimestamp", _jobs.jobendtimestamp);
				SqlCmd.Parameters.AddWithValue("@jobstatus", _jobs.jobstatus);
				SqlCmd.Parameters.AddWithValue("@jobcommand", _jobs.jobcommand);
				SqlCmd.Parameters.AddWithValue("@jobreturncode", _jobs.jobreturncode);
				SqlCmd.Parameters.AddWithValue("@joboutputfile", _jobs.joboutputfile);
				SqlCmd.Parameters.AddWithValue("@userid", _jobs.userid);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar jobs", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Insertar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
		public jobs.State Actualizarjobs(jobs.Data _jobs)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar jobs", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_jobs_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@jobname", _jobs.jobname);
				SqlCmd.Parameters.AddWithValue("@jobstarttimestamp", _jobs.jobstarttimestamp);
				SqlCmd.Parameters.AddWithValue("@jobendtimestamp", _jobs.jobendtimestamp);
				SqlCmd.Parameters.AddWithValue("@jobstatus", _jobs.jobstatus);
				SqlCmd.Parameters.AddWithValue("@jobcommand", _jobs.jobcommand);
				SqlCmd.Parameters.AddWithValue("@jobreturncode", _jobs.jobreturncode);
				SqlCmd.Parameters.AddWithValue("@joboutputfile", _jobs.joboutputfile);
				SqlCmd.Parameters.AddWithValue("@userid", _jobs.userid);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar jobs", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Actualizar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
		public jobs.State Eliminarjobs(jobs.Data _jobs)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar jobs", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_jobs_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@jobname", _jobs.jobname);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar jobs", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Eliminar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
	}
}
