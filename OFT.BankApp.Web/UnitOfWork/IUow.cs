using OFT.BankApp.Web.Data.Interfaces;

namespace OFT.BankApp.Web.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        void SaveChanges();
    }
}