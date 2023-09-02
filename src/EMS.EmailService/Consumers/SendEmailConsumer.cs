using MassTransit;
using MessagingCore.Email;

namespace EMS.EmailService.Consumers;

public class SendEmailConsumer : IConsumer<SendEmailRequest>
{
    private readonly ILogger<SendEmailConsumer> _logger;

    public SendEmailConsumer(ILogger<SendEmailConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<SendEmailRequest> context)
    {
        var request = context.Message;
        _logger.LogInformation($"Sending email to {request.To} with subject {request.Subject} and body {request.Body}");
    }
}