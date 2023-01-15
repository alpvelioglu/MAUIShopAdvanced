using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIShopAdvanced.Abstract
{
    public class TableData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
