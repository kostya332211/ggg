using System.Web.Mvc;

namespace LABA3.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult PageNotFound()
        {
            return View();
        }

    }
}