using AspCoreBlazorTutorial.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
            new Person()
            {
                Id = 6,FirstName = "Elie",LastName = "Feghali",Sex = Sex.Male
            },
        };


        // will be called on /api/people
        [HttpGet]
        public IActionResult GetPeople()
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
        public IActionResult GetPersonzasw(int personId) // must be async Task if fetching data from Db
        {
            var person = People.FirstOrDefault(x => x.Id == personId);
            if (person == null)
                return NotFound("Sorry :(");
            return Ok(person);
        }

        [HttpPost]
        public IActionResult PostPerson(Person person)
        {
            //update list(check if exists,etc..)
            //not the best way to do so,best is to Post and Put alone,for now thats fine

            if (person.Id == 0)
            {
                //Create

                person.Id = People.Count == 0 ? 1 : People.Select(x => x.Id).Max() + 1; // in real case scenario,this should be awaited 
                People.Add(person);
            }
            else
            {
                var selectedPerson = People.FirstOrDefault(x => x.Id == person.Id);
                if (selectedPerson == null)
                    return BadRequest("Trying to update a missing person");
                selectedPerson.FirstName = person.FirstName;
                selectedPerson.LastName = person.LastName;
                selectedPerson.Sex = person.Sex;
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var selectedPerson = People.FirstOrDefault(x => x.Id == id);
            if (selectedPerson == null)
                return BadRequest("Trying to delete a missing person");
            People.Remove(selectedPerson);
            return Ok();
        }
    }


}
