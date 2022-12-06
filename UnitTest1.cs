using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace _06_11testcases
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void TestMethod1()
        {
            double cost = 16.65;
            RestClient client = new RestClient("https://digitalapi.auspost.com.au");
            RestRequest request= new RestRequest("/postage/parcel/domestic/calculate");
            request.AddHeader("auth-key", "58afcb4e-0e80-42d6-9159-c692b6f7c9ca");
            request.AddParameter("from_postcode", 4075);
            request.AddParameter("to_postcode", 2250);
            request.AddParameter("length", 25);
            request.AddParameter("width", 25);
            request.AddParameter("height", 5);
            request.AddParameter("weight", 1.5);
            request.AddParameter("service_code", "AUS_PARCEL_REGULAR");

            RestResponse response = client.Execute(request);

            JObject output = JObject.Parse(response.Content);
          
            Assert.AreEqual(cost, (double)output.SelectToken("postage_result.total_cost"));




        }
    }
}