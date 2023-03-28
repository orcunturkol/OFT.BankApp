using OFT.BankApp.Web.Data.Context;
using OFT.BankApp.Web.Data.Interfaces;

namespace OFT.BankApp.Web.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly BankContext _bankContext;

        public Repository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public void Create (T entity)
        {
            _bankContext.Set<T>().Add(entity);
            _bankContext.SaveChanges();
        }

        public void Remove (T entity)
        {
            _bankContext.Set<T>().Remove(entity);
            _bankContext.SaveChanges();
        }

        public List<T> GetAll (int id)
        {
            return _bankContext.Set<T>().ToList();
        }

        public T GetById (object id)
        {
            return _bankContext.Set<T>().Find(id);
        }

        public void Update (T entity)
        {
            _bankContext.Set<T>().Update(entity);
            _bankContext.SaveChanges();
        }
    }
}
