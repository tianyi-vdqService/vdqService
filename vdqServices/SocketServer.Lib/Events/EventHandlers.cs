using SocketServer.Lib.ISocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Events
{
    /// <summary>
    /// 连接事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ConnectionEventHandler(ISocketConnection sender, ConnectionEventArgs e);

    /// <summary>
    /// 消息事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MessageEventHandler(ISocketConnection sender, MessageEventArgs e);
}
