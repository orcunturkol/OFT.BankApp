using Microsoft.AspNetCore.Mvc;
using OFT.BankApp.Web.Data.Context;

namespace OFT.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankContext _contextAccessor;
        public IActionResult Index()
        {
            return View();
        }
    }
}
