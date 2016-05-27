using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Core
{
    public class Message
    {
        /// <summary>
        /// 具体内容
        /// </summary>
        private byte[] entity;
        public byte[] Entity
        {
            get { return entity; }
            set { entity = value; }
        }
    }
}
