using DIServer.Connector;
using DIServer.Connector.Managers;
using DIServer.Managers;
using DIServer.Models;
using Newtonsoft.Json;
using SGH_MOSA.Filters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;

namespace SGH_MOSA.Controllers
{
    public class ConfiguracionController : Controller
    {
        string DISessionId = (System.Web.HttpContext.Current.Session["DISSessionID"] != null) ? System.Web.HttpContext.Current.Session["DISSessionID"] as string : null;
        DISSession DISession = new DISSession();
        ConfiguracionManager Manager;

        //Este Metodo funcionara para listar todos los puestos existentes y permitir crear uno nuevo si así lo desean.
        [AuthSAP("Adminsitrador")]
        public ActionResult Puesto()
        {
            return View();
        }

        //metodo obtiene todos los puestos.
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public ActionResult GetPuestos()//ESTE METODO EJECUTA LA CONSULTA 
        {
            string query = " SELECT  Code, U_Puesto, U_Descripcion FROM [@PUESTO_PLANILLA] order by cast(U_Puesto as int) desc ";
            SqlCommand cmd = new SqlCommand(query);
            string data = getDataPuesto(cmd);
            var objDAta = JsonConvert.DeserializeObject<List<Puesto>>(data);
            return Json(objDAta, JsonRequestBehavior.AllowGet);

        }

        private static string getDataPuesto(SqlCommand cmd)//ESTE METOD OBTIENE LA INFORMACIÓN Y ENVIA PARA COMvERTIR EN UN JSON 
        {
            string json;
            string strConnString = ConfigurationManager.ConnectionStrings["myConnectionStringMosa"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {

                cmd.Connection = con;
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    json = ToJson.ConvierteToJson(reader);
                }
                con.Close();
            }
            return json;
        }



        [HttpPost]
        [AuthSAP("Adminsitrador")]
        public JsonResult EditPuesto(Puesto puesto)
        {

            Puesto PuestoCreated = null;
            string message = "";
            bool created = false;

            if (DISession.Start(DISessionId))
            {
                Manager = new ConfiguracionManager(this.DISession);
                PuestoCreated = Manager.UpdatePuesto(puesto);
                message = Manager.Message;
                if (PuestoCreated != null)
                    created = true;
            }

            return Json(new { Created = created, Message = message, puesto = PuestoCreated }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [AuthSAP("Adminsitrador")]
        public JsonResult CreatePuesto(Puesto newPuesto)
        {
            //consulta el ultimo regisro y lo envia para que pueda ser registrado
            string constring = ConfigurationManager.ConnectionStrings["myConnectionStringMosa"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);

            string QueryString = " SELECT top 1 (Code + 1 ) as code FROM [@PUESTO_PLANILLA] order by cast(Code as int) desc ";
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(QueryString, con);
            da.SelectCommand = command;

            da.Fill(dt);
            con.Close();
            string IdPuesto = dt.Rows[0]["code"].ToString();

            Puesto PuestoCreated = null;
            string message = "";
            bool created = false;

            if (DISession.Start(DISessionId))
            {
                Manager = new ConfiguracionManager(this.DISession);
                PuestoCreated = Manager.CreatePuesto(newPuesto, IdPuesto);
                message = Manager.Message;
                if (PuestoCreated != null)
                    created = true;
            }

            return Json(new { Created = created, Message = message, puesto = PuestoCreated }, JsonRequestBehavior.AllowGet);

        }


    }
}
