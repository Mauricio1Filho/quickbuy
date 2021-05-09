using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace QuickBuy.Dominio.Ferramentas
{
    public class SocketImageServer
    {
        public static  void StartListening()
        {
            ////////////////////////////////////////////

            Console.WriteLine("Server is starting...");
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.0.84") , 9050);

            Socket newsock = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream, ProtocolType.Tcp);

            newsock.Bind(ipep);
            newsock.Listen(10);
            Console.WriteLine("Waiting for a client...");

            Socket client = newsock.Accept();
            IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("Connected with {0} at port {1}",
                            newclient.Address, newclient.Port);

            while (true)
            {
                data = ReceiveVarData(client);
                try
                {
                    using (var ms = new MemoryStream(data))
                    {
                        using (var fs = new FileStream(@"C:\inetpub\wwwroot\images\imagem-1.jpg", FileMode.Create))
                        {
                            ms.WriteTo(fs);
                        }
                    }

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("something broke");
                }


                if (data.Length == 0)
                    newsock.Listen(10);
            }
            //Console.WriteLine("Disconnected from {0}", newclient.Address);
            client.Close();
            newsock.Close();
            /////////////////////////////////////////////

        }

        private static byte[] ReceiveVarData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];

            recv = s.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];


            while (total < size)
            {
                recv = s.Receive(data, total, dataleft, 0);
                if (recv == 0)
                {
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            return data;
        }

    
        public static int SendVarData(byte[] data)
        {                      
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.0.84"), 9050);

            Socket server = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ipep);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Unable to connect to server.");
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }


            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;

            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = server.Send(datasize);

            while (total < size)
            {
                sent = server.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }

    }
}
