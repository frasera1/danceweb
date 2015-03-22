using System;
using System.Collections.Generic;
using System.Linq;
using dancenew.ViewModels;

namespace dancenew.Data
{
    public class DanceRepository : IDanceRepository
    {
        private DanceContext _ctx;

        public DanceRepository(DanceContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Schedule> GetSchedules()
        {
            return _ctx.Schedules;
        }

        public DDAdminViewModel GetAdminViewModel()
        {
            var adminVM = new DDAdminViewModel
            {
                Schedules = _ctx.Schedules.ToList(),
                Classes = _ctx.Klassens.ToList(),
                Updates = _ctx.Updates.ToList(),
                Bios = _ctx.Bios.ToList()
            };

            return adminVM;
        }

        public ScheduleVM GetSchedulesVM()
        {
            var scheduleVm = new ScheduleVM
            {
                AdultsAdvanced = _ctx.Schedules.Where(s => s.Group == "Erwachsene" && s.Level == "Anfänger" && s.ClassName !="Modern Dance"),
                AdultsBeginner = _ctx.Schedules.Where(s => s.Group == "Erwachsene" && s.Level == "Fortgeschrittene" && s.ClassName != "Modern Dance"),
                AdultModern = _ctx.Schedules.Where(s => s.Group == "Erwachsene" && s.ClassName == "Modern Dance"),
                Kids34 = _ctx.Schedules.Where(s => s.Group == "Kinder" && s.Level == "Alles34"),
                Kids34Eng = _ctx.Schedules.Where(s => s.Group == "Kinder" && s.Level == "Alles34Eng"),
                Kids57 = _ctx.Schedules.Where(s => s.Group == "Kinder" && s.Level == "Alles57")
            };
            return scheduleVm;
        }

        public Schedule GetScheduleById(int scheduleId)
        {
            return _ctx.Schedules.FirstOrDefault(s => s.Id == scheduleId);
        }

        public void SaveSchedule(Schedule newSchedule)
        {     
            if (newSchedule.Id == 0)
            _ctx.Schedules.Add(newSchedule);
            else
            {
                Schedule dbEntry = _ctx.Schedules.Find(newSchedule.Id);
                if (dbEntry != null)
                {
                    dbEntry.ClassName = newSchedule.ClassName;
                    dbEntry.Group = newSchedule.Group;
                    dbEntry.Level = newSchedule.Level;
                    dbEntry.Weekday = newSchedule.Weekday;
                    dbEntry.StartTime = newSchedule.StartTime;
                    dbEntry.EndTime = newSchedule.EndTime;
                    dbEntry.SortPos = newSchedule.SortPos;
                }
            }
            Save();
        }

        public Schedule DeleteSchedule(int Id)
        {
            var dbEntry = _ctx.Schedules.Find(Id);
            if (dbEntry != null)
            {
                _ctx.Schedules.Remove(dbEntry);
                Save();
            }
            return dbEntry;
        }

        public IQueryable<Klassen> GetKlassens()
        {
            return _ctx.Klassens;
        }

        public Klassen GetKlassById(int Id)
        {
            return _ctx.Klassens.FirstOrDefault(k => k.Id == Id);
        }

        public void SaveKlass(Klassen newKlass)
        {
            if (newKlass.Id == 0)
                _ctx.Klassens.Add(newKlass);
            else
            {
                Klassen dbEntry = _ctx.Klassens.Find(newKlass.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = newKlass.Title;
                    dbEntry.Description = newKlass.Description;
                    dbEntry.Type = newKlass.Type;
                    dbEntry.SortPos = newKlass.SortPos;
                }
            }
            Save();
        }

        public Klassen DeleteKlass(int Id)
        {
            var dbEntry = _ctx.Klassens.Find(Id);
            if (dbEntry != null)
            {
                _ctx.Klassens.Remove(dbEntry);
                Save();
            }
            return dbEntry;
        }

        public IQueryable<Bio> GetBios()
        {
            return _ctx.Bios;
        }

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            { 
                return false;
            }
        }       
    }
}