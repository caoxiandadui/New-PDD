using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDD.Core.IRepository.Good;
using PDD.Core.Model;
using PDD.Core.Model.Good;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        //注入
        private readonly IGoodsRepository _goodsRepository;
        //商品分类接口
        private readonly IGTypeRepository _gTypeRepository;
        public GoodsController(IGoodsRepository goodsRepository,IGTypeRepository gTypeRepository)
        {
            _goodsRepository = goodsRepository;
            _gTypeRepository = gTypeRepository;
        }

        /// <summary>
        /// 绑定商品分类一级
        /// </summary>
        /// <returns></returns> 
         [HttpGet]
         [Route("/api/BindGtypeOne")]
        public IActionResult BindGtypeOne()
        {
            var list = _gTypeRepository.GTypeShow().Where(x=>x.Pid==0).ToList();
            //返回
            return Ok(new { msg = "", code = 0, data = list });
        }

       

        /// <summary>
        /// 显示所有商品信息+查询
        /// </summary>
        /// <param name="nm"></param>
        /// <param name="gid"></param>
        
        [HttpGet]
        [Route("/api/GoodsShowSear")]
        public IActionResult GoodsShow(string nm="",int gid=0,int state=-1)//1为上架，0为未上架，2出售中，3仓库中，4售罄中,5回收站
        {
            //1为加入回收站，0默认
            //获取所有数据，显示不在回收站中的
            var list = _goodsRepository.GetList().Where(x=>x.opid==0).ToList();

            //查询商品名称关键字id
            if (!string.IsNullOrEmpty(nm))
            {
                list = list.Where(x => x.SName.Contains(nm) || x.SId.Equals(Convert.ToInt32(nm))).ToList();
            }
            //查询商品分类
            if (gid!=0)
            {
                list = list.Where(x => x.Pid.Equals(gid)).ToList();
            }
            if (state!=-1)
            {
                if (state==5)//回收站中的
                {
                    list = _goodsRepository.GetList().Where(x => x.opid == 1).ToList();
                }
                else
                {
                    //2出售中，3仓库中，4售罄中
                    list = list.Where(x => x.State.Equals(state)).ToList();
                }
               
            }
            //返回
            return Ok(new { msg = "", code = 0, data = list });

        }

        /// <summary>
        /// 修改商品上架状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statues"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptGoodsStates")]
        public IActionResult UptGoodsStates(int id,int statues)
        {
            try
            {
                int i = _goodsRepository.UptGoodsStatue(id, statues);
                return Ok(i);
            }
            catch (Exception)
            {

                throw;
            } 
        }

        /// <summary>
        /// 商品加入回收站
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/GoodsJoinResp")]
        public IActionResult GoodsJoinResp(int id)
        {
            try
            {
                int i = _goodsRepository.GoodsJoinResp(id);
                return Ok(i);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("/api/GoodsAdd")]
        public IActionResult Add(PDD.Core.Model.Goods gs)
        {
            int i = _goodsRepository.Add(gs);
            return Ok(i);

        }
        [HttpPost]
        [Route("/api/GoodsDel")]
        public int Del(int ids)
        {
            return _goodsRepository.Delete(ids);
        }
        [HttpPost]
        [Route("/api/GoodsUpt")]
        public IActionResult Upt(PDD.Core.Model.Goods gs)
        {
             int i=_goodsRepository.Upt(gs);
            return Ok(i);

        }

    }
}
