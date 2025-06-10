using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id) { 
            var people = Repository.People.FirstOrDefault(p => p.Id == id);
            if (people == null) {
                return NotFound();
            }
            return Ok(people);

        }
        
        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }
            Repository.People.Add(people);
            return NoContent();
        }
    }

    public class People()
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class Repository()
    {
        public static List <People> People = new List <People>
        {
            new People()
            {
                Id = 1,
                Name = "Pedro",
                Birthdate = new DateTime(1990,12,3)
            },
            new People()
            {
                Id = 1,
                Name = "Alba",
                Birthdate = new DateTime(1990,11,3)
            },
            new People()
            {
                Id = 1,
                Name = "Cesar",
                Birthdate = new DateTime(1990,1,8)
            },
        };
    }
}
