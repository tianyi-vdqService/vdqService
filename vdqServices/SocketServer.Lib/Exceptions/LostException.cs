using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Exceptions
{
    public class LostException : ApplicationException
    {
        public LostException() : base("该客户端已经掉线")
        {

        }
        public LostException(string Message) : base(Message)
        {

        }
        public LostException(string Message, Exception inner)
            : base(Message, inner)
        {

        }


    }
}
