using Microsoft.EntityFrameworkCore;
using OFT.BankApp.Web.Data.Context;
using OFT.BankApp.Web.Data.Entitites;
using OFT.BankApp.Web.Data.Interfaces;

namespace OFT.BankApp.Web.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _bankcontext;

        public AccountRepository(BankContext bankcontext)
        {
            _bankcontext = bankcontext;
        }

        public void Create(Account account)
        {
            _bankcontext.Accounts.Add(account);
            _bankcontext.SaveChanges();
        }
    }
}
