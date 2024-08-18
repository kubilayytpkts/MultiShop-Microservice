using MultiShop.Cargo.BusinessLogicLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiSop.Cargo.DataAccessLayer.Abstracts.Inferfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLogicLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {

        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public void BDelete(int id)
        {
            _cargoDetailDal.Delete(id);
        }

        public List<CargoDetail> BGetAll()
        {
            return _cargoDetailDal.GetAll();
        }

        public CargoDetail BGetById(int id)
        {
            return _cargoDetailDal.GetById(id);
        }

        public void BInsert(CargoDetail entity)
        {
            _cargoDetailDal.Insert(entity);
        }

        public void BUpdate(CargoDetail entity)
        {
            _cargoDetailDal.Update(entity);
        }
    }
}
