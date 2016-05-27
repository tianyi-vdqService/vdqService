using Common.Lib.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Util
{
    public class DeviceUtil
    {
        public static readonly string MySqlCon = ConfigurationManager.ConnectionStrings["SqlConnectionStr"].ToString();
        public static List<Device> GetDeviceList(string param1, string param2)
        {
            List<Device> list = new List<Device>();
            return list;
        }
    }
}
