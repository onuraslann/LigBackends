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
    public class TeamsController : ControllerBase
    {

        ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _teamService.GetAll();
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]

        public IActionResult Add(Team  team)
        {
            var result = _teamService.Add(team);
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("delete")]

        public IActionResult Delete(Team team)
        {
            var result = _teamService.Delete(team);
            if (result.Success)
            {

                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
