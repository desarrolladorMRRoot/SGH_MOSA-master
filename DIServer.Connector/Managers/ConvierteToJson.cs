using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DIServer.Connector.Managers
{
    public class ToJson
    {
        public static string ConvierteToJson(SqlDataReader reader)
        {

            {
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);

                using (JsonWriter jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.WriteStartArray();

                    while (reader.Read())
                    {
                        jsonWriter.WriteStartObject();

                        int fields = reader.FieldCount;

                        for (int i = 0; i < fields; i++)
                        {
                            jsonWriter.WritePropertyName(reader.GetName(i));
                            jsonWriter.WriteValue(reader[i]);
                        }

                        jsonWriter.WriteEndObject();
                    }

                    jsonWriter.WriteEndArray();

                    return sw.ToString();
                }

            }
        }
    }
}
