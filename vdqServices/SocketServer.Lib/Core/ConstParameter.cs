using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Core
{
    public class ConstParameter
    {
        public static readonly int BUFFER_SIZE = 8192;//缓冲区大小(以字节为单位)

        public static readonly char SPLIT_CHAR = '^'; //特定的分隔符

        public static string POLICY_STRING = "<policy-file-request/>";//策略验证字符串

        public static string BROADCAST_ENDPOINT = "0.0.0.0";//群发端点

        public static string BROADCAST_NAME = "所有人";//群发时的虚拟称呼

        public static int SizeOfInt = 4;//整型转换为字节型数组的长度
    }
}
