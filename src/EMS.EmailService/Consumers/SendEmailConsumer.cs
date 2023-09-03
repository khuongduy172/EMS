using EMS.EmailService.Common;
using MassTransit;
using MessagingCore.Email;

namespace EMS.EmailService.Consumers;

public class SendEmailConsumer : IConsumer<SendEmailRequest>
{
    private readonly ILogger<SendEmailConsumer> _logger;
    private readonly IMailService _mailService;

    public SendEmailConsumer(ILogger<SendEmailConsumer> logger, IMailService mailService)
    {
        _logger = logger;
        _mailService = mailService;
    }

    public async Task Consume(ConsumeContext<SendEmailRequest> context)
    {
        var request = context.Message;
        await _mailService.SendAsync(new MailData(new List<string> { request.To }, request.Subject, request.Body));
        _logger.LogInformation($"Sending email to {request.To} with subject {request.Subject} and body {request.Body}");
    }
}