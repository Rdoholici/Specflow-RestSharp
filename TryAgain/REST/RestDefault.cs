using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryAgain.REST
{
    class RestDefault
    {

        static RestClient client;
        static RestRequest request;
        static RestResponse response;

        public static void createClient(String url)
        {
            client = new RestClient(url);
        }

        public static void createRequest(String resource)
        {
            request = new RestRequest(resource);
        }

        public static void addJsonBody(String body)
        {
            request.AddJsonBody(body);
        }

        public static void performGetCall()
        {
            response = (RestResponse)client.Get(request);
        }

        public static void performPostCall()
        {
            response = (RestResponse)client.Post(request);
            Console.WriteLine(response.Content);
        }

        public static String getResponseMessage()
        {
            return response.StatusCode.ToString();
        }

        public static int getResponseCode()
        {
            return (int)response.StatusCode;
        }
    }
}
