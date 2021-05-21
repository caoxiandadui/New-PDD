using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDD.Core.IRepository.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICommodityRepository _commodityRepository;
        private readonly IExpressageRepository  _expressageRepository;
        public OrderController(IOrderDetailRepository orderDetailRepository,ICommodityRepository commodityRepository, IExpressageRepository expressageRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _commodityRepository = commodityRepository;
            _expressageRepository = expressageRepository;
        }

        /// <summary>
        /// 显示订单信息
        /// </summary>
        /// <param name="NameorNumOrPhone"></param>
        /// <param name="starTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="SaleAfter"></param>
        /// <param name="States"></param>
        /// <param name="userid"></param>
        /// <param name="GoodsName"></param>
        /// <param name="zid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowOrder")]
        public IActionResult ShowOrder(int page,int limit,string NameorNumOrPhone="",string starTime="",string EndTime="",int SaleAfter=0,int States=0,int userid=0,string GoodsName="",int zid=0)
        {
            var list = _orderDetailRepository.GetOrderDetails();
            //查询买家姓名，买家电话，订单号
            if (!string.IsNullOrEmpty(NameorNumOrPhone))
            {
                list = list.Where(x => x.Uname.Contains(NameorNumOrPhone) || x.Uphone.Contains(NameorNumOrPhone) || x.OrderNum.Equals(NameorNumOrPhone)).ToList();
            }
            //查询时间
            if (!string.IsNullOrEmpty(starTime))
            {
                list = list.Where(x => x.OrderCreateTime < Convert.ToDateTime(starTime)).ToList();
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                list = list.Where(x => x.OrderCreateTime >Convert.ToDateTime(EndTime)).ToList();
            }

            //退款状态
            if (SaleAfter!=0)
            {
                list = list.Where(x => x.OrderOperId.Equals(SaleAfter)).ToList();
            }

            //订单状态
            if (States!=0)
            {
                list = list.Where(x => x.State.Equals(States)).ToList();
            }

            //用户id
            if (userid!=0)
            {
                list = list.Where(x => x.Uid.Equals(userid)).ToList();
            }
            //商品名称
            if (!string.IsNullOrEmpty(GoodsName))
            {
                list = list.Where(x => x.SName.Contains(GoodsName)).ToList();
            }
            //自提点判断
            if (zid!=0)
            {
                list = list.Where(x => x.ZId.Equals(zid)).ToList();
            }

            //总条数
            int count = list.Count;
            //分页后的数据
            list = list.Skip((page - 1) * limit).Take(limit).ToList();
            //返回
            return Ok(new { msg = "", code = 0, data = list,count=count });
        }


        /// <summary>
        /// 修改订单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptOrder")]
        public IActionResult UptOrder(PDD.Core.Model.OrderDetails model)
        {
            try
            {
                int i = _orderDetailRepository.UptOrder(model);
                return Ok(i);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        /// <summary>
        /// 显示评价管理信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowCommodity")]
        public IActionResult ShowCommodity(int page,int limit)
        {
            try
            {
                //获取所有评价管理信息
                var list = _commodityRepository.GetCommodities();
                //总条数
                int count = list.Count;
                //分页后的数据
                list = list.Skip((page - 1) * limit).Take(limit).ToList();
                //返回
                return Ok(new { msg = "", code = 0, data = list,count=count });
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 修改评价管理状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptCommodityStatue")]
        public IActionResult UptCommodityStatue(PDD.Core.Model.Order.Commodity model)
        {
            try
            {
                //执行
                int i = _commodityRepository.UptCommStatues(model);
                //返回
                return Ok(i);
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// 删除评论信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/DelCommodity")]
        public IActionResult DelCommodity(PDD.Core.Model.Order.Commodity model)
        {
            try
            {
                //执行
                int i = _commodityRepository.DelCommodity(model);
                //返回
                return Ok(i);
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        /// <summary>
        /// 获取所有快递单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowExpressage")]
        public IActionResult ShowExpressage(int page,int limit,int SType=0,string SDate="",int statue=0,string NameGoodsNumPhone="",int ExpressageStatus=0,int PrintStatus=-1)
        {
            //获取数据
            var list = _expressageRepository.GetExpressages();
            foreach (var item in list)
            {
                item.Adress = item.PS + item.PSS + item.Ax;
            }
            //按时间类型查询
            if (SType!=0&&!string.IsNullOrEmpty(SDate))
            {
                if (SType == 1)//下单时间
                {
                    list = list.Where(x => x.OrderCreateTime.ToString().Equals(SDate)).ToList();
                }
                else if (SType == 2)//付款时间
                {
                    list = list.Where(x => x.PaymentDate.ToString().Equals(SDate)).ToList();
                }
                else if (SType == 3) 
                {
                   
                    list = list.Where(x => x.FPrintDate.ToString().Equals(SDate)).ToList(); //发货单打印时间
                }
                else if (SType ==4)//快递单打印时间
                {
                    list = list.Where(x => x.KPrintDate.ToString().Equals(SDate)).ToList(); 
                }
                else if (SType == 5)//发货时间
                {
                    list = list.Where(x => x.FGoodsDate.ToString().Equals(SDate)).ToList();
                }
            }

            //订单状态查询
            if (statue!=0)
            {
                list = list.Where(x => x.State.Equals(statue)).ToList();
            }

            //姓名商品订单编号电话查询
            if (!string.IsNullOrEmpty(NameGoodsNumPhone))
            {
                list = list.Where(x => x.Uname.Equals(NameGoodsNumPhone) || x.SName.Equals(NameGoodsNumPhone) || x.OrderNum.Equals(NameGoodsNumPhone) || x.Uphone.Equals(NameGoodsNumPhone)).ToList();
            }
            //打印类型查询 1团长单，2发货单，3采购单，4配货单，5路线单,6快递单 0（什么也不是）
            if (ExpressageStatus!=0)
            {
                list = list.Where(x => x.ExpressageStatus.Equals(ExpressageStatus)).ToList();
            }
            //打印状态
            if (PrintStatus!=-1)//0未打印，1打印，-1未定
            {
                list = list.Where(x => x.PrintStatus.Equals(PrintStatus)).ToList();
            }
            //总数据
            int count = list.Count;
            //分页后的数据
            list = list.Skip((page - 1) * limit).Take(limit).ToList();
            //返回
            return Ok(new { msg = "", code = 0, data = list });
        }

        /// <summary>
        /// 打印订单 1团长单，2发货单，3采购单，4配货单，5路线单,6快递单 0（什么也不是）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptExpModef")]
        public IActionResult UptExpModef([FromForm]int id, [FromForm]int mid)
        {
            try
            {
                int i = _expressageRepository.UptPrint(id, mid);
                return Ok(i);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
