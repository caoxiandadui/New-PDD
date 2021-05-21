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
    public class FreightController : ControllerBase
    {
         private readonly IFreightRepository _freightRepository;

        public FreightController(IFreightRepository freightRepository )
        {
            _freightRepository = freightRepository;

        }
        [HttpPost]
        [Route("/api/FreightAdd")]
        public IActionResult Add(PDD.Core.Model.Good.Freight gs)
        {
            int i = _freightRepository.Add(gs);
            return Ok(i);

        }
        [HttpPost]
        [Route("/api/FreightDel")]
        public int Del(int ids)
        {
            return _freightRepository.Del(ids);
        }
    }
}
