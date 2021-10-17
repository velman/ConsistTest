using ConsistTest.Models;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsistTest
{
    public class BusenessObject : IBusenessObject
    {        
        private IDALObject _dl;
        private readonly ILogger<BusenessObject> _logger;
        public BusenessObject(IDALObject dl, ILogger<BusenessObject> logger)
        {
            _dl = dl;
            _logger = logger;
        }
        public IEnumerable<TreeItem<Person>> BuildPersonsTree(List<Person> persons)
        {
            IEnumerable<TreeItem<Person>> tree = null;
            try
            {
                tree = persons.GenerateTree(c => c.Id, c => c.Parent);                
            }
            catch (Exception ex)
            {                
                _logger.LogError(ex.Message);
            }
            

            return tree;
        }

        public async Task<HttpResponseMessage> CallConsistTestAPI(IEnumerable<TreeItem<Person>> tree)
        {
            HttpResponseMessage res = null;
            try
            {
                res = await _dl.PostTreeToAPI(tree);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            

            return res;
        }

        public void CopyTree(TreeItem<Person> persons, List<PersonDto> _resTree, int deep = 0)
        {            
            //Helper.CopyTree(persons);                     
        }
    }
}
