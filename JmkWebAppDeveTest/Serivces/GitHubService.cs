using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace JmkWebAppDeveTest.Serivces
{
    public class GitHubService
    {
        HttpClient client;

        //The URL of the WEB API Service
        readonly string url = "https://api.github.com/users/";

        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public GitHubService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
        }
        //http://www.developer.com/net/asp/consuming-an-asp.net-web-api-using-httpclient.html
        //http://www.codeproject.com/Articles/611176/Calling-ASP-NET-WebAPI-using-HttpClient
        public UserInfo[] Get(string login = "")
        {
            if (login == "")
            {
                HttpResponseMessage response = client.GetAsync(this.url).Result;
                UserInfo[] data = JsonConvert.DeserializeObject<UserInfo[]>(response.Content.ReadAsStringAsync().Result);
                return data;
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(this.url + login).Result;
                UserInfo obj = JsonConvert.DeserializeObject<UserInfo>(response.Content.ReadAsStringAsync().Result);
                UserInfo[] data = new UserInfo[1];
                data[0] = obj;
                return data;
            }
        }

    }
}