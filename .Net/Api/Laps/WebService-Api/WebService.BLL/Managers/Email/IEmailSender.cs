using WebService.BLL.Abstractions;

namespace WebService.BLL.Managers.Email
{
    public interface IEmailSender
    {
        Task<Result> SendEmailAsync(string email,string subject, string htmlMessage);
    }
}
