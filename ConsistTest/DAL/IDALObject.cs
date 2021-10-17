using ConsistTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsistTest
{    
    public interface IDALObject
    {
        Task<HttpResponseMessage> PostTreeToAPI(IEnumerable<TreeItem<Person>> tree);
    }
}
