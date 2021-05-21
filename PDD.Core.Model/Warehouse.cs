using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Model
{
    public class Warehouse//仓库表
    {
        public int Mcid { get; set; }
        public string Mname { get; set; }
        public string Mplace { get; set; }
        public string Mcoordinate { get; set; }
        public string Mnum { get; set; }
        public bool Mstatus { get; set; }
    }
}
