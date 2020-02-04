using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace JenkinsFinder
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Thread.Sleep(1000);
            int _localPort = 33848;
            int _remotePort = 33848;
            List<string> instances = new List<string>();
            UdpClient client = new UdpClient(_localPort, AddressFamily.InterNetwork);
            IPEndPoint groupEp = new IPEndPoint(IPAddress.Broadcast, _remotePort);
            client.Connect(groupEp);
            client.Send(new byte[0], 0);
            client.Close();
            IPEndPoint recvEp = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                UdpClient udpResponse = new UdpClient(_localPort);
                Byte[] recvBytes = udpResponse.Receive(ref recvEp);

                Console.WriteLine(Encoding.ASCII.GetString(recvBytes));
                udpResponse.Close();
            }
        }
    }
}
