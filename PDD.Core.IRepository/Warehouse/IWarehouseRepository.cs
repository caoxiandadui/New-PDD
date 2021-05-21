using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.IRepository.Warehouse
{
    public interface IWarehouseRepository:IBaseRepository<PDD.Core.Model.Warehouse>
    {
        
        int WaerhouseDel(int id);//删除
        int WaerhouseAdd(PDD.Core.Model.Warehouse Model);//添加
        public List<PDD.Core.Model.Warehouse>  GetWaerhouseList();//显示
        public int WaerhouseUpt(PDD.Core.Model.Warehouse Model);//修改
        public int UptStates(int id,int status);//修改状态
    }
}
