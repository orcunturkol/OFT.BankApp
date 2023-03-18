using Microsoft.AspNetCore.Mvc;
using OFT.BankApp.Web.Data.Context;

namespace OFT.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankContext _contextAccessor;

        public HomeController(BankContext contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public IActionResult Index()
        {
            return View(_contextAccessor.ApplicationUsers.ToList());
        }
    }
}
