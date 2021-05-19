using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace proyecto.Helpers
{
    public class AdministradorParametros
    {
        private Log _log = new Log();
        public AdministradorParametros() {
        }
        public string ParamDesdeWebConfig(string key)
        {
            string valor = "";
            try
            {
                valor = ConfigurationManager.AppSettings[""+key+""];
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, "-1");
            }

            return valor;

        }
        public class SQLParams
        {
            private Log _log = new Log();

            public SQLParams(){
              
            }

            public string GetConnectionString(string provider)
            {
                string SQLServerConnectionString = "";
                try
                {
                    switch (provider) {
                        case "SQLSERVER":
                            SQLServerConnectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
                            break;
                        case "MYSQL":
                            SQLServerConnectionString = ConfigurationManager.ConnectionStrings["MYSQLConnection"].ConnectionString;
                            break;
                        case "SQLITE":
                            SQLServerConnectionString = ConfigurationManager.ConnectionStrings["SQLITEConnection"].ConnectionString;
                            break;
                        case "ORACLE":
                            SQLServerConnectionString = ConfigurationManager.ConnectionStrings["ORACLEConnection"].ConnectionString;
                            break;
                    }

                    return SQLServerConnectionString;
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message, "-1");
                }
                return "";
            }

            public System.String SQLServerConnectionString { get; set; }

            public enum SqlProvider
            {
                SQLSERVER,
                MYSQL,
            }
        }
        public class ActiveDirectoryParams
        {
            private Log _log = new Log();
            public ActiveDirectoryParams()
            {
                try
                {
                    ActiveDirectoryServidor = ConfigurationManager.AppSettings["ActiveDirectoryServidor"];
                    ActiveDirectoryPuerto = ConfigurationManager.AppSettings["ActiveDirectoryPuerto"];
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message, "-1");
                }
            }

            public System.String ActiveDirectoryServidor { get; set; }
            public System.String ActiveDirectoryPuerto { get; set; }
        }

        public class EmailParams
        {
            private Log _log = new Log();
            public EmailParams()
            {
                try
                {
                    ServidorIP = @ConfigurationManager.AppSettings["CorreoServidorIP"];
                    ServidorPuerto = ConfigurationManager.AppSettings["CorreoServidorPuerto"];
                    CorreoElectronicoSistema = ConfigurationManager.AppSettings["CorreoElectronicoSistema"];
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message, "-1");
                }
            }

            public System.String ServidorIP { get; set; }
            public System.String ServidorPuerto { get; set; }
            public System.String CorreoElectronicoSistema { get; set; }
        }

    }
}
