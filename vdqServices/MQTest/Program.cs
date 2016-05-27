using Common.Lib.Model;
using Common.Lib.Util;
using MQService.Lib.Core;
using MQService.Lib.Util;
using SocketServer.Lib.Events;
using SocketServer.Lib.ISocket;
using SocketServer.Lib.Socket;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoCapture.Lib.Core;

namespace MQTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //MQ消息推送封装
            //MQSend.Send("MQMessage", SystemConfig.MQUserName, SystemConfig.MQPassword, SystemConfig.MQClientIp, SystemConfig.MQClientPort, SystemConfig.MySqlCon);
            //写日志封装
            //LogUtil.WriteLog("WriteLogMessage", (Int32)LogType.NetWork); 
            //Console.Write("启动客户端，开始调用天翼SDK,开始测试\n\r");
            //Console.Write("*************************************************\n\r");
            //Console.Write("*************************************************\n\r"); 
            //VideoCaptureCore.GetVedioCapture() ;
            try
            {
                Thread tServer = new Thread(StartServerListen);
                tServer.Start();
            }
            catch (Exception ex)
            {

            }
            Console.Read();
        }
        public static void StartServerListen()
        {
            try
            {
                SocketHostServer socket = new SocketHostServer();
                socket.Connected += new ConnectionEventHandler(socket_Connected);
                //OutPut("服务开始启动...");
                socket.StartUp();
            }
            catch (Exception ex)
            {
                File.AppendAllText(@".\ErroLog.txt", "服务未开启" + DateTime.Now + "\r\n");//追添内容并换行
                throw new Exception("服务未开启！");
            }
        }
        private static void socket_Connected(ISocketConnection sender, ConnectionEventArgs e)
        {
            OutPut(sender.RemoteEndPoint.ToString() + "成功连接");
        }

        static void OutPut(object result)
        {
            Console.WriteLine(result.ToString());
        }

    }
}
