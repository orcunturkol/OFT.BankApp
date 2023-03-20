using Microsoft.AspNetCore.Mvc;
using OFT.BankApp.Web.Data.Context;
using OFT.BankApp.Web.Data.Interfaces;
using OFT.BankApp.Web.Data.Repositories;
using OFT.BankApp.Web.Mapping;
using OFT.BankApp.Web.Models;

namespace OFT.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankContext _contextAccessor;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        public HomeController(BankContext contextAccessor, IApplicationUserRepository applicationUserRepository
            , IUserMapper userMapper)
        {
            _contextAccessor = contextAccessor;
            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
        }
        public IActionResult Index()
        {
            return View(_userMapper.MapToListOfUserList(_applicationUserRepository.GetAll()));
        }
    }
}
