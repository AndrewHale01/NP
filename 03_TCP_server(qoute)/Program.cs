using System.ComponentModel.Design;
using System.Net;
using System.Net.Sockets;

namespace _03_TCP_server_qoute_
{
    internal class Program
    {
        static int port = 4040;
        static string address = "127.0.0.1";
        static Random random = new Random();
        static void Main(string[] args)
        {
            List<string> quotes = new List<string>
{
    "The only way to do great work is to love what you do. — Steve Jobs",
    "Success is not final, failure is not fatal: it is the courage to continue that counts. — Winston Churchill",
    "Believe you can and you're halfway there. — Theodore Roosevelt",
    "Dream big and dare to fail. — Norman Vaughan",
    "The future depends on what you do today. — Mahatma Gandhi",
    "Do what you can, with what you have, where you are. — Theodore Roosevelt",
    "Everything you've ever wanted is on the other side of fear. — George Addair",
    "Opportunities don't happen. You create them. — Chris Grosser",
    "Don't watch the clock; do what it does. Keep going. — Sam Levenson",
    "Success usually comes to those who are too busy to be looking for it. — Henry David Thoreau"
};
            NetworkStream ns = null;
            StreamWriter sw = null;
            StreamReader sr = null;

            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
            TcpListener listener = new TcpListener(iPEndPoint);
            try
            {
                listener.Start(10);
                Console.WriteLine("Server started! Waiting for connection!");

                TcpClient client = listener.AcceptTcpClient();

                ns = client.GetStream();
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);
                string response = "";
                List<string> sent_quotes = new List<string>();
                while (client.Connected)
                {
                                    
                    response = sr.ReadLine()!;
                    if (response == "quote")
                    {
                        string message = quotes[random.Next(quotes.Count)];
                        sent_quotes.Add(message);
                        sw.WriteLine(message);
                        sw.Flush();
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"Client : {client.Client.RemoteEndPoint}");
                        Console.WriteLine($"Time : {DateTime.Now.ToLongTimeString()}");
                        Console.WriteLine($"Message : {response}");
                        Console.WriteLine("List quotes : ");
                        foreach(string q in sent_quotes)
                        {
                            Console.WriteLine(q);
                            Console.WriteLine("----------------------------");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Client disconected!");
                        Console.WriteLine($"Time : {DateTime.Now.ToLongTimeString()}");
                        break;
                    }      
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
