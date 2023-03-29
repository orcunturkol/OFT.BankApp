using OFT.BankApp.Web.Data.Context;
using OFT.BankApp.Web.Data.Interfaces;
using OFT.BankApp.Web.Data.Repositories;

namespace OFT.BankApp.Web.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly BankContext _bankContext;

        public Uow(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_bankContext);
        }

        public void SaveChanges()
        {
            _bankContext.SaveChanges();
        }
    }
}
