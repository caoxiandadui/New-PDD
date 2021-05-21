using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Model
{
    public class Management//入库
    {
        public int SMid { get; set; }
        public string SModd { get; set; }
        public string SMGpic { get; set; }
        public string SMGname { get; set; }
        public string SMGsize { get; set; }
        public string SMGid { get; set; }
        public string SMWname { get; set; }
        public string SMGodd { get; set; }
        public string SMnum { get; set; }
        public DateTime SMtime { get; set; }
        public string SMtimes { get => SMtime.ToString("yyyy-MM-dd HH:mm:ss"); }
    }
}
