using AspCoreBlazorTutorial.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreBlazorTutorial.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public static List<Person> People = new List<Person>()
        {
            new Person()
            {
                Id = 1,FirstName = "Mhmd",LastName = "Tabikh",Sex = Sex.Male
            },
            new Person()
            {
                Id = 2,FirstName = "Daniel",LastName = "Jreige",Sex = Sex.Male
            },
            new Person()
            {
                Id = 3,FirstName = "SaraH",LastName = "Salim",Sex = Sex.Female
            },
                   new Person()
            {
                Id = 4,FirstName = "Charles",LastName = "Fenianos",Sex = Sex.Male
            },
                          new Person()
            {
                Id = 5,FirstName = "Carmen",LastName = "Kaouk",Sex = Sex.Female
            },
        };


        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            return Ok(People);
        }

        //will throw ambigous exception if uncommented when calling /api/people
        //[HttpGet] 
        //public async Task<IActionResult> GetPeoplez()
        //{
        //    return NotFound();
        //}


        // will be called on /api/people/1
        [HttpGet("{personId}")]
        public async Task<IActionResult> GetPersonzasw(int personId) 
        {
            var person = People.FirstOrDefault(x => x.Id == personId);
            if (person == null)
                return NotFound("Sorry :(");
            return Ok(person);
        }
    }
}
