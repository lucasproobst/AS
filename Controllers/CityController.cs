using System.Collections.Generic;
using System.Threading.Tasks;
using API_AP2_POO.Interfaces;
using API_AP2_POO.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_AP2_POO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetCities()
        {
            var cities = await _cityRepository.GetCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCityById(int id)
        {
            var city = await _cityRepository.GetCityByIdAsync(id);
            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<City>> CreateCity(City city)
        {
            var createdCity = await _cityRepository.CreateCityAsync(city);
            return CreatedAtAction(nameof(GetCityById), new { id = createdCity.Id }, createdCity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<City>> UpdateCity(int id, City city)
        {
            var existingCity = await _cityRepository.GetCityByIdAsync(id);
            if (existingCity == null)
                return NotFound();

            var updatedCity = await _cityRepository.UpdateCityAsync(id, city);
            return Ok(updatedCity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var success = await _cityRepository.DeleteCityAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
