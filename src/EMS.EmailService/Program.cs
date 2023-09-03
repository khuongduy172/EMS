using EMS.EmailService;
using EMS.EmailService.Common;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.ConfigureMassTransit(builder.Configuration);

    builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
    builder.Services.AddTransient<IMailService, MailService>();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}