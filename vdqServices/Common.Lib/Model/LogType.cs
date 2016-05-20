using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Model
{
    public enum LogType
    {
        /// <summary>
        /// 网络类型日志
        /// </summary>
        NetWork = 1,

        /// <summary>
        /// 视频捕获日志
        /// </summary>
        VdqCpature = 2,

        /// <summary>
        /// 视频解析日志
        /// </summary>
        VdqANSYS = 3,

        /// <summary>
        /// 视频诊断日志
        /// </summary>
        VdqDiagnosis = 4,

        /// <summary>
        /// MQ消息推送日志
        /// </summary>
        MQServer = 5,

        /// <summary>
        /// 服务器监控日志
        /// </summary>
        VdqServer = 6,

        /// <summary>
        /// 光收发器监控日志
        /// </summary>
        VdqMod = 7
    }
}
