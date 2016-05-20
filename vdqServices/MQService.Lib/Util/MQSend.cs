using Common.Lib.Model;
using Common.Lib.Util;
using MQService.Lib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQService.Lib.Util
{
    public class MQSend
    {
        static string connStr;
        public static void Send(string message, string userName, string password, string clientIp, int clientPort,string conn)
        {
            connStr = conn;
            //调用MQ
            Producer myProducer = new Producer(userName, password, clientIp, clientPort);

            QueueConsumer myConsumer = new QueueConsumer(myProducer.QueueName, userName, password, clientIp, clientPort);

            myConsumer.OnMessageArrive += MyConsumer_OnMessageArrive1; ;
            myProducer.Send(message);

        }
        /// <summary>
        /// MQ调用之后，的回调方法，执行相关操作
        /// </summary>
        /// <param name="msg"></param>
        private static void MyConsumer_OnMessageArrive1(string msg)
        {
            LogUtil.WriteLog(msg, (Int32)LogType.MQServer, connStr);
        }
    }
}
