using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQService.Lib.Core
{
    public class QueueConsumer
    {
        public event Action<string> OnMessageArrive;

        private IModel _ch;

        private IConnection _conn;


        private string _queueName;

        private bool _isClose = false;

        string exchange = "BaseDataExchange";//路由  

        string exchangeType = "topic";//交换模式  

        string routingKey = "routeData.ywAlarm.video";//路由关键字  


        public QueueConsumer(string queueName)
        {
            _queueName = queueName;

            ConnectionFactory cf = new ConnectionFactory();

            cf.Endpoint = new AmqpTcpEndpoint("25.30.9.145", 5672);


            cf.UserName = "guest";
            cf.Password = "guest";

            cf.RequestedHeartbeat = 0;


            _conn = cf.CreateConnection();

            _ch = _conn.CreateModel();

        }

        public void Close()
        {
            _isClose = true;

        }


        public void Receive()
        {
            while (!_isClose)
            {
                //实际应用时使用BasicConsume方法
                BasicGetResult res = _ch.BasicGet(_queueName, true);

                if (res != null && OnMessageArrive != null)
                {
                    string content = UTF8Encoding.UTF8.GetString(res.Body);


                    OnMessageArrive(content);
                }


            }

            _ch.Close();

            _conn.Close();
        }
    }
}
