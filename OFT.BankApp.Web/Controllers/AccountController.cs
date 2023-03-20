using Microsoft.AspNetCore.Mvc;
using OFT.BankApp.Web.Data.Context;
using OFT.BankApp.Web.Data.Interfaces;
using OFT.BankApp.Web.Data.Repositories;
using OFT.BankApp.Web.Mapping;
using OFT.BankApp.Web.Models;

namespace OFT.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountMapper _accountMapper;
        public AccountController(IUserMapper userMapper, IApplicationUserRepository applicationUserRepository, IAccountRepository accountRepository, IAccountMapper accountMapper)
        {
            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
            _accountRepository = accountRepository;
            _accountMapper = accountMapper;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _userMapper.MapToUserList(_applicationUserRepository.GetById(id));
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _accountRepository.Create(_accountMapper.Map(model));

            return RedirectToAction("Index", "Home");
        }
    }
}
