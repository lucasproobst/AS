using System.Collections.Generic;
using System.Threading.Tasks;
using API_AP2_POO.Interfaces;
using API_AP2_POO.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_AP2_POO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<People>>> GetPeople()
        {
            var people = await _peopleRepository.GetPeopleAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetPeopleById(int id)
        {
            var people = await _peopleRepository.GetPeopleByIdAsync(id);
            if (people == null)
                return NotFound();

            return Ok(people);
        }

        [HttpPost]
        public async Task<ActionResult<People>> CreatePeople(People people)
        {
            var createdPeople = await _peopleRepository.CreatePeopleAsync(people);
            return CreatedAtAction(nameof(GetPeopleById), new { id = createdPeople.Id }, createdPeople);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<People>> UpdatePeople(int id, People updatedPeople)
        {
            var existingPeople = await _peopleRepository.GetPeopleByIdAsync(id);
            if (existingPeople == null)
                return NotFound();

            var updatedPerson = await _peopleRepository.UpdatePeopleAsync(id, updatedPeople);
            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeople(int id)
        {
            var success = await _peopleRepository.DeletePeopleAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
