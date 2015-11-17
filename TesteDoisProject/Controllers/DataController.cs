using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteDoisProject.Models;

namespace TesteDoisProject.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/

        private DefaultContext db = new DefaultContext();

        //public JsonResult GetLastContact()
        //{
        //    Contact c = null;
        //    using (db)
        //    {
        //        c = db.contacts.OrderByDescending(i => i.ContactID).Take(1).FirstOrDefault();
        //    }

        //    return new JsonResult { Data = c, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

    }
}
