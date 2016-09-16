using JmkWebAppDeveTest.Models;
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
        string baseUrl = string.Empty;

        public GitHubService(string url)
        {
            baseUrl = url;
            HttpClientInitialisation(url);
        }

        private void HttpClientInitialisation(string url)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
        }

        public UserInfo[] GetUsers()
        {
                HttpResponseMessage response = client.GetAsync(this.baseUrl).Result;
                UserInfo[] usersInfo = JsonConvert.DeserializeObject<UserInfo[]>(response.Content.ReadAsStringAsync().Result);
                return usersInfo;          
        }

        public UserInfo[] GetUser(string login)
        {
            HttpResponseMessage response = client.GetAsync(this.baseUrl).Result;
            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(response.Content.ReadAsStringAsync().Result);
            UserInfo[] usersInfo = new UserInfo[1];
            usersInfo[0] = userInfo;
            return usersInfo;

        }
        public Repos[] GetRepos()
        {
            HttpResponseMessage response = client.GetAsync(this.baseUrl).Result;
            Repos[] repos = JsonConvert.DeserializeObject<Repos[]>(response.Content.ReadAsStringAsync().Result);
            return repos;       

        }
    }
}