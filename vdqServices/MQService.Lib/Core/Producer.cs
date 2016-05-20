using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQService.Lib.Core
{
    public class Producer
    {
        string exchange = "BaseDataExchange";//路由  

        string exchangeType = "topic";//交换模式  

        string routingKey = "routeData.ywAlarm.video";//路由关键字  

        //是否对消息队列持久化保存  
        bool persistMode = false;

        private string _queueName;

        public string QueueName
        {
            get { return _queueName; }
        }

        private IModel _ch;

        public Producer(string userName, string password, string clientIp, int clientPort)
        {

            InitModel(userName, password, clientIp, clientPort);
        }

        private void InitModel(string userName, string password, string clientIp, int clientPort)
        {
            ConnectionFactory cf = new ConnectionFactory();

            cf.UserName = userName;//某个vhost下的用户

            cf.Password = password;

            cf.RequestedHeartbeat = 0;


            cf.Endpoint = new AmqpTcpEndpoint(clientIp, clientPort);


            IConnection conn = cf.CreateConnection();

            _ch = conn.CreateModel();


            _ch.ExchangeDeclare(exchange, exchangeType, true);

            //声明一个队列  
            var name = _ch.QueueDeclare(GetQueueId(), true, false, true, null);

            //将一个队列和一个路由绑定起来。并制定路由关键字    
            _ch.QueueBind(name, exchange, routingKey);


        }

        private string GetQueueId()
        {

            _queueName = String.Format("{0}.reply", exchange);


            return _queueName;
        }


        public void Send(string content)
        {
            IMapMessageBuilder b = new MapMessageBuilder(_ch);

            //IDictionary<string, object> target = b.Headers;

            //target["header"] = "chendan";

            //IDictionary<string, object> targerBody = b.Body;

            //targerBody["body"] = content; 

            if (persistMode)
            {
                ((IBasicProperties)b.GetContentHeader()).DeliveryMode = 2;

            }
            else
            {
                ((IBasicProperties)b.GetContentHeader()).DeliveryMode = 1;
            }


            //写入  
            _ch.BasicPublish(exchange, routingKey, null, System.Text.Encoding.Default.GetBytes(content));

        }
    }
}
