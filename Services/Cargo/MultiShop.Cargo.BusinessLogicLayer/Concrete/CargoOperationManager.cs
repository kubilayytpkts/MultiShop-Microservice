using MultiShop.Cargo.BusinessLogicLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using MultiSop.Cargo.DataAccessLayer.Abstracts.Inferfaces;
using MultiSop.Cargo.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLogicLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationsDal _cargoOperationsDal;

        public CargoOperationManager(ICargoOperationsDal cargoOperationsDal)
        {
            _cargoOperationsDal = cargoOperationsDal;
        }

        public void BDelete(int id)
        {
            _cargoOperationsDal.Delete(id);
        }

        public List<CargoOperations> BGetAll()
        {
            return _cargoOperationsDal.GetAll();
        }

        public CargoOperations BGetById(int id)
        {
           return _cargoOperationsDal.GetById(id);
        }

        public void BInsert(CargoOperations entity)
        {
            _cargoOperationsDal.Insert(entity);
        }

        public void BUpdate(CargoOperations entity)
        {
            _cargoOperationsDal.Update(entity);
        }
    }
}
