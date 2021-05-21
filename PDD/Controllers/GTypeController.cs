using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDD.Core.IRepository.Good;
using PDD.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GTypeController : ControllerBase
    {
        //注入
        private readonly IGTypeRepository _gTypeRepository;

        public GTypeController(IGTypeRepository gTypeRepository)
        {
            _gTypeRepository = gTypeRepository;
        }

        /// <summary>
        /// 获取所有商品分类信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowAllGType")]
        public IActionResult ShowAllGType()
        {
            //获取所有商品分类信息
            var list = _gTypeRepository.GTypeShow();
            //返回
            return Ok(new { msg = "", code = 0, data = list });
        }

        [HttpGet]
        [Route("/api/GtypeShow")]
        public IActionResult GtypeShow(int page,int limit,string nm="",int TTid=-1)
        {
            var list = _gTypeRepository.GTypeShow();
            if (!string.IsNullOrEmpty(nm))
            {
                list = list.Where(x => x.Tname.Equals(nm)).ToList();
            }
            if(TTid!=-1)
            {
                list = list.Where(x => x.GTstate.Equals(TTid)).ToList();
            }
            int count = list.Count();
            list = list.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { msg = "", code = 0, data = list });
        }
        [HttpPost]
        [Route("/api/GtypeDel")]
        public int Del(int ids)
        {
            return _gTypeRepository.Delete(ids);
        }
        [HttpPost]
        [Route("/api/GTypeUpt")]
        public IActionResult Upt(PDD.Core.Model.Good.Gtype gd)
        {
            int i = _gTypeRepository.Upt(gd);

            return Ok(i);

        }
        [HttpPost]
        [Route("/api/GTypeAdd")]
        public IActionResult Add(PDD.Core.Model.Good.Gtype gs)
        {
            int i = _gTypeRepository.Add(gs);
            return Ok(i);

        }

    }
}
