using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProformaInvoice.Controllers
{
    public class ProformaUserController : Controller
    {
        
        [HttpGet]
        public ActionResult ManageUser()
        {
            return View();
        }
	}
}