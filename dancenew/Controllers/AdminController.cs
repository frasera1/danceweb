using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using dancenew.Data;
using dancenew.ViewModels;

namespace dancenew.Controllers
{
   [Authorize(Users = "dancediscovery@gmail.com")]
    public class AdminController : Controller
    {
        private readonly IDanceRepository _dDb;

        public AdminController(IDanceRepository dDb)
        {
            _dDb = dDb;
        }
        //Get viewmodel for all tabs
         
        public ActionResult Index()
        {
                var adminVM = _dDb.GetAdminViewModel();
                return View(adminVM.Schedules); 
        }

        public ActionResult _ScheduleTab()
        {
            var adminVM = _dDb.GetAdminViewModel();
            return PartialView(adminVM.Schedules);
        }

        public ViewResult EditSchedule(int Id)
        {
            var schedule = _dDb.GetScheduleById(Id);
            PopulateLevelList(schedule.Level);
            PopulateWeekDayList(schedule.Group);
            PopulateGroupList(schedule.Weekday);
            return View(schedule);
        }

        public ActionResult CreateSchedule()
        {
            PopulateLevelList();
            PopulateWeekDayList();
            PopulateGroupList();
            return View("EditSchedule", new Schedule());
        }

        [HttpPost]
        public ActionResult EditSchedule(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _dDb.SaveSchedule(schedule);
                TempData["message"] = string.Format("{0} has been saved", schedule.ClassName);
                return RedirectToAction("Index");
            }
            PopulateLevelList(schedule.Level);
            PopulateWeekDayList(schedule.Weekday);
            PopulateGroupList(schedule.Group);
            return View(schedule);
        }

        public ActionResult DeleteSchedule(int Id)
        {
            var deletedSchedule = _dDb.DeleteSchedule(Id);
            if (deletedSchedule != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedSchedule.ClassName);
            }
            return RedirectToAction("Index");
        }

        public ActionResult _ClassTab()
        {
            var adminVM = _dDb.GetAdminViewModel();
            return PartialView(adminVM.Classes);
        }

        public ViewResult EditClass(int Id)
        {
            var klass = _dDb.GetKlassById(Id);
            PopulateTypeList(klass.Type);
            return View(klass);
        }

        public ActionResult CreateClass()
        {
            PopulateTypeList();
            return View("EditClass", new Klassen());
        }

        [HttpPost]
        public ActionResult EditClass(Klassen klass)
        {
            if (ModelState.IsValid)
            {
                _dDb.SaveKlass(klass);
                TempData["message"] = string.Format("{0} has been saved", klass.Title);
                return RedirectToAction("Index");
            }
            PopulateTypeList(klass.Type);
            return View(klass);
        }

        public ActionResult DeleteClass(int Id)
        {
            var deletedClass = _dDb.DeleteKlass(Id);
            if (deletedClass != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedClass.Title);
            }
            return RedirectToAction("Index");
        }

        

        public ActionResult _UpdatesTab()
        {
            return PartialView();
        }

        public ActionResult _BioTab()
        {
            return PartialView();
        }

        private IEnumerable<WeekDays> GetWeekDays()
        {
            var weekdays = new List<WeekDays>()
                {  
                    new WeekDays() {ID = "Montag", Name = "Montag"},
                    new WeekDays() {ID = "Dienstag ", Name = "Dienstag "},
                    new WeekDays() {ID = "Mittwoch ", Name = "Mittwoch "},
                    new WeekDays() {ID = "Donnerstag ", Name = "Donnerstag "},
                    new WeekDays() {ID = "Freitag ", Name = "Freitag"},
                    new WeekDays() {ID = "Samstag", Name = "Samstag "},
                    new WeekDays() {ID = "Suntag", Name = "Suntag"}
                };
            return weekdays;
        }

        private void PopulateWeekDayList(string selectedWeekday = null)
        {
            var weekQuery = GetWeekDays().ToList();
            ViewBag.WeekDay = new SelectList(weekQuery, "ID","Name", selectedWeekday);
        }

        private void PopulateGroupList(string selectedGroup = null)
        {
            var groupQuery = _dDb.GetSchedules().Select(g => new {g.Group}).Distinct().ToList();
            ViewBag.Group = new SelectList(groupQuery, "Group","Group", selectedGroup);
        }

        private void PopulateLevelList(string selectedLevel = null)
        {
            var levelQuery = _dDb.GetSchedules().Select(l => new { l.Level }).Distinct().ToList();
            ViewBag.Level = new SelectList(levelQuery, "Level", "Level", selectedLevel);
        }

        private void PopulateTypeList(string selectedType = null)
        {
            var typeQuery = _dDb.GetKlassens().Select(t => new { t.Type }).Distinct().ToList();
            ViewBag.Type = new SelectList(typeQuery, "Type", "Type", selectedType);
        }


    }
}