using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JmkWebAppDeveTest.Models
{
    public class Repos
    {
        public string id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public int stargazers_count { get; set; }
    }
}