using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsistTest
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string password);
    }
}
