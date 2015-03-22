using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace dancenew.Data
{
    public class DanceDbMigrationConfiguration : DbMigrationsConfiguration<DanceContext>
    {
        public DanceDbMigrationConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(DanceContext context)
        {
            base.Seed(context);
#if DEBUG
            if (!context.Schedules.Any())
            {
                var schedule1 = new Schedule()
                {
                    Group = "Erwachsene",
                    Weekday = "Montag",
                    Level = "Anfänger",
                    ClassName = "Ballet Für Anfänger",
                    StartTime = "20:00",
                    EndTime = "21:00",
                    SortPos = 1

                };
                context.Schedules.Add(schedule1);

                var schedule2 = new Schedule()
                {
                    Group = "Kinder",
                    Weekday = "Montag",
                    Level = "Fortgeschrittene",
                    ClassName = "Kinderklassen Kreativer Tanz (3-4 Jahre)",
                    StartTime = "15:30",
                    EndTime = "16:15",
                    SortPos = 1

                };
                context.Schedules.Add(schedule2);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    var message = ex.Message;
                }
            }
#endif
        }
    }
}
