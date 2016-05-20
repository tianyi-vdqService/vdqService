using Common.Lib.Model;
using Common.Lib.Util;
using MQService.Lib.Core;
using MQService.Lib.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public VdqService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //MQ消息推送封装
            MQSend.Send("MQMessage", SystemConfig.MQUserName, SystemConfig.MQPassword, SystemConfig.MQClientIp, SystemConfig.MQClientPort,SystemConfig.MySqlCon);
            //写日志封装
            LogUtil.WriteLog("WriteLogMessage",(Int32) LogType.NetWork, SystemConfig.MySqlCon);

        } 
        protected override void OnStop()
        {
        }
    }
}
