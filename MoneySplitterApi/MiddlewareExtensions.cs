using Microsoft.EntityFrameworkCore;
using MoneySplitterApi.Models;

namespace MoneySplitterApi
{
    public static class MiddlewareExtensions
    {
        public static void UseMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
