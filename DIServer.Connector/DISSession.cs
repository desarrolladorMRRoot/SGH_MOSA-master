using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBODI_Server;
using System.Configuration;
using System.Xml;


namespace DIServer.Connector
{
    public class DISSession
    {
        public string DISessionId { get; set; }
        public string Message { get; set; }
        protected string DBServer;
        protected string DBName;
        protected string DBUserName;
        protected string DBUserPassword;
        protected string DBType;
        protected string CompanyUserName;
        protected string CompanyUserPass;
        protected string LicenseServer;
        protected string Language;
        public XmlDocument Response { get; set; }

        public DISSession()
        {
            DBServer = ConfigurationManager.AppSettings["DIServer.DbServer"];
            DBName = ConfigurationManager.AppSettings["DIServer.DbName"];
            DBUserName = ConfigurationManager.AppSettings["DIServer.DBUserName"];
            DBUserPassword = ConfigurationManager.AppSettings["DIServer.DBUserPassword"];
            DBType = ConfigurationManager.AppSettings["DIServer.DBType"];
            CompanyUserName = ConfigurationManager.AppSettings["DIServer.CompanyUserName"];
            CompanyUserPass = ConfigurationManager.AppSettings["DIServer.CompanyUserPass"];
            LicenseServer = ConfigurationManager.AppSettings["DIServer.LicenseServer"];
            Language = ConfigurationManager.AppSettings["DIServer.Language"];
        }

        public bool Start(string SessionStarted = null)
        {
            bool isloged = false;
            Message = string.Empty;

            if (SessionStarted != null)
            {
                if (SessionStarted == string.Empty)
                    SessionStarted = null;
            }

            if (SessionStarted == null)
            {
                if (Request(LoginCMD()))
                {
                    var newSessionId = Response.DocumentElement.InnerText;
                    Guid session = Guid.Empty;

                    if (Guid.TryParse(newSessionId, out session))
                    {
                        DISessionId = newSessionId;
                        isloged = true;
                        Message = "Se ha generado una nueva session";
                    }
                }
                else
                {
                    DISessionId = null;
                    Message = "No se ha realizado la petición al servidor";
                }
            }
            else
            {
                DISessionId = SessionStarted;
                isloged = true;
                Message = "Se reutilizará la session existente";
            }

            return isloged;

        }

        public void Off()
        {
            String command = LogoutCMD();
            DISessionId = string.Empty;

            if (Request(command))
            {
                DISessionId = null;
                Message = "Se ha cerrado la session";
            }
            else
            {
                Message = "No se ha cerrado la session";
            }
        }

        public void Off2(string dissOff)
        {
            dissOff = DISessionId;
            String command = LogoutCMD();
            //DISessionId = string.Empty;

            if (Request(command))
            {
                // DISessionId = null;
                Message = "Se ha cerrado la session";
            }
            else
            {
                Message = "No se ha cerrado la session";
            }
        }

        public string ExecuteSQL(string SQLQuery)
        {
            var CommandXML = ExecuteSQLCMD(SQLQuery);

            if (Request(CommandXML))
            {
                Response = Response;
                Message = "Se ha ejecutado ExecuteSQL sactifactoriamente";
            }
            else
            {
                Response = null;
                Message = "No se pudo realizar la petición";
            }

            return Message;

        }

        public bool Request(string CommandXML = null)
        {
            Node node = new Node();
            bool result = false;
            string tplCommandString = MasterXML(CommandXML);

            if (CommandXML == null || CommandXML == string.Empty)
            {
                Response = null;
                Message = "El comando XML esta vacio.";
            }
            else
            {
                try
                {
                    string command = node.Interact(tplCommandString);
                    XmlDocument response = new XmlDocument();
                    response.LoadXml(command);
                    Response = response;
                    Message = response.DocumentElement.InnerText;

                    result = true;
                }
                catch (Exception e)
                {
                    Response = null;
                    Message = "Error inesperado al intentar realizar una petición : " + e.Message;
                }
            }

            return result;
        }

        public bool Request2(string CommandXML = null)
        {
            Node node = new Node();
            bool result = false;
            string tplCommandString = MasterXML(CommandXML);

            if (CommandXML == null || CommandXML == string.Empty)
            {
                Response = null;
                Message = "El comando XML esta vacio.";
            }
            else
            {
                try
                {
                    string command = node.Interact(tplCommandString);
                    XmlDocument response = new XmlDocument();
                    response.LoadXml(command);
                    Response = response;
                    Message = response.DocumentElement.InnerText;

                    result = true;
                }
                catch (Exception e)
                {
                    Response = null;
                    Message = "Error inesperado al intentar realizar una petición : " + e.Message;
                }
            }

            return result;
        }

        private string ExecuteSQLCMD(string SQLQuery)
        {
            String XML;
            XML = "<dis:ExecuteSQL xmlns:dis='http://www.sap.com/SBO/DIS'>";
            XML += "<DoQuery>" + SQLQuery + "</DoQuery>";
            XML += "</dis:ExecuteSQL>";

            return XML;
        }

        private string LoginCMD()
        {
            string loginCmd;

            loginCmd = "<dis:Login xmlns:dis='http://www.sap.com/SBO/DIS'>";
            loginCmd += "<DatabaseServer>" + DBServer + "</DatabaseServer>";
            loginCmd += "<DatabaseUsername>" + DBUserName + "</DatabaseUsername>";
            loginCmd += "<DatabasePassword>" + DBUserPassword + "</DatabasePassword>";
            loginCmd += "<DatabaseType>" + DBType + "</DatabaseType>";
            loginCmd += "<DatabaseName>" + DBName + "</DatabaseName>";
            loginCmd += "<LicenseServer>" + LicenseServer + "</LicenseServer>";
            loginCmd += "<CompanyUsername>" + CompanyUserName + "</CompanyUsername>";
            loginCmd += "<CompanyPassword>" + CompanyUserPass + "</CompanyPassword>";
            loginCmd += "<Language>" + Language + "</Language>";
            loginCmd += "</dis:Login>";

            return loginCmd;
        }

        private string LogoutCMD()
        {
            string TplXML = "<dis:Logout xmlns:dis='http://www.sap.com/SBO/DIS'></dis:Logout>";
            return TplXML;
        }

        private string HeaderXML()
        {
            string TplHeaderXML = "<env:Header><SessionID>" + DISessionId + "</SessionID></env:Header>";
            return TplHeaderXML;
        }

        private string MasterXML(string TplComandXML)
        {
            String TplXML = String.Empty;

            TplXML = @"<?xml version=""1.0"" encoding=""UTF-16""?>";
            TplXML += @"<env:Envelope xmlns:env=""http://schemas.xmlsoap.org/soap/envelope/"">";
            TplXML += HeaderXML();
            TplXML += "<env:Body>";
            TplXML += TplComandXML;
            TplXML += "</env:Body>";
            TplXML += "</env:Envelope>";
            return TplXML;
        } 

    }
}
