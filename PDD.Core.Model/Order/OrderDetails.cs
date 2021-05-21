using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Model
{
   public class OrderDetails
    {
        public int OrderId           { get; set; }
        public int SId               { get; set; }
        public string OrderNum          { get; set; }
        public DateTime OrderCreateTime   { get; set; }
        public string ShippingMay       { get; set; }
        public int State             { get; set; }
        public int GoodNum           { get; set; }
        public double GoodPrefer        { get; set; }
        public int OrderOperId       { get; set; }//退款状态
        public int Uid               { get; set; }
        public int PTid              { get; set; }

        public string FGoods   { get; set; }//发货方式
        public int ZId			 { get; set; }//自提点
        public int DaYin		 { get; set; }//是否打印 0未打印 1打印
        public string Remark { get; set; }//备注

        public string SName { get; set; }//商品名称

        public int Sprice { get; set; }//商品单价

        public string specification { get; set; }//规格名称

        public string Uname { get; set; }//用户名称

        public string Uphone { get; set; }//用户电话

        public string PS { get; set; }//省

        public string PSS { get; set; }//市
        public string Ax { get; set; }//详细地址

        public string PTName { get; set; }//支付方式id名称

        public string LmagePath { get; set; }//商品图片路径





    }
}
