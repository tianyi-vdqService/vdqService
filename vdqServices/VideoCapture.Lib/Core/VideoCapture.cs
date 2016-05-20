using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using com_thrdmanagerLib;
using com_realtime_playerLib;
using com_sessionLib;
using Common.Lib.Util;
using Common.Lib.Model;

namespace VideoCapture.Lib.Core
{
    public class VideoCapture
    {
        static string connStr;
        public void GetVedioCapture(string conn)
        {
            try
            {
                connStr = conn;
                ThrdManager thdManager = new ThrdManager();
                thdManager.RegUIThrd();
                HxhtSession session = new HxhtSession();
                string initXml = "<Message type=\"center\">"
                         + "< Center host=\"\" port =\"\" version=\"3\" ssl=\"0\" />"
                         + "< Access host=\"\" port=\"\" />"
                         + "< Self host=\"\" />"
                         + "< Catalog url=\"\" />"
                         + "< Account name=\"\" pswd=\"\" dog=\"\" decrypt=\"\" />"
                         + "</ Message >"; 

                string centerInfo = session.GetCenterInfo(null);
                if (!String.IsNullOrEmpty(centerInfo))
                {
                    do
                    {
                        try
                        {
                            long init = session.Init(initXml, centerInfo);
                            if (init == 0)
                            {
                                long login = session.Login();
                                if (login == 0)
                                {
                                    //执行session初始化，登录，等待回调函数执行；
                                    session.OnStatusChanged += Session_OnStatusChanged;
                                }
                                else
                                {
                                    thdManager.UnRegUIThrd();
                                    LogUtil.WriteLog("调用天翼SDK，初始化异常，SDK登录认证失败", (Int32)LogType.VdqCpature, connStr);
                                }
                            }
                            else
                            {
                                thdManager.UnRegUIThrd();
                                LogUtil.WriteLog("调用天翼SDK，初始化异常，SDK初始化认证失败", (Int32)LogType.VdqCpature, connStr);
                            }

                        }
                        catch (Exception)
                        {
                            thdManager.UnRegUIThrd();
                            LogUtil.WriteLog("调用天翼SDK，初始化异常，SDK登录认证失败", (Int32)LogType.VdqCpature, connStr);
                        }
                        finally
                        {
                            thdManager.UnRegUIThrd();
                        }
                    } while (session.LoggedIn());
                }
                else
                {
                    thdManager.UnRegUIThrd();
                    LogUtil.WriteLog("调用天翼SDK，从中心获取信息，GetCenterInfo出错", (Int32)LogType.VdqCpature, connStr);
                }
            }
            //SDK初始化异常 
            catch (Exception ex)  
            {
                LogUtil.WriteLog("调用天翼SDK，初始化异常，创建ThrdManager出错",(Int32)LogType.VdqCpature, connStr);
            } 
        }

        private void Session_OnStatusChanged(uint nStatus, long nError)
        {
            try
            {
                HxhtRealtimePlayerCom player = new HxhtRealtimePlayerCom();
                //xml格式字符串
                string lpszSource = "";
                long init = 0;

                //设备列表(Naming,附加参数)；
                List<Device> list = DeviceUtil.GetDeviceList("", "", connStr);

                //调SDK,
                init = player.Init(lpszSource);
                if (init == 0)
                {
                    //初始化成功，调用连接 
                    try
                    {
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
                    //初始化失败
                    LogUtil.WriteLog("调用天翼SDK，初始化异常， player.Init失败", (Int32)LogType.VdqCpature, connStr);
                }
            }
            catch (Exception)
            {
                LogUtil.WriteLog("调用天翼SDK，初始化异常，调用组件HxhtRealtimePlayerCom失败", (Int32)LogType.VdqCpature, connStr);
            }
        } 
    }
}
