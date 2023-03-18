using Microsoft.AspNetCore.Mvc;
using OFT.BankApp.Web.Data.Context;
using OFT.BankApp.Web.Models;

namespace OFT.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _context;

        public AccountController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _context.ApplicationUsers.Select(x=> new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            }).SingleOrDefault(x => x.Id == id);
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _context.Accounts.Add(new Data.Entitites.Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance
            });

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
