using MultiShop.Cargo.EntityLayer.Concrete;
using MultiSop.Cargo.DataAccessLayer.Abstracts.Inferfaces;
using MultiSop.Cargo.DataAccessLayer.Concrete;
using MultiSop.Cargo.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoOperations :IGenericRepository<CargoOperations>,ICargoOperationsDal
    {
        public EfCargoOperations(CargoDbContext dbContext):base(dbContext)
        {
        }
    }
}
