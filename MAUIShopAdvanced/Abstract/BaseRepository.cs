using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIShopAdvanced.Abstract
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        SQLiteConnection conn;

        public BaseRepository()
        {
            conn = new SQLiteConnection(Constants.DBPath);
            conn.CreateTable<T>();
        }
        public void AddOrUpdate(T item)
        {
            if (item.ID != 0) conn.Update(item);
            else conn.Insert(item);
        }

        public void Delete(T item)
        {
            conn.Delete(item);
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<T> GetAll()
        {
            return conn.Table<T>().ToList();
        }
    }
}
