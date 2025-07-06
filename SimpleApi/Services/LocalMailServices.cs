using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.FileProviders;

namespace SimpleApi.Services
{
    public class LocalMailServices : IMailServices
    {
        private readonly string _mailFrom = string.Empty;
        private readonly string _mailTo = string.Empty;

        public LocalMailServices(IConfiguration configuration)
        {
            _mailFrom = configuration["mailSettring:mailFromAddress"];
            _mailTo = configuration["mailSettring:mailToAddress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"mail from {_mailFrom} to {_mailTo} {nameof(LocalMailServices)}");
            Console.WriteLine(subject);
            Console.WriteLine(_mailFrom);

        }

        public static void Email(string htmlString)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("mhdyd399@_mailFrom.com");
                message.To.Add(new MailAddress("mhdyd399@gmail.com"));
                message.Subject = "asp.Net Core";
                message.IsBodyHtml = true;
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("mhdyd399@gmail.com", "yghn urpc osjm asiw");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
