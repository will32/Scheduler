using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scheduler.Areas.Schedule.Controllers
{
    public class EventController : Controller
    {
        // GET: Event/Event
        public ActionResult Index(int? year)
        {
            if (year == null)
            {
                year = DateTime.Now.Year;
            }

            return View();
        }
    }
}