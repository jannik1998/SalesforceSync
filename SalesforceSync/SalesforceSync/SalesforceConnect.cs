using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Serializers;
using System.IO;
using System.Windows.Forms;

namespace SalesforceSync
{
    class SalesforceConnect
    {
        public static string sfdcConsumerkey = "3MVG95G8WxiwV5PsTvEdWEqbENaYQcQJJYjKUqNBB0PbV4hDI0CE1FaOoAq1cBr5qeMOAAAEN_CC2tqCWSjuF";
        public static string sfdcConsumerSecret = "67495FEA129D06990EF30A4388BA41A33DF0D4093387804A0948B0EC6CA7BE02";
        public static string sfdcUserName = "jh@dev.com";
        public static string SfdcloginPassword = "BY!oa71a455";
        public static string SfdcSecurityToken = "I6u3Sg7ha7JXRy93JnPRGU7K0";

        public static String accessToken = "";
        public static DateTime AccessTokenTimeStamp = System.DateTime.Now;
        public static String ThreadURL = "";
        public static String SalesforceDomain = "https://login.salesforce.com";
        public static String SFLoginResult = "";

        public static string RequestText = "";
        public static string responseText = "";
        public async Task GetSalesforceAccessToken()
        {
            //Service1.ProcessName = "GetSalesforceAccessToken";

            ThreadURL = SalesforceDomain + "/services/oauth2/token";
            AccessTokenTimeStamp = System.DateTime.Now;
            //Step1: Authentication process
            Console.WriteLine("Dictionary wird im Json format gespeichert und verschlüsselt");
            var dictionaryForUrl = new Dictionary<String, String>
                {
                    {"grant_type","password" },
                    {"client_id", sfdcConsumerkey},
                    {"client_secret", sfdcConsumerSecret},
                    {"username", sfdcUserName},
                    {"password", SfdcloginPassword + SfdcSecurityToken}
                };
            HttpClient authhc = new HttpClient();
            HttpContent httpContent = new FormUrlEncodedContent(dictionaryForUrl);
            HttpResponseMessage httpresponse = new HttpResponseMessage();
            String message = "";
            try
            {
                httpresponse = authhc.PostAsync(ThreadURL, httpContent).Result;
                message = await httpresponse.Content.ReadAsStringAsync();
                Console.WriteLine("Httpresponse: " + httpresponse);

                JObject jsonObj = JObject.Parse(message);
                accessToken = (String)jsonObj["access_token"];
                if (accessToken == null || accessToken == "") { SFLoginResult = "Error: " + message; }

                ThreadURL = (String)jsonObj["instance_url"];
                String ErrorType = "";
                String ErrorMsg = "";
                ErrorType = (String)jsonObj["error"];
                ErrorMsg = (String)jsonObj["error_description"];

                if ((accessToken != null && accessToken != "") && ErrorMsg == null)
                {
                    SFLoginResult = "Success";
                    
                }
                else if (accessToken == null && (ErrorMsg != "" && ErrorMsg != null))
                {
                    SFLoginResult = "Error: " + ErrorMsg;
                }
            }
            catch (Exception e) { SFLoginResult = "Error: " + e.Message; }
        }
        public async Task SendRequest(string data)
        {

            var client = new RestClient("https://eu32.salesforce.com/services/apexrest/RestApiService?Action=Insert");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer  " + accessToken);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

        }

        public string ReadCsv(string p)
        {
            try
            {
                string path = p;
                var csv = new List<string[]>();
                var lines = File.ReadAllLines(path);

                foreach (string line in lines)
                    csv.Add(line.Split(','));

                var properties = lines[0].Split(',');

                var listObjResult = new List<Dictionary<string, string>>();

                for (int i = 1; i < lines.Length; i++)
                {
                    var objResult = new Dictionary<string, string>();
                    for (int j = 0; j < properties.Length; j++)
                        objResult.Add(properties[j], csv[i][j]);

                    listObjResult.Add(objResult);
                }

                Console.WriteLine(JsonConvert.SerializeObject(listObjResult));
                return JsonConvert.SerializeObject(listObjResult);
            }
            catch(Exception e )
            {
                String a = "Das Verzeichnis ist ungültig";
                Console.WriteLine("Das Verzeichnis ist ungültig");
                return a;
            }


        }
    }
}
