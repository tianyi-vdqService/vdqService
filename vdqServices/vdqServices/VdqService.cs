﻿using MQService.Lib.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace vdqServices
{
    public partial class VdqService : ServiceBase
    {
        public VdqService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //调用MQ
            Producer myProducer = new Producer();

            QueueConsumer myConsumer = new QueueConsumer(myProducer.QueueName);

            myConsumer.OnMessageArrive += MyConsumer_OnMessageArrive; 

            //myConsumer.Receive();

            myProducer.Send("陈丹是二货");
        }
        /// <summary>
        /// MQ调用之后，的回调方法，执行相关操作
        /// </summary>
        /// <param name="msg"></param>
        private void MyConsumer_OnMessageArrive(string msg)
        {
            Console.WriteLine(msg);
        }

        protected override void OnStop()
        {
        }
    }
}
