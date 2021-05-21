using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Model.Order
{
  public  class Expressage
    {
        public int          ExpId             { get; set; }
        public string ExpNum            { get; set; }
        public int          OrderId           { get; set; }
        public string ShipAdress        { get; set; }
        public string OderImg           { get; set; }
        public int          ExpressageStatus  { get; set; }
        public int          PrintStatus       { get; set; }
        public  DateTime    FGoodsDate        { get; set; }
        public  DateTime    FPrintDate        { get; set; }
        public  DateTime    KPrintDate        { get; set; }
        public int ModId { get; set; }//写到这了

        public string OrderNum { get; set; }  //订单编号
        public DateTime OrderCreateTime { get; set; }//下单时间
        public int State { get; set; }//订单状态
        public int GoodNum { get; set; }//商品购买数量
        public string Remark { get; set; }//备注
     

        public int Uid { get; set; }//用户编号
        public string Uname { get; set; }//姓名
        public string Uphone { get; set; }//手机号
        public string Ax { get; set; }//详细地址
        public string PS { get; set; }//省
        public string PSS { get; set; }//市
        public string Adress { get; set; }//完整地址
        public DateTime PaymentDate { get; set; }//付款时间

        public string SName { get; set; }//商品名称

        public int ShopID { get; set; }//门店id
        public int Tid { get; set; }//团长id
    }
}
