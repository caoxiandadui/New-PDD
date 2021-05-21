using PDD.Core.Common;
using PDD.Core.IRepository.Good;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Repository.Goods
{
    public class GoodsRepository : IGoodsRepository//商品接口
    {
        
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="gd"></param>
        /// <returns></returns>
        public int Add(Model.Goods gd)
        {
            string sql = $@"insert into Goods (SName,Sprice, Ssell, repertory, sort, State, SDate, PhotoId, DefPhoto, SpId, Paid, Bus_BId, EId,FmId,Uid, Mcid, ShopID, Tid,opid,Goodkey,Remark,DanWei,ZiTid,Goodsdetials,GoodsCode,GoodsGuiGe,CostPrice,OriginalPrice,GoodsBh,GoodsWeigth,GoodsVeigth,GoodsGPic,YorN,KId,STeid) values ( '{gd.SName}',{gd.Sprice},{gd.Ssell},{gd.repertory},{gd.sort},{gd.State}, '{gd.SDate}',{gd.PhotoId}, '{gd.DefPhoto}', {gd.SpId}, {gd.Paid}, {gd.Bus_BId}, {gd.EId}, {gd.FmId}, {gd.Uid},{gd.Mcid},{gd.ShopID},{gd.Tid},{gd.opid},'{gd.Goodkey}','{gd.Remark}','{gd.DanWei}',{gd.ZiTid},'{gd.Goodsdetials}',{gd.GoodsCode},'{gd.GoodsGuiGe}',{gd.CostPrice},{gd.OriginalPrice},'{gd.GoodsBh}',{gd.GoodsVeigth},{gd.GoodsVeigth},'{gd.GoodsGPic}',{gd.YorN},{gd.KId},{gd.STeid});";
            return DapperHelper.Execute(sql);

        }   
     

        public int Delete(int ids)
        {
            string sql = $"delete from Goods where Sid={ids}";
            return DapperHelper.Execute(sql);
        }

        /// <summary>
        /// 显示所有商品信息连上分类表
        /// </summary>
        /// <returns></returns>
        public List<PDD.Core.Model.Goods> GetList()
        {
            string sql = "select * from Goods a join gtype b on a.Tid=b.tid";
            var list = DapperHelper.GetList<PDD.Core.Model.Goods>(sql);

            //返回
            return list;
        }


        /// <summary>
        /// 商品加入回收站
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GoodsJoinResp(int id)
        {
            string sql = $"update Goods set opid=1 where SId={id}";
            //执行
            try
            {
                int i = DapperHelper.Execute(sql);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Upt(Model.Goods gd)
        {
            string sql = $"update  Goods set  SName='{gd.SName}',SPrice={gd.Sprice},Ssell={gd.Ssell},repertory={gd.repertory},sort={gd.sort},State={gd.State},SDate='{gd.SDate}',PhotoId={gd.PhotoId},DefPhoto='{gd.DefPhoto}',SPId={gd.SpId},Paid={gd.Paid},Bus_BId={gd.Bus_BId},EId={gd.EId},FmId={gd.FmId},Uid={gd.Uid},Mcid={gd.Mcid},ShopID={gd.ShopID},Tid={gd.Tid} where SId={gd.SId}";
            return DapperHelper.Execute(sql);

        }


        /// <summary>
        /// 修改商品上架状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statues">1上架，0未上架</param>
        /// <returns></returns>
        public int UptGoodsStatue(int id, int statues)
        {
            //sql
            string sql = $"update Goods set State={statues} where SId={id}";
            //执行
            try
            {
                int i = DapperHelper.Execute(sql);
                //返回
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
