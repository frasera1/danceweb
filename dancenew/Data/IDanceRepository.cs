using System.Collections.Generic;
using System.Linq;
using dancenew.ViewModels;

namespace dancenew.Data
{
    public interface IDanceRepository
    {
        DDAdminViewModel GetAdminViewModel();
        ScheduleVM GetSchedulesVM();
        IQueryable<Schedule> GetSchedules();
        Schedule GetScheduleById(int scheduleId);
        void SaveSchedule(Schedule newSchedule);
        Schedule DeleteSchedule(int Id);

        IQueryable<Klassen> GetKlassens();
        Klassen GetKlassById(int Id);
        void SaveKlass(Klassen newKlass);
        Klassen DeleteKlass(int Id);

        IQueryable<Bio> GetBios();

        bool Save();
    }
}