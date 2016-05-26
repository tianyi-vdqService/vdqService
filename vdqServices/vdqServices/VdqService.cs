using Common.Lib.Model;
using Common.Lib.Util;
using MQService.Lib.Core;
using MQService.Lib.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using vdqServices.Config;

namespace vdqServices
{
    public partial class VdqService : ServiceBase
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
        public VdqService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            //MQ消息推送封装
            MQSend.Send("MQMessage", MQUserName, MQPassword, MQClientIp, MQClientPort,MySqlCon);
            //写日志封装
            LogUtil.WriteLog("WriteLogMessage",(Int32) LogType.NetWork, MySqlCon);

        } 
        protected override void OnStop()
        {
        }
    }
}
