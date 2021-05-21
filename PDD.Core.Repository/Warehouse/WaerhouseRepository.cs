using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDD.Core.Common;
using PDD.Core.IRepository.Warehouse;
using PDD.Core.Model;

namespace PDD.Core.Repository.Warehouse
{
    public class WaerhouseRepository : IWarehouseRepository

    {
        public int WaerhouseAdd(Model.Warehouse Model)
        {
            string sql = $"insert into Warehouse values({Model.Mcid},'{Model.Mname}','{Model.Mplace}','{Model.Mcoordinate}','{Model.Mnum}',{Model.Mstatus})";
            return DapperHelper.Add(sql);
        }

        public int WaerhouseDel(int id)
        {
            string sql = $"delete from Warehouse where Mcid ={id}";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Warehouse> GetWaerhouseList()
        {
            string sql = $"select * from Warehouse";
            var list = DapperHelper.GetList<PDD.Core.Model.Warehouse>(sql);
            return list;
        }

        public int UptStates(int id, int status)
        {
            string sql = $"update Warehouse set Mstatus={status} where Mcid={id}";
            int i = DapperHelper.Execute(sql);
            return i;
        }



        public int WaerhouseUpt(Model.Warehouse Model )
        {
            string sql = $"update Warehouse set Mcid={Model.Mcid},Mname='{Model.Mname}',Mplace='{Model.Mplace}',Mcoordinate='{Model.Mcoordinate}',Mnum='{Model.Mnum}'";
            int i = DapperHelper.Execute(sql);
            return i;
        }
      
    }
}
