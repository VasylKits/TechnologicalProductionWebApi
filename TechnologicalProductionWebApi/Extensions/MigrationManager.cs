using Microsoft.EntityFrameworkCore;
using TechnologicalProductionWebApi.DB;

namespace TechnologicalProductionWebApi.Extensions;

public static class MigrationManager
{
    public static void MigrateDatabase(this WebApplication app)
    {
        try
        {
            using var scope = app.Services.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            appContext.Database.Migrate();
        }
        catch (Exception ex)
        {
        }
    }
}