using Newtonsoft.Json;
using SocketServer.Lib.Core;
using SocketServer.Lib.Events;
using SocketServer.Lib.Exceptions;
using SocketServer.Lib.ISocket;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Lib.Socket
{
    public class SocketConnection : ISocketConnection
    {
        private SocketError errorCode;

        public SocketConnection(System.Net.Sockets.Socket socket)
        {
            this.serverSocket = socket;
        }

        #region ISocketConnection 成员

        private System.Net.Sockets.Socket serverSocket;
        public System.Net.Sockets.Socket ServerSocket
        {
            get
            {
                return this.serverSocket;
            }
            set
            {
                this.serverSocket = value;
            }
        }

        private byte[] headerBuffer = new byte[ConstParameter.BUFFER_SIZE];

        public byte[] HeaderBuffer
        {
            get { return headerBuffer; }
            set { headerBuffer = value; }
        }
        private PackageHeader curHeader;
        public PackageHeader CurHeader
        {
            get { return this.curHeader; }
        }

        private int ReceivePacketLength = 0;

        private byte[] messageBuffer;
        private Message messageObj;
        public Message MessageObj
        {
            get { return this.messageObj; }
        }

        public bool Connected
        {
            get { return this.serverSocket.Connected; }
        }

        public event ConnectionEventHandler DisConnected;

        public event MessageEventHandler ReceiveData;

        public System.Net.EndPoint RemoteEndPoint
        {
            get { return this.serverSocket.RemoteEndPoint; }
        }

        public List<byte> ReceiveBytes = new List<byte>(ConstParameter.BUFFER_SIZE);

        public bool Send(byte[] data)
        {
            try
            {
                if (this.Connected)
                {
                    this.serverSocket.BeginSend(data, 0, data.Length, SocketFlags.None, out errorCode, new AsyncCallback(SendAsyncCallback), this);
                    if (errorCode == SocketError.Success)
                    {
                        return true;
                    }
                    else
                    {
                        //this.DisConnected(this, new ConnectionEventArgs(ErrorMessage.SendError));
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                //this.DisConnected(this, new ConnectionEventArgs(ErrorMessage.UnknownError));
            }
            return false;
        }

        private void SendAsyncCallback(IAsyncResult result)
        {
            try
            {
                ISocketConnection socket = (SocketConnection)result.AsyncState;
                socket.ServerSocket.EndSend(result, out errorCode);
                if (errorCode != SocketError.Success)
                {
                    //if (this.DisConnected != null)
                    //DisConnected(this, new ConnectionEventArgs(ErrorMessage.SendError));
                }
            }
            catch (Exception e)
            {
                //if (this.DisConnected != null)
                //DisConnected(this, new ConnectionEventArgs(e.Message));
            }
        }

        public bool Send(object obj)
        {
            try
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
                return Send(data);
            }
            catch (Exception e)
            {
                //DisConnected(this, new ConnectionEventArgs(ErrorMessage.UnknownError));
                return false;
            }
        }

        /// <summary>
        /// 开始接收数据
        /// 数据将被定义为包头数据，和包体数据 两段来接受！
        /// </summary>
        public void Start()
        {
            //从接收包头开始
            ReceiveHeaderPacket();
        }

        /// <summary>
        /// 接受包头函数
        /// </summary>
        public void ReceiveHeaderPacket()
        {
            //包头空的时候创建包头
            this.curHeader = new PackageHeader();
            this.curHeader.Length = -1;
            //this.headerBuffer = UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this.curHeader));
            //this.headerBuffer = new byte[ConstParameter.BUFFER_SIZE];
            this.serverSocket.BeginReceive(this.headerBuffer, 0, this.headerBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveHeaderCallback), this);
        }
        /// <summary>
        /// 处理头包数据回调
        /// </summary>
        /// <param name="result"></param>
        private void ReceiveHeaderCallback(IAsyncResult result)
        {
            try
            {
                //Console.WriteLine("开始接受头信息..");
                ISocketConnection socket = (SocketConnection)result.AsyncState;
                int recvCount = socket.ServerSocket.EndReceive(result, out errorCode);
                if (recvCount <= 0)
                {
                    //客户关闭连接
                    File.AppendAllText(@".\ErroLog.txt", "客户端关闭或断开连接" + DateTime.Now + "\r\n");//追添内容并换行
                    //Console.WriteLine("客户端关闭或断开连接！");
                    return;
                }
                string str1 = System.Text.Encoding.Unicode.GetString(socket.HeaderBuffer, 0, recvCount);
                string charstr = str1[0].ToString();
                string charstr1 = str1.Substring(str1.Length - 1, 1);


                if (charstr == "@" && charstr1 == "#")
                {
                    if (errorCode == SocketError.Success)
                    {
                        //处理头包 并开始处理接收信息   
                        string[] strings = str1.Split('|');
                        if (strings.Length != 9)
                        {
                            //Console.WriteLine("信息体接受成功！");
                            //Console.WriteLine("接收信息内容格式不合法！");
                            //Console.WriteLine("接收字节数：" + recvCount);
                            File.AppendAllText(@".\ErroLog.txt", "接收信息内容格式不合法" + DateTime.Now + "\r\n");//追添内容并换行
                            this.ReceiveBytes.Clear();
                            this.ReceivePacketLength = 0;

                            if (this.DisConnected != null)
                                DisConnected(this, new ConnectionEventArgs(ErrorMessage.ReceiveError));
                        }
                        else
                        {
                            if (strings[0] != ""
                                && strings[1] != ""
                                && strings[2] != ""
                                && strings[3] != ""
                                && strings[4] != ""
                                && strings[5] != ""
                                && strings[6] != ""
                                && strings[7] != ""
                                && strings[8] != "")
                            {
                                Console.WriteLine("信息体接受成功！");
                                Console.WriteLine("接收字节数：" + recvCount);
                                strings[0] = strings[0].Substring(1);//去掉第一个字
                                strings[8] = strings[8].Substring(0, strings[8].Length - 1);//去掉最后一个

                                //CarData carData = new CarData();
                                //carData.CarNumber = strings[0];
                                //carData.ClientNumber = strings[1];
                                //carData.Time = DateTime.Parse(strings[2]);
                                //carData.Speed = strings[3];
                                //carData.Location = Int32.Parse(strings[4]);
                                //carData.Longitude = strings[5] != null ? (decimal?)decimal.Parse(strings[5]) : null;
                                //carData.Latitude = strings[6] != null ? (decimal?)decimal.Parse(strings[6]) : null;
                                //carData.Direction = strings[7];
                                //carData.Position = strings[8];
                                 
                                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnectionStr"].ToString()))
                                {
                                    conn.Open();
                                    string sql = "";
                                    int results = 0 ;
                                    using (SqlCommand cmd = new SqlCommand(string.Format(sql), conn))
                                    {
                                        SqlDataReader read = cmd.ExecuteReader();
                                        if (read.Read())
                                        {
                                            results = read.GetInt32(0);
                                        }
                                    }
                                    conn.Close(); 
                                }
                            }
                            else
                            {
                                File.AppendAllText(@".\ErroLog.txt", "接收信息内容格式不合法" + DateTime.Now + "\r\n");//追添内容并换行
                                //Console.WriteLine("信息体接受成功！");
                                //Console.WriteLine("接收信息内容格式不合法！");
                            }
                        }
                    }
                }
                else
                {
                    File.AppendAllText(@".\ErroLog.txt", "信息接收失败" + DateTime.Now + "\r\n");//追添内容并换行
                    //Console.WriteLine("信息接收失败");
                    this.ReceiveBytes.Clear();
                    this.ReceivePacketLength = 0;

                    if (this.DisConnected != null)
                        DisConnected(this, new ConnectionEventArgs(ErrorMessage.ReceiveError));
                    throw new Exception("接收信息格式不合法！");
                }

                this.ReceivePacketLength = BitConverter.ToInt32(this.headerBuffer, 0);
                if (this.ReceivePacketLength > 0)
                {
                    this.ReceiveBytes.AddRange(this.headerBuffer.Skip<byte>(ConstParameter.SizeOfInt).Take<byte>(this.ReceivePacketLength));
                    if (this.ReceivePacketLength > ConstParameter.BUFFER_SIZE)
                    {
                        this.ReceiveHeaderPacket();
                    }
                }

                if (socket.ServerSocket.Available == 0)
                {
                    if (this.ReceiveBytes.Count == this.ReceivePacketLength && this.ReceivePacketLength > 0)
                    {
                        ServiceRequest request = JsonConvert.DeserializeObject<ServiceRequest>(UTF8Encoding.UTF8.GetString(this.ReceiveBytes.ToArray()));
                        request.Length = this.ReceivePacketLength + ConstParameter.SizeOfInt;
                        if (this.ReceiveData != null)
                        {
                            this.ReceiveData(this, new MessageEventArgs(request));
                        }
                    }

                    this.ReceiveBytes.Clear();
                    this.ReceivePacketLength = 0;
                }

            }
            catch (Exception ex)
            {
                File.AppendAllText(@".\ErroLog.txt", ex.Message + DateTime.Now + "\r\n");//追添内容并换行
                Console.WriteLine(ex.Message);
                this.ReceiveBytes.Clear();
                this.ReceivePacketLength = 0;

                if (this.DisConnected != null)
                    DisConnected(this, new ConnectionEventArgs(ErrorMessage.UnknownError, ex));
            }
        }

        #endregion

        #region ISocketConnection 成员


        public void Stop()
        {
            if (this.Connected)
            {
                this.serverSocket.Shutdown(SocketShutdown.Both);
                this.serverSocket.Close();
            }
        }

        #endregion
    }
}
