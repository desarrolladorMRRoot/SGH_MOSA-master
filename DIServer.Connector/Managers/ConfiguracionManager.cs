using DIServer.Connector;
using DIServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DIServer.Managers
{
    public class ConfiguracionManager
    {
        public DISSession DISSession;
        public string Message;
        public string DISessionId;

        public ConfiguracionManager(DISSession session)
        {
            DISSession = session;
            DISessionId = DISSession.DISessionId;
        }

        public Puesto UpdatePuesto(Puesto puesto)
        {
            string command = string.Empty;
            command += "<dis:Update xmlns:dis='http://www.sap.com/SBO/DIS'>";
            command += "<Service>PUESTOSPLANILLA</Service>";
            command += "<PUESTOSPLANILLANAME>";
            command += "<DocEntry>" + puesto.Code + "</DocEntry>";
            command += "<Code>" + puesto.Code + "</Code>";
            command += "<Name>" + puesto.Code + puesto.U_Puesto + "</Name>";
            command += "<U_Puesto>" + puesto.U_Puesto + "</U_Puesto>";
            command += "<U_Descripcion>" + puesto.U_Descripcion + "</U_Descripcion>";
            command += "</PUESTOSPLANILLANAME>";
            command += "</dis:Update>";

            if (DISSession.Request(command))
            {
                XmlNode fault = DISSession.Response.GetElementsByTagName("env:Fault")[0];

                if (fault != null)
                {
                    Message = fault.FirstChild.NextSibling.InnerText;
                }
                else
                {
                    Message = DISSession.Response.InnerText;
                    XmlNode nOrderCreated = DISSession.Response.GetElementsByTagName("RetKey")[0];
                    //Int32 IdPOCreated = Convert.ToInt32(nOrderCreated.InnerText);
                    //empleado = GetByIdE(IdPOCreated);
                    Message = "Puesto Actualizado!";
                    string dissOff = DISSession.DISessionId;
                    DISSession.Off2(dissOff);
                }
                //string dissOff = DISession.DISessionId;
                // DISession.Off2(dissOff);
            }
            else
            {
                Message = "No se ha podido realizar la petición";
            }

            return puesto;
        }

        public Puesto CreatePuesto(Puesto puesto, string IDPuesto)
        {

            //Consulta el ultimo registro en la base de datos.
            //esto solo es con algunos documentos de SAP

            string command = string.Empty;
            command += "<dis:Add xmlns:dis='http://www.sap.com/SBO/DIS'>";
            command += "<Service>PUESTOSPLANILLA</Service>";
            command += "<PUESTOSPLANILLANAME>";
            command += "<Code>" + IDPuesto + "</Code>";
            command += "<Name>" + IDPuesto + puesto.U_Puesto + "</Name>";
            command += "<U_Puesto>" + puesto.U_Puesto + "</U_Puesto>";
            command += "<U_Descripcion>" + puesto.U_Descripcion + "</U_Descripcion>";


            command += "</PUESTOSPLANILLANAME>";
            command += "</dis:Add>";

            if (DISSession.Request(command))
            {
                XmlNode fault = DISSession.Response.GetElementsByTagName("env:Fault")[0];

                if (fault != null)
                {
                    Message = fault.FirstChild.NextSibling.InnerText;
                }
                else
                {
                    Message = DISSession.Response.InnerText;
                    XmlNode nOrderCreated = DISSession.Response.GetElementsByTagName("RetKey")[0];
                    //Int32 IdPOCreated = Convert.ToInt32(nOrderCreated.InnerText);
                    //RT = GetById(IdPOCreated);
                    Message = "El puesto se ha creado exitosamente!";
                    string dissOff = DISSession.DISessionId;
                    DISSession.Off2(dissOff);
                }
                // string dissOff = DISession.DISessionId;
                //  DISession.Off2(dissOff);
            }
            else
            {
                Message = "No se ha podido realizar la petición";
            }

            return puesto;
        }

    }
}
