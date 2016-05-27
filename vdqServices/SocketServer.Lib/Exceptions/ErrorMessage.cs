using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Exceptions
{
    public enum ErrorMessage
    {
        SendError, ReceiveError, ClientLeave, UnknownError
    }
}
