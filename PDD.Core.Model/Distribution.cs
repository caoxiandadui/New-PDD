using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Model
{
    public class Distribution//配送小区
    {
        public int Hid { get; set; }
        public string Hname { get; set; }
        public int Tid { get; set; }
        public string Hpath { get; set; }//路线
        public string Hplace { get; set; }//地址
        public string TName_1 { get; set; }
        public string TPhone_1 { get; set; }
    }
}
