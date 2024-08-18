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
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public void BDelete(int id)
        {
            _cargoCompanyDal.Delete(id);
        }

        public List<CargoCompany> BGetAll()
        {
           return _cargoCompanyDal.GetAll();
        }

        public CargoCompany BGetById(int id)
        {
            return _cargoCompanyDal.GetById(id);
        }

        public void BInsert(CargoCompany entity)
        {
            _cargoCompanyDal.Insert(entity);
        }

        public void BUpdate(CargoCompany entity)
        {
            _cargoCompanyDal.Update(entity);
        }
    }
}
