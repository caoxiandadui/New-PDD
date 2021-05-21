using System;

namespace PDD.Core.Model
{
    public class Goods
    {
        public int SId { get; set; }
        public string SName { get; set; }
        public int Sprice { get; set; }
        public int Ssell { get; set; }
        public int repertory { get; set; }
        public int sort { get; set; }
        public int State { get; set; }//1为上架，0为未上架，2出售中，3仓库中，4售罄中
        public DateTime SDate { get; set; }

        public int PhotoId { get; set; }
        public string DefPhoto { get; set; }
        public int SpId { get; set; }
        public int Paid { get; set; }
        public int Bus_BId { get; set; }
        public int EId { get; set; }
        public int FmId { get; set; }
        public int Uid { get; set; }
        //新加的字段
        public int KId { get; set; }
        public int STeid { get; set; }

        public int Mcid { get; set; }
        public int ShopID { get; set; }
        public int Tid { get; set; }
        public int opid { get; set; }//操作id(0默认，1加入回收站)
      
        public int Pid { get; set; }//上级编号

        public string  Goodkey       { get; set; }
        public string Remark        { get; set; }
        public string DanWei        { get; set; }
        public int          ZiTid         { get; set; }
        public string Goodsdetials  { get; set; }
        public int          GoodsCode     { get; set; }
        public string  GoodsGuiGe    { get; set; }
        public int          CostPrice     { get; set; }
        public int          OriginalPrice { get; set; }
        public string  GoodsBh       { get; set; }
        public int          GoodsWeigth   { get; set; }
        public int          GoodsVeigth   { get; set; }
        public string GoodsGPic { get; set; }
        public int YorN { get; set; }
    }
}
