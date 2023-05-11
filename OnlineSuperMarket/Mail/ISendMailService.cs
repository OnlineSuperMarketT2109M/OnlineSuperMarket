using System.Threading.Tasks;
namespace OnlineSuperMarket.Mail
{
    public interface ISendMailService
    {
        Task SendMail(MailContent mailContent);

        Task SendMailAsync(string email, string subject, string htmlMessage);
    }
}
