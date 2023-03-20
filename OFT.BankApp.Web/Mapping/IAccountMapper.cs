using OFT.BankApp.Web.Data.Entitites;
using OFT.BankApp.Web.Models;

namespace OFT.BankApp.Web.Mapping
{
    public interface IAccountMapper
    {
        Account Map(AccountCreateModel model);
    }
}
