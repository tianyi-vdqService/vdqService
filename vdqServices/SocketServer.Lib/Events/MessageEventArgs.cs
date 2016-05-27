using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Events
{
    /// <summary>
    /// 消息事件参数
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        private object eventArg;
        public object EventArg
        {
            get { return this.eventArg; }
            set { this.eventArg = value; }
        }
        public MessageEventArgs(object eventArg)
        {
            this.eventArg = eventArg;
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
