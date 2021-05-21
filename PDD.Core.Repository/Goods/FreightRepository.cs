using PDD.Core.Common;
using PDD.Core.IRepository.Good;
using PDD.Core.Model.Good;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Repository.Order
{
  public  class FreightRepository:IFreightRepository
    {
        
public int Add(Freight gd)
        {
            string sql = $" INSERT into Freight VALUES(null,{gd.FreMoney},'{gd.FMName}','{gd.FStyle}','{gd.FPAdress}',{gd.BWeigth},{gd.BYMoney},{gd.FirstWeigth},{gd.YunFei},{gd.XuWeigth},{gd.Xufei});";
            return DapperHelper.Execute(sql);
        }

        public int Del(int ids)
        {
            string sql = $"delete from Freight where FmId={ids}";
            return DapperHelper.Execute(sql);
        }
    }
}
