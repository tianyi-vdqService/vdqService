using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Core
{
    public class ServiceRequest
    {
        public string MethodName { get; set; }

        public string ModuleName { get; set; }

        public object[] Parameters { get; set; }

        public string ServiceName { get; set; }

        public int Length { get; set; }
    }
}
