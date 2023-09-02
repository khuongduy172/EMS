using IMS.Data.Context;
using MassTransit;
using MessagingCore;
using MessagingCore.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public TestController(ApplicationDbContext context, ISendEndpointProvider sendEndpointProvider)
    {
        _context = context;
        _sendEndpointProvider = sendEndpointProvider;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var temp = await _context.Users.FirstOrDefaultAsync();
        var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri(QueueHelper.GetQueueName(Constants.QueueNames.EmailService)));
        await endpoint.Send(new SendEmailRequest("khongduy1722001@gmail.com", "Test", "Test"));
        return Ok(temp);
    }
}