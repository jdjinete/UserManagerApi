using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebAppManagerContent.Helpers
{
    public class ConsumeRESTfulAPI
    {
        public string GetItems(string url)
        {

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
              return GetRequest(request);
            }
            catch (WebException ex)
            {
                 throw ex;
                // Handle error
            }
        }
        public string PostItem(string url, string json)
        {

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }


            try
            {
               return  GetRequest(request);
            }
            catch (WebException ex)
            {
                throw ex;
                // Handle error
            }
        }


        private string GetRequest(HttpWebRequest request)
        {
            using WebResponse response = request.GetResponse();
            using Stream strReader = response.GetResponseStream();
            if (strReader == null) return string.Empty;
            using StreamReader objReader = new StreamReader(strReader);
            string responseBody = objReader.ReadToEnd();
            return responseBody;
        }
        private static void PutItem(int id, string data)
        {
            var url = $"http://localhost:8080/items";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"id\":\"{id}\",\"data\":\"{data}\"}}";
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
        }

        private static void DeleteItem(int id)
        {
            var url = $"http://localhost:8080/items/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }

        }
    }
}