using MQService.Lib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //调用MQ
            Producer myProducer = new Producer();

            QueueConsumer myConsumer = new QueueConsumer(myProducer.QueueName);

            myConsumer.OnMessageArrive += MyConsumer_OnMessageArrive1; ;

            //myConsumer.Receive();

            myProducer.Send("陈丹是二货");
        }
        /// <summary>
        /// MQ调用之后，的回调方法，执行相关操作
        /// </summary>
        /// <param name="msg"></param>
        private static void MyConsumer_OnMessageArrive1(string msg)
        {
            Console.WriteLine(msg);
        }
         
    }
}
