using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Events
{
    /// <summary>
    /// 连接事件参数
    /// </summary>
    public class ConnectionEventArgs : EventArgs
    {
        private Exception message;
        public Exception Message
        {
            get { return message; }
            set { message = value; }
        }

        private object eventArg;
        public object EventArg
        {
            get { return this.eventArg; }
            set { this.eventArg = value; }
        }
        public ConnectionEventArgs(object eventArg)
        {
            this.eventArg = eventArg;
        }
        public ConnectionEventArgs(object eventArg, Exception message)
        {
            this.eventArg = eventArg;
            this.message = message;
        }
        public override string ToString()
        {
            if (this.eventArg != null)
            {
                return this.eventArg.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
