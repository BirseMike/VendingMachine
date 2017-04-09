namespace VendingMachine.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Acme Vending Machine";

            return View();
        }
    }
}
