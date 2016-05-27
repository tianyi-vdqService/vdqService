using Common.Lib.Model;
using Common.Lib.Util;
using MQService.Lib.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQService.Lib.Util
{
    public class MQSend
    {
        public static readonly string MQUserName = ConfigurationManager.AppSettings["MQ.UserName"].ToString();
        public static readonly string MQPassword = ConfigurationManager.AppSettings["MQ.Password"].ToString();
        public static readonly string MQClientIp = ConfigurationManager.AppSettings["MQ.ClientIp"].ToString();
        public static readonly int MQClientPort = Int32.Parse(ConfigurationManager.AppSettings["MQ.ClientPort"].ToString());
        public static readonly string MQExchange = ConfigurationManager.AppSettings["MQ.Exchange"].ToString();
        public static readonly string MQExchangeType = ConfigurationManager.AppSettings["MQ.ExchangeType"].ToString();
        public static readonly string MQRoutingKey = ConfigurationManager.AppSettings["MQ.RoutingKey"].ToString();
        public static readonly string MySqlCon = ConfigurationManager.ConnectionStrings["SqlConnectionStr"].ToString(); 
        public static void Send(string message)
        { 
            //调用MQ
            Producer myProducer = new Producer(MQUserName, MQPassword, MQClientIp, MQClientPort);

            QueueConsumer myConsumer = new QueueConsumer(myProducer.QueueName, MQUserName, MQPassword, MQClientIp, MQClientPort);

            myConsumer.OnMessageArrive += MyConsumer_OnMessageArrive1; ;
            myProducer.Send(message);

        }
        /// <summary>
        /// MQ调用之后，的回调方法，执行相关操作
        /// </summary>
        /// <param name="msg"></param>
        private static void MyConsumer_OnMessageArrive1(string msg)
        {
            LogUtil.WriteLog(msg, (Int32)LogType.MQServer);
        }
    }
}
