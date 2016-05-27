using SocketServer.Lib.Core;
using SocketServer.Lib.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.ISocket
{
    /// <summary>
    /// 基础Socket连接
    /// </summary>
    public interface ISocketConnection
    {
        System.Net.Sockets.Socket ServerSocket { get; set; }
        PackageHeader CurHeader { get; }
        Message MessageObj { get; }
        bool Connected { get; }
        byte[] HeaderBuffer
        { get; set; }
        /// <summary>
        /// 断开连接事件
        /// </summary>
        event ConnectionEventHandler DisConnected;
        /// <summary>
        /// 接收到数据事件
        /// </summary>
        event MessageEventHandler ReceiveData;
        /// <summary>
        /// 获取远程终结点
        /// </summary>
        EndPoint RemoteEndPoint { get; }
        /// <summary>
        /// 发送二进制数据
        /// </summary>
        /// <param name="data">byte 数组</param>
        /// <returns></returns>
        bool Send(byte[] data);
        /// <summary>
        /// 发送object对象
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        bool Send(object obj);
        /// <summary>
        /// 开始接收数据
        /// </summary>
        void Start();
        /// <summary>
        /// 停止
        /// </summary>
        void Stop();
    }
}
