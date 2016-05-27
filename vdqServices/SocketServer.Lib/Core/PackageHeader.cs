using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Core
{
    public class PackageHeader
    {
        private int length;
        private MessageType messageType;
        private Type entityType;
        private string dataService;
        private string operation;
        private string dataModle;
        /// <summary>
        /// 调用的Model
        /// </summary>
        //public string DataModle
        //{
        //    get { return dataModle; }
        //    set { dataModle = value; }
        //}
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        /// <summary>
        /// 消息类型
        /// </summary>
        //public MessageType MessageType
        //{
        //    get { return messageType; }
        //    set { messageType = value; }
        //}
        /// <summary>
        /// 要调用的Service
        /// </summary>
        public string DataService
        {
            get { return dataService; }
            set { dataService = value; }
        }
        /// <summary>
        /// 操作（要调用的方法)
        /// </summary>
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }
        /// <summary>
        /// 对象的类型
        /// </summary>
        //public Type EntityType
        //{
        //    get { return entityType; }
        //    set { entityType = value; }
        //}
        /// <summary>
        /// 发送人ID
        /// </summary>
        public int SenderId
        {
            get;
            set;
        }
        /// <summary>
        /// 接受人Id
        /// </summary>
        public int receiverId
        {
            get;
            set;
        }
        /// <summary>
        /// 返回的类型
        /// </summary>
        public Type CallbackType
        {
            get;
            set;
        }
    }
}
