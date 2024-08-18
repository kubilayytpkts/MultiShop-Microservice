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
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public void BDelete(int id)
        {
            _cargoCustomerDal.Delete(id);
        }

        public List<CargoCustomer> BGetAll()
        {
            return _cargoCustomerDal.GetAll();
        }

        public CargoCustomer BGetById(int id)
        {
            return _cargoCustomerDal.GetById(id);
        }

        public void BInsert(CargoCustomer entity)
        {
            _cargoCustomerDal.Insert(entity);
        }

        public void BUpdate(CargoCustomer entity)
        {
            _cargoCustomerDal.Update(entity);
        }
    }
}
