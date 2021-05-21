using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDD.Core.Model;
using PDD.Core.IRepository.Good;
using PDD.Core.Repository;
using PDD.Core.IRepository;
namespace PDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        private readonly ISpecificationRepository _specificationRepository;
        public SpecificationController(ISpecificationRepository specificationRepository)
        {
            _specificationRepository = specificationRepository;
        }
        [HttpGet]
        [Route("/api/specificationShow")]
        public IActionResult ShowList(int page,int limit)
        {
            var list = _specificationRepository.ShowList();
            int count = list.Count();
            list = list.Skip((page - 1) * limit).Take(limit).ToList();

            return Ok(new
            {
                msg = "",
                code = 0,
                data = list,
                count=count
            });
        }
        [HttpPost]
        [Route("/api/specificationDel")]
        public int Del(string ids)
        {
            return _specificationRepository.Del(ids);
        }
        [HttpPost]
        [Route("/api/SperciAdd")]
        public IActionResult Add(PDD.Core.Model.Good.Specification gs)
        {
            int i = _specificationRepository.Add(gs);
            return Ok(i);
        }
        [HttpPost]
        [Route("/api/SpecificationUpt")]
        public IActionResult Upt(PDD.Core.Model.Good.Specification gs)
        {
            int i = _specificationRepository.Upt(gs);
            return Ok(i);

        }

    }
}
