using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Model
{
    public class Inventory//盘点管理
    {
        public int CMid { get; set; }
        public int SMid { get; set; }
        public int WMid { get; set; }
        public string CModd { get; set; }
        public int Mcid { get; set; }
        public int CMstartnum { get; set; }
        public int CMendnum { get; set; }
        public string CMname { get; set; }
        public DateTime CMtime { get; set; }
        public string CMtimes { get => CMtime.ToString("yyyy-MM-dd HH:mm:ss"); }
    }
}
