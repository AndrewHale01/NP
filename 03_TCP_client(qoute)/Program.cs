using System.Net;
using System.Net.Sockets;

namespace _03_TCP_client_qoute_
{
    internal class Program
    {
        static int port = 4040;
        static string address = "127.0.0.1";
        
        static void Main(string[] args)
        {
            NetworkStream ns = null;
            StreamWriter sw = null;
            StreamReader sr = null;

            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(iPEndPoint);

            ns = tcpClient.GetStream();
            sw = new StreamWriter(ns);
            sr = new StreamReader(ns);
            try
            {
                string message = "";
                while (message != "exit")
                {
                    Console.WriteLine("Enter a message (quote):");
                    message = Console.ReadLine()!;
                    sw.WriteLine(message);
                    sw.Flush();
                    if (message == "exit")
                    {
                        message = $"{DateTime.Now.ToShortTimeString()}";

                        sw.WriteLine(message);
                        sw.Flush();
                        break;
                    }

                    string response = sr.ReadLine()!;
                    Console.WriteLine($"Response from server : Qoute : {response}");
                }
                

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            ns?.Close();
            sw?.Close();
            sr?.Close();
        }
    }
}
