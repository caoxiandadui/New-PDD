using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Model
{
    public class CWarehouse//出库
    {
        public int WMid { get; set; }
        public string WModd { get; set; }
        public string WMWname { get; set; }
        public string WMGpic { get; set; }
        public string WMGname { get; set; }
        public string WMGsize { get; set; }
        public string WMGodd { get; set; }
        public int WMnum { get; set; }
        public DateTime WMtime { get; set; }
        public string WMtimes { get => WMtime.ToString("yyyy-MM-dd HH:mm:ss"); }

    }
}
