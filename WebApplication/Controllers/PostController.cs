using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult article()
        {
            return View();
        }
    }
}