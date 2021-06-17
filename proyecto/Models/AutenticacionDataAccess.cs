using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using proyecto.Helpers;
using MySql.Data.MySqlClient;
namespace proyecto.Models
{
    public class AutenticacionDataAccess
    {
        Autenticacion.State _state = new Autenticacion.State();
        private Log _log = new Log();
        private Encriptador _crypto = new Encriptador();
        private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
        private Conexion Base = new Conexion();

        public Autenticacion Login(Autenticacion.Data data)
        {
            List<Autenticacion.Data> lstAutenticacion = new List<Autenticacion.Data>();
            try
            {
                _log.Traceo("Inicia Sesión de Usuario " + _crypto.DesencriptarValorFront(data.Usuario), "0");

                MySqlConnection SqlCnn;
                SqlCnn = Base.AbrirConexionMySql();
                MySqlCommand SqlCmd = new MySqlCommand("Proc_Autenticacion_Login", SqlCnn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@usuario", _crypto.DesencriptarValorFront(data.Usuario));
                SqlCmd.Parameters.AddWithValue("@password", _crypto.DesencriptarValorFront(data.Password));
                MySqlDataReader rdr = SqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    Autenticacion.Data _Autenticacion = new Autenticacion.Data();
                    _Autenticacion.Usuario = (System.String)rdr["Usuario"];
                    _Autenticacion.FechaUltimoLogin = (System.DateTime)rdr["FechaUltimaSesionIniciada"]; 
                    lstAutenticacion.Add(_Autenticacion);
                }
                Base.CerrarConexionMySql(SqlCnn);
                _state.error = 0;
                _state.descripcion = "Sesion Iniciada";
                _log.Traceo("Sesión de Usuario " + data.Usuario + " iniciada", _state.error.ToString());
                return new Autenticacion(_state, lstAutenticacion);
            }
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
            {
                _state.error = -3;
                _state.descripcion = Ex.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            return new Autenticacion(_state);
        }

        public Autenticacion.State LoginAD(Autenticacion.Data data)
        {
            List<Autenticacion.Data> lstAutenticacion = new List<Autenticacion.Data>();
            try
            {
                _log.Traceo("Inicia Sesión de Usuario "+ _crypto.DesencriptarValorFront(data.Usuario), "0");

                Autenticacion objUsuarioVerificado = VerificarUsuario(data);
                if (objUsuarioVerificado._error.error != 0) {
                    _state.error = objUsuarioVerificado._error.error;
                    _state.descripcion = objUsuarioVerificado._error.descripcion;
                    _log.Error(objUsuarioVerificado._error.descripcion, objUsuarioVerificado._error.error.ToString());
                    return _state;
                }

                data.Dominio = _params.ActiveDirectoryServidor;

                var RespAD = false;

                using (var context = new PrincipalContext(ContextType.Domain, data.Dominio))
                {
                    var UsuarioEnPlano = _crypto.DesencriptarValorFront(data.Usuario);
                    var PasswordEnPlano = _crypto.DesencriptarValorFront(data.Password);
                    RespAD = context.ValidateCredentials(UsuarioEnPlano,PasswordEnPlano);
                }

                if (RespAD == true)
                {
                    _state.error = 0;
                    _state.descripcion = "Sesion Iniciada";
                    _log.Traceo("Sesión de Usuario " + data.Usuario + " iniciada", _state.error.ToString());
                }
                else {
                    _state.error = -4;
                    _state.descripcion = "Usuario Inexistente";
                    _log.Error(_state.descripcion, _state.error.ToString());
                }
                return _state;
            }
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
            {
                _state.error = -3;
                _state.descripcion = Ex.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            return _state;
        }

        public Autenticacion.State Logout(Autenticacion.Data data)
        {
            Autenticacion.State _state = new Autenticacion.State();
            try
            {
                _log.Traceo("Cierre de Sesión de Usuario " + _crypto.DesencriptarValorFront(data.Usuario), "0");

                MySqlConnection SqlCnn;
                SqlCnn = Base.AbrirConexionMySql();
                MySqlCommand SqlCmd = new MySqlCommand("Proc_Autenticacion_Logout", SqlCnn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@usuario", _crypto.DesencriptarValorFront(data.Usuario));
                MySqlDataReader rdr = SqlCmd.ExecuteReader();
               
                Base.CerrarConexionMySql(SqlCnn);
                _state.error = 0;
                _state.descripcion = "Sesion Finalizada";
                _log.Traceo("Sesión de Usuario " + data.Usuario +" Finalizada"+ " iniciada", _state.error.ToString());
                return _state;
            }
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
            {
                _state.error = -3;
                _state.descripcion = Ex.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            return _state;
        }

        private Autenticacion VerificarUsuario(Autenticacion.Data data)
        {
            List<Autenticacion.Data> lstAutenticacion = new List<Autenticacion.Data>();
            try
            {
                _log.Traceo("Verifica existencia de Usuario " + _crypto.DesencriptarValorFront(data.Usuario), "0");

                MySqlConnection SqlCnn;
                SqlCnn = Base.AbrirConexionMySql();
                MySqlCommand SqlCmd = new MySqlCommand("Proc_Autenticacion_VerificaUsuario", SqlCnn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@usuario", _crypto.DesencriptarValorFront(data.Usuario));
                MySqlDataReader rdr = SqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    Autenticacion.Data _Autenticacion = new Autenticacion.Data();
                    _Autenticacion.Usuario = (System.String)rdr["Usuario"];
                    lstAutenticacion.Add(_Autenticacion);
                }
                Base.CerrarConexionMySql(SqlCnn);
                _state.error = 0;
                _state.descripcion = "Usuario Existente";
                _log.Traceo("Usuario Verificado: " + data.Usuario, _state.error.ToString());
                return new Autenticacion(_state, lstAutenticacion);
            }
            catch (MySqlException XcpSQL)
            {
                _state.error = -2;
                _state.descripcion = "Error: " + XcpSQL.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            catch (Exception Ex)
            {
                _state.error = -3;
                _state.descripcion = Ex.Message;
                _log.Error(_state.descripcion, _state.error.ToString());
            }
            return new Autenticacion(_state);
        }

    }
}
