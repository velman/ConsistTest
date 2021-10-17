using ConsistTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsistTest
{

    public class DALObject : IDALObject
    {
        static HttpClient client = new HttpClient();
        static string url = "http://82.81.136.140/ConsistTest/Family";
        public async Task<HttpResponseMessage> PostTreeToAPI(IEnumerable<TreeItem<Person>> tree)
        {
            
            using (HttpClient client = new HttpClient())
            {                
                var jsonStr = JsonConvert.SerializeObject(tree);
                jsonStr = "{\"identity\": 1, \"fullName\": \"jojo\", \"childs\": []}";

                var res = await client.PostAsync(url, new StringContent(jsonStr, Encoding.UTF8, "application/json"));

                return res;
            }
        }
    }
}
