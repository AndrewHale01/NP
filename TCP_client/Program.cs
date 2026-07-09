using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP_client
{
    internal class Program
    {
        static int port = 8080;
        static string address = "127.0.0.1";
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(ipPoint);

                string message = "";
                while (message != "end")
                {
                    Console.WriteLine("Enter your message");
                    message = Console.ReadLine()!;
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    socket.Send(data);

                    int bytes = 0;
                    string response = "";
                    data = new byte[1024];
                    do
                    {
                        bytes = socket.Receive(data);
                        response = Encoding.Unicode.GetString(data, 0, bytes);
                        Console.WriteLine($"Server response : {response}");
                    } while (socket.Available > 0);

                }

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
