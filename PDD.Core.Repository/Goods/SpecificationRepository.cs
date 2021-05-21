using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDD.Core.Common;
using PDD.Core.IRepository.Good;
using PDD.Core.Model.Good;

namespace PDD.Core.Repository.Goods
{
    public class SpecificationRepository : IRepository.Good.ISpecificationRepository
    {
        DapperHelper db = new DapperHelper();

        public int Add(Specification gs)
        {
            string sql = $"insert into Specification (PName, specification,attribute,Gvalue) values ('{gs.PName}', '{gs.specification}','{gs.attribute}','{gs.Gvalue}');";
            return DapperHelper.Execute(sql);

        }

        public int Del(string ids)
        {
            string sql = $"delete from Specification where SpId in ({ids})";
            return DapperHelper.Execute(sql);
        }


        public List<Specification> ShowList()
        {
            string sql = "select * from Specification";
            var list = DapperHelper.GetList<PDD.Core.Model.Good.Specification>(sql);
            return list;

        }

        public int Upt(Specification gd)
        {
            string sql = $"update Specification set PName='{gd.PName}',specification='{gd.specification}',attribute='{gd.attribute}',Gvalue='{gd.Gvalue}' where SpId={gd.SpId}";
            return DapperHelper.Execute(sql);

        }
    }
  }

