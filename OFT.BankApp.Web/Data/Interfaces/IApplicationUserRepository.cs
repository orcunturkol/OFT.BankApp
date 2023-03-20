using OFT.BankApp.Web.Data.Entitites;

namespace OFT.BankApp.Web.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List <ApplicationUser> GetAll ();
        ApplicationUser GetById(int id);
    }
}
