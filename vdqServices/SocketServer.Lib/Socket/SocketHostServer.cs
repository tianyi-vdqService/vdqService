using Newtonsoft.Json;
using SocketServer.Lib.Core;
using SocketServer.Lib.Events;
using SocketServer.Lib.ISocket;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Socket
{
    public class SocketHostServer : ISocketHostServer
    {
        private string hostIP = ConfigurationManager.AppSettings["Server_Address"]; 
        public string HostIP
        {
            get { return this.hostIP; }
            set { this.hostIP = value; }
        }

        private int hostPort = Int32.Parse(ConfigurationManager.AppSettings["Server_Address_Port"]);
        public int HostPort
        {
            get { return this.hostPort; }
            set { this.hostPort = value; }
        }

        private int socketBufferSize = 1024 * 16;
        public int SockerBufferSize
        {
            get { return this.socketBufferSize; }
            set { this.socketBufferSize = value; }
        }

        private TcpListener tcpListener;

        private Dictionary<EndPoint, ISocketConnection> clients;
        public Dictionary<EndPoint, ISocketConnection> Clients
        {
            get { return this.clients; }
        }

        public ConnectionEventHandler Connected;

        public SocketHostServer()
            : this(ConfigurationManager.AppSettings["Server_Address"], Int32.Parse(ConfigurationManager.AppSettings["Server_Address_Port"]))
        { }

        public SocketHostServer(int port)
            : this(ConfigurationManager.AppSettings["Server_Address"], port)
        {
            this.hostPort = port;
        }

        public SocketHostServer(string ip, int port)
        {
            this.hostPort = port;
            this.hostIP = ip;
            this.tcpListener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
            this.clients = new Dictionary<EndPoint, ISocketConnection>();
        }

        public void StartUp()
        {
            this.tcpListener.Start(10);
            this.tcpListener.BeginAcceptSocket(new AsyncCallback(AcceptCallback), this);
        }

        public void AcceptCallback(IAsyncResult result)
        {
            try
            {
                System.Net.Sockets.Socket socket = this.tcpListener.EndAcceptSocket(result);
                ISocketConnection con = new SocketConnection(socket);
                con.ReceiveData += new MessageEventHandler(con_ReceiveData);

                if (this.clients.ContainsKey(con.RemoteEndPoint))
                {
                    this.clients[con.RemoteEndPoint] = con;
                }
                else
                {
                    this.clients.Add(con.RemoteEndPoint, con);
                }
                con.Start();


                if (this.Connected != null)
                    //this.Connected(con, new ConnectionEventArgs("客户端：" + con.RemoteEndPoint + "连接"));
                    StartUp();
            }
            catch (Exception ex)
            {

            }
        }

        private void con_ReceiveData(ISocketConnection sender, MessageEventArgs e)
        {
            ServiceRequest request = e.EventArg as ServiceRequest;
            string serviceStr = "SocketServer." + request.ModuleName;
            string methodStr = request.MethodName;
            object[] parameters = request.Parameters;
            Type[] parametersTypes = new Type[parameters.Length];
            int i = 0;
            foreach (object o in parameters)
            {
                if (o.GetType().Equals(typeof(Int64)))
                {
                    parameters.SetValue(Int32.Parse(o.ToString()), i);
                    parametersTypes.SetValue(typeof(Int32), i);
                }
                else
                {
                    parametersTypes.SetValue(o.GetType(), i);
                }
                i++;
            }

            System.Runtime.Remoting.ObjectHandle objectHandle = Activator.CreateInstance("SocketServer", serviceStr);
            object instanceService = objectHandle.Unwrap();

            MethodInfo method = instanceService.GetType().GetMethod(methodStr, parametersTypes);

            object result = method.Invoke(null, parameters);
            ServiceResponse response = new ServiceResponse() { ResponseData = result.ToString() };
            byte[] responseByte = UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
            List<byte> responseBytes = new List<byte>();

            responseBytes.AddRange(BitConverter.GetBytes(request.Length));
            responseBytes.AddRange(BitConverter.GetBytes(responseByte.Length));
            responseBytes.AddRange(responseByte);
            sender.Send(responseBytes.ToArray());
        }

        #region ISocketHostServer 成员


        public System.Net.EndPoint GetRemoteEndPoint(System.Net.EndPoint remoteEndPoint)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ServiceResponse
    {
        public string ResponseData { get; set; }
    }
}
