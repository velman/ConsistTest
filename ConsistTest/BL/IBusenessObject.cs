using ConsistTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsistTest
{
    public interface IBusenessObject
    {
        IEnumerable<TreeItem<Person>> BuildPersonsTree(List<Person> persons);
        Task<HttpResponseMessage> CallConsistTestAPI(IEnumerable<TreeItem<Person>> tree);

        void CopyTree(TreeItem<Person> persons, List<PersonDto> _resTree, int deep = 0);
    }
}
