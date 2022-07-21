using Microsoft.AspNetCore.Mvc;
using SpaceStationAPI.Model;
using SpaceStationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceStationAPI.Controller
{
    [ApiController]
    [Route("Iss")]
    public class IssController : ControllerBase
    {
        public IIssService _issService;
        public IssController(IIssService issService)
        {
            _issService = issService;

        }
        [HttpPost("AddIssData")]
        public ActionResult<List<IssNow>> AddIssData(IssNow issNow)
        {
            var res = _issService.addData(issNow);
            return Ok(res);
        }

        [HttpGet]
        public bool Get()
        {
            return true;
        }
    }
}
