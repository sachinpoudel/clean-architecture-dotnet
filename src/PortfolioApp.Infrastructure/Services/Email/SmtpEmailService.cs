using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PortfolioApp.Application.Interfaces.Services;
using PortfolioApp.Domain.Options;

namespace PortfolioApp.Infrastructure.Services.Email;

public class SmtpEmailService(ILogger<SmtpEmailService> logger, IOptions<EmailSettings> emailSettings) : IEmailService
{
    public async Task SendEmailAsync(string to, string subject, string body, CancellationToken cancellationToken = default)
    {
        var client = new SmtpClient(emailSettings.Value.Host, emailSettings.Value.Port)
        {
            Credentials = new NetworkCredential(emailSettings.Value.Username, emailSettings.Value.Password),
            EnableSsl = true
        };

        using var msg = new MailMessage
        {
            From = new MailAddress(emailSettings.Value.FromAddress),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        msg.To.Add(to); // 
        logger.LogInformation("Sending email to {To} with subject {Subject}", to, subject);

        await client.SendMailAsync(msg, cancellationToken);
        logger.LogInformation("Email sent to {To} with subject {Subject}", to, subject);
    }
}