using System.Web.Mvc;
using dancenew.Data;

namespace dancenew.Controllers
{
    public class ScheduleController : Controller

    {
        private IDanceRepository _dDb;

        public ScheduleController(IDanceRepository dDb)
        {
            _dDb = dDb;
        }
        // GET: Schedule
        public ActionResult Index()
        {
            var schedules = _dDb.GetSchedulesVM();
            return View(schedules);
        }
    }
}