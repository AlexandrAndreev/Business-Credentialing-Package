using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Business_Credentialing_Package.APIClients
{
    public class UCCSearchReport
    {
        private const string apiName = "UCCSearchReport";

        private readonly MBBaseClient client;

        public UCCSearchReport(MBBaseClient mbClient)
        {
           this.client = mbClient;
        }

        public JsonObject GetReport(string JSONRequestModel)
        {
            var url = new Uri(client.BaseAddress + apiName + "/GetReport");
            var content = new StringContent(JSONRequestModel, Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, content).Result;
            var result = JsonSerializer.Deserialize<JsonObject>(response.Content.ReadAsStream());
            return result;
        }

        public JsonObject GetArchiveReport(string AppId)
        {
            var url = new Uri(client.BaseAddress + apiName + "/GetArchiveReport?AppId=" + AppId);
            var response = client.GetAsync(url).Result;
            var result = JsonSerializer.Deserialize<JsonObject>(response.Content.ReadAsStream());
            return result;
        }
    }
}
