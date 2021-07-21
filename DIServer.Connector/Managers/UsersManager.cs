using DIServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DIServer.Connector.Managers
{
    public class UsersManager
    {
        public DISSession DISession;
        public string DISessionId;
        public string Message;

        public UsersManager(DISSession session)
        {
            DISession = session;
        }


        public User IsAutentic(string UserName, string UserPassword)
        {
            User User = null;

            if (DISession.Start(DISessionId))
            {
                XmlDocument responsePO = new XmlDocument();

                string QuerString = string.Format("SELECT * FROM OUSR WHERE E_MAIL='{0}' AND U_Password='{1}'", UserName, UserPassword);

                DISession.ExecuteSQL(QuerString);
                responsePO = DISession.Response;
                XmlNodeList xnList = responsePO.GetElementsByTagName("row");

                if (xnList.Count > 0)
                {
                    XmlNode xn = xnList[0];
                    if (xn["USER_CODE"].InnerText != "")
                    {
                        User = new User();
                        User.UserName = xn["USER_CODE"].InnerText;
                        User.Name = xn["USER_CODE"].InnerText;
                        User.UserId = xn["USERID"].InnerText;
                        User.Role = "Operador";

                        if (xn["SUPERUSER"].InnerText.ToString() == "Y")
                            User.Role = "Adminsitrador";

                        Message = "Se ha realizado la consulta exitosamente";

                    }
                    else
                    {
                        Message = "DIS Session no valid";
                    }
                }
                string dissOff = DISession.DISessionId;
                DISession.Off2(dissOff);
            }
            else
            {
                Message = "DIS Session no valida";
            }

            return User;

        }


    }
}
