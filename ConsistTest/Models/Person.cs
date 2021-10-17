
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ConsistTest.Models
{
   
    public class Person
    {
        public Person()
        {
        }
        public int? Id { get; set; }

        public string Name { get; set; }
      
        public int? Parent { get; set; }
    }
}
