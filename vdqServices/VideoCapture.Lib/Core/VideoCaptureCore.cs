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
        static string account, accountNaming, password, connStr, sessionId, centerIp, centerPort, accessIp;
        static int privilege, accessPort;
        public static void GetVedioCapture(string conn, string userAccount, string userPwd, string cIp, string cPort)
        {
            try
            {
                Console.Write("进入主方法类：调用方法\n\r");
                Console.Write("*************************************************\n\r");
                Console.Write("*************************************************\n\r");
                connStr = conn;
                account = userAccount;
                password = userPwd;
                centerIp = cIp;
                centerPort = cPort;
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
                    LogUtil.WriteLog("调用天翼SDK，获取失败", (Int32)LogType.VdqCpature, connStr);
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
                LogUtil.WriteLog("调用天翼SDK，初始化异常，创建ThrdManager出错", (Int32)LogType.VdqCpature, connStr);
            }
        }

        private static void Session_OnStatusChanged(uint nStatus, long nError)
        {
            try
            {
                Console.Write("\n\r");
                Console.Write("*************************************************\n\r");
                Console.Write("*************************************************\n\r");
                Console.Write("天翼SDK初始化认证成功，业务流程\n\r");
                Console.Write("*************************************************\n\r");
                Console.Write("*************************************************\n\r");
                HxhtRealtimePlayerCom player = new HxhtRealtimePlayerCom();
                long init = 0;

                //设备列表(Naming,附加参数)；
                //List<Device> list = DeviceUtil.GetDeviceList("", "", connStr);

                string naming = "0000000000200000000000000690059:0000000000200000000000000660000:25.30.7.199:200100";

                //调SDK,xml格式字符串
                string vedioInitXml = SDKConnectStr.GetVedioInitXml(naming, accountNaming, account, privilege, sessionId, centerIp, centerPort, accessIp, accessPort);


                Console.Write("开始视频点位初始化认证\n\r");
                Console.Write("*************************************************\n\r");
                Console.Write("*************************************************\n\r");
                init = player.Init(vedioInitXml);
                if (init == 0)
                {
                    //初始化成功，调用连接 
                    Console.Write("视频点位初始化认证成功，返回值为：" + init + "\n\r");
                    Console.Write("*************************************************\n\r");
                    Console.Write("*************************************************\n\r");
                    try
                    {
                        Console.Write("视频点位初始化认证成功，后续流程，还不清楚，需要进一步落实\n\r");
                        Console.Write("*************************************************\n\r");
                        Console.Write("*************************************************\n\r");
                        Console.Read();
                        //一次播放只能调用一次Connect，如果想再次调用Connect，必须先调用Stop停止。
                        //如果播放过程中出现错误，可以使用Reconnect立即重新连接。
                        long conn = player.Connect();

                        player.Stop();
                    }
                    catch (Exception)
                    {
                        player.Stop();
                        long reconn = player.Reconnect();
                    }
                }
                else
                {
                    Console.Write("视频点位初始化认证失败，返回值为：" + init + "\n\r");
                    Console.Write("*************************************************\n\r");
                    Console.Write("*************************************************\n\r");
                    Console.Read();
                    //初始化失败
                    LogUtil.WriteLog("调用天翼SDK，初始化异常， player.Init失败", (Int32)LogType.VdqCpature, connStr);
                }
            }
            catch (Exception)
            {
                Console.Read();
                LogUtil.WriteLog("调用天翼SDK，初始化异常，调用组件HxhtRealtimePlayerCom失败", (Int32)LogType.VdqCpature, connStr);
            }
        }
    }
}
