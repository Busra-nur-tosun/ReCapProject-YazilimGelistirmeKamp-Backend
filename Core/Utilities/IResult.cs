using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
     public  interface IResult
    {
       public  string Message { get; }
       public  bool Success { get; }
    }
}
