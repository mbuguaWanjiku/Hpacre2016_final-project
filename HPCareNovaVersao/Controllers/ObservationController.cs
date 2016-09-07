using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class ObservationController : Controller
    {
        // GET: Observation
        public ActionResult CreateObservation()
        {
            return PartialView();
        }
    }
}