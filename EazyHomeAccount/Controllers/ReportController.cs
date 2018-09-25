using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EazyHomeAccount.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Default()
        {
            return View();
        }
        // GET: Report custom
        public ActionResult Custom()
        {
            return View();
        }
    }
}