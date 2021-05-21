using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Model.Good
{
  public  class Gtype
    {
        public int Tid   { get; set; }
        public string Tname { get; set; }
        public string Sb    { get; set; }
        public string GTphoto { get; set; }
        public int GTstate { get; set; }

        public int Sort  { get; set; }
        public int Pid   { get; set; }
      
    }
}
