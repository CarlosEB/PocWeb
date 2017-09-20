using System.Web.Mvc;
using Poc.Domain.Entities;
using Poc.App.Interfaces;

namespace WebPoc.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserApp _user;

        public HomeController(IUserApp user)
        {
            _user = user;
        }

        public ActionResult Index()
        {
            var user = _user.GetUsers();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            var user = new User
            {
                Name = "Cesar Sies",
                Address = "Rua de Londrina"
            };

            _user.Create(user);

            return View();
        }
    }
}