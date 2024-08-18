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
    public class EfCargoDetail:IGenericRepository<CargoDetail>,ICargoDetailDal
    {
        public EfCargoDetail(CargoDbContext cargoDbContext):base(cargoDbContext)
        {
                
        }
    }
}
