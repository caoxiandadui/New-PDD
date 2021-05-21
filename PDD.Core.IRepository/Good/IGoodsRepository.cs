using PDD.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.IRepository.Good
{
    public interface IGoodsRepository
    {
        /// <summary>
        /// 显示所有商品信息，和商品分类表连着
        /// </summary>
        /// <returns></returns>
        public  List<PDD.Core.Model.Goods> GetList();

        /// <summary>
        /// 修改商品上架状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statues"></param>
        /// <returns></returns>
        public int UptGoodsStatue(int id, int statues);

        /// <summary>
        /// 把商品加入回收站
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GoodsJoinResp(int id);

        int Add(PDD.Core.Model.Goods gd);
      
        int Delete(int ids);


        int Upt(PDD.Core.Model.Goods gd);

    }
}
