using com_errorLib;
using com_realtime_playerLib; 
using Common.Lib.Model;
using Common.Lib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoCapture.Lib.config;

namespace VideoCapture.Lib.Core
{
    public class VideoCaptureCore
    { 
        public static void GetVedioCapture()
        {
            try
            {
                Console.Write("进入主方法类：调用方法\n\r");
                Console.Write("*************************************************\n\r");
                Console.Write("*************************************************\n\r"); 
                try
                {
                    //string sdkInitXml = SDKConnectStr.GetSDKInitXml(centerIp, centerPort, account, password);
                    Console.Write("开始天翼SD初始化~\n\r");
                    Console.Write("*************************************************\n\r");
                    Console.Write("*************************************************\n\r");
                    HxhtRealtimePlayerCom player = new HxhtRealtimePlayerCom();
                    //player


                }
                catch (Exception)
                {
                    Console.Read();
                    LogUtil.WriteLog("调用天翼SDK，获取失败", (Int32)LogType.VdqCpature);
                }
                finally
                {
                    Console.Read();
                }
            }
            //SDK初始化异常 
            catch (Exception ex)
            {
                Console.Read();
                LogUtil.WriteLog("调用天翼SDK，初始化异常，创建ThrdManager出错", (Int32)LogType.VdqCpature);
            }
        }
 
    }
}
