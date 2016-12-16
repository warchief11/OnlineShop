using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
      
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}