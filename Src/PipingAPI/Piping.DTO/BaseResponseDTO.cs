using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
   public class BaseResponseDTO
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }
}
