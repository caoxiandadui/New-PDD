using PDD.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.IRepository.Good
{
    public interface IFreightRepository
    {
        int Add(PDD.Core.Model.Good.Freight gd);
        int Del(int ids);

    }
}
