using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDD.Core.Model;

namespace PDD.Core.IRepository.Good
{
   public interface IGTypeRepository
    {
        List<PDD.Core.Model.Good.Gtype> GTypeShow();
        int Delete(int ids);
        int Upt(PDD.Core.Model.Good.Gtype gd);
        int Add(PDD.Core.Model.Good.Gtype gd);
    }
}
