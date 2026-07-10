using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SoketServer
{
    internal class Program
    {
        static int port = 8080;
        static string address = "127.0.0.1";
        static void Main(string[] args)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(address), port);


            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listenSocket.Bind(iPEndPoint);
                Console.WriteLine("Server stated! Waiting for connection...");
                listenSocket.Listen(10);
                Socket client = listenSocket.Accept();
                string response_client = "";
                Console.WriteLine("Client connected");
                while (true)
                {
                    int bytes = 0;
                    byte[] data = new byte[1024];
                    bytes = client.Receive(data);

                    string msg = Encoding.Unicode.GetString(data, 0, bytes);
                    Console.WriteLine($"{DateTime.Now.ToShortTimeString()} : {msg}" + " " +
                        $"from {client.RemoteEndPoint}");
                    if (msg == "date")
                    {
                        response_client = $"Current date is {DateTime.Now.ToShortDateString()}";
                    }
                    else if (msg == "time")
                    {
                        response_client = $"Current time is {DateTime.Now.ToShortTimeString()}";
                    }
                    else if (msg != "time" || msg != "date")
                    {
                        response_client = $"False message";
                    }
                    else if (msg == "end")
                    {
                        response_client = "Goodbye!";
                    }

                    data = Encoding.Unicode.GetBytes(response_client);
                    client.Send(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            listenSocket.Shutdown(SocketShutdown.Both);
            listenSocket.Close();
        }
    }
}
