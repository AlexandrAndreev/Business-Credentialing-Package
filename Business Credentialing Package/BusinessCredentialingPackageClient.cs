using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using Business_Credentialing_Package.APIClients;

namespace Business_Credentialing_Package
{
    public class BusinessCredentialingPackageClient
    {
        private ProfessionalLicenseSearchClient professionalLicenseSearchClient;

        private MBBaseClient mbBaseClient;

        private UCCSearchReport uCCSearchReport;

        public string Authorization { get; private set; }

        private MBBaseClient MBBaseClient
        {
            get
            {
                if (mbBaseClient == null)
                {
                    mbBaseClient = new MBBaseClient(Authorization, baseUri);
                }

                return mbBaseClient;
            }
        }

        public ProfessionalLicenseSearchClient ProfessionalLicenseSearchClient
        {
            get
            {
                if (professionalLicenseSearchClient == null)
                {
                    professionalLicenseSearchClient = new ProfessionalLicenseSearchClient(MBBaseClient);
                }

                return professionalLicenseSearchClient;
            }
        }

        public UCCSearchReport UCCSearchReport
        {
            get
            {
                if (uCCSearchReport == null)
                {
                    uCCSearchReport = new UCCSearchReport(MBBaseClient);
                }

                return uCCSearchReport;
            }
        }

        private readonly Uri baseUri;
        public BusinessCredentialingPackageClient(string client_id, string client_secret, EnvironmentType type = EnvironmentType.Production)
        {
            baseUri = new Uri(type.ToDescriptionString());
            Authorization = MBAuthorizations(client_id, client_secret);
        }

        public string MBAuthorizations(string client_id, string client_secret)
        {
            using (var client = new HttpClient() { BaseAddress = baseUri })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var authorization = new JsonObject()
                {
                    ["client_id"] = JsonValue.Create(client_id),
                    ["client_secret"] = JsonValue.Create(client_secret),
                    ["grant_type"] = JsonValue.Create("client_credentials")
                };
                var content = new StringContent(authorization.ToString(), Encoding.UTF8, "application/json");
                try
                {
                    var response = client.PostAsync(new Uri(baseUri, "OAuth/GetAccessToken"), content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jsr = JsonSerializer.Deserialize<JsonObject>(response.Content.ReadAsStream());
                        JsonNode access_token;
                        if (jsr.TryGetPropertyValue("access_token", out access_token))
                        {
                            return access_token.ToString();
                        }
                        else
                        {
                            throw new Exception(string.Format("Authorizations faled : {}", response.Content.ReadAsStringAsync().Result));
                        }
                    }
                    else
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (HttpRequestException)
                {
                    throw;
                }
            }
        }
    }
}
