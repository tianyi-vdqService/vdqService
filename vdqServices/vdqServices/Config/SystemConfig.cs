using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vdqServices.Config
{
    public class SystemConfig
    {
        public static readonly string MQUserName = ConfigurationManager.AppSettings["MQ.UserName"].ToString();
        public static readonly string MQPassword = ConfigurationManager.AppSettings["MQ.Password"].ToString();
        public static readonly string MQClientIp = ConfigurationManager.AppSettings["MQ.ClientIp"].ToString();
        public static readonly int MQClientPort = Int32.Parse(ConfigurationManager.AppSettings["MQ.ClientPort"].ToString());
        public static readonly string MQExchange = ConfigurationManager.AppSettings["MQ.Exchange"].ToString();
        public static readonly string MQExchangeType = ConfigurationManager.AppSettings["MQ.ExchangeType"].ToString();
        public static readonly string MQRoutingKey = ConfigurationManager.AppSettings["MQ.RoutingKey"].ToString();
        public static readonly string MySqlCon = ConfigurationManager.ConnectionStrings["SqlConnectionStr"].ToString();
    }
}
