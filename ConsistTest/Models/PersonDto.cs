using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsistTest.Models
{
    public class PersonDto
    {
        public int? Identity { get; set; }

        public string FullName { get; set; }

        public List<PersonDto> Childs { get; set; }
    }
}
