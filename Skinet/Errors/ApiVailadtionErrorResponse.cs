using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Errors
{
    public class ApiVailadtionErrorResponse : ApiResponse
    {
        public ApiVailadtionErrorResponse() : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; }
        
        
    }
}