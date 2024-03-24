using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EventsApp.Models;

namespace EventsApp.Models {

    public static class SeedData {

        public static void EnsurePopulated(IApplicationBuilder app) {
            EventsAppDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<EventsAppDBContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.Events.Any()) {
                context.Events.AddRange(
                    new Event {
                        EventName = "Городской забег",
                        Category="Бег",
                        EventText="Приглашаем принять участие в городском пробеге",
                        EventTime = DateTime.Now,

                    },
                    new Event
                    {
                        EventName = "Городской заплыв",
                        Category = "Плавание",
                        EventText = "Приглашаем принять участие в городском заплыве",
                        EventTime = DateTime.Now,

                    },
                    new Event
                    {
                        EventName = "Городской заезд",
                        Category = "Велоспорт",
                        EventText = "Приглашаем принять участие в городском заезде",
                        EventTime = DateTime.Now,

                    }

                );
                context.SaveChanges();
            }
        }
    }
}
