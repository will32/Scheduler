using Microsoft.AspNet.Identity.Owin;
using Scheduler.Areas.Schedule.Models;
using Scheduler.Models;
using Scheduler.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Scheduler.Areas.Schedule.Controllers
{
    public class EventController : Controller
    {
        public EventController()
        {
        }

        public EventController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        #region Properties
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        private ApplicationDbContext _db;
        protected ApplicationDbContext Db
        {
            get
            {
                if (_db == null)
                {
                    _db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                }
                return _db;
            }
        }
        #endregion Properties

        public ActionResult Index()
        {
            return View();
        }


        // Change to Api later if upgrade to MVC 6
        // List the events in the specific month
        // GET: Schedule/Event/ListEventInMonth
        public async Task<ActionResult> ListEventsInMonth(int? year, int? month)
        {
            if (year == null)
            {
                year = DateTime.Now.Year;
            }
            if (month == null)
            {
                month = DateTime.Now.Month;
            }

            ViewBag.Month = month;
            ViewBag.Year = year;

            List<Event> events = await Db.Events.Where(e => e.Year == year && e.Month == month).ToListAsync();
            List<EventListMonthViewModel> eventsInMonth = new List<EventListMonthViewModel>();
            foreach (Event e in events)
            {
                EventListMonthViewModel eventInMonth = new EventListMonthViewModel();
                eventInMonth.Name = e.Name;
                eventInMonth.Day = e.Day;
                eventsInMonth.Add(eventInMonth);
            }

            return PartialView("_ListEventsInMonth", eventsInMonth);
        }
    }
}