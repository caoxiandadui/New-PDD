using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDD.Core.Model.Order
{
   public class Commodity//评价管理表
    {
        public int EId          { get; set; }
        public int GId          { get; set; }
        public string EName        { get; set; }
        public int GoodScore    { get; set; }
        public int SeverScore   { get; set; }
        public string EContent     { get; set; }
        public string ReplyContent { get; set; }
        public DateTime EDate        { get; set; }
        public string Evaluation   { get; set; }
        public int EStatue { get; set; }

        public string SName { get; set; }//商品名称
        public string DefPhoto { get; set; }//商品默认图片
    }
}
