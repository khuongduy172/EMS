using IMS.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TestController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var temp = _context.Users.FirstOrDefault();
        return Ok(temp);
    }
}