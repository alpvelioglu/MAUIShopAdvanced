using MAUIShopAdvanced.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIShopAdvanced.Models
{
    public class CheckoutModel : TableData
    {
        public string UserName { get; set; }
        public string MonitorName { get; set; }
        public string CPUName { get; set; }
        public string StorageType { get; set; }
        public int StorageCapacity { get; set; }
        public string RamSize { get; set; }
    }
}
