using OFT.BankApp.Web.Data.Context;
using OFT.BankApp.Web.Data.Entitites;
using OFT.BankApp.Web.Data.Interfaces;

namespace OFT.BankApp.Web.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly BankContext _bankContext;

        public ApplicationUserRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public List <ApplicationUser> GetAll()
        {
            return _bankContext.ApplicationUsers.ToList();
        }

        public ApplicationUser GetById(int id)
        {
            return _bankContext.ApplicationUsers.SingleOrDefault(x => x.Id == id);
        }

        public void Create (ApplicationUser user) { 
        _bankContext.ApplicationUsers.Add(user);
        _bankContext.SaveChanges();
        }
    }
}
