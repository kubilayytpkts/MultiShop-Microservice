using MultiSop.Cargo.DataAccessLayer.Abstracts.Inferfaces;
using MultiSop.Cargo.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSop.Cargo.DataAccessLayer.Repositories
{
    public class IGenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoDbContext _dbContext;

        public IGenericRepository(CargoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            T value = _dbContext.Set<T>().Find(id);
            _dbContext.Set<T>().Remove(value);
            _dbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
