using Common.Lib.Model;
using Common.Lib.Util;
using MQService.Lib.Core;
using MQService.Lib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTest
{
    public class Program
    { 
        static void Main(string[] args)
        {
            //MQ消息推送封装
            MQSend.Send("MQMessage", SystemConfig.MQUserName, SystemConfig.MQPassword, SystemConfig.MQClientIp, SystemConfig.MQClientPort, SystemConfig.MySqlCon);
            //写日志封装
            LogUtil.WriteLog("WriteLogMessage", (Int32)LogType.NetWork, SystemConfig.MySqlCon);
        }
         
    }
}
