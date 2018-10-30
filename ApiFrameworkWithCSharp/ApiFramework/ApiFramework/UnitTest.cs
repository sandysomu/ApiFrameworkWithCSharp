using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Xunit;

namespace ApiFramework
{
    public class RestSharp
    {
        [Fact]
        public void Test1()
        {
            string url = "http://eventmanagement.uat.prod.sbet.com.au/";

            var client = new RestClient(url);

            var request = new RestRequest("api/eventmanagement/v1/venues/12", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("X-WHA-System-ID", "Swagger-Test");
            request.AddHeader("X-WHA-Message-ID", "Message-ID-124");

            IRestResponse response = client.Execute(request);

            RootObject root = JsonConvert.DeserializeObject<RootObject>(response.Content);
        }

        [Fact]
        public async Task Test2()
        {
            string url = "http://eventmanagement.uat.prod.sbet.com.au/";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("X-WHA-System-ID", "Swagger-Test");
            client.DefaultRequestHeaders.Add("X-WHA-Message-ID", "Message-ID-124");

            client.BaseAddress = new Uri(url);

            var number = 12;
            var response = await client.GetAsync($"api/eventmanagement/v1/venues/{number}");

            var myRootObject = await response.Content.ReadAsAsync<RootObject>();
        }

    }







        public class RootObject
    {
        public int id { get; set; }
        public int eventType { get; set; }
        public string name { get; set; }
        //[JsonProperty]
        public string country { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public int refId { get; set; }
    }

}
