using Common.Lib.Model;
using Common.Lib.Util;
using MQService.Lib.Core;
using MQService.Lib.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoCapture.Lib.Core;

namespace MQTest
{
    public class Program
    {
        public static readonly string MQUserName = ConfigurationManager.AppSettings["MQ.UserName"].ToString();
        public static readonly string MQPassword = ConfigurationManager.AppSettings["MQ.Password"].ToString();
        public static readonly string MQClientIp = ConfigurationManager.AppSettings["MQ.ClientIp"].ToString();
        public static readonly int MQClientPort = Int32.Parse(ConfigurationManager.AppSettings["MQ.ClientPort"].ToString());
        public static readonly string MQExchange = ConfigurationManager.AppSettings["MQ.Exchange"].ToString();
        public static readonly string MQExchangeType = ConfigurationManager.AppSettings["MQ.ExchangeType"].ToString();
        public static readonly string MQRoutingKey = ConfigurationManager.AppSettings["MQ.RoutingKey"].ToString();
        public static readonly string CenterIp = ConfigurationManager.AppSettings["Center.Host"].ToString();
        public static readonly string CenterPort = ConfigurationManager.AppSettings["Center.Port"].ToString();
        public static readonly string AccountName = ConfigurationManager.AppSettings["Account.Name"].ToString();
        public static readonly string AccountPwd = ConfigurationManager.AppSettings["Account.Pwd"].ToString();
        public static readonly string MySqlCon = ConfigurationManager.ConnectionStrings["SqlConnectionStr"].ToString();
        static void Main(string[] args)
        {
            //MQ消息推送封装
            //MQSend.Send("MQMessage", SystemConfig.MQUserName, SystemConfig.MQPassword, SystemConfig.MQClientIp, SystemConfig.MQClientPort, SystemConfig.MySqlCon);
            //写日志封装
            //LogUtil.WriteLog("WriteLogMessage", (Int32)LogType.NetWork, SystemConfig.MySqlCon); 
            Console.Write("启动客户端，开始调用天翼SDK,测试:"+ MySqlCon + "\n\r");
            Console.Write("*************************************************\n\r");
            Console.Write("*************************************************\n\r"); 
            VideoCaptureCore.GetVedioCapture(MySqlCon, AccountName, AccountPwd, CenterIp, CenterPort) ;
        }
         
    }
}
