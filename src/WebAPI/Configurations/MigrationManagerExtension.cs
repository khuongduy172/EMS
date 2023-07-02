using IMS.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Configurations;

public static class MigrationManagerExtension
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Database.Migrate();
        }

        return webApp;
    }
}