using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDD.Core.IRepository.Stock;
using PDD.Core.Model;
using PDD.Core.Common;

namespace PDD.Controllers
{
    //现有存货
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        [HttpPost]
        [Route("/api/GetStockList")]
        public IActionResult GetStockList(int page, int limit, string name, string times, string id)
        {
            var list = _stockRepository.GetStockList(name,times,id);
            return Ok(new
            {
                code=0,
                msg="",
                data=list.Skip((page-1)*limit).Take(limit),
            }
            );
        }
        [HttpPost]
        [Route("/api/StockAdd")]
        public int StockAdd(PDD.Core.Model.Stock stock)
        {
            int i = 0;
            i += _stockRepository.StockAdd(stock);
            return i;
        }
        [HttpPost]
        [Route("/api/StockDel")]
        public int StockDel(int id)
        {
            int i = 0;
            i += _stockRepository.StockDel(id);
            return i;
        }
    }
}
