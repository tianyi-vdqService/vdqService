using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.ISocket
{
    public interface ISocketHostServer
    {
        EndPoint GetRemoteEndPoint(EndPoint remoteEndPoint);
    }
}
