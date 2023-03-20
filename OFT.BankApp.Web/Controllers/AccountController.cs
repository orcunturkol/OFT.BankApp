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
        private readonly BankContext _context;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;

        public AccountController(BankContext context, IUserMapper userMapper, IApplicationUserRepository applicationUserRepository)
        {
            _context = context;
            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _userMapper.MapToUserList(_applicationUserRepository.GetById(id));
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
