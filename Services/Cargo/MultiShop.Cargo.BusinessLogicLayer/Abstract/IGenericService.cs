using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLogicLayer.Abstract
{
    public interface IGenericService <T> where T : class
    {
        void BInsert(T entity);
        void BUpdate(T entity);
        void BDelete(int id);
        T BGetById(int id);
        List<T> BGetAll();
    }
}
