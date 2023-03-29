using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OFT.BankApp.Web.Data.Context;
using OFT.BankApp.Web.Data.Entitites;
using OFT.BankApp.Web.Data.Interfaces;
using OFT.BankApp.Web.Data.Repositories;
using OFT.BankApp.Web.Mapping;
using OFT.BankApp.Web.Models;
using OFT.BankApp.Web.UnitOfWork;

namespace OFT.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUow _uow;

        public AccountController(IUow uow)
        {
            _uow = uow;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _uow.GetRepository<ApplicationUser>().GetById(id);
            return View(new UserListModel
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _uow.GetRepository<Account>().Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId
            }
                );
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int userId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();

            var accountList = query.Where(x => x.ApplicationUserId == userId).ToList();

            var user = _uow.GetRepository<ApplicationUser>().GetById(userId);

            ViewBag.Fullname = user.Name + " " + user.Surname;

            var list = new List<AccountListModel>();

            foreach (var account in accountList)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    ApplicationUserId = account.ApplicationUserId,
                    Id = account.Id
                });
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();

            var accounts = query.Where(x => x.Id != accountId).ToList();

            var list = new List<AccountListModel>();

            ViewBag.SenderId = accountId;

            foreach (var account in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    ApplicationUserId = account.ApplicationUserId,
                    Id = account.Id
                });
            }
            return View(new SelectList(list, "Id", "AccountNumber"));
        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model) {

            var account = _uow.GetRepository<Account>().GetById(model.AccountId);
            var senderAccount = _uow.GetRepository<Account>().GetById(model.SenderId);

            senderAccount.Balance -= model.Amount;
            _uow.GetRepository<Account>().Update(senderAccount);

            account.Balance += model.Amount;
            _uow.GetRepository<Account>().Update(account);

            _uow.SaveChanges();

        return RedirectToAction("Index", "Home");
        }
    }
}
