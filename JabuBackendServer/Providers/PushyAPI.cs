using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace JabuBackendServer.Providers
{
    class PushyAPI
    {
        // Insert your Secret API Key here
        public static readonly string SECRET_API_KEY = "4d05620f4a3eeb35d6e5686a2ea4940e92ed9dc0399b8a7943b6c2278b77d5fc";

        public static void SendPush(PushyPushRequest push)
        {
            // Create an HTTP request to the Pushy API
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.pushy.me/push?api_key=" + SECRET_API_KEY);
     
            // Send a JSON content-type header
            request.ContentType = "application/json";

            // Set request method to POST
            request.Method = "POST";

            // Convert request post body to JSON (using JSON.NET package from Nuget)
            string postData = JsonConvert.SerializeObject(push);

            // Convert post data to a byte array
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentLength property of the WebRequest
            request.ContentLength = byteArray.Length;

            // Get the request stream
            Stream dataStream = request.GetRequestStream();

            // Write the data to the request stream
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Close the stream
            dataStream.Close();

            // Proceed with caution
            WebResponse response;

            try
            {
                // Execute the request
                response = request.GetResponse();
            }
            catch (WebException exc)
            {
                // Get returned JSON error as string
                string errorJSON = new StreamReader(exc.Response.GetResponseStream()).ReadToEnd();

                // Parse into object
                PushyAPIError error = JsonConvert.DeserializeObject<PushyAPIError>(errorJSON);

                // Throw error
                throw new Exception(error.error);
            }

            // Open the stream using a StreamReader for easy access
            StreamReader reader = new StreamReader(response.GetResponseStream());

            // Read the response JSON for debugging
            string responseData = reader.ReadToEnd();

            // Clean up the streams
            reader.Close();
            response.Close();
            dataStream.Close();
        }
    }
    class PushyPushRequest
    {
        public object data;
        public string[] tokens;

        public object notification;

        public PushyPushRequest(object data, string[] deviceTokens, object notification)
        {
            this.data = data;
            this.tokens = deviceTokens;
            this.notification = notification;
        }
    }

    class PushyAPIError
    {
        public string error;

        public PushyAPIError(string error)
        {
            this.error = error;
        }
    }

}