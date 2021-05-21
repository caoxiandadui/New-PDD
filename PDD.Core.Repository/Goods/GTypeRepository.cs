using System;
using System.Collections.Generic;
using PDD.Core.Model.Good;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDD.Core.Model;
using PDD.Core.IRepository;
using PDD.Core.Common;
using PDD.Core.IRepository.Good;

namespace PDD.Core.Repository.Goods
{
    public class GTypeRepository : IGTypeRepository
    {
        DapperHelper db = new DapperHelper();

        public int Add(Gtype gd)
        {
            string sql = $"insert into Gtype (Tid, Tname, Sb,GTphoto, Sort,GTstate, Pid) values ({gd.Tid}, '{gd.Tname}','{gd.Sb}', '{gd.GTphoto}', {gd.Sort},{gd.GTstate} ,{gd.Pid});";
            return DapperHelper.Execute(sql);
        }

        public int Delete(int ids)
        {
            string sql = $"delete from GType Where TId={ids}";
            return DapperHelper.Execute(sql);

        }

        public List<Gtype> GTypeShow()
        {
            string sql = $"select * from Gtype";
            return DapperHelper.GetList<PDD.Core.Model.Good.Gtype>(sql);
        }

        public int Upt(Model.Good.Gtype gd)
        {
            string sql = $"update Gtype set Tname='{gd.Tname}',Sb='{gd.Sb}',Gtphoto='{gd.GTphoto}',Sort='{gd.Sort}',GTstate='{gd.GTstate}',Pid={gd.Pid} where Tid={gd.Tid}";
            return DapperHelper.Execute(sql);

        }
    }
}
