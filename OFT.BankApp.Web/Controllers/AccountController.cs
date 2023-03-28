using Microsoft.AspNetCore.Mvc;
using OFT.BankApp.Web.Data.Context;
using OFT.BankApp.Web.Data.Entitites;
using OFT.BankApp.Web.Data.Interfaces;
using OFT.BankApp.Web.Data.Repositories;
using OFT.BankApp.Web.Mapping;
using OFT.BankApp.Web.Models;

namespace OFT.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IApplicationUserRepository _applicationUserRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper _accountMapper;
        //public AccountController(IUserMapper userMapper, IApplicationUserRepository applicationUserRepository, IAccountRepository accountRepository, IAccountMapper accountMapper)
        //{
        //    _applicationUserRepository = applicationUserRepository;
        //    _userMapper = userMapper;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}

        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<ApplicationUser> _applicationUserRepository;
        public AccountController(IRepository<Account> accountRepository, IRepository<ApplicationUser> applicationUserRepository)
        {
            _accountRepository = accountRepository;
            _applicationUserRepository = applicationUserRepository;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _applicationUserRepository.GetById(id);
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
            _accountRepository.Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId
            }
                );
            return RedirectToAction("Index", "Home");
        }
    }
}
