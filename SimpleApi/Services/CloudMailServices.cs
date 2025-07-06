namespace SimpleApi.Services
{
    public class CloudMailServices : IMailServices
    {
        private readonly string _mailFrom = string.Empty;
        private readonly string _mailTo = string.Empty;

        public CloudMailServices(IConfiguration configuration)
        {
            _mailFrom = configuration["mailSettring:mailFromAddress"];
            _mailTo = configuration["mailSettring:mailToAddress"];
        }
        public void Send(string subject, string message)
        {
            Console.WriteLine($"mail from {_mailFrom} to {_mailTo} {nameof(IMailServices)}");
            Console.WriteLine(subject);
            Console.WriteLine(_mailFrom);

        }
    }
}
