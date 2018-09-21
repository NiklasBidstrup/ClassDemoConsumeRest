using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ModelLibrary;
using Newtonsoft.Json;

namespace ClassDemoConsumeRest
{
    internal class RestConsumer
    {
        private const string URI = "https://jsonplaceholder.typicode.com/todos";

        public RestConsumer()
        {
        }

        public void Start()
        {
            IList<RestData> all = GetAll();
            foreach (RestData data in all)
            {
                //Console.WriteLine(data);
            }

            RestData one = GetOne(12);
            Console.WriteLine("ONE \n" + one);

            bool resultat = Post(new RestData(555, 555, "peter was here", true));
            Console.WriteLine("Post result = " + resultat);

            bool putResultat = Put(3, new RestData(555, 555, "peter was here", true));
            Console.WriteLine("Put result = " + putResultat);

            bool deleteResultat = Delete(12);
            Console.WriteLine("Delete result = " + deleteResultat);

        }

        private IList<RestData> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = client.GetStringAsync(URI).Result;
                IList<RestData> cList = JsonConvert.DeserializeObject<IList<RestData>>(jsonContent);
                return cList;
            }
        }

        private RestData GetOne(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = client.GetStringAsync(URI+ "/" + id).Result;
                RestData data = JsonConvert.DeserializeObject<RestData>(jsonContent);
                return data;
            }
        }

        public bool Post(RestData restData)
        {
            // laver body
            String json = JsonConvert.SerializeObject(restData);
            StringContent content = new StringContent(json,Encoding.UTF8, "application/json");
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                // sender
                HttpResponseMessage resultMessage = client.PostAsync(URI, content).Result;
                
                
                // optional if any result to unpack
                string jsonResult = resultMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Json svar string = " +jsonResult);
                // ingen rigtig svar
                //var result = JsonConvert.DeserializeObject<TReturnType>(jsonResult);

                return resultMessage.IsSuccessStatusCode;

            }
        }

        public bool Put(int id, RestData restData)
        {
            // laver body
            String json = JsonConvert.SerializeObject(restData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                // sender
                HttpResponseMessage resultMessage = client.PutAsync(URI +"/"+id, content).Result;


                // optional if any result to unpack
                string jsonResult = resultMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Json svar string = " + jsonResult);
                // ingen rigtig svar
                //var result = JsonConvert.DeserializeObject<TReturnType>(jsonResult);

                return resultMessage.IsSuccessStatusCode;

            }
        }

        public bool Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                // sender
                HttpResponseMessage resultMessage = client.DeleteAsync(URI +"/"+id).Result;


                // optional if any result to unpack
                string jsonResult = resultMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Json svar string = " + jsonResult);
                // ingen rigtig svar
                //var result = JsonConvert.DeserializeObject<TReturnType>(jsonResult);

                return resultMessage.IsSuccessStatusCode;

            }
        }

    }
}