using System.Net;
using System.Net.Mail;

namespace _05_SMTP_Mail_Sender
{
    class MaillSender
    {
        string server_address = "smtp.gmail.com";
        int port = 587;

        //const string username = "galevskiy2009@gmail.com";
        //const string password = "qeik trte gezw ixvy";

        public void sendMessage(string username, string password)
        {
            Console.WriteLine("Enter theme message : ");
            string theme = Console.ReadLine()!;

            Console.WriteLine("Enter text message : ");
            string text = Console.ReadLine()!;
            
            Console.WriteLine("Enter whom send message : ");
            string to = Console.ReadLine()!; 

            MailMessage message = new MailMessage(username, to, theme, text);

            Console.WriteLine("Enter path to file for attachment: ");
            string filePathattachments = Console.ReadLine()!;
            message.Attachments.Add(new Attachment(filePathattachments));
            //message.Attachments.Add(new Attachment(@"C:\Users\Світлана\source\repos\NP\05_SMTP_Mail_Sender\nuts.jpg"));
            //message.Attachments.Add(new Attachment(@"C:\Users\Світлана\source\repos\NP\05_SMTP_Mail_Sender\text.txt"));

            Console.WriteLine("Enter path to file for body: ");
            //string filePath = @"C:\Users\Світлана\source\repos\NP\05_SMTP_Mail_Sender\mail.html";
            string filePath = Console.ReadLine()!;
            string extension = Path.GetExtension(filePath);


            using (StreamReader sr = new StreamReader(filePath))
            {
                message.Body = sr.ReadToEnd();

            }
            if (extension == ".html")
                message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(server_address, port);
            smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential(username, password);


            smtp.SendCompleted += Smtp_SendCompleted;
            smtp.SendAsync(message, message);

            Console.ReadKey();
        }

        private void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var state = (MailMessage)e.UserState!;
            Console.WriteLine($"Message was sent! {state?.Subject}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MaillSender maillSender = new MaillSender();
            Console.WriteLine("Welcome to Mail Sender");
            Console.WriteLine("Enter email : ");
            string email = Console.ReadLine()!;

            Console.WriteLine("Enter secret password : ");
            string password = Console.ReadLine()!;
            maillSender.sendMessage(email, password);
        }
    }
}
