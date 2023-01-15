using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIShopAdvanced.Abstract
{
    public class Constants
    {
        public static string DBFileName = "FinalDB.db3";

        public static string DBPath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }
    }
}
