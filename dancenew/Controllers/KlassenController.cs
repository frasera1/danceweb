using System.Linq;
using System.Web.Mvc;
using dancenew.Data;

namespace dancenew.Controllers
{
    public class KlassenController : Controller
    {
        private IDanceRepository _dDb;

        public KlassenController(IDanceRepository dDb)
        {
            _dDb = dDb;
        }
        // GET: Klassen
        public ActionResult Index()
        {
            var classes = _dDb.GetKlassens().ToList();
            return View(classes);
        }
    }
}