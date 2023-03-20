using OFT.BankApp.Web.Data.Entitites;
using OFT.BankApp.Web.Models;

namespace OFT.BankApp.Web.Mapping
{
    public interface IUserMapper
    {
        List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);

        UserListModel MapToUserList(ApplicationUser user);
    }
}
