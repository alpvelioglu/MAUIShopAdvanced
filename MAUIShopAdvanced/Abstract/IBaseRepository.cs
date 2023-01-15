using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIShopAdvanced.Abstract
{
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {
        List<T> GetAll();
        void AddOrUpdate(T item);
        void Delete(T item);
    }
}
