using Microsoft.AspNetCore.Mvc;
using PracticeNET.Models;

namespace PracticeNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private static List<Team> teams = new List<Team>()
        {
            new Team()
            {
                Name= "Name1",
                Id= 1,
                Country = "Country1",
                TeamPrinciple = "Principle 1"
            },
            new Team()
            {
                Name= "Name3",
                Id= 3,
                Country = "Country3",
                TeamPrinciple = "Principle 3"
            },
            new Team()
            {
                Name= "Name2",
                Id= 2,
                Country = "Country2",
                TeamPrinciple = "Principle 2"
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(teams);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var team = teams.FirstOrDefault(t => t.Id == id);
            if (team == null)
            {
                return BadRequest("team not found");
            }
            return Ok(team);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Team team) {
            teams.Add(team);
            return CreatedAtAction("Get", team);
        }


        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, string country)
        {
            var team = teams.FirstOrDefault(t => t.Id == id);
            if (team == null)
            {
                return BadRequest("team not found");
            }
            team.Country = country;
            return Ok(team); 
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var team = teams.FirstOrDefault(t => t.Id == id);
            if (team == null)
            {
                return BadRequest("team not found");
            }

            teams.Remove(team);
            return NoContent();
        }



    }
}
