using Microsoft.AspNetCore.Mvc;
using OFT.BankApp.Web.Data.Entitites;
using OFT.BankApp.Web.Models;

namespace OFT.BankApp.Web.Data.Interfaces
{
    public interface IAccountRepository
    {
        void Create(Account account);
    }
}
