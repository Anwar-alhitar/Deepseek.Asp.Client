using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepseek.AspClient.Models.Response
{
    public class ApiError
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
    }
}
