using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDD.Core.IRepository.Warehouse;
using PDD.Core.Model;
using PDD.Core.Common;


namespace PDD.Controllers
{
    //仓库表
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        [HttpGet]
        [Route("/api/GetWaerhouseList")]
        public IActionResult GetWaerhouseList(int page,int limit)
        {
            var list = _warehouseRepository.GetWaerhouseList();
            //返回数据
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list.Skip((page - 1) * limit).Take(limit),
            }
            );
        }
        [HttpPost]
        [Route("/api/WaerhouseAdd")]
        public int WaerhouseAdd(PDD.Core.Model.Warehouse warehouse)
        {
            int i = 0;
            i += _warehouseRepository.WaerhouseAdd(warehouse);
            return i;
        }

        [HttpPost]
        [Route("/api/WaerhouseDel")]
        public int WaerhouseDel(int id)
        {
            int i=0;
            i += _warehouseRepository.WaerhouseDel(id);
            return i;

        }
        [Route("/api/UptStates")]
        [HttpPut]
        public IActionResult UptStates(int id,int status)
        {
            int i = _warehouseRepository.UptStates(id, status);
            return Ok(i);
        }

        //反填
        [Route("/api/FanT")]
        [HttpPost]
        public IActionResult WaerhouseFanT(int id)
        {
            var list = _warehouseRepository.GetWaerhouseList();
            PDD.Core.Model.Warehouse warehouse = list.FirstOrDefault(x => x.Mcid.Equals(id));
            return Ok(new { msg = "", code = 0, data = warehouse });
        }

       [Route("/api/WaerhouseUpt")]
       [HttpPost]
       public IActionResult WaerhouseUpt(PDD.Core.Model.Warehouse warehouse)
        {
            int i = _warehouseRepository.WaerhouseUpt(warehouse);
            return Ok(i);
        }
    }
}
