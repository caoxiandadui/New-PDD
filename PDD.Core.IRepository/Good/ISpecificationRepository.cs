using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDD.Core.Model;
namespace PDD.Core.IRepository.Good
{
  public interface ISpecificationRepository
    {
        List<PDD.Core.Model.Good.Specification> ShowList();

        int Del(string ids);
        int Add(PDD.Core.Model.Good.Specification gs);
        int Upt(PDD.Core.Model.Good.Specification gd);
    }
}
