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
        static void Main(string[] args)
        {
            //MQ消息推送封装
            //MQSend.Send("MQMessage", SystemConfig.MQUserName, SystemConfig.MQPassword, SystemConfig.MQClientIp, SystemConfig.MQClientPort, SystemConfig.MySqlCon);
            //写日志封装
            LogUtil.WriteLog("WriteLogMessage", (Int32)LogType.NetWork); 
            Console.Write("启动客户端，开始调用天翼SDK,开始测试\n\r");
            Console.Write("*************************************************\n\r");
            Console.Write("*************************************************\n\r"); 
            VideoCaptureCore.GetVedioCapture() ;
        }
         
    }
}
