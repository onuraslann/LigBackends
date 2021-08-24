using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        ILeagueService _leagueService;

        public LeaguesController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _leagueService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(League league)
        {
            var result = _leagueService.Add(league);
            if (result.Success)
            {
                return Ok(league);

            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(League league)
        {
            var result = _leagueService.Delete(league);
            if (result.Success)
            {
                return Ok(league);

            }
            return BadRequest(result);

        }
    }
}
